using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        private List<Rabbit> data;

        public Cage(string name, int capacity)
        {
            data = new List<Rabbit>();
            Name = name;
            Capacity = capacity;
        }

        public string  Name { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;
        public void Add(Rabbit rabbit)
        {
            if (Capacity>data.Count)
            {
                data.Add(rabbit);
            }
        }
        public bool RemoveRabbit(string name)
        {
            var rabbit= data.FirstOrDefault(x => x.Name == name);

            return data.Remove(rabbit);
        }

        public void RemoveSpecies(string species)
        {
            data= data.Where(x => x.Species != species).ToList();
        }
        public Rabbit SellRabbit(string name)
        {
            var rabbit = data.FirstOrDefault(x => x.Name == name);
            rabbit.Available = false;
            return rabbit;
        }
        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            var selected = data.Where(x => x.Species == species).ToArray();
            for (int i = 0; i < selected.Length; i++)
            {
                selected[i].Available = false;
            }
            return selected;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Rabbits available at {Name}:");
            foreach (var rabbit in data)
            {
                if (rabbit.Available==true)
                {
                    sb.AppendLine(rabbit.ToString());
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
