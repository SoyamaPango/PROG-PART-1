using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace RecipeWPF
{
    public partial class EnterIngredientWindow : Window, INotifyPropertyChanged
    {
        private Ingredient _newIngredient;

        public Ingredient NewIngredient
        {
            get { return _newIngredient; }
            private set
            {
                if (_newIngredient != value)
                {
                    _newIngredient = value;
                    OnPropertyChanged(nameof(NewIngredient));
                }
            }
        }

        public EnterIngredientWindow()
        {
            InitializeComponent();
            AddPlaceholderText(null, null);
            DataContext = this; 
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
            string name = IngredientNameTextBox.Text.Trim();
            string quantityText = QuantityTextBox.Text.Trim();
            string unit = UnitTextBox.Text.Trim();
            string caloriesText = IngredientCaloriesTextBox.Text.Trim();
            string foodGroup = IngredientFoodGroupTextBox.Text.Trim();

            // Validate and parse quantity
            if (!double.TryParse(quantityText, out double quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid positive quantity.");
                return;
            }

            // Validate and parse calories
            if (!double.TryParse(caloriesText, out double calories) || calories < 0)
            {
                MessageBox.Show("Please enter a valid non-negative calorie amount.");
                return;
            }

            // Validate other fields
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(unit) ||
                string.IsNullOrWhiteSpace(foodGroup))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Create the new Ingredient object
            NewIngredient = new Ingredient(name, quantity, unit, calories, foodGroup);

            // Close the dialog window
            DialogResult = true;
            Close();
        }

        // Placeholder text handling methods
        private void RemovePlaceholderText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text == GetPlaceholderText(textBox.Name))
            {
                textBox.Text = "";
            }
        }

        private void AddPlaceholderText(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IngredientNameTextBox.Text))
            {
                IngredientNameTextBox.Text = "Enter ingredient name";
            }
            if (string.IsNullOrWhiteSpace(QuantityTextBox.Text))
            {
                QuantityTextBox.Text = "Enter quantity";
            }
            if (string.IsNullOrWhiteSpace(UnitTextBox.Text))
            {
                UnitTextBox.Text = "Enter unit";
            }
            if (string.IsNullOrWhiteSpace(IngredientCaloriesTextBox.Text))
            {
                IngredientCaloriesTextBox.Text = "Enter calories";
            }
            if (string.IsNullOrWhiteSpace(IngredientFoodGroupTextBox.Text))
            {
                IngredientFoodGroupTextBox.Text = "Enter food group";
            }
        }

        private string GetPlaceholderText(string textBoxName)
        {
            switch (textBoxName)
            {
                case "IngredientNameTextBox":
                    return "Enter ingredient name";
                case "QuantityTextBox":
                    return "Enter quantity";
                case "UnitTextBox":
                    return "Enter unit";
                case "IngredientCaloriesTextBox":
                    return "Enter calories";
                case "IngredientFoodGroupTextBox":
                    return "Enter food group";
                default:
                    return "";
            }
        }

        // Implement INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
