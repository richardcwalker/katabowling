using BowlingScorer;
using NUnit.Framework;

namespace BowlingScorerTests
{
    public class BowlingScoringTests
    {
        public Game _newGameForScoringTestCase;
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
            _newGameForScoringTestCase = new Game();
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
            _newGameForScoringTestCase.Roll(1);
            _newGameForScoringTestCase.Roll(2);
            Assert.IsTrue(_newGameForScoringTestCase.Score() == 3 
                && _newGameForScoringTestCase.IsFrameFinished 
                && _newGameForScoringTestCase.FrameNumber == 2);
        }

        // Game Score Test Case(no spares or bonuses for now) just two frames
        [Test]
        public void FrameNotFinishedLogicTest()
        {
            _newGameForScoringTestCase.Roll(1);
            Assert.IsFalse(_newGameForScoringTestCase.IsFrameFinished);
        }
    }
}