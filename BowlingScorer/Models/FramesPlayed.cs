using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingScorer.Models
{
    public class FramesPlayed
    {
        public int FrameNumber { get; set; }
        public int FrameScore { get; set; }
        public bool WasStrike { get; set; }
        public bool WasSpare { get; set; }
    }
}
