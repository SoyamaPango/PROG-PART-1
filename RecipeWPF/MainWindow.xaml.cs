using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RecipeWPF
{
    public partial class MainWindow : Window
    {
        private List<Recipe> recipes = new List<Recipe>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DisplayRecipeList()
        {
            RecipeListBox.Items.Clear();

            foreach (var recipe in recipes.OrderBy(r => r.Name))
            {
                RecipeListBox.Items.Add(recipe.Name);
            }

            RecipeDetailsTextBlock.Text = "";
        }

        private void EnterRecipeDetails_Click(object sender, RoutedEventArgs e)
        {
            var enterRecipeWindow = new EnterRecipeWindow();
            if (enterRecipeWindow.ShowDialog() == true)
            {
                Recipe newRecipe = enterRecipeWindow.GetEnteredRecipe();
                recipes.Add(newRecipe);

                DisplayRecipeList();
            }
        }

        private void DisplayRecipeList_Click(object sender, RoutedEventArgs e)
        {
            DisplayRecipeList();
        }

        private void DisplayRecipeByName_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = RecipeListBox.SelectedItem as string;
            if (recipeName != null)
            {
                Recipe foundRecipe = recipes.FirstOrDefault(r => r.Name == recipeName);

                if (foundRecipe != null)
                {
                    RecipeDetailsTextBlock.Text = $"Name: {foundRecipe.Name}\nFood Group: {foundRecipe.FoodGroup}\nCalories: {foundRecipe.Calories}\n\nIngredients:\n";

                    foreach (var ingredient in foundRecipe.Ingredients)
                    {
                        RecipeDetailsTextBlock.Text += $"{ingredient.Name}: {ingredient.Quantity} {ingredient.Unit}\n";
                    }
                }
                else
                {
                    RecipeDetailsTextBlock.Text = "Recipe not found.";
                }
            }
            else
            {
                RecipeDetailsTextBlock.Text = "Select a recipe from the list.";
            }

        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            string ingredientName = IngredientTextBox.Text.ToLower();
            string selectedFoodGroup = (FoodGroupComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            bool caloriesParsed = int.TryParse(CaloriesTextBox.Text, out int maxCalories);

            var filteredRecipes = recipes.Where(recipe =>
                (string.IsNullOrEmpty(ingredientName) || ingredientName == "enter ingredient" || recipe.Ingredients.Any(ingredient =>
                    ingredient.Name.ToLower().Contains(ingredientName)))
                && (selectedFoodGroup == "Choose a food group" || recipe.FoodGroup == selectedFoodGroup)
                && (!caloriesParsed || recipe.Calories <= maxCalories)
            ).OrderBy(r => r.Name).ToList();

            RecipeListBox.Items.Clear();
            foreach (var recipe in filteredRecipes)
            {
                RecipeListBox.Items.Add(recipe.Name);
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text == "Enter ingredient" || textBox.Text == "Enter max calories")
            {
                textBox.Text = "";
                textBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Foreground = new SolidColorBrush(Colors.Gray);
                if (textBox == IngredientTextBox)
                {
                    textBox.Text = "Enter ingredient";
                }
                else if (textBox == CaloriesTextBox)
                {
                    textBox.Text = "Enter max calories";
                }
            }
        }
    }
}
