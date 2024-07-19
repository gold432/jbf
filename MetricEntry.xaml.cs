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
            if (cmbExercise.SelectedItem is ComboBoxItem selectedItem)
            {
                string selectedExercise = selectedItem.Content.ToString();

                TextBox m1TextBox = walkingSteps;
                TextBox m2TextBox = walkingDistance;
                TextBox m3TextBox = walkingMinutes;

                switch (selectedExercise)
                {
                    case "Walking":
                        m1TextBox = walkingSteps;
                        m2TextBox = walkingDistance;
                        m3TextBox = walkingMinutes;
                        break;
                    case "Swimming":
                        m1TextBox = swimmingLaps;
                        m2TextBox = swimmingMinutes;
                        m3TextBox = swimmingAvgHR;
                        break;
                    case "Running":
                        m1TextBox = runningDistance;
                        m2TextBox = runningSpeed;
                        m3TextBox = runningMinutes;
                        break;
                    case "Sit-Ups":
                        m1TextBox = sitUpsTime;
                        m2TextBox = walkingSteps;
                        m3TextBox = walkingSteps;
                        break;
                    case "Jumping-Jacks":
                        m1TextBox = walkingSteps;
                        m2TextBox = walkingSteps;
                        m3TextBox = walkingSteps;
                        break;
                    case "Press-Ups":
                        m1TextBox = walkingSteps;
                        m2TextBox = walkingSteps;
                        m3TextBox = walkingSteps;
                        break;
                }

                double m1 = 0;
                double m2 = 0;
                double m3 = 0;

                if (double.TryParse(m1TextBox.Text, out double m1r))
                {
                    m1 = m1r;
                }
                else
                {
                    MessageBox.Show("The first metric is not, but must be, a number");
                }

                if (double.TryParse(m2TextBox.Text, out double m2r))
                {
                    m2 = m2r;
                }
                else
                {
                    MessageBox.Show("The second metric is not, but must be, a number");
                }

                if (double.TryParse(m3TextBox.Text, out double m3r))
                {
                    m3 = m3r;
                }
                else
                {
                    MessageBox.Show("The third metric is not, but must be, a number");
                }

                _model.RecordActivity(selectedExercise, m1, m2, m3);
                ((MainWindow)Application.Current.MainWindow).GoToPage(new ProgressPage(_model));
            }
        }
    }
}
