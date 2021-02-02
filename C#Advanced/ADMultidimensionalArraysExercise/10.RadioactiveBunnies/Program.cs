using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.RadioactiveBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();
            int x = dimensions[0];
            int y = dimensions[1];
            char[,] matrix = ReadMatrix(x, y);
            Queue<char> commands = new Queue<char>(Console.ReadLine().ToCharArray());

            int initialRow = 0;
            int initialCol = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'P')
                    {
                        initialRow = row;
                        initialCol = col;
                    }
                }
            }
            bool winGame = false;
            bool loseGame = false;
            int nextRow = 0;
            int nextCol = 0;

            while (commands.Count > 0)
            {
                char newCommand = commands.Dequeue();
                FindNextPosition(initialRow, initialCol, ref nextRow, ref nextCol, newCommand);
                if (!ContinueMove(nextRow, nextCol, x, y))
                {
                    winGame = true;
                    matrix[initialRow, initialCol] = '.';
                }
                else
                {
                    if (matrix[nextRow, nextCol] == 'B')
                    {
                        loseGame = true;
                        matrix[initialRow, initialCol] = '.';
                    }
                    else
                    {
                        matrix[initialRow, initialCol] = '.';
                        initialRow = nextRow;
                        initialCol = nextCol;
                    }
                }
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'B')
                        {
                            if (ContinueMove(row - 1, col, x, y)
                                && matrix[row - 1, col] == '.')
                            {
                                matrix[row - 1, col] = 'N';
                            }
                            if (ContinueMove(row + 1, col, x, y)
                                && matrix[row + 1, col] == '.')
                            {
                                matrix[row + 1, col] = 'N';
                            }
                            if (ContinueMove(row, col - 1, x, y)
                                && matrix[row, col - 1] == '.')
                            {
                                matrix[row, col - 1] = 'N';
                            }
                            if (ContinueMove(row, col + 1, x, y)
                                && matrix[row, col + 1] == '.')
                            {
                                matrix[row, col + 1] = 'N';
                            }
                        }
                    }
                }
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'N')
                        {
                            matrix[row, col] ='B';
                        }
                    }
                }
                if (winGame)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"won: {initialRow} {initialCol}");
                    return;
                }
                if (loseGame)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"dead: {nextRow} {nextCol}");
                    return;
                }
            }
        }

        private static void FindNextPosition(int initialRow, int initialCol, ref int nextRow, ref int nextCol, char newCommand)
        {
            if (newCommand == 'U')
            {
                nextRow = initialRow - 1;
                nextCol = initialCol;
            }
            else if (newCommand == 'D')
            {
                nextRow = initialRow + 1;
                nextCol = initialCol;
            }
            else if (newCommand == 'R')
            {
                nextRow = initialRow;
                nextCol = initialCol + 1;
            }
            else if (newCommand == 'L')
            {
                nextRow = initialRow;
                nextCol = initialCol - 1;
            }
        }

        public static bool ContinueMove(int row, int col, int x, int y)
        {
            bool continueMoves = false;
            if (row >= 0 && row < x
                && col >= 0 && col < y)
            {
                continueMoves = true;
            }
            return continueMoves;
        }
        public static char[,] ReadMatrix(int x, int y)
        {
            char[,] matrix = new char[x, y];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            return matrix;
        }
        public static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
