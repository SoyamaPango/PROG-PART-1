using System.Windows;

namespace RecipeWPF
{
    public partial class EnterStepWindow : Window
    {
        public string NewStep { get; private set; }

        public EnterStepWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            NewStep = StepTextBox.Text.Trim();
            DialogResult = true;
            Close();
        }
    }
}
