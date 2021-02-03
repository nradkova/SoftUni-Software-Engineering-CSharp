using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split()
                 .Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(Console.ReadLine().Split()
                 .Select(int.Parse).ToArray());
            int inputS = input[1];
            while (queue.Count>0&&inputS>0)
            {
                queue.Dequeue();
                inputS--;
            }
            int inputX = input[2];
            foreach (var num in queue)
            {
                if (num==inputX)
                {
                    Console.WriteLine("true");
                    return;
                }
            }
            if (queue.Count>0)
            {
                Console.WriteLine(queue.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
