using System.Collections.Generic;

namespace RecipeWPF
{
    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public string FoodGroup { get; set; }
        public int Calories { get; set; }

        public Recipe()
        {
            Ingredients = new List<Ingredient>();
        }
    }
}
