using System.Windows;
using System.Windows.Controls;
namespace FitnessTracker
{
    public partial class MetricEntry : Page
    {
        private readonly FitnessTrackerModel _model;
        string selectedExercise;
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
                selectedExercise = selectedItem.Content.ToString();
                ShowSelectedPanel(selectedExercise);
            }
        }

        private void ShowSelectedPanel(string e)
        {
            walkingPanel.Visibility = Visibility.Collapsed;
            swimmingPanel.Visibility = Visibility.Collapsed;
            runningPanel.Visibility = Visibility.Collapsed;
            sitUpsPanel.Visibility = Visibility.Collapsed;
            jumpingJacksPanel.Visibility = Visibility.Collapsed;
            pressUpsPanel.Visibility = Visibility.Collapsed;
            switch (e)
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
            string metric1;
            string metric2;
            string metric3;
            switch (selectedExercise)
            {
                case "Walking":
                    metric1 = walkingSteps.Text;
                    metric2 = walkingDistance.Text;
                    metric3 = walkingMinutes.Text;
                    break;
                case "Swimming":
                    metric1 = swimmingLaps.Text;
                    metric2 = swimmingMinutes.Text;
                    metric3 = swimmingAvgHR.Text;
                    break;
                case "Running":
                    metric1 = runningDistance.Text;
                    metric2 = runningSpeed.Text;
                    metric3 = runningMinutes.Text;
                    break;
                case "Sit-Ups":
                    metric1 = sitUpsTime.Text;
                    metric2 = sitUpsCount.Text; 
                    metric3 = sitUpsCount.Text; 
                    break;
                case "Jumping-Jacks":
                    metric1 = jumpingJacksCount.Text; 
                    metric2 = jumpingJacksCount.Text; 
                    metric3 = jumpingJacksCount.Text; 
                    break;
                case "Press-Ups":
                    metric1 = pressUpsCount.Text; 
                    metric2 = pressUpsCount.Text; 
                    metric3 = pressUpsCount.Text; 
                    break;
            }

            _model.RecordActivity(selectedExercise); 
            ((MainWindow)Application.Current.MainWindow).GoToPage(new ProgressPage(_model));
        }
    }
}
