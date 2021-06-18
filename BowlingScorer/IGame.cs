using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingScorer
{
    public interface IGame
    {
        public int Score();
        public void Roll(int PinsKnockedDown);
    }
}
