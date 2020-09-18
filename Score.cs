using System;
using System.Collections.Generic;
using System.Text;

namespace Millionaire_GAME
{
    class Score
    {
        public static int UserScore { get; private set; }

        public static void SetScore()
        {
            Score.UserScore = (int)(100 * Math.Pow(2, Game.NumberQuestion));
        }

        public static void ZeroScore()
        {
            Score.UserScore = 0;
        }
    }
}
