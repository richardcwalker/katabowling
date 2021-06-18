using BowlingScorer;
using NUnit.Framework;

namespace BowlingScorerTests
{
    public class BowlingScoringTests
    {
        /// <summary>
        // The game consists of 10 frames.

        // In each frame the player has two rolls to knock down 10 pins. (20 rolls in total)

        // The score for the frame is the total number of pins knocked down,
        // plus bonuses for strikes and spares.
        //
        // A spare is when the player knocks down all 10 pins in two rolls.
        // The bonus for that frame is the number of pins knocked down by the next roll.
        //
        // A strike is when the player knocks down all 10 pins on his first roll.
        // The frame is then completed with a single roll.
        // The bonus for that frame is the value of the next two rolls.
        //
        // In the tenth frame a player who rolls a spare or strike is allowed to roll the extra balls to complete the frame.
        //
        // However no more than three balls can be rolled in tenth frame.
        //
        /// </summary>
        [SetUp]
        public void Setup()
        {

        }

        // Strike on first roll
        // IsStrike and IsFrameFinished will be true.
        [Test]
        public void PlayerScoresStrikeFirstRoll()
        {
            Game _newGame = new Game();
            //First Roll
            _newGame.Roll(10);
            Assert.That(_newGame.IsStrike && _newGame.IsFrameFinished);
        }

        // Spare (two rolls knocks down 10 pins)
        [Test]
        public void PlayerScoresSpare()
        {
            Game _newGame = new Game();
            //First Roll
            _newGame.Roll(4);
            //First Roll
            _newGame.Roll(6);
            Assert.True(_newGame.IsSpare && _newGame.IsFrameFinished);
        }

        // No Spare (two rolls knocks down <10 pins)
        [Test]
        public void PlayerWontScoreSpare()
        {
            Game _newGame = new Game();
            //First Roll
            _newGame.Roll(3);
            //Second Roll
            _newGame.Roll(6);
            Assert.IsFalse(_newGame.IsSpare && _newGame.IsFrameFinished);
        }

        // Game Score Test Case(no spares or bonuses for now) just two frames
        //[TestCase(1, ExpectedResult = 1)]
        //[TestCase(2, ExpectedResult = 3)]
        [Test]
        public void GameScoreNoStrikeOrSpare()
        {
            Game _newGame = new Game();
            _newGame.Roll(1);
            _newGame.Roll(2);
            Assert.IsTrue(_newGame.Score() == 3 && _newGame.IsFrameFinished);
        }

        // Game Score Test Case(no spares or bonuses for now) just two frames
        [Test]
        public void FrameNotFinishedLogicTest()
        {
            Game _newGame = new Game();
            _newGame.Roll(1);
            Assert.IsFalse(_newGame.IsFrameFinished);
        }

        [Test]
        public void CheckFrameFinishedFlagResetsAfterTwoRolls()
        {
            Game _newGame = new Game();
            //Frame 1
            _newGame.Roll(5);
            _newGame.Roll(5);
            //Frame 2
            _newGame.Roll(4); // Next frame
            Assert.IsFalse(_newGame.IsFrameFinished);
        }

        // Strike bonus tally
        // The bonus for that frame is the number of pins knocked down by the next roll.
        [Test]
        public void BonusForStrike()
        {
            Game _newGame = new Game();
            //Strike
            _newGame.Roll(10);
            //Next frame
            _newGame.Roll(6); // Bonus to add
            _newGame.Roll(2);
            //// Bonus is 8 from both rolls
            //// so total score should be :
            //// 10(strike from frame 1) + 8(frame 2 total) + 8(bonus from both rolled this frame) = 26
            Assert.That(_newGame.Score() == 26);
        }

        // Spare bonus tally
        // The bonus for that frame is the number of pins knocked down by the next roll.
        [Test]
        public void BonusForSpare()
        {
            Game _newGame = new Game();
            //Spare
            _newGame.Roll(5);
            _newGame.Roll(5);
            //Next frame
            _newGame.Roll(4); // Bonus to add
            _newGame.Roll(2);
            //// Bonus is 4 from the first roll of second frame
            //// so total score should be :
            //// 10(spare from frame 1) + 6(frame 2 total) + (bonus first roll in this frame)4 = 20
            Assert.That(_newGame.Score() == 20);
        }

        // Game with a spare in the middle
        [Test]
        public void TenFramesBonusForSpare()
        {
            Game _newGame = new Game();
            _newGame.Roll(1);
            _newGame.Roll(2);
            _newGame.Roll(3); 
            _newGame.Roll(4);
            //Spare
            _newGame.Roll(5);
            _newGame.Roll(5);
            _newGame.Roll(4); // Bonus to add
            _newGame.Roll(2); 
            _newGame.Roll(1);
            _newGame.Roll(2);
            _newGame.Roll(3); 
            _newGame.Roll(4);
            _newGame.Roll(1);
            _newGame.Roll(2);
            _newGame.Roll(3); 
            _newGame.Roll(4);
            _newGame.Roll(1);
            _newGame.Roll(2);
            _newGame.Roll(3); 
            _newGame.Roll(4);
            Assert.That(_newGame.Score() == 60);
        }

        // Game with a spare in the middle
        [Test]
        public void TenFramesBonusForStrike()
        {
            Game _newGame = new Game();
            _newGame.Roll(1);
            _newGame.Roll(2);
            _newGame.Roll(3);
            _newGame.Roll(4);
            //Strike
            _newGame.Roll(10);
            //Next frame to add the scores for the rolls
            _newGame.Roll(6); 
            _newGame.Roll(2); 
            //...
            _newGame.Roll(5);
            _newGame.Roll(5);
            _newGame.Roll(2);
            _newGame.Roll(1);
            _newGame.Roll(2);
            _newGame.Roll(3);
            _newGame.Roll(4);
            _newGame.Roll(1);
            _newGame.Roll(2);
            _newGame.Roll(3);
            _newGame.Roll(4);
            _newGame.Roll(1);
            _newGame.Roll(2);
            _newGame.Roll(3);
            _newGame.Roll(4);
            Assert.That(_newGame.Score() == 88);
        }
    }
}