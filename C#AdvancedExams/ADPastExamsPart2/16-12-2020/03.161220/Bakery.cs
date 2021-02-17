using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
   public  class Bakery
    {
        private List<Employee> data;
        public Bakery(string name,int capacity)
        {
            data = new List<Employee>();
            Name = name;
            Capacity = capacity;
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;
        public void Add(Employee employee)
        {
            if (data.Count<Capacity)
            {
                data.Add(employee);
            }
        }
        public bool Remove(string name)
        {
            var employee = data.FirstOrDefault(x => x.Name == name);
            return data.Remove(employee);
        }
        public Employee GetOldestEmployee()
        {
            return data.OrderByDescending(x => x.Age).First();
        }
        public Employee GetEmployee(string name)
        {
            return data.FirstOrDefault(x => x.Name == name);
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {Name}:");
            foreach (var employee in data)
            {
                sb.AppendLine(employee.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
