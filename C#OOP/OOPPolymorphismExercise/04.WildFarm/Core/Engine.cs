using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WildFarm.Core.Contracts;
using WildFarm.Factories;
using WildFarm.Models.Animals;
using WildFarm.Models.Foods;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly ICollection<Animal> animals;
        private readonly FoodFactory foodFactory;
        private readonly AnimalFactory animalFactory;

        public  Engine()
        {
            animals = new List<Animal>();
            foodFactory = new FoodFactory();
            animalFactory = new AnimalFactory();
        }
        public void Run()
        {
            string command = string.Empty;
            while ((command=Console.ReadLine())!="End")
            {
                string[] animalArgs = command.Split();
                string animalType = animalArgs[0];
               
                Animal animal = null;
                try
                {
                    animal = animalFactory
                        .CreateAnimal(animalType, animalArgs.Skip(1).ToArray());
                    animals.Add(animal);
                    Console.WriteLine(animal.ProduceSound());
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

                string[] foodArgs = Console.ReadLine().Split();
                string foodType = foodArgs[0];
                int foodQty = int.Parse(foodArgs[1]);

               Food food = null;
                try
                {
                    food = foodFactory
                        .CreateFood(foodType, foodQty);
                    animal?.Feed(food);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }

        }
    }
}
