using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    internal class Recipe
    {
       
            private List<Ingredient> ingredients;
            private List<string> steps;

            public Recipe()
            {
                ingredients = new List<Ingredient>();
                steps = new List<string>();
            }

        // details of the ingredients

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

                ingredients.Add(new Ingredient(name, quantity, unit));
            }

            Console.Write("Enter the number of steps: ");
            int numSteps = int.Parse(Console.ReadLine());

            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Enter step {i + 1}: ");
                string step = Console.ReadLine();
                steps.Add(step);
            }

            Console.WriteLine("Recipe details entered successfully.");
        }

        // display the ingredients
        public void Display()
                {
                Console.WriteLine("\nRecipe:");
                Console.WriteLine("Ingredients:");
                foreach (Ingredient ingredient in ingredients)
                {
                    Console.WriteLine($"{ingredient.Name}: {ingredient.Quantity} {ingredient.Unit}");
                }

                Console.WriteLine("\nSteps:");
                for (int i = 0; i < steps.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {steps[i]}");
                }
               }

        // scales the ingredients
        public void Scale()
        {
            Console.Write("Enter scale factor (0.5 for half, 2 for double, 3 for triple): ");
            double factor = double.Parse(Console.ReadLine());

            foreach (Ingredient ingredient in ingredients)
            {
                ingredient.ScaleQuantity(factor);
            }

            Console.WriteLine("Recipe scaled successfully.");
        }

            // reset quantities
        public void ResetQuantities()
        {
            foreach (Ingredient ingredient in ingredients)
            {
                ingredient.ResetQuantity();
            }

            Console.WriteLine("Quantities reset to original values.");
        }

        public void ClearData()
            {
                ingredients.Clear();
                steps.Clear();
                Console.WriteLine("All data cleared.");
            }
        }

    }



   

