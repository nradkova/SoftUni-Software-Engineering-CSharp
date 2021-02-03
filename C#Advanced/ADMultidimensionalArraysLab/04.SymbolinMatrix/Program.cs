using System;

namespace _04.SymbolinMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int element = int.Parse(Console.ReadLine());
            char[,] matrix = new char[element, element];
            int row = 0;
            int col = 0;
            for ( row = 0; row < matrix.GetLength(0); row++)
            {
                char[] chars = Console.ReadLine().ToCharArray();
                for ( col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = chars[col];
                }
            }
            char symbol = char.Parse(Console.ReadLine());
            bool IsFound = false;
            for (row = 0; row < matrix.GetLength(0); row++)
            {
                for (col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row,col]==symbol)
                    {
                        IsFound = true;
                        break;
                    }
                }
                if (IsFound)
                {
                    break;
                }
            }
            if (IsFound)
            {
                Console.WriteLine($"({row}, {col})");
            }
            else
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
           
        }
    }
}
