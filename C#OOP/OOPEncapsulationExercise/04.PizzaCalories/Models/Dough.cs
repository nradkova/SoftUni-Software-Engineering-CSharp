using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using _04.PizzaMake.Common;

namespace _04.PizzaMake.Models
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnigue;
        private double defaultModifier=2;
        private int weight;
        public Dough(string flourType, string bakingTechnigue, int weight)
        {
            FlourType = flourType;
            BakingTechnigue = bakingTechnigue;
            Weight = weight;
        }

        public string FlourType
        {
            get { return flourType; }
            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException(Constants.INVALID_DOUGH_TYPE_MSG);
                }
                flourType = value;
            }
        }
        public string BakingTechnigue
        {
            get { return bakingTechnigue; }
            private set
            {
                if (value.ToLower() != "crispy"
                    && value.ToLower() != "chewy"
                    && value.ToLower() != "homemade")
                {
                    throw new ArgumentException(Constants.INVALID_DOUGH_TYPE_MSG);
                }
                bakingTechnigue = value;
            }
        }

        public int Weight
        {
            get { return weight; }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(Constants.INVALID_DOUGH_WEIGHT_MSG);
                }
                weight = value;
            }
        }
        public double CalculateCalories()
        {
            double flourModifier = 0;
            double bakingModifier = 0;

            switch (FlourType.ToLower() )
            {
                case "white":flourModifier = 1.5;
                    break;
                case "wholegrain":flourModifier = 1;
                    break;
            }
            switch (BakingTechnigue.ToLower())
            {
                case "crispy":
                    bakingModifier = 0.9;
                    break;
                case "chewy":
                    bakingModifier = 1.1;
                    break;
                case "homemade":
                    bakingModifier = 1;
                    break;
            }
            return Weight * defaultModifier * flourModifier * bakingModifier;
        }
    }
}
