using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;

namespace FitnessTracker
{
    public partial class Register : Page
    {
        private readonly FitnessTrackerModel _model;

        public Register(FitnessTrackerModel model)
        {
            InitializeComponent();
            _model = model;
            // _model = model ?? throw new ArgumentNullException(nameof(model));
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _model.Register(usernameTextBox.Text, passwordBox.Password, _model);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                Debug.WriteLine($"Exception details: {ex}");
            }
        }
    }
}