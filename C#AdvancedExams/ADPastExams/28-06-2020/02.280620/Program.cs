using System;

namespace _02._280620
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = ReadMatrix(n);
            int snakeRow = 0;
            int snakeCol = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                }
            }
            //Print(matrix);
            int foodCount = 0;
            bool GameIsOver = false;

            while (foodCount < 10 && !GameIsOver)
            {
                matrix[snakeRow, snakeCol] = '.';
                string command = Console.ReadLine();
                if (command == "up")
                {
                    snakeRow--;
                }
                else if (command == "down")
                {
                    snakeRow++;
                }
                else if (command == "left")
                {
                    snakeCol--;
                }
                else if (command == "right")
                {
                    snakeCol++;
                }
                if (!ContinueGame(snakeRow, snakeCol, n))
                {
                    GameIsOver = true;
                    break;
                }
                if (matrix[snakeRow, snakeCol] == '*')
                {
                    matrix[snakeRow, snakeCol] = 'S';
                    foodCount++;
                }
                if (matrix[snakeRow, snakeCol] == 'B')
                {
                    matrix[snakeRow, snakeCol] = '.';
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            if (matrix[row, col] == 'B')
                            {
                                snakeRow = row;
                                snakeCol = col;
                                matrix[row, col] = 'S';
                            }
                        }
                    }
                }
            }
            if (GameIsOver == true)
            {
                Console.WriteLine("Game over!");
            }
            else
            {
                Console.WriteLine("You won! You fed the snake.");
            }
            Console.WriteLine($"Food eaten: {foodCount}");
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
