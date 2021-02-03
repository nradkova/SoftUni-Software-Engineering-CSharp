using System;
using System.Linq;

namespace _03.PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int element = int.Parse(Console.ReadLine());
            int[,] matrix = new int[element, element];
            long primaryDiagonal = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] numbers = Console.ReadLine().Split(" ").
                Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = numbers[col];
                    if (row==col)
                    {
                    primaryDiagonal += matrix[row, col];
                    }
                }
            }
            Console.WriteLine(primaryDiagonal);
        }
    }
}
