using System;
using System.Collections.Generic;
using System.Threading;

namespace _07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<Pump> pumps = new Queue<Pump>();
            int remainder = 0;

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                Pump pump = new Pump(i, int.Parse(input[0])
                    , int.Parse(input[1]));
                pumps.Enqueue(pump);
            }
            Queue<Pump> temp = new Queue<Pump>();

            while (pumps.Count > 0)
            {
                Pump currentPump = pumps.Dequeue();
                if (currentPump.Fuel + remainder < currentPump.Distance)
                {
                    while (temp.Count > 0)
                    {
                        pumps.Enqueue(temp.Dequeue());
                    }
                    pumps.Enqueue(currentPump);
                    remainder = 0;
                }
                else
                {
                    remainder = currentPump.Fuel + remainder - currentPump.Distance;
                    temp.Enqueue(currentPump);
                }
            }
            Console.WriteLine(temp.Peek().Index);
        }
        public class Pump
        {
            public int Index { get; set; }
            public int Fuel { get; set; }
            public int Distance { get; set; }
            public Pump(int index, int fuel, int distance)
            {
                this.Index = index;
                this.Fuel = fuel;
                this.Distance = distance;
            }
        }
    }
}
