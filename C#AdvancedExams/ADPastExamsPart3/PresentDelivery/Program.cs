using System;

namespace PresentDelivery
{
    public class Position
    {
        public int Row { get; set; }
        public int Col { get; set; }
    }
    class Program
    {
        private static string[,] matrix;
        private static Position position;
        private static int niceKids;
        private static int kidsLeft;
        private static int presents;

        static void Main(string[] args)
        {
            presents =int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            matrix = new string[n, n];
            position = new Position();
            niceKids = 0;
            ReadMatrix();
            kidsLeft = niceKids;
            bool areOver = false;
            
            while (true)
            {
                if (presents==0)
                {
                    areOver = true;
                    break;
                }
                var command = Console.ReadLine();
                if (command == "Christmas morning")
                {
                    break;
                }
                matrix[position.Row, position.Col] = "-";
                FollowCommand(command);
                int initialRow = position.Row;
                int initialCol = position.Col;
                if (IsInvalidPosition())
                {
                    continue;
                }
                if (matrix[position.Row, position.Col] == "V")
                {
                    kidsLeft--;
                    presents--;
                }
                if (matrix[position.Row, position.Col] == "C")
                {
                    DropPresent(position.Row - 1, position.Col);
                    position.Row = initialRow;
                   
                    DropPresent(position.Row + 1, position.Col);
                    position.Row = initialRow;
                   
                    DropPresent(position.Row, position.Col-1);
                    position.Col = initialCol;

                    DropPresent(position.Row, position.Col+1);
                    position.Col = initialCol;
                }
                matrix[position.Row, position.Col] = "S";
            }
            if (areOver)
            {
                Console.WriteLine("Santa ran out of presents!");
            }
            PrintMatrix();
            if (kidsLeft==0)
            {
                Console.WriteLine($"Good job, Santa! " +
                    $"{niceKids} happy nice kid / s.");
            }
            else
            {
                Console.WriteLine($"No presents for " +
                    $"{kidsLeft} nice kid/ s.");
            }
        }

        private static void DropPresent(int row, int col)
        {
            if (presents>0&&kidsLeft>0)
            {
                if (matrix[row,col]=="V")
                {
                    presents--;
                    kidsLeft--;
                }
                if (matrix[row, col] == "X")
                {
                    presents--;
                }
            }
            matrix[row,col] = "-";
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]+" ");
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
                var line = Console.ReadLine().Split();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                    if (line[col] == "S")
                    {
                        position.Row = row;
                        position.Col = col;
                    }
                    if (line[col] == "V")
                    {
                        niceKids++;
                    }
                }
            }
        }
    }
}
