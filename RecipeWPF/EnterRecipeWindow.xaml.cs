using System.Collections.Generic;
using System.Windows;

namespace RecipeWPF
{
    public partial class EnterRecipeWindow : Window
    {
        public string RecipeName { get; private set; }
        public List<Ingredient> EnteredIngredients { get; private set; }
        public List<string> EnteredSteps { get; private set; }
        public string FoodGroup {  get; private set; }
        public int Calories { get; private set; }

        public EnterRecipeWindow()
        {
            InitializeComponent();
            EnteredIngredients = new List<Ingredient>();
            EnteredSteps = new List<string>();
        }

        public Recipe GetEnteredRecipe()
        {
            Recipe newRecipe = new Recipe
            {
                Name = RecipeName,
                Ingredients = EnteredIngredients,
            };

            return newRecipe;
        }

        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            var ingredientDialog = new EnterIngredientWindow();
            if (ingredientDialog.ShowDialog() == true)
            {
                EnteredIngredients.Add(ingredientDialog.NewIngredient);
                RefreshIngredientsListView();
            }
        }


        private void AddStep_Click(object sender, RoutedEventArgs e)
        {
            var stepDialog = new EnterStepWindow();
            if (stepDialog.ShowDialog() == true)
            {
                EnteredSteps.Add(stepDialog.NewStep);
                RefreshStepsListBox();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            RecipeName = RecipeNameTextBox.Text.Trim();
            DialogResult = true;
            Close();
        }

        private void RefreshIngredientsListView()
        {
            // Refresh the ListView with updated ingredients list
            IngredientsListView.ItemsSource = null;
            IngredientsListView.ItemsSource = EnteredIngredients;
        }

        private void RefreshStepsListBox()
        {
            // Refresh the ListBox with updated steps list
            StepsListBox.ItemsSource = null;
            StepsListBox.ItemsSource = EnteredSteps;
        }
    }
}
