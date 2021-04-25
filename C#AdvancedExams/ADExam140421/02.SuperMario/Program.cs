using System;

namespace _2
{
    class Program
    {
        private static char[][] table;
        private static int lives;
        private static int playerRow = 0;
        private static int playerCol = 0;

        static void Main(string[] args)
        {
            lives = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            table = ReadTable(rows);

            bool hasLost = false;
            bool hasWon = false;
            while (true)
            {
                string[] commandArgs = Console.ReadLine()
                    .Split();
                string command = commandArgs[0];
                int bowserRow = int.Parse(commandArgs[1]);
                int bowserCol = int.Parse(commandArgs[2]);
                if (AreValidCoordinates(bowserRow, bowserCol))
                {
                    table[bowserRow][bowserCol] = 'B';
                }
                
                table[playerRow][playerCol] = '-';

                ExecuteCommand(command);

                if (table[playerRow][playerCol] == 'B')
                {
                    lives -= 2;
                    table[playerRow][playerCol] = '-';
                }
                if (table[playerRow][playerCol] == 'P')
                {
                    hasWon = true;
                    hasLost = false;
                    table[playerRow][playerCol] = '-';
                }
                if (lives <= 0)
                {
                    hasLost = true;
                    if (hasWon)
                    {
                        hasLost = true;
                    }
                    table[playerRow][playerCol] = 'X';
                }

                if (hasWon)
                {
                    break;
                }
                if (hasLost)
                {
                    break;
                }
            }

            if (hasWon)
            {
                Console.WriteLine($"Mario has successfully" +
                    $" saved the princess! Lives left: {lives}");
            }
            if (hasLost)
            {
                Console.WriteLine($"Mario died at " +
                    $"{playerRow};{playerCol}.");
            }
            PrintTable();
        }

        private static void PrintTable()
        {
            for (int row = 0; row < table.Length; row++)
            {
                for (int col = 0; col < table[row].Length; col++)
                {
                    Console.Write(table[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static void ExecuteCommand(string command)
        {
            lives--;
            if (command == "D")
            {
                playerCol++;
                if (playerCol >= table[playerRow].Length)
                {
                    playerCol--;
                }
            }
            if (command == "A")
            {
                playerCol--;
                if (playerCol < 0)
                {
                    playerCol = 0;
                }
            }
            if (command == "S")
            {
                playerRow++;
                if (playerRow >= table.Length)
                {
                    playerRow--;
                }
            }
            if (command == "W")
            {
                playerRow--;
                if (playerRow < 0)
                {
                    playerRow = 0;
                }
            }
        }
        private static bool AreValidCoordinates
            (int bowserRow, int bowserCol)
        {
            if (bowserRow < 0 || bowserRow >= table.Length)
            {
                return false;
            }
            if (bowserCol < 0 || bowserCol >= table[bowserRow].Length)
            {
                return false;
            }
            return true;
        }

        private static char[][] ReadTable(int rows)
        {
            char[][] result = new char[rows][];
            for (int row = 0; row < rows; row++)
            {
                string line = Console.ReadLine();
                result[row] = new char[line.Length];
                for (int col = 0; col < line.Length; col++)
                {
                    result[row][col] = line[col];
                    if (line[col] == 'M')
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
