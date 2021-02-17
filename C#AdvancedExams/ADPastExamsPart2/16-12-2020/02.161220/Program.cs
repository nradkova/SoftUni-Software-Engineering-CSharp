using System;

namespace _02.Selling
{
    class Program
    {
        private static int row;
        private static int col;
        private static char[,] table;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            row = 0;
            col = 0;
            table = ReadTable(n);
            int moneySaved = 0;
           
            while (true)
            {
                string command = Console.ReadLine();
                table[row, col] = '-';
                FollowCommand(command);
                if (IsValidPosition())
                {
                    if (char.IsDigit(table[row, col]))
                    {
                        moneySaved += int.Parse(table[row, col].ToString());
                    }
                    if (table[row, col] == 'O')
                    {
                        table[row, col] = '-';
                        MoveToNextPillar();
                    }
                    table[row, col] = 'S';
                }
                else
                {
                    break;
                }
                if (moneySaved>=50)
                {
                    break;
                }
            }
            if (moneySaved>=50)
            {
                Console.WriteLine("Good news! You succeeded " +
                    "in collecting enough money!");
            }
            else
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }
            Console.WriteLine($"Money: { moneySaved}");
            PrintTable();
           
        }

        private static void PrintTable()
        {
            for (int r = 0; r < table.GetLength(0); r++)
            {
                for (int c = 0; c < table.GetLength(1); c++)
                {
                    Console.Write(table[r,c]);
                }
                Console.WriteLine();
            }
        }

        private static void MoveToNextPillar()
        {
            for (int r = 0; r < table.GetLength(0); r++)
            {
                for (int c = 0; c < table.GetLength(1); c++)
                {
                    if (table[r, c] == 'O')
                    {
                        row = r;
                        col = c;
                    }
                }
            }
        }

        private static bool IsValidPosition()
        {
            if (row < 0 || row >= table.GetLength(0))
            {
                return false;
            }
            if (col < 0 || col >= table.GetLength(1))
            {
                return false;
            }
            return true;
        }

        private static void FollowCommand(string command)
        {
            if (command == "up")
            {
                row--;
            }
            if (command == "down")
            {
                row++;
            }
            if (command == "left")
            {
                col--;
            }
            if (command == "right")
            {
                col++;
            }
        }

        private static char[,] ReadTable(int n)
        {
            var result = new char[n, n];
            for (int r = 0; r < result.GetLength(0); r++)
            {
                var line = Console.ReadLine();
                for (int c = 0; c < result.GetLength(1); c++)
                {
                    result[r, c] = line[c];
                    if (result[r,c]=='S')
                    {
                        row = r;
                        col = c;
                    }
                }
            }
            return result;
        }
    }
}
