using System;

namespace _02._240219
{
    public class Position
    {
        public char Name { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
    }
    class Program
    {
        private static char[,] matrix;
        private static Position first;
        private static Position second;
        static void Main(string[] args)
        {
            int n =int.Parse(Console.ReadLine());
            first = new Position();
            second = new Position();
            matrix = ReadMatrix(n);
            while (true)
            {
                var input = Console.ReadLine().Split();
                var firstCommand = input[0];
                var secondCommand = input[1];
                FollowCommand(firstCommand, first);
                FollowCommand(secondCommand, second);
                if (IsInvalidPosition(first))
                {
                    break;
                }
                if (IsInvalidPosition(second))
                {
                    break;
                }
            }
            PrintMatrix();
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }

        private static bool IsInvalidPosition(Position position)
        {
            if (position.Row<0||position.Row>=matrix.GetLength(0))
            {
                return true;
            }
            if (position.Col < 0 || position.Col >= matrix.GetLength(1))
            {
                return true;
            }
            if (matrix[position.Row,position.Col]!=position.Name
                && matrix[position.Row, position.Col] != '*')
            {
                matrix[position.Row, position.Col] = 'x';
                return true;
            }
            return false;
        }

        private static void FollowCommand(string command, Position position)
        {
            matrix[position.Row, position.Col] = position.Name;
            if (command=="down")
            {
                position.Row++;
            }
            if (command=="up")
            {
                position.Row--;
            }
            if (command=="left")
            {
                position.Col--;
            }
            if (command=="right")
            {
                position.Col++;
            }
        }

        private static char[,] ReadMatrix(int n)
        {
            var table = new char[n, n];
            for (int row = 0; row < table.GetLength(0); row++)
            {
                var line =Console.ReadLine();
                for (int col = 0; col < table.GetLength(1); col++)
                {
                    table[row, col] = line[col];
                    if (line[col]=='f')
                    {
                        first.Row = row;
                        first.Col = col;
                        first.Name = 'f';
                    }
                    if (line[col] == 's')
                    {
                        second.Row = row;
                        second.Col = col;
                        second.Name = 's';
                    }
                }
            }
            return table;
        }
    }
}
