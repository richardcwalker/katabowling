using BowlingScorer.Models;
using System;
using System.Collections.Generic;

namespace BowlingScorer
{
    public class Game : IGame
    {
        private int GameTotalScore;
        private int FrameScore = 0;
        public int Frame = 0;
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
            return FrameScore;
        }
        /// <summary>
        /// Passes in the number of pins knocked down when a roll is made 
        /// by a player.
        /// </summary>
        /// <param name="PinsKnockedDown"></param>
        public void Roll(int PinsKnockedDown)
        {
            PlayerRoll++;
            Frame++;
            FrameTally(PinsKnockedDown);
            
        }

        private void FrameTally(int pinsKnockedDown)
        {
            CheckForStrike(pinsKnockedDown);
            //If second roll check for spare (all 10 pins down in two rolls)
            if(!IsStrike && PlayerRoll == 2)
            {
                CheckForSpare(pinsKnockedDown);
            }
            ScoreTally(pinsKnockedDown);
            
        }

        private void ScoreTally(int PinsKnockedDown)
        {
            FrameScore = FrameScore + PinsKnockedDown;
            GameTotalScore = GameTotalScore + FrameScore;
        }

        private void CheckForSpare(int pinsKnockedDown)
        {
            switch (FrameScore + pinsKnockedDown)
            {
                case 10:
                    IsSpare = true;
                    break;
                default:
                    IsSpare = false;
                    break;
            }
            AddFrameTally(IsStrike, IsSpare);
        }

        private void CheckForStrike(int PinsKnockedDown)
        {
            if (PinsKnockedDown == 10)
            {
                IsStrike = true;
                IsFrameFinished = true;
                AddFrameTally(IsStrike, IsSpare);
            }
        }

        private void AddFrameTally(bool isStrike, bool IsSpare)
        {
            FramesPlayed.Add(new FramesPlayed
            {
                FrameNumber = Frame,
                FrameScore = FrameScore,
                WasSpare = false,
                WasStrike = true
            });

        }
    }
}
