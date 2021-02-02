using System;

namespace _02._190820
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = ReadMatrix(n);
            int beeRow = 0;
            int beeCol = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }
            string command = string.Empty;
            int flowersCount = 0;
            int nextRow = 0;
            int nextCol = 0;
            bool GotLost = false;

            while ((command = Console.ReadLine()) != "End"
                && GotLost == false)
            {
                matrix[beeRow, beeCol] = '.';
                if (command == "right")
                {
                    beeCol++;
                    nextRow = beeRow;
                    nextCol = beeCol + 1;
                }
                else if (command == "left")
                {
                    beeCol--;
                    nextRow = beeRow;
                    nextCol = beeCol - 1;
                }
                else if (command == "up")
                {
                    beeRow--;
                    nextRow = beeRow - 1;
                    nextCol = beeCol;
                }
                else if (command == "down")
                {
                    beeRow++;
                    nextRow = beeRow + 1;
                    nextCol = beeCol;
                }

                if (!ContinueGame(beeRow, beeCol, n))
                {
                    GotLost = true;
                }
                else
                {
                    if (matrix[beeRow, beeCol] == 'f')
                    {
                        flowersCount++;
                        matrix[beeRow, beeCol] = 'B';
                    }
                    else if (matrix[beeRow, beeCol] == 'O')
                    {
                        matrix[beeRow, beeCol] = '.';
                        if (matrix[nextRow, nextCol] == 'f')
                        {
                            flowersCount++;
                        }
                        matrix[nextRow, nextCol] = 'B';
                        beeRow = nextRow;
                        beeCol = nextCol;
                    }
                }
            }

            if (GotLost)
            {
                Console.WriteLine("The bee got lost!");
            }
            if (flowersCount >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate" +
                    $" {flowersCount} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers," +
                    $" she needed {5 - flowersCount} flowers more");
            }
            Print(matrix);
        }

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

        static bool ContinueGame(int row, int col, int n)
        {
            if (row >= 0 && row < n
                && col >= 0 && col < n)
            {
                return true;
            }
            return false;
        }
    }
}
