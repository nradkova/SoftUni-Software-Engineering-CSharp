using System;
using System.Data;
using System.Linq;

namespace _06.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[][] matrix = new double[n][];
            for (int row = 0; row < n; row++)
            {
                double[] data = Console.ReadLine().
                    Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse).ToArray();
                matrix[row] = new double[data.Length];
                for (int col = 0; col < data.Length; col++)
                {
                    matrix[row][col] = data[col];
                }
            }
            for (int row = 0; row < n - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] *= 2;
                        matrix[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] /= 2;
                    }
                    for (int col = 0; col < matrix[row + 1].Length; col++)
                    {
                        matrix[row + 1][col] /= 2;
                    }
                }
            }
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);
                if (row <n && row >= 0
                    && col < matrix[row].Length && col >= 0)
                {
                    if (tokens[0] == "Add")
                    {
                        matrix[row][col] += value;
                    }
                    if (tokens[0] == "Subtract")
                    {
                        matrix[row][col] -= value;
                    }
                }
            }
            PrintMatrix(matrix);
        }
        public static void PrintMatrix(double[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
