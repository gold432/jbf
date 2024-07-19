using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;

namespace FitnessTracker
{
    public partial class Login : Page
    {
        private readonly FitnessTrackerModel _model;

        public Login(FitnessTrackerModel model)
        {
            InitializeComponent();
            _model = model;
            // _model = model ?? throw new ArgumentNullException(nameof(model));
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _model.Login(usernameTextBox.Text, passwordBox.Password, _model);
                // if (_model.Login(usernameTextBox.Text, passwordBox.Password))
                // {
                //     var mainWindow = Application.Current.MainWindow as MainWindow;
                //     if (mainWindow == null)
                //     {
                //         MessageBox.Show("Unable to navigate. Invalid application state.");
                //         return;
                //     }
                // }
                // else
                // {
                //     MessageBox.Show("Invalid username or password");
                // }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                Debug.WriteLine($"Exception details: {ex}");
            }
        }
    }
}