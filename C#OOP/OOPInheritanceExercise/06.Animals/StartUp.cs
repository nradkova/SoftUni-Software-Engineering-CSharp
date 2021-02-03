using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = string.Empty;
            List<Animal> puppies = new List<Animal>();
            while ((input = Console.ReadLine()) != "Beast!")
            {
                string[] tokens = Console.ReadLine().Split();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string gender = tokens[2];
                    Animal puppy = null;
                try
                {
                    if (input == "Cat")
                    {
                        puppy = new Cat(name, age, gender);
                    }
                    if (input == "Dog")
                    {
                        puppy = new Dog(name, age, gender);
                    }
                    if (input == "Frog")
                    {
                        puppy = new Frog(name, age, gender);
                    }
                    if (input == "Kitten")
                    {
                        puppy = new Kitten(name, age);
                    }
                    if (input == "Tomcat")
                    {
                        puppy = new Tomcat(name, age);
                    }
                }
                catch (ArgumentException e)
                {

                    Console.WriteLine(e.Message);
                }
                if (puppy!=null)
                {
                puppies.Add(puppy);
                }
            }
            foreach (var puppy in puppies)
            {
                Console.WriteLine(puppy.ToString());
            }
        }
    }
}
