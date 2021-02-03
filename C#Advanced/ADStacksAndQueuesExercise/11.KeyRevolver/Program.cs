using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int reward = int.Parse(Console.ReadLine());
            int bulletsCounter = 0;
            int bulletsLoaded = barrelSize;

            while (locks.Count > 0 && bullets.Count > 0)
            {
                int usedBullet = bullets.Pop();
                bulletsCounter++;
                bulletsLoaded--;
                if (usedBullet <= locks.Peek())
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else 
                {
                    Console.WriteLine("Ping!");
                }
                if (bulletsLoaded == 0 && bullets.Count >0)
                {
                    Console.WriteLine("Reloading!");
                     bulletsLoaded = barrelSize;
                }
            }
            if (locks.Count == 0)
            {
                Console.WriteLine($"{bullets.Count}" +
                    $" bullets left. Earned ${ reward - bulletsCounter * bulletPrice}");
            }
            else 
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
