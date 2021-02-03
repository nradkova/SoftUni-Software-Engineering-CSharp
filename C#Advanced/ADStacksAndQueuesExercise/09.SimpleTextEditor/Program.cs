using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder();
            int n = int.Parse(Console.ReadLine());
            Stack<string> stackFinished = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();
                if (command[0] == "1")
                {
                    stackFinished.Push(text.ToString());
                    text.Append( command[1]);
                }
                else if (command[0] == "2")
                {
                    stackFinished.Push(text.ToString());
                    text = text.Remove(text.Length - int.Parse(command[1]), int.Parse(command[1]));
                }
                else if (command[0] == "3")
                {
                    Console.WriteLine(text[int.Parse(command[1])-1]);
                }
                else if (command[0] == "4")
                {
                    if (stackFinished.Count>0)
                    {
                    text = new StringBuilder( stackFinished.Pop());
                    }
                }
            }
        }
    }
}
