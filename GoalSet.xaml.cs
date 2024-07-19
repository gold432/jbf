using System.Windows;
using System.Windows.Controls;

namespace FitnessTracker
{
    public partial class GoalSettingPage : Page
    {
        private readonly FitnessTrackerModel _model;

        public GoalSettingPage(FitnessTrackerModel model)
        {
            InitializeComponent();
            _model = model;
        }

        private void SetGoalButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(goalTextBox.Text, out int goal))
            {
                _model.SetGoal(goal);
                ((MainWindow)Application.Current.MainWindow).GoToPage(new MetricEntry(_model));
            }
            else
            {
                MessageBox.Show("Invalid goal value.");
            }
        }
    }
}