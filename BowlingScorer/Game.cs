using BowlingScorer.Models;
using System;
using System.Collections.Generic;

namespace BowlingScorer
{
    public class Game : IGame
    {
        private int GameTotalScore;
        private int FrameScore = 0;
        public int ThisFrameNumber = 1;
        public int PlayerRoll = 0;
        public int Bonus = 0;
        public bool IsFrameFinished = false;
        public bool IsStrike = false;
        public bool IsSpare = false;
        public List<FramesPlayed> FramesPlayed = new List<FramesPlayed>();
        public Game()
        {

        }
        public int Score()
        {
            return GameTotalScore;
        }
        /// <summary>
        /// Passes in the number of pins knocked down when a roll is made 
        /// by a player.
        /// </summary>
        /// <param name="PinsKnockedDown"></param>
        public void Roll(int pinsKnockedDown)
        {
            try
            {
                PlayerRoll++;
                if (PlayerRoll == 1)
                {
                    IsFrameFinished = false;
                }
                ScoreTally(pinsKnockedDown);
                FrameTally(pinsKnockedDown);
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void FrameTally(int pinsKnockedDown)
        {
            if (PlayerRoll == 1)
            {
                CheckForStrike(pinsKnockedDown);
            }
            else
            {
                if (!IsStrike)
                {
                    CheckForSpare();
                }
                //2nd roll so frame complete
                IsFrameFinished = true;
                AddFrameTally(IsStrike, IsSpare);
                ThisFrameNumber++;

                PlayerRoll = 0;
                FrameScore = 0;
            }
        }

        private void ScoreTally(int PinsKnockedDown)
        {
            FrameScore = FrameScore + PinsKnockedDown;
            GameTotalScore = GameTotalScore + PinsKnockedDown;

            //Check previous frame 

            if (FramesPlayed.Count > 0 && PlayerRoll == 1)
            {
                //Was this a spare
                var lastFrame = FramesPlayed.Find(f => f.FrameNumber == ThisFrameNumber - 1);
                //Add first roll score to bonus
                if (lastFrame.WasSpare)
                {
                    Bonus = Bonus  + PinsKnockedDown;
                    GameTotalScore = GameTotalScore + Bonus;
                }

            }
            //Add to score
        }

        private void CheckForSpare()
        {
            switch (FrameScore)
            {
                case 10:
                    IsSpare = true;
                    break;
                default:
                    IsSpare = false;
                    break;
            }

        }

        private void CheckForStrike(int PinsKnockedDown)
        {
            if (PinsKnockedDown == 10)
            {
                IsStrike = true;
                IsFrameFinished = true;
            }
        }

        private void AddFrameTally(bool isStrike, bool IsSpare)
        {
            FramesPlayed.Add(new FramesPlayed
            {
                FrameNumber = ThisFrameNumber,
                FrameScore = FrameScore,
                FrameBonus = Bonus,
                WasSpare = IsSpare,
                WasStrike = IsStrike,
                IsFrameFinished = IsFrameFinished
            });

        }
    }
}
