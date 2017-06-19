using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGameKata
{
    public class BowlingScorer
    {
        private List<int> rolls;

        public BowlingScorer()
        {
            rolls = new List<int>();
        }

        public void Roll(int pins)
        {
            rolls.Add(pins);
        }

        public int GetScore()
        {
            var score = 0;

            foreach(var roll in rolls)
            {
                score = score + roll;
            }

            return score;
        }
    }
}
