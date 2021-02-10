using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._25102020
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            var matrix = new int[rows, cols];
            var positions = new Queue<int>();
            while (true)
            {
                var line = Console.ReadLine();
                if (line == "Bloom Bloom Plow")
                {
                    break;
                }
                var tokens = line
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                int row = tokens[0];
                int col = tokens[1];
                if (IsValidPosition(row, col, matrix))
                {
                    positions.Enqueue(row);
                    positions.Enqueue(col);
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }
            }
           
            while (positions.Count>1)
            {
                int row = positions.Dequeue();
                int col = positions.Dequeue();
                BloomingFlowers(row, col, matrix);
            }
            
            Print(matrix);
        }

        private static void Print(int[,] matrix)
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

        private static void BloomingFlowers(int row, int col, int[,] matrix)
        {
            for (int c = 0; c < matrix.GetLength(1); c++)
            {
                matrix[row, c] += 1;
            }
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                matrix[r, col] += 1;
            }
            matrix[row, col] -= 1;
        }

        private static bool IsValidPosition(int row, int col, int[,] matrix)
        {
            if (row < 0 || row >= matrix.GetLength(0))
            {
                return false;
            }
            if (col < 0 || col >= matrix.GetLength(1))
            {
                return false;
            }
            return true;
        }
    }
}
