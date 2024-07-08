namespace DynamicProgramming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Finding maximum value obtainable by cutting up the rod
            RodCutting rc = new RodCutting(new int[] { 1, 3, 5, 5, 7, 8, 8, 9 });
            rc.CutRodBU();
            rc.PrintCutRodArrays();
            Console.WriteLine();
            #endregion

            #region Finding Longest Common Subsequence of given example
            LongestCommonSubsequence lcs = new LongestCommonSubsequence("BACBCD", "BCDBAD");
            lcs.CalculateMatrices();
            lcs.PrintLCS();
            Console.WriteLine();
            lcs.PrintBottomUpMatrix();
            Console.WriteLine();
            lcs.PrintDirectionMatrix();
            Console.WriteLine();
            #endregion

            #region Finding subarray with maximum sum of given example
            int[] maxSubArray = MaximumSubarray.GetMaximumSubarray(
                new int[] { 12, -3, -25, 20, -3, -16, -23, 18, 20, -7, 12, -5, -22, 15, -4, 7 });
            Console.Write("Subarray with maximum sum is: ");
            foreach (var item in maxSubArray)
            {
                Console.Write($"{item}  ");
            }
            Console.WriteLine();
            #endregion
        }
    }
}
