using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BowlingScorer;
namespace BowlingScorerTests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void Roll10()
        {
            Game game = new Game();
            game.Roll(10);
            int score = game.Score();
            Assert.IsTrue(score == 10);
        }
    }
}
