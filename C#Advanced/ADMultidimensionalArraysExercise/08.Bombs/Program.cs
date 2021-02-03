using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _08.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = ReadMatrix(n, n);
            int[] infoData = Console.ReadLine()
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
            Queue<int> bombCoordinates = new Queue<int>(infoData);

            while (bombCoordinates.Count > 1)
            {
                int rowBomb = bombCoordinates.Dequeue();
                int colBomb = bombCoordinates.Dequeue();
                int bomb = matrix[rowBomb, colBomb];
                if (bomb > 0)
                {
                    BombExplosion(n, matrix, rowBomb, colBomb, bomb);
                    matrix[rowBomb, colBomb] = 0;
                }

            }
            FindAndSumAliveCells(n, matrix);
            PrintMatrix(matrix);

        }

        private static void FindAndSumAliveCells(int n, int[,] matrix)
        {
            int sum = 0;
            int aliveCellsCount = 0;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        sum += matrix[row, col];
                        aliveCellsCount++;
                    }
                }
            }
            Console.WriteLine($"Alive cells: { aliveCellsCount}");
            Console.WriteLine($"Sum: {sum}");
        }

        private static void BombExplosion(int n, int[,] matrix, int rowBomb, int colBomb, int bomb)
        {
            if (IsValid(rowBomb - 1, colBomb - 1, n)
                                    && matrix[rowBomb - 1, colBomb - 1] > 0)
            {
                matrix[rowBomb - 1, colBomb - 1] -= bomb;
            }
            if (IsValid(rowBomb - 1, colBomb, n)
                && matrix[rowBomb - 1, colBomb] > 0)
            {
                matrix[rowBomb - 1, colBomb] -= bomb;
            }
            if (IsValid(rowBomb - 1, colBomb + 1, n)
               && matrix[rowBomb - 1, colBomb + 1] > 0)
            {
                matrix[rowBomb - 1, colBomb + 1] -= bomb;
            }
            if (IsValid(rowBomb, colBomb + 1, n)
              && matrix[rowBomb, colBomb + 1] > 0)
            {
                matrix[rowBomb, colBomb + 1] -= bomb;
            }
            if (IsValid(rowBomb, colBomb - 1, n)
             && matrix[rowBomb, colBomb - 1] > 0)
            {
                matrix[rowBomb, colBomb - 1] -= bomb;
            }
            if (IsValid(rowBomb + 1, colBomb - 1, n)
             && matrix[rowBomb + 1, colBomb - 1] > 0)
            {
                matrix[rowBomb + 1, colBomb - 1] -= bomb;
            }
            if (IsValid(rowBomb + 1, colBomb + 1, n)
            && matrix[rowBomb + 1, colBomb + 1] > 0)
            {
                matrix[rowBomb + 1, colBomb + 1] -= bomb;
            }
            if (IsValid(rowBomb + 1, colBomb, n)
           && matrix[rowBomb + 1, colBomb] > 0)
            {
                matrix[rowBomb + 1, colBomb] -= bomb;
            }
        }

        public static bool IsValid(int row, int col, int n)
        {
            bool isValid = false;
            if (row >= 0 && row < n
                && col >= 0 && col < n)
            {
                isValid = true;
            }
            return isValid;
        }
        public static int[,] ReadMatrix(int x, int y)
        {
            int[,] matrix = new int[x, x];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
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
