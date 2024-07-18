using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace FitnessTracker

{
    public partial class MetricEntry : Page
    {
        private dynamic metrics;

        public MetricEntry(FitnessTrackerModel model)
        {
            InitializeComponent();

            // // Load metrics from Metrics.json
            // string json = File.ReadAllText("Metrics.json");
            // metrics = JsonConvert.DeserializeObject<dynamic>(json);

            // // Populate combo box with metric keys
            // foreach (string key in metrics.Keys)
            // {
            //    _metricComboBox.Items.Add(key);
            // }
        }

        private void cmbExercise_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedExercise = (cmbExercise.SelectedItem as ComboBoxItem).Content.ToString();

            walkingPanel.Visibility = Visibility.Collapsed;
            swimmingPanel.Visibility = Visibility.Collapsed;
            squatsPanel.Visibility = Visibility.Collapsed;

            switch (selectedExercise)
            {
                case "Walking":
                    walkingPanel.Visibility = Visibility.Visible;
                    break;
                case "Swimming":
                    swimmingPanel.Visibility = Visibility.Visible;
                    break;
                case "Squats":
                    squatsPanel.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to Progress.xaml page
            Progress<int> progressPage = new Progress<int>();
            this.NavigationService.Navigate(progressPage);
        }
    }
}
