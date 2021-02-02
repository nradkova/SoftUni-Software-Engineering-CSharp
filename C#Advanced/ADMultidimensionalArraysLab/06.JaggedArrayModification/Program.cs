using System;
using System.Linq;

namespace _06.JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int element = int.Parse(Console.ReadLine());
            int[,] matrix = new int[element, element];
            int row = 0;
            int col = 0;
            for (row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine().Split()
                    .Select(int.Parse).ToArray();
                for (col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] tokens = command.Split();
                int rowIndex = int.Parse(tokens[1]);
                int colIndex = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);
                if (tokens[0] == "Add")
                {
                    if (rowIndex < element && colIndex < element
                       && rowIndex >=0 && colIndex >=0)
                    {
                        matrix[rowIndex, colIndex] += value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
                else if (tokens[0] == "Subtract")
                {
                    if (rowIndex < element && colIndex < element
                         && rowIndex >= 0 && colIndex >= 0)
                    {
                        matrix[rowIndex, colIndex] -= value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
                command = Console.ReadLine();
            }
            for (row = 0; row < matrix.GetLength(0); row++)
            {
                for (col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
