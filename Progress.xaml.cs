using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace FitnessTracker
{
    public partial class ProgressPage : Page
    {
        private readonly FitnessTrackerModel _model;

        public ProgressPage(FitnessTrackerModel model)
        {
            InitializeComponent();
            _model = model;
            UpdateProgressText();
        }

        private void UpdateProgressText()
        {
            double totalCaloriesBurned = _model.GetTotalCaloriesBurned();
            double goal = _model.GetGoal();
            string progressText = $"You have burned {totalCaloriesBurned} calories.\n";
            if (totalCaloriesBurned >= goal)
            {
                progressText += " Congratulations, you have achieved your goal!";
            }
            else
            {
                progressText += $"You still need to burn {goal - totalCaloriesBurned} calories to achieve your goal.";
            }
            progressTextBlock.Text = progressText;
        }
    }
}