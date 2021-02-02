using System;
using System.Linq;
using System.Numerics;

namespace _04.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split()
                    .Select(int.Parse).ToArray();
            string[,] matrix = ReadMatrix(dimensions[0], dimensions[1]);
            string command = string.Empty;
            bool isValid = false;
            int x1 = 0;
            int y1 = 0;
            int x2 = 0;
            int y2 = 0;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split();

                if (tokens.Length == 5 && tokens[0] == "swap")
                {
                     x1 = int.Parse(tokens[1]);
                     y1 = int.Parse(tokens[2]);
                     x2 = int.Parse(tokens[3]);
                     y2 = int.Parse(tokens[4]);
                    if (x1 < dimensions[0] && x1 >= 0
                        && x2 < dimensions[0] && x1 >= 0
                        && y1 < dimensions[1] && y1 >= 0
                        && y2 < dimensions[1] && y2 >= 0)
                    {
                        isValid = true;
                    }
                }
               
                if (!isValid)
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    string temp = matrix[x1, y1];
                    matrix[x1, y1] = matrix[x2, y2];
                    matrix[x2, y2] = temp;
                    PrintMatrix(matrix);
                    isValid = false;
                }
            }
        }
        public static string[,] ReadMatrix(int x, int y)
        {
            string[,] matrix = new string[x, y];
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
