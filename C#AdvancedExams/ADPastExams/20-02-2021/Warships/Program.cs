using System;
using System.Linq;

namespace Warships
{
    class Program
    {
        private static int playerShips = 0;
        private static int enemyShips = 0;
        private static string[,] table;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] command = Console.ReadLine()
                .Split(",");
            table = ReadTable(n);

            int playerInitialShips = playerShips;
            int enemyInitialShips = enemyShips;
            bool playerWin = false;
            bool enemyWin = false;

            for (int i = 1; i <= command.Length; i++)
            {
                int[] commandArgs = command[i - 1]
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int currentRow = commandArgs[0];
                int currentCol = commandArgs[1];
                if (!AreValid(currentRow, currentCol))
                {
                    continue;
                }

                if (i % 2 != 0)
                {
                    PlayerAttacks(currentRow,currentCol);
                    if (enemyShips==0)
                    {
                        playerWin = true;
                        break;
                    }
                }
                else
                {
                    EnemyAttacks(currentRow, currentCol);
                    if (playerShips == 0)
                    {
                        enemyWin = true;
                        break;
                    }
                }

                if (playerWin)
                {
                    break;
                }
                if (enemyWin)
                {
                    break;
                }
            }

            int allSunkShips = playerInitialShips
                + enemyInitialShips
                - playerShips
                - enemyShips;
            if (playerWin)
            {
                Console.WriteLine($"Player One has won the game!" +
                    $" {allSunkShips} " +
                    $"ships have been sunk in the battle.");
            }
            else if (enemyWin)
            {
                Console.WriteLine($"Player Two has won the game!" +
                    $" {allSunkShips} " +
                    $"ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! " +
                    $"Player One has {playerShips} ships left." +
                    $" Player Two has {enemyShips} ships left.");
            }
        }

        private static void EnemyAttacks(int row, int col)
        {
            if (table[row, col] == "<")
            {
                table[row, col] = "X";
                playerShips--;
            }
            if (table[row, col] == "#")
            {
                DestroyMine(row, col);
            }
        }

        private static void PlayerAttacks(int row, int col)
        {
            if (table[row,col]==">")
            {
                table[row, col] = "X";
                enemyShips--;
            }
            if (table[row,col]=="#")
            {
                DestroyMine(row, col);
            }
        }

        private static void DestroyMine(int row, int col)
        {
            if (AreValid(row-1,col-1))
            {
                DestroyShips(row - 1, col - 1);
            }

            if (AreValid(row - 1, col))
            {
                DestroyShips(row - 1, col);
            }

            if (AreValid(row - 1, col + 1))
            {
                DestroyShips(row - 1, col + 1);
            }

            if (AreValid(row , col - 1))
            {
                DestroyShips(row , col - 1);
            }

            if (AreValid(row , col +1))
            {
                DestroyShips(row , col+1);
            }

            if (AreValid(row +1, col - 1))
            {
                DestroyShips(row + 1, col - 1);
            }

            if (AreValid(row +1, col))
            {
                DestroyShips(row + 1, col);
            }

            if (AreValid(row + 1, col + 1))
            {
                DestroyShips(row + 1, col + 1);
            }
        }

        private static void DestroyShips(int row, int col)
        {
            if (table[row,col]=="<")
            {
                table[row, col] = "X";
                playerShips--;
            }
            if (table[row, col] == ">")
            {
                table[row, col] = "X";
                enemyShips--;
            }
        }

        private static bool AreValid(int row, int col)
        {
            if (row < 0 || row >= table.GetLength(0))
            {
                return false;
            }
            if (col < 0 || col >= table.GetLength(1))
            {
                return false;
            }
            return true;
        }

        private static string[,] ReadTable(int n)
        {
            string[,] result = new string[n, n];
            for (int row = 0; row < n; row++)
            {
                string[] lineArgs = Console.ReadLine()
                    .Split();
                for (int col = 0; col < n; col++)
                {
                    result[row, col] = lineArgs[col];
                    if (result[row, col] == "<")
                    {
                        playerShips++;
                    }
                    if (result[row, col] == ">")
                    {
                        enemyShips++;
                    }
                }
            }
            return result;
        }
    }
}
