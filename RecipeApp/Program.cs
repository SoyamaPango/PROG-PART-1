using System;
using System.Collections.Generic;

namespace RecipeApp
{
    class Program
    {
        static List<Recipe> recipes = new List<Recipe>(); // List to store recipes

        static void Main(string[] args)
        {
            Recipe.CaloriesExceedsHandler += NotifyCaloriesExceeds;

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nRecipe App Menu:");
                Console.WriteLine("1. Enter Recipe Details");
                Console.WriteLine("2. Display Recipe List");
                Console.WriteLine("3. Display Recipe by Name");
                Console.WriteLine("4. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        EnterRecipeDetails();
                        break;
                    case 2:
                        DisplayRecipeList();
                        break;
                    case 3:
                        DisplayRecipeByName();
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        // Method to enter recipe details
        static void EnterRecipeDetails()
        {
            Console.Write("Enter recipe name: ");
            string name = Console.ReadLine();
            Recipe recipe = new Recipe(name);
            recipe.EnterDetails();
            recipes.Add(recipe);

        }


        // Method to display recipe list
        static void DisplayRecipeList()
        {
            Console.WriteLine("\nRecipe List:");
            foreach (Recipe recipe in recipes.OrderBy(r => r.Name))
            {
                Console.WriteLine(recipe.Name);
            }
        }

        // Method to display recipe by name
        static void DisplayRecipeByName()
        {
            Console.Write("Enter recipe name: ");
            string name = Console.ReadLine();
            Recipe recipe = recipes.Find(r => r.Name == name);
            if (recipe != null)
            {
                recipe.Display();
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }
        // Method to handle exceeding calories
        static void NotifyCaloriesExceeds(string recipeName)
        {
            Console.WriteLine($"WARNING: The total calories for {recipeName} exceed 300!");
        }
    }
}

