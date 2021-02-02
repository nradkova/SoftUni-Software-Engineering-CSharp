using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> playList = new Queue<string>(Console.ReadLine()
                .Split(", ").ToArray());
            while (playList.Count > 0)
            {
                string input = Console.ReadLine();
                if (input == "Play")
                {
                    playList.Dequeue();
                }
                else if (input.Contains("Add"))
                {
                    input = input.Remove(0, 4);
                    if (!playList.Contains(input))
                    {
                        playList.Enqueue(input);
                    }
                    else
                    {
                        Console.WriteLine($"{input} is already contained!");
                    }
                }
                else if (input == "Show")
                {
                    Console.WriteLine(string.Join(", ", playList));
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
