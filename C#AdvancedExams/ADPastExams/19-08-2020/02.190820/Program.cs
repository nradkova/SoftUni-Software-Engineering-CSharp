using System;


namespace Bee
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
            var matrix = new char[n, n];
            var position = ReadMatrix(matrix);
            int flowersCount = 0;
            bool gotLost = false;
            while (true)
            {
                var command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }
                matrix[position.Row, position.Col] = '.';
                FollowCommand(command, position);

                if (ValidatePosition(position.Row, position.Col, matrix))
                {
                    if (matrix[position.Row, position.Col] == 'O')
                    {
                        matrix[position.Row, position.Col] = '.';
                        FollowCommand(command, position);
                        if (!ValidatePosition(position.Row, position.Col, matrix))
                        {
                            gotLost = true;
                        }
                    }
                    if (matrix[position.Row, position.Col] == 'f')
                    {
                        flowersCount++;
                    }
                }
                if (!ValidatePosition(position.Row, position.Col, matrix)
                    || gotLost == true)
                {
                    gotLost = true;
                    break;
                }
                matrix[position.Row, position.Col] = 'B';
            }

            if (gotLost)
            {
                Console.WriteLine("The bee got lost!");
            }
            if (flowersCount < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers," +
                    $" she needed {5 - flowersCount} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate " +
                    $"{flowersCount} flowers!");
            }
            Print(matrix);

        }

        private static void Print(char[,] matrix)
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

        private static void FollowCommand(string command, Position position)
        {

            if (command == "up")
            {
                position.Row--;
            }
            if (command == "down")
            {
                position.Row++;
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

        private static bool ValidatePosition(int row, int col,
            char[,] matrix)
        {
            if (row < 0 || row >= matrix.GetLength(0))
            {
                return false;
            }
            if (col < 0 || col >= matrix.GetLength(1))
            {
                return false;
            }
            return true;
        }

        private static Position ReadMatrix(char[,] matrix)
        {
            var position = new Position();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var line = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                    if (matrix[row, col] == 'B')
                    {
                        position.Row = row;
                        position.Col = col;
                    }
                }
            }
            return position;
        }
    }
}
