using System;

namespace Selling
{
    class Program
    {
        private static char[,] table;
        private static int playerRow = 0;
        private static int playerCol = 0;

        static void Main(string[] args)
        {
            int n =int.Parse(Console.ReadLine());
            table = ReadTable(n);

            bool isOut = false;
            int collectedSum =0;
            while (collectedSum<50)
            {
                string command =Console.ReadLine();
                ExecuteCommand(command);

                if (IsOutOfTable())
                {
                    isOut = true;
                    break;
                }
                if (char.IsDigit(table[playerRow, playerCol]))
                {
                    collectedSum += 
                        int.Parse(table[playerRow, playerCol].ToString());
                }
                if (table[playerRow, playerCol]=='O')
                {
                    table[playerRow, playerCol] = '-';
                    FindNextPillar();
                }
                table[playerRow, playerCol] = 'S';
            }

            if (isOut)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }
            else
            {
                Console.WriteLine("Good news! " +
                    "You succeeded in collecting enough money!");
            }

            Console.WriteLine($"Money: {collectedSum}");

            PrintTable();
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

        private static void FindNextPillar()
        {
            for (int row = 0; row < table.GetLength(0); row++)
            {
                for (int col = 0; col < table.GetLength(1); col++)
                {
                    if (table[row, col] == 'O')
                    {
                        playerRow = row;
                        playerCol = col;
                        table[row, col] = '-';
                    }
                }
            }
        }

        private static bool IsOutOfTable()
        {
            if (playerRow < 0 || playerRow >= table.GetLength(0))
            {
                return true;
            }
            if (playerCol < 0 || playerCol >= table.GetLength(1))
            {
                return true;
            }
            return false;
        }

        private static void ExecuteCommand(string command)
        {
            table[playerRow, playerCol] = '-';

            if (command=="right")
            {
                playerCol++;
            }
            if (command == "left")
            {
                playerCol--;
            }
            if (command == "down")
            {
                playerRow++;
            }
            if (command == "up")
            {
                playerRow--;
            }
        }

        private static char[,] ReadTable(int n)
        {
            char[,] result = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                string line =Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    result[row, col] = line[col];
                    if (line[col]=='S')
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
