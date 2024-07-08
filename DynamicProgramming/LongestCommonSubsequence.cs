using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class LongestCommonSubsequence
    {
        private int[,] bottomUpMatrix;
        private char[,] directionMatrix;
        public string FirstString { get; set; }
        public string SecondString { get; set; }

        public LongestCommonSubsequence(string firstString, string secondString)
        {
            this.FirstString = firstString;
            this.SecondString = secondString;
            CalculateMatrices();
        }

        public void PrintLCS()
        {
            PrintLCSRecursive(FirstString.Length - 1, SecondString.Length - 1);
        }

        public void PrintLCSRecursive(int i, int j)
        {
            if (i < 0 || j < 0 || i > directionMatrix.GetLength(0) || j > directionMatrix.GetLength(1))
            {
                return;
            }
            if (directionMatrix[i,j] == '\\')
            {
                PrintLCSRecursive(i - 1, j - 1);
                Console.Write(FirstString[i]);
            }
            else if (directionMatrix[i,j] == '|')
            {
                PrintLCSRecursive(i - 1, j);
            }
            else
            {
                PrintLCSRecursive(i, j - 1);
            }
        }

        public void CalculateMatrices()
        {
            directionMatrix = new char[FirstString.Length, SecondString.Length];

            bottomUpMatrix = new int[FirstString.Length + 1, SecondString.Length + 1];
            for (int i = 0; i < bottomUpMatrix.GetLength(0); i++)
            {
                bottomUpMatrix[i, 0] = 0;
            }
            for (int i = 0; i < bottomUpMatrix.GetLength(1); i++)
            {
                bottomUpMatrix[0, i] = 0;
            }

            for (int i = 0; i < FirstString.Length; i++)
            {
                for (int j = 0; j < SecondString.Length; j++) 
                { 
                    if (FirstString[i] == SecondString[j])
                    {
                        directionMatrix[i, j] = '\\';
                        bottomUpMatrix[i + 1, j + 1] = bottomUpMatrix[i, j] + 1;
                    }
                    else if (bottomUpMatrix[i, j + 1] >= bottomUpMatrix[i + 1, j])
                    {
                        directionMatrix[i, j] = '|';
                        bottomUpMatrix[i + 1, j + 1] = bottomUpMatrix[i, j + 1];
                    }
                    else
                    {
                        directionMatrix[i, j] = '-';
                        bottomUpMatrix[i + 1, j + 1] = bottomUpMatrix[i + 1, j];
                    }
                }
            }
        }

        public void PrintBottomUpMatrix()
        {
            for (int i = 0; i < bottomUpMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < bottomUpMatrix.GetLength(1); j++)
                {
                    Console.Write($"{bottomUpMatrix[i,j]}  ");
                }
                Console.WriteLine();
            }
        }

        public void PrintDirectionMatrix()
        {
            for (int i = 0; i < directionMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < directionMatrix.GetLength(1); j++)
                {
                    Console.Write($"{directionMatrix[i, j]}  ");
                }
                Console.WriteLine();
            }
        }
    }
}
