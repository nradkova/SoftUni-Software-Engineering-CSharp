using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightSetup = int.Parse(Console.ReadLine());
            int freeWindowSetup = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            int carPassed = 0;
            string input = Console.ReadLine();
            while (input != "END")
            {
                while (input != "green")
                {
                    cars.Enqueue(input);
                    input = Console.ReadLine();
                }
               int greenLight = greenLightSetup;
               int freeWindow = freeWindowSetup;

                while (cars.Count > 0 && greenLight > cars.Peek().Length)
                {
                    greenLight -= cars.Dequeue().Length;
                    carPassed++;
                }

                int timeLeft = greenLight + freeWindow;
                if (cars.Count > 0 && timeLeft > 0)
                {
                    string crashedCar = cars.Dequeue();
                    if (timeLeft >=crashedCar. Length)
                    {
                        carPassed++;
                    }
                    else
                    {
                        int crashIndex =timeLeft;
                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{crashedCar} was hit at {crashedCar[crashIndex]}.");
                        return;
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carPassed} total cars passed the crossroads.");
        }
    }
}
