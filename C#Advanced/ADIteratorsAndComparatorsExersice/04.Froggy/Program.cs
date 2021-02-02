using System;
using System.Linq;

namespace _04.Froggy
{
   public class Program
    {
        static void Main(string[] args)
        {
            int[] stones = Console.ReadLine().Split(", ")
                .Select(int.Parse).ToArray();
            Lake lakeStones = new Lake(stones);
            Console.WriteLine(string.Join(", ", lakeStones));
        }
    }
}
