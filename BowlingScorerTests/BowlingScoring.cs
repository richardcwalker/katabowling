using BowlingScorer;
using NUnit.Framework;

namespace BowlingScorerTests
{
    public class BowlingScoring
    {
        /// <summary>
        // The game consists of 10 frames. In each frame the player has two rolls to knock down 10 pins.
        // The score for the frame is the total number of pins knocked down, plus bonuses for strikes and spares.
        //
        //A spare is when the player knocks down all 10 pins in two rolls.
        //The bonus for that frame is the number of pins knocked down by the next roll.
        //A strike is when the player knocks down all 10 pins on his first roll.
        //The frame is then completed with a single roll.
        //The bonus for that frame is the value of the next two rolls.
        //In the tenth frame a player who rolls a spare or strike is allowed to roll the extra balls to complete the frame.
        //However no more than three balls can be rolled in tenth frame.
        //
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RollExpectFailAsRollsNotTwo()
        {
            Game _newGame = new Game();
            //First Roll
            _newGame.Roll(9);
            Assert.IsTrue(_newGame.Frame == 2);
        }
    }
}