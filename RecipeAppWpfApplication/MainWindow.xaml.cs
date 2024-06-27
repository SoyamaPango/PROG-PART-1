using System.Collections.Generic;
using System.Linq;
using System.Windows;
using RecipeAppLogicThree;

namespace RecipeAppWpfApplication
{
    public partial class MainWindow : Window
    {
        private List<Recipe> recipes;

        public MainWindow()
        {
            InitializeComponent();
            LoadRecipes();
        }

        private void LoadRecipes()
        {
            recipes = new List<Recipe>
            {
                new Recipe("Recipe1"),
                new Recipe("Recipe2"),
                // Add more recipes or load from a data source
            };
        }

        private void FilterRecipes_Click(object sender, RoutedEventArgs e)
        {
            string ingredientName = IngredientTextBox.Text.ToLower();
            var filteredRecipes = recipes.Where(r => r.Ingredients.Any(i => i.Name.ToLower().Contains(ingredientName))).ToList();
            RecipeListBox.ItemsSource = filteredRecipes.Select(r => r.Name).ToList();
        }

        private void RecipeListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (RecipeListBox.SelectedItem != null)
            {
                string selectedRecipeName = RecipeListBox.SelectedItem.ToString();
                Recipe selectedRecipe = recipes.FirstOrDefault(r => r.Name == selectedRecipeName);
                if (selectedRecipe != null)
                {
                    DisplayRecipeDetails(selectedRecipe);
                }
            }
        }

        private void DisplayRecipeDetails(Recipe recipe)
        {
            RecipeDetailsTextBlock.Text = $"Recipe: {recipe.Name}\n" +
                                          $"Total Calories: {recipe.CalculateTotalCalories()}\n" +
                                          $"Ingredients:\n" +
                                          $"{string.Join("\n", recipe.Ingredients.Select(i => $"{i.Name}: {i.Quantity} {i.Unit}, Calories: {i.Calories}, Food Group: {i.FoodGroup}"))}\n" +
                                          $"Steps:\n" +
                                          $"{string.Join("\n", recipe.Steps)}";
        }
    }
}
