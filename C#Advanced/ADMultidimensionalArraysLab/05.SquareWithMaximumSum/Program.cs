using System;
using System.Linq;

namespace _05.SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] elements = Console.ReadLine().Split(", ").
               Select(int.Parse).ToArray();
            int[,] matrix = new int[elements[0], elements[1]];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] numbers = Console.ReadLine().Split(", ").
                Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }
            int maxSum = int.MinValue;
            int pointA = 0;
            int pointB = 0;
            int pointC = 0;
            int pointD = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int currentSum = matrix[row, col] + matrix[row, col + 1]
                        + matrix[row + 1, col] + matrix[row + 1, col + 1];
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        pointA = matrix[row, col];
                        pointB = matrix[row, col + 1];
                        pointC = matrix[row + 1, col];
                        pointD = matrix[row + 1, col + 1];
                    }
                }
            }
            Console.WriteLine(pointA + " " + pointB);
            Console.WriteLine(pointC + " " + pointD);
            Console.WriteLine(maxSum);

        }
    }
}
