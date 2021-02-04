using System;
using System.Collections.Generic;
using System.Text;
using _04.PizzaMake.Models;

namespace _04.PizzaMake.Core
{
   public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {
            Pizza pizza = null;
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] input = command.Split();
                    if (input[0] == "Pizza")
                    {
                        pizza = MakePizza(input);
                    }
                    if (input[0] == "Dough")
                    {
                        pizza.Dough = MakeDough(input);
                    }
                    if (input[0] == "Topping")
                    {
                        Topping topping = MakeTopping(input);
                        try
                        {
                            pizza.AddTopping(topping);
                        }
                        catch (ArgumentException ae)
                        {
                            Console.WriteLine(ae.Message);
                            return;
                        }
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                }
            }
            Console.WriteLine(pizza);
        }
            private  Pizza MakePizza(string[] input)
            {
                Pizza pizza = null;
                if (input[0] == "Pizza")
                {
                    pizza = new Pizza(input[1]);
                }
                return pizza;
            }
            private  Dough MakeDough(string[] input)
            {
                Dough dough =
                        new Dough(input[1], input[2], int.Parse(input[3]));
                return dough;
            }
            private  Topping MakeTopping(string[] input)
            {
                Topping topping =
                     new Topping(input[1], int.Parse(input[2]));

                return topping;
            }
        }
    }

