using System;

namespace BowlingScorer
{
    public class Game : IGame
    {
        private int RunningScore;
        public int Frame = 0;
        public int PlayerRoll = 0;
        public bool IsFrameFinished = false;
        public bool IsStrike = false;

        public int Score()
        {
            return RunningScore;
        }
        /// <summary>
        /// Passes in the number of pins knocked down when a roll is made 
        /// by a player.
        /// </summary>
        /// <param name="PinsKnockedDown"></param>
        public void Roll(int PinsKnockedDown)
        {
            PlayerRoll++;
            ScoringTally(PinsKnockedDown);
        }

        private void ScoringTally(int PinsKnockedDown)
        {
            CheckForStrike(PinsKnockedDown);
            RunningScore = RunningScore + PinsKnockedDown;
        }

        private void CheckForStrike(int PinsKnockedDown)
        {
            if (PinsKnockedDown == 10)
            {
                IsStrike = true;
                IsFrameFinished = true;
            }
        }
    }
}
