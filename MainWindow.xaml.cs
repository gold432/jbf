using System.Windows;
using System.Windows.Controls;

namespace FitnessTracker
{
    public partial class MainWindow : Window
    {
        private readonly FitnessTrackerModel _model;

        public MainWindow()
        {
            InitializeComponent();
            _model = new FitnessTrackerModel();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
                mainFrame.Navigate(new Login(_model));
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Login(_model));

        }
    }

}