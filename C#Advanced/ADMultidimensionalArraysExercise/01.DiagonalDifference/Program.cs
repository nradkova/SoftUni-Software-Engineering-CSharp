using System;
using System.Linq;

namespace _01.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] numbers = Console.ReadLine().Split()
                    .Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            int primaryDiagonal = 0;
            int secondaryDiagonal = 0;
            for (int row = 0; row < n; row++)
            {
                int col = row;
                primaryDiagonal += matrix[row, col];
            }
            for (int row = 0; row < n; row++)
            {
                    int col = n - 1 - row;
                    secondaryDiagonal += matrix[row, col];
            }
            Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));
        }
    }
}
