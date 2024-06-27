using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeAppLogicTwo
{
    public class Recipe
    {
        public string Name { get; }
        public List<Ingredient> Ingredients { get; private set; }
        public List<string> Steps { get; private set; }
        private double totalCalories;

        public Recipe(string name)
        {
            Name = name;
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();
            totalCalories = 0;
        }

        public void EnterDetails()
        {
            // Implementation to enter details
        }

        public void Display()
        {
            // Implementation to display details
        }

        public double CalculateTotalCalories()
        {
            totalCalories = Ingredients.Sum(ingredient => ingredient.Calories * ingredient.Quantity);
            return totalCalories;
        }

        public delegate void CaloriesExceeds(string recipeName);
        public static event CaloriesExceeds CaloriesExceedsHandler;
    }
}
