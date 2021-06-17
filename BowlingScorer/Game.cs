using System;

namespace BowlingScorer
{
    public class Game
    {
        private int RunningScore;
        public int Frame = 0;
        public void Roll(int PinsKnockedDown)
        {

            Frame++;
        }
    }
}
