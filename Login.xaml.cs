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
                if (_model.Login(usernameTextBox.Text, passwordBox.Password))
                {
                    if (passwordBox.Password.Length < 12)
                    {
                        MessageBox.Show("Password is less than 12 characters.");
                        return;
                    }
                    bool hasLowercase = passwordBox.Password.Any(c => char.IsLower(c));
                    bool hasUppercase = passwordBox.Password.Any(c => char.IsUpper(c));

                    if (!hasLowercase)
                    {
                        MessageBox.Show("The password does not have a lower-case character.");
                        return;
                    }
                    if (!hasUppercase)
                    {
                        MessageBox.Show("The password does not have an upper-case character.");
                        return;
                    }

                    var mainWindow = Application.Current.MainWindow as MainWindow;
                    if (mainWindow == null)
                    {
                        MessageBox.Show("Unable to navigate. Invalid application state.");
                        return;
                    }

                    mainWindow.GoToPage(new GoalSettingPage(_model));
                }
                else
                {
                    MessageBox.Show("Invalid username or password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                Debug.WriteLine($"Exception details: {ex}");
            }
        }
    }
}