using System;
using System.Linq;

namespace _07.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = ReadMatrix(4, 4);

            PrintMatrix(matrix);
            for (int row = matrix.GetLength(0); row >=0; row++)
            {
                for (int col = matrix.GetLength(1); col >=0; col++)
                {

                }
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
