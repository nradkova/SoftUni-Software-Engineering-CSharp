using System;

namespace _02._240219
{
    class Program
    {
        public class Position
        {
            public int Row { get; set; }
            public int Col { get; set; }

        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int firstRow = 0;
            int firstCol = 0;
            int secondRow = 0;
            int secondCol = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string rowLine = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowLine[col];
                    if (rowLine[col] == 'f')
                    {
                        firstRow = row;
                        firstCol = col;
                    }
                    if (rowLine[col] == 's')
                    {
                        secondRow = row;
                        secondCol = col;
                    }
                }
            }
            bool GameIsOver = false;
            while (!GameIsOver)
            {
                string[] command = Console.ReadLine().Split();
                string firstCommand = command[0];
                string secondCommand = command[1];

                Position firstPosition = Move(firstCommand, matrix, firstRow, firstCol, n);
                if (matrix[firstPosition.Row, firstPosition.Col] == '*')
                {
                    matrix[firstPosition.Row, firstPosition.Col] = 'f';
                    firstRow = firstPosition.Row;
                    firstCol = firstPosition.Col;
                }
                else if (matrix[firstPosition.Row, firstPosition.Col] == 's')
                {
                    matrix[firstPosition.Row, firstPosition.Col] = 'x';
                    GameIsOver = true;
                    break;
                }
                Position secondPosition = Move(secondCommand, matrix, secondRow, secondCol, n);
                if (matrix[secondPosition.Row, secondPosition.Col] == '*')
                {
                    matrix[secondPosition.Row, secondPosition.Col] = 's';
                    secondRow = secondPosition.Row;
                    secondCol = secondPosition.Col;
                }
                else if (matrix[secondPosition.Row, secondPosition.Col] == 'f')
                {
                    matrix[secondPosition.Row, secondPosition.Col] = 'x';
                    GameIsOver = true;
                    break;
                }
            }
            Print(matrix);
        }

        static Position Move(string firstCommand, char[,] matrix, int row, int col, int n)
        {
            Position position = new Position();
            if (firstCommand == "right")
            {
                col++;
                if (col >= n)
                {
                    col = 0;
                }
            }
            else if (firstCommand == "left")
            {
                col--;
                if (col < 0)
                {
                    col = n - 1;
                }
            }
            else if (firstCommand == "up")
            {
                row--;
                if (row < 0)
                {
                    row = n - 1;
                }
            }
            else if (firstCommand == "down")
            {
                row++;
                if (row >= n)
                {
                    row = 0;
                }
            }
            position.Row = row;
            position.Col = col;

            return position;
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
