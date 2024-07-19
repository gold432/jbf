using System.Windows;
using System.Windows.Controls;

namespace FitnessTracker
{
    public partial class MetricEntry : Page
    {
        private readonly FitnessTrackerModel _model;

        public MetricEntry(FitnessTrackerModel model)
        {
            InitializeComponent();
            _model = model;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ShowSelectedPanel("Walking");
        }

        private void cmbExercise_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbExercise.SelectedItem is ComboBoxItem selectedItem)
            {
                string selectedExercise = selectedItem.Content.ToString();
                ShowSelectedPanel(selectedExercise);
            }
        }

        private void ShowSelectedPanel(string exercise)
        {
            walkingPanel.Visibility = Visibility.Collapsed;
            swimmingPanel.Visibility = Visibility.Collapsed;
            runningPanel.Visibility = Visibility.Collapsed;
            sitUpsPanel.Visibility = Visibility.Collapsed;
            jumpingJacksPanel.Visibility = Visibility.Collapsed;
            pressUpsPanel.Visibility = Visibility.Collapsed;

            switch (exercise)
            {
                case "Walking":
                    walkingPanel.Visibility = Visibility.Visible;
                    break;
                case "Swimming":
                    swimmingPanel.Visibility = Visibility.Visible;
                    break;
                case "Running":
                    runningPanel.Visibility = Visibility.Visible;
                    break;
                case "Sit-Ups":
                    sitUpsPanel.Visibility = Visibility.Visible;
                    break;
                case "Jumping-Jacks":
                    jumpingJacksPanel.Visibility = Visibility.Visible;
                    break;
                case "Press-Ups":
                    pressUpsPanel.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).GoToPage(new ProgressPage(_model));
        }
    }
}