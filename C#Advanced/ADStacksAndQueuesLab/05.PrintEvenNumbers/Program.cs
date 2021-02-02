using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().
              Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>();
            foreach (var number in numbers)
            {
                queue.Enqueue(number);
            }
            StringBuilder output = new StringBuilder();
            while (queue.Count > 0)
            {
                if (queue.Peek() % 2 == 0)
                {
                    output.Append(queue.Dequeue());
                    output.Append(", ");
                }
                else
                {
                    queue.Dequeue();
                }
            }
            Console.WriteLine(output.ToString().TrimEnd(new char[] { ',', ' ' }));
        }
    }
}
