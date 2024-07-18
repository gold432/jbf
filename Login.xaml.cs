using System.Windows;
using System.Windows.Controls;

namespace FitnessTracker
{
    public partial class Login : Page
    {
        private readonly FitnessTrackerModel _model;

        public Login(FitnessTrackerModel model)
        {
            InitializeComponent();
            _model = model;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (_model.Login(usernameTextBox.Text, passwordBox.Password))
            {
                if (passwordBox.Password.Length < 12)
                {
                    MessageBox.Show("password is less than 12 characters.");
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
                mainFrame.Navigate(new GoalSettingPage(_model));
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }
    }
}