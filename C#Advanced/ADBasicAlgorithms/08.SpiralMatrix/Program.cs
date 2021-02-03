using System;

namespace SpiralMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            string direction = "right";
            int row = 0;
            int col = 0;
            for (int i = 0; i < n * n; i++)
            {
                if (direction == "right")
                {
                    matrix[row, col] = i + 1;
                    if (col == n-1 || matrix[row, col+1] != 0)
                    {
                        direction = "down";
                        row++;
                        col--;
                    }
                    col++;
                }
               else if (direction == "down")
                {
                    matrix[row, col] = i + 1;
                    if (row == n-1 || matrix[row+1, col] != 0)
                    {
                        direction = "left";
                        col--;
                        row--;
                    }
                    row++;
                }
               else if (direction == "left")
                {
                    matrix[row, col] = i + 1;
                    if (col==0 || matrix[row, col-1] != 0)
                    {
                        direction = "up";
                        row--;
                        col++;
                    }
                    col--;
                }
               else if (direction == "up")
                {
                    matrix[row, col] = i + 1;
                    if (row==0 || matrix[row-1, col] != 0)
                    {
                        direction = "right";
                        col++;
                        row++;
                    }
                    row--;
                }
            }
            for ( row = 0; row < matrix.GetLength(0); row++)
            {
                for ( col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row,col]<10)
                    {
                        Console.Write($" {matrix[row, col]} ");
                    }
                    else
                    {
                    Console.Write(matrix[row,col]+ " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
