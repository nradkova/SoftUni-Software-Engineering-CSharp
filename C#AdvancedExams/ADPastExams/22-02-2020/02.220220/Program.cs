using System;

namespace _02._220220
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int x = int.Parse(Console.ReadLine());
            char[,] matrix = ReadMatrix(n);
            int playerRow = 0;
            int playerCol = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;

                    }
                }
            }

            bool winGame = false;
            for (int i = 0; i < x; i++)
            {
                string command = Console.ReadLine();
                int currentRow = playerRow;
                int currentCol = playerCol;
                matrix[playerRow, playerCol] = '-';
                playerRow = MoveRow(n, command, playerRow);
                playerCol = MoveCol(n, command, playerCol);
                if (matrix[playerRow, playerCol] == 'B')
                {
                    playerRow = MoveRow(n, command, playerRow);
                    playerCol = MoveCol(n, command, playerCol);
                }
                if (matrix[playerRow, playerCol] == 'T')
                {
                    playerRow = currentRow;
                    playerCol = currentCol;
                }
                if (matrix[playerRow, playerCol] == 'F')
                {
                    matrix[playerRow, playerCol] = 'f';
                    winGame = true;
                    break;
                }
                matrix[playerRow, playerCol] = 'f';
            }

            if (winGame)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }
            Print(matrix);

            static char[,] ReadMatrix(int n)
            {
                char[,] matrix = new char[n, n];
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    string input = Console.ReadLine();
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = input[col];
                    }
                }
                return matrix;
            }
            static void Print(char[,] matrix)
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
            static int MoveRow(int n, string command, int row)
            {
                if (command == "up")
                {
                    row--;
                    if (row < 0)
                    {
                        row = n - 1;
                    }
                }
                else if (command == "down")
                {
                    row++;
                    if (row >= n)
                    {
                        row = 0;
                    }
                }
                return row;
            }
            static int MoveCol(int n, string command, int col)
            {
                if (command == "left")
                {
                    col--;
                    if (col < 0)
                    {
                        col = n - 1;
                    }
                }
                else if (command == "right")
                {
                    col++;
                    if (col >= n)
                    {
                        col = 0;
                    }
                }
                return col;
            }
        }
    }
}
