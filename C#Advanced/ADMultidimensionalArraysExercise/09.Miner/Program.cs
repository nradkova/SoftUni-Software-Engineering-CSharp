using System;
using System.Collections.Generic;

namespace _09.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> commands = new Queue<string>(Console.ReadLine().Split());
            string[,] matrix = ReadMatrix(n);
            int initialRow = 0;
            int initialCol = 0;
            int coals = 0;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == "s")
                    {
                        initialRow = row;
                        initialCol = col;
                    }
                    if (matrix[row, col] == "c")
                    {
                        coals++;
                    }
                }
            }
            while (commands.Count > 0)
            {
                string currentCommand = commands.Dequeue();
                Queue<int> nextCoordinates =
                    FindNextSymbol(n, matrix, initialRow, initialCol, currentCommand);
                if (nextCoordinates.Count == 2)
                {
                    int nextRow = nextCoordinates.Dequeue();
                    int nextCol = nextCoordinates.Dequeue();
                    string nextSymbol = matrix[nextRow, nextCol];
                    if (nextSymbol == "*")
                    {
                        matrix[initialRow, initialCol] = "*";
                        matrix[nextRow, nextCol] = "s";
                        initialRow = nextRow;
                        initialCol = nextCol;
                    }
                    else if (nextSymbol == "e")
                    {
                        Console.WriteLine($"Game over! ({nextRow}, {nextCol})");
                        return;
                    }
                    else if (nextSymbol == "c")
                    {
                        matrix[initialRow, initialCol] = "*";
                        matrix[nextRow, nextCol] = "s";
                        initialRow = nextRow;
                        initialCol = nextCol;
                        coals--;
                        if (coals==0)
                        {
                            Console.WriteLine($"You collected all coals!" +
                                $" ({initialRow}, {initialCol})");
                            return;
                        }
                    }
                }
            }
            Console.WriteLine($"{ coals} coals left." +
                $" ({ initialRow}, { initialCol})");
        }

        private static Queue<int> FindNextSymbol(int n, string[,] matrix, int initialRow, int initialCol, string currentCommand)
        {
            Queue<int> nextCoordinates = new Queue<int>();
            if (currentCommand == "up")
            {
                if (IsValid(initialRow - 1, initialCol, n))
                {
                    nextCoordinates.Enqueue(initialRow - 1);
                    nextCoordinates.Enqueue(initialCol);
                }
            }
            else if (currentCommand == "down")
            {
                if (IsValid(initialRow + 1, initialCol, n))
                {
                    nextCoordinates.Enqueue(initialRow + 1);
                    nextCoordinates.Enqueue(initialCol);
                }
            }
            else if (currentCommand == "left")
            {
                if (IsValid(initialRow, initialCol - 1, n))
                {
                    nextCoordinates.Enqueue(initialRow);
                    nextCoordinates.Enqueue(initialCol - 1);
                }
            }
            else if (currentCommand == "right")
            {
                if (IsValid(initialRow, initialCol + 1, n))
                {
                    nextCoordinates.Enqueue(initialRow);
                    nextCoordinates.Enqueue(initialCol + 1);
                }
            }

            return nextCoordinates;
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
        public static string[,] ReadMatrix(int x)
        {
            string[,] matrix = new string[x, x];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            return matrix;
        }
        public static void PrintMatrix(string[,] matrix)
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
