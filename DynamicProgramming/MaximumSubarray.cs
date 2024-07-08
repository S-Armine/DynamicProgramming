using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class MaximumSubarray
    {
        public static int[] GetMaximumSubarray(int[] array)
        {
            int maxSum = array[0];
            int currentSum = array[0];
            int startCurrentIndex = 0;
            int startMaxIndex = 0;
            int endMaxIndex = 1;
            for (int i = 0; i < array.Length; i++)
            {
                currentSum += array[i];
                if (currentSum < array[i])
                {
                    startCurrentIndex = i;
                    currentSum = array[i];
                }
                if (currentSum > maxSum)
                {
                    startMaxIndex = startCurrentIndex;
                    endMaxIndex = i + 1;
                    maxSum = currentSum;
                }
            }
            int[] result = new int[endMaxIndex - startMaxIndex];
            Array.Copy(array, startMaxIndex, result, 0, endMaxIndex - startMaxIndex);
            return result;
        }
    }
}
