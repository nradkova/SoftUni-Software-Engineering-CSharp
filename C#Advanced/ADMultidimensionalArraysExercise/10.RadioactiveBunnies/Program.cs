using System;
using System.Linq;

namespace RadioactiveBunnies
{
    class Program
    {
        private static char[,] table;
        private static int playerRow = 0;
        private static int playerCol = 0;
        private static bool playerLoose = false;

        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int n = dimensions[0];
            int m = dimensions[1];
            table = ReadTable(n, m);

            bool playerWin = false;

            string commandLine = Console.ReadLine();
            for (int i = 0; i < commandLine.Length; i++)
            {
                var command = commandLine[i];
                var prevRow = playerRow;
                var prevCol = playerCol;

                ExecuteCommand(command);

                if (AreOutOfTable(playerRow, playerCol))
                {
                    table[prevRow, prevCol] = '.';
                    playerWin = true;
                }
                else if (table[playerRow, playerCol] == 'B')
                {
                    table[playerRow, playerCol] = 'B';
                    playerLoose = true;
                }
                else
                {
                    table[playerRow, playerCol] = 'P';
                    table[prevRow, prevCol] = '.';
                }

                MultiplyBunnies();

                if (playerWin)
                {
                    playerRow = prevRow;
                    playerCol = prevCol;
                    break;
                }
                if (playerLoose)
                {
                    break;
                }
            }

            PrintTable();

            if (playerWin)
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }
            if (playerLoose)
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }

        }


        private static void PrintTable()
        {
            for (int row = 0; row < table.GetLength(0); row++)
            {
                for (int col = 0; col < table.GetLength(1); col++)
                {
                    Console.Write(table[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void MultiplyBunnies()
        {
            for (int row = 0; row < table.GetLength(0); row++)
            {
                for (int col = 0; col < table.GetLength(1); col++)
                {
                    if (table[row, col] == 'B')
                    {
                        CreateNewBunny(row - 1, col);
                        CreateNewBunny(row + 1, col);
                        CreateNewBunny(row, col - 1);
                        CreateNewBunny(row, col + 1);

                    }
                }
            }
            RestoreBunniesPositions();
        }

        private static void RestoreBunniesPositions()
        {
            for (int row = 0; row < table.GetLength(0); row++)
            {
                for (int col = 0; col < table.GetLength(1); col++)
                {
                    if (table[row, col] == 'N')
                    {
                        table[row, col] = 'B';
                    }
                }
            }
        }

        private static void CreateNewBunny(int row, int col)
        {
            if (AreOutOfTable(row, col))
            {
                return;
            }
            if (table[row, col] == 'P')
            {
                playerLoose = true;
                table[row, col] = 'N';
                return;
            }
            if (table[row, col] == '.')
            {
                table[row, col] = 'N';
            }

            return;
        }

        private static bool AreOutOfTable(int row, int col)
        {
            if (row < 0 || row >= table.GetLength(0))
            {
                return true;
            }
            if (col < 0 || col >= table.GetLength(1))
            {
                return true;
            }
            return false;
        }

        private static void ExecuteCommand(char command)
        {
            if (command == 'U')
            {
                playerRow--;
            }
            if (command == 'D')
            {
                playerRow++;
            }
            if (command == 'R')
            {
                playerCol++;
            }
            if (command == 'L')
            {
                playerCol--;
            }
        }

        private static char[,] ReadTable(int n, int m)
        {
            char[,] result = new char[n, m];
            for (int row = 0; row < n; row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < m; col++)
                {
                    result[row, col] = line[col];
                    if (result[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
            return result;
        }
    }
}
