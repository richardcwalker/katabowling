using System;

namespace BowlingScorer
{
    public class Game
    {
        private int RunningScore;
        public int Frame = 0;
        public int PlayerRoll = 0;
        public bool IsframeFinished = false;
        public bool IsStrike = false;

        public int Score()
        {
            return RunningScore;
        }
        public void Roll(int PinsKnockedDown)
        {
            PlayerRoll++;

            if(PinsKnockedDown == 10)
            {
                IsStrike = true;
                IsframeFinished = true;
            }

            RunningScore = RunningScore + PinsKnockedDown;
            
            if (PlayerRoll == 2)
            {
                Frame++;
            }       
        }
    }
}
