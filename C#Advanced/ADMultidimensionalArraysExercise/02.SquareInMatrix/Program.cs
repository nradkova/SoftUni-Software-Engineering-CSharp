using System;
using System.Linq;

namespace _02.SquareInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split()
                    .Select(int.Parse).ToArray();
            if (dimensions[0] > 0 && dimensions[1] > 0)
            {
                string[,] matrix = ReadMatrix(dimensions[0], dimensions[1]);
                int squaresCount = 0;
                for (int row = 0; row < matrix.GetLength(0) - 1; row++)
                {
                    for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                    {
                        if (matrix[row, col] == matrix[row + 1, col + 1]
                            && matrix[row, col] == matrix[row, col + 1]
                            && matrix[row, col] == matrix[row + 1, col])
                        {
                            squaresCount++;
                        }
                    }
                }
                Console.WriteLine(squaresCount);
            }
        }
        public static string[,] ReadMatrix(int x, int y)
        {
            string[,] matrix = new string[x, y];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] symbols = Console.ReadLine().Split();
                 
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = symbols[col];
                }
            }
            return matrix;
        }
    }
}
