using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        private ICollection<Ingredient> ingredients;

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            ingredients = new List<Ingredient>();
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public ICollection<Ingredient> Ingredients
            => ingredients;
        public int CurrentAlcoholLevel => ingredients.Sum(x => x.Alcohol);

        public void Add(Ingredient ingredient)
        {
            if (!ingredients.Any(x => x.Name == ingredient.Name))
            {
                if (ingredients.Count<Capacity
                    && CurrentAlcoholLevel + ingredient.Alcohol<=MaxAlcoholLevel)
                {
                    ingredients.Add(ingredient);
                }
            }
        }
        public bool Remove(string name)
        {
            Ingredient ingredient = ingredients
                .FirstOrDefault(x => x.Name == name);
            if (ingredient==null)
            {
                return false;
            }
            else
            {
                ingredients.Remove(ingredient);
                return true;
            }
        }

        public Ingredient FindIngredient(string name)
        {
            Ingredient ingredient = ingredients
                .FirstOrDefault(x => x.Name == name);

            return ingredient;
        }
        public Ingredient GetMostAlcoholicIngredient()
        {
            if (ingredients.Count>0)
            {
                Ingredient ingredient = ingredients
                .OrderByDescending(x => x.Alcohol).First();
                return ingredient;
            }
            return null;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {Name} - " +
                $"Current Alcohol Level: {CurrentAlcoholLevel}");
            foreach (var ingredient in ingredients)
            {
                sb.AppendLine(ingredient.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
