using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private string name;
        private string gender;
        private int age;
        public  Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");

                }
                else
                {
                    this.name = value;
                }
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input!");

                }
                else
                {
                    this.age = value;
                }
            }
        }
        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                if (value != "Male" && value != "Female")
                {
                    throw new ArgumentException("Invalid input!");

                }
                else
                {
                    this.gender = value;
                }
            }
        }

        public abstract string ProduceSound();
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}");
            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sb.Append($"{this.ProduceSound()}");
            return sb.ToString();
        }

    }
}