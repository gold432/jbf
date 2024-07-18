using System.Windows.Controls;
using Newtonsoft.Json;
using System.IO;

namespace FitnessTracker
{
    public partial class MetricEntry : Page
    {
        private readonly FitnessTrackerModel _model;
        private Dictionary<string, List<string>> _workoutMetrics;

        public MetricEntry(FitnessTrackerModel model)
        {
            InitializeComponent();
            _model = model;
            LoadMetricsFromJson();
            PopulateWorkoutComboBox();
        }

        private void LoadMetricsFromJson()
        {
            string json = File.ReadAllText("metrics.json");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            dynamic data = JsonConvert.DeserializeObject(json);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            _workoutMetrics = new Dictionary<string, List<string>>();

            foreach (var activity in data.activities)
            {
                string workoutName = activity.Name;
                List<string> metrics = new List<string>();

                foreach (var metric in activity.metrics)
                {
                    metrics.Add((string)metric.Value);
                }

                _workoutMetrics.Add(workoutName, metrics);
            }
        }

        private void PopulateWorkoutComboBox()
        {
            WorkoutComboBox.Items.Clear();

            foreach (var workout in _workoutMetrics.Keys)
            {
                WorkoutComboBox.Items.Add(workout);
            }
        }

        private void WorkoutComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // MetricListBox.ItemsSource = _workoutMetrics[WorkoutComboBox.SelectedValue.ToString()];
        }
    }
}