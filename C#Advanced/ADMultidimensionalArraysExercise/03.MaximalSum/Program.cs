using System;
using System.Linq;

namespace _03.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split()
                    .Select(int.Parse).ToArray();
            int[,] matrix = ReadMatrix(dimensions[0], dimensions[1]);
            int maxSum = int.MinValue;
            int[,] bestMatrix = new int[3, 3];
            if (dimensions[0] > 2 && dimensions[1] > 2)
            {
                for (int row = 0; row < matrix.GetLength(0) - 2; row++)
                {
                    for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                    {

                        int[,] currentMatrix = new int[3, 3]
                        {
                            { matrix[row, col], matrix[row, col+1],matrix[row, col+2] },
                            { matrix[row+1, col], matrix[row+1, col+1], matrix[row+1, col+2] },
                            { matrix[row+2, col], matrix[row+2, col+1], matrix[row+2, col+2] }
                        };
                        int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                    + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                    + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                        if (sum > maxSum)
                        {
                            maxSum = sum;
                            bestMatrix = currentMatrix;
                        }
                    }
                }
                Console.WriteLine($"Sum = {maxSum}");
                PrintMatrix(bestMatrix);
            }
        }
        public static int[,] ReadMatrix(int x, int y)
        {
            int[,] matrix = new int[x, y];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] numbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }
            return matrix;
        }
        public static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
