using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> pets;
        public Clinic(int capacity)
        {
            Capacity = capacity;
            pets = new List<Pet>();
        }

        public int Capacity { get; set; }
        public int Count { get { return pets.Count; } }

        public void Add(Pet pet)
        {
            if (pets.Count < Capacity)
            {
                pets.Add(pet);
            }
        }
        public bool Remove(string name)
        {
            Pet petToRemove = pets.FirstOrDefault(x => x.Name == name);
            if (petToRemove != null)
            {
                pets.Remove(petToRemove);
                return true;
            }
            return false;
        }
        public Pet GetPet(string name)
        {
            Pet pet = pets.FirstOrDefault
                (x => x.Name == name);
            if (pet != null)
            {
                return pet;
            }
            return null;
        }
        public Pet GetOldestPet()
        {
            if (pets.Count > 0)
            {
                int maxAge = pets.Max(x => x.Age);
                foreach (var pet in pets)
                {
                    if (pet.Age == maxAge)
                    {
                        return pet;
                    }
                }
            }
            return null;
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The clinic has the following patients:");
            foreach (var pet in pets)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
