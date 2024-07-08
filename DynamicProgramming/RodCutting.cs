using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class RodCutting
    {
        private int[] r;
        private int[] s;
        private int[] prices;

        public RodCutting(int[] prices)
        {
            this.prices = prices;
            r = new int[prices.Length + 1];
            s = new int[prices.Length + 1];
        }

        public void CutRodBU()
        {
            r[0] = s[0] = 0;
            for (int j = 1; j < r.Length; j++)
            {
                int maxValue = int.MinValue;
                for (int i = 0; i < j; i++)
                {
                    int current = prices[i] + r[j - i - 1];
                    if (maxValue < current)
                    {
                        maxValue = current;
                        s[j] = i + 1;
                    }
                }
                r[j] = maxValue;
            }
;       }

        public void PrintCutRodArrays()
        {
            Console.WriteLine($"r = {string.Join(" ", r)}");
            Console.WriteLine($"s = {string.Join(" ", s)}");
        }
    }
}
