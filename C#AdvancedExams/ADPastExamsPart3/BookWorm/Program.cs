using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookWorm
{
    public class Position
    {
        public int Row { get; set; }
        public int Col { get; set; }
    }
    class Program
    {
        private static char[,] matrix;
        private static Position position;
        static void Main(string[] args)
        {
            var word = new Stack<char>(Console.ReadLine().ToCharArray());
            int n = int.Parse(Console.ReadLine());
            matrix = new char[n, n];
            position = new Position();
            ReadMatrix();
            while (true)
            {
                var command =Console.ReadLine();
                if (command=="end")
                {
                    break;
                }
                int initialRow = position.Row;
                int initialCol = position.Col;
                matrix[position.Row, position.Col] ='-';
                FollowCommand(command);
                if (IsInvalidPosition())
                {
                    if (word.Count>0)
                    {
                        word.Pop();
                    }
                    position.Row = initialRow;
                    position.Col = initialCol;
                    matrix[position.Row, position.Col] = 'P';
                    continue;
                }
                if (char.IsLetter( matrix[position.Row, position.Col]))
                {
                    word.Push(matrix[position.Row, position.Col]);
                }
                matrix[position.Row, position.Col] = 'P';
            }
            Console.WriteLine(new string(word.ToArray().Reverse().ToArray()));
            PrintMatrix();

        }
        private static void PrintMatrix()
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
        private static bool IsInvalidPosition()
        {
            if (position.Row < 0 || position.Row >= matrix.GetLength(0))
            {
                return true;
            }
            if (position.Col < 0 || position.Col >= matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }

        private static void FollowCommand(string command)
        {
            
            if (command == "down")
            {
                position.Row++;
            }
            if (command == "up")
            {
                position.Row--;
            }
            if (command == "left")
            {
                position.Col--;
            }
            if (command == "right")
            {
                position.Col++;
            }
        }

        private static void ReadMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var line = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                    if (line[col] == 'P')
                    {
                        position.Row = row;
                        position.Col = col;
                    }
                }
            }
        }
    }
}
