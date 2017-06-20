using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGameKata
{
    public class BowlingScorer
    {
        //private List<int> rolls;
        private int[] rolls;
        private int currentRoll;

        public BowlingScorer()
        {
            rolls = new int[21];
            currentRoll = 0;
        }

        public void Roll(int pins)
        {
            if (pins > 10)
                throw new Exception("Oh noes!");

            rolls[currentRoll] = pins;
            currentRoll++;
        }

        public int GetScore()
        {
            var score = 0;
            var rollCount = 0;

            for(var frame = 0; frame < 10; frame++)
            {
                if (rolls[rollCount] == 10)
                {
                    score = score + rolls[rollCount]
                        + rolls[rollCount + 1] + rolls[rollCount + 2];
                    rollCount = rollCount + 1;
                }
                else if (rolls[rollCount] + rolls[rollCount + 1] == 10)
                {
                    score = score + rolls[rollCount] 
                        + rolls[rollCount + 1] + rolls[rollCount + 2];
                    rollCount = rollCount + 2;
                }
                else
                {
                    score = score + rolls[rollCount] + rolls[rollCount + 1];
                    rollCount = rollCount + 2;
                }
                
            }
            
            return score;
        }
    }
}
