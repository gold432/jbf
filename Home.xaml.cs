using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace FitnessTracker
{
    public partial class Home : Page
    {
        private readonly FitnessTrackerModel _model;

        public Home(FitnessTrackerModel model)
        {
            InitializeComponent();
            _model = model; // Initialize the _model field
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).GoToPage(new Login(_model));
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).GoToPage(new Login(_model));
        }
    }
}