using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using WildFarm.Models.Animals;
using WildFarm.Models.Animals.Birds;
using WildFarm.Models.Animals.Mammals;
using WildFarm.Models.Animals.Mammals.Felines;

namespace WildFarm.Factories
{
   public  class AnimalFactory
    {
        public Animal CreateAnimal(string strType,string [] animalArgs)
        {
            string name = animalArgs[0];
            double weight = double.Parse(animalArgs[1]);
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetTypes()
                .FirstOrDefault(x => x.Name == strType);
            if (type==null)
            {
                throw new InvalidOperationException
                    (Common.ExceptionMessages.InvalidType);
            }
            Animal animal=null;
            if (strType=="Hen")
            {
                double wingSize= double.Parse(animalArgs[2]);
                animal = new Hen(name, weight, wingSize);
            }
            if (strType == "Owl")
            {
                double wingSize = double.Parse(animalArgs[2]);
                 animal = new Owl(name, weight, wingSize);
            }
            if (strType == "Mouse")
            {
                string  livingRegion = animalArgs[2];
                 animal = new Mouse(name, weight, livingRegion);
            }
            if (strType == "Dog")
            {
                string livingRegion = animalArgs[2];
                 animal = new Dog(name, weight, livingRegion);
            }
            if (strType == "Cat")
            {
                string livingRegion = animalArgs[2];
                string breed = animalArgs[3];
                 animal = new Cat(name, weight,livingRegion, breed);
            }
            if (strType == "Tiger")
            {
                string livingRegion = animalArgs[2];
                string breed = animalArgs[3];
                 animal = new Tiger(name, weight, livingRegion, breed);
            }
                return animal;
        }
    }
}
