using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScorer
{
    public class Game
    {
        private int RunningScore;
        /// <summary>
        /// The game consists of 10 frames. In each frame the player has two rolls to knock down 10 pins. 
        /// The score for the frame is the total number of pins knocked down, plus bonuses for strikes and spares.
        /// A spare is when the player knocks down all 10 pins in two rolls.
        /// The bonus for that frame is the number of pins knocked down by the next roll.
        /// A strike is when the player knocks down all 10 pins on his first roll.
        /// The frame is then completed with a single roll. 
        /// The bonus for that frame is the value of the next two rolls.
        /// In the tenth frame a player who rolls a spare or strike is allowed to roll the extra balls to complete the frame. 
        /// However no more than three balls can be rolled in tenth frame.

        /// </summary>
        public Game()
        {
            RunningScore = 0;
        }

        public void Roll(int NumberOfPins)
        {
            RunningScore = RunningScore + NumberOfPins;           
        }

        public int Score()
        {
            return RunningScore;
        }
    }
}
