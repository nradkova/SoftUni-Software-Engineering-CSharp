using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Christmas
{
    public class Bag
    {
        private List<Present> data;

        public Bag(string color, int capacity)
        {
            data = new List<Present>();
            Color = color;
            Capacity = capacity;
        }

        public string  Color { get; set; }
        public int Capacity { get; set; }

        public int Count => data.Count;
        public void Add(Present present)
        {
            if (Capacity>data.Count)
            {
                data.Add(present);
            }
        }
        public bool Remove(string name)
        {
            var present = data.FirstOrDefault(x => x.Name == name);
            return data.Remove(present);
        }
        public Present GetHeaviestPresent()
        {
            return data.OrderByDescending(x => x.Weight).First();
        }
        public Present GetPresent(string name)
        {
            return data.FirstOrDefault(x => x.Name==name);
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Color} bag contains:");
            foreach (var present in data)
            {
                sb.AppendLine(present.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
