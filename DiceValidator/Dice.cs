using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DiceValidator
{
    public class Dice
    {
        public int Sides { get; set; }
        public List<int> Rolls { get; set; }

        public Dice() 
        {
            Rolls = new List<int>();
        }

        public double getAvgRolls()
        {
            return Rolls.Count > 0 ? Rolls.Average() : 0;
        }

        public double getProbability(int value)
        {
            // Amount of rolls on a given number over the total rolls in the sample
            return ((double)Rolls.Count(x => x == value) / Rolls.Count());
        }

        public double getProbabilityStandard()
        {
            // Get probability of rolling any one value in a perfectly weighted die
            return ((double)1 / Sides);
        }

        public int getMode()
        {
            if (Rolls.Count > 0)
            {
                // Group by each number and return the largest group
                return Rolls.GroupBy(v => v)
                .OrderByDescending(g => g.Count())
                .First().Key;
            }
            else
            {
                return 0;
            }
        }

        public double GetMedian()
        {
            if (Rolls.Count > 0)
            {
                var ys = Rolls.OrderBy(x => x).ToList();
                double mid = (ys.Count - 1) / 2.0;
                return (ys[(int)(mid)] + ys[(int)(mid + 0.5)]) / 2;
            }
            else
            {
                return 0;
            }
        }
    }
}
