using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Diagnostics;

namespace FitnessTracker
{
    public partial class MainWindow : Window
    {
        private readonly FitnessTrackerModel _model;

        public MainWindow()
        {
            InitializeComponent();
            _model = new FitnessTrackerModel();
            mainFrame.Navigate(new Home(_model));
        }
        public void GoToPage(Page page)
        {
            try
            {
                this.Content = page;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Navigation error: {ex.Message}");
                Debug.WriteLine($"Navigation exception details: {ex}");
            }
        }
    }

}