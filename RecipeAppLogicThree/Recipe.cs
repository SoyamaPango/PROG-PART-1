using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeAppLogicThree
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
            // Existing code to enter details
        }

        public void Display()
        {
            // Existing code to display details
        }

        public double CalculateTotalCalories()
        {
            totalCalories = Ingredients.Sum(ingredient => ingredient.Calories * ingredient.Quantity);
            return totalCalories;
        }

        public delegate void CaloriesExceeds(string recipeName);
        public static event CaloriesExceeds CaloriesExceedsHandler;
    }

    public class Ingredient
    {
        public string Name { get; }
        public double Quantity { get; }
        public string Unit { get; }
        public double Calories { get; }
        public string FoodGroup { get; }

        public Ingredient(string name, double quantity, string unit, double calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
        }
    }
}
