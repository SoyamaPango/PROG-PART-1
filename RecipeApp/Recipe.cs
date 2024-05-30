using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    // Class to represent a Recipe
    internal class Recipe
    {
        public string Name { get; }
        
        private List<Ingredient> ingredients;
        private List<string> steps;
        private double totalCalories;

        public Recipe(string name)
        {
            Name = name;
            ingredients = new List<Ingredient>();
            steps = new List<string>();
            totalCalories = 0;
        }

        // Enter details including ingredient's name, quantity, unit, calories, and food group
        public void EnterDetails()
        {
            Console.Write("Enter the number of ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine());

            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write($"Enter ingredient {i + 1} name: ");
                string name = Console.ReadLine();

                Console.Write($"Enter quantity for {name}: ");
                double quantity = double.Parse(Console.ReadLine());

                Console.Write($"Enter unit of measurement for {name}: ");
                string unit = Console.ReadLine();

                Console.Write($"Enter calories for {name}: ");
                double calories = double.Parse(Console.ReadLine());

                Console.Write($"Enter food group for {name}: ");
                string foodGroup = Console.ReadLine();

                ingredients.Add(new Ingredient(name, quantity, unit, calories, foodGroup));
            }

            Console.Write("Enter the number of steps: ");
            int numSteps = int.Parse(Console.ReadLine());

            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Enter step {i + 1}: ");
                string step = Console.ReadLine();
                steps.Add(step);
            }

            CalculateTotalCalories(); // Calculate total calories
            totalCalories = ingredients.Sum(ingredient => ingredient.Calories * ingredient.Quantity);

            NotifyIfExceedsCaloriesLimit(); // Check if calories exceed limit and notify
            Console.WriteLine("Recipe details entered successfully.");
        }

        // Display the recipe
        public void Display()
        {
            Console.WriteLine($"\nRecipe: {Name}");
            Console.WriteLine("Ingredients:");
            foreach (Ingredient ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Name}: {ingredient.Quantity} {ingredient.Unit}, Calories: {ingredient.Calories}, Food Group: {ingredient.FoodGroup}");
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
            Console.WriteLine($"Total Calories: {totalCalories}");
        }

        // Calculate total calories of the recipe
        private void CalculateTotalCalories()
        {
            totalCalories = ingredients.Sum(ingredient => ingredient.Calories * ingredient.Quantity);
        }

        // Notify if the total calories exceed 300 using delegate
        private void NotifyIfExceedsCaloriesLimit()
        {
            if (totalCalories > 300)
            {
                CaloriesExceedsHandler?.Invoke(Name);
            }
        }

        // Delegate to notify when calories exceed limit
        public delegate void CaloriesExceeds(string recipeName);
        public static event CaloriesExceeds CaloriesExceedsHandler;
    }
}

