using System;

namespace BowlingScorer
{
    public class Game
    {
        private int RunningScore;
        public int Frame = 0;
        public int PlayerRoll = 0;
        public void Roll(int PinsKnockedDown)
        {
            PlayerRoll++;
            RunningScore = RunningScore + PinsKnockedDown;
            if (PlayerRoll == 2)
            {
                Frame++;
            }
            
        }
    }
}
