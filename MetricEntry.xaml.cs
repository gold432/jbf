using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace YourNamespace
{
    public partial class MetricEntry : Window
    {
        private dynamic metrics;

        public MetricEntry()
        {
            InitializeComponent();

            // Load metrics from Metrics.json
            string json = File.ReadAllText("Metrics.json");
            metrics = JsonConvert.DeserializeObject<dynamic>(json);

            // Populate combo box with metric keys
            foreach (string key in metrics.Keys)
            {
               _metricComboBox.Items.Add(key);
            }
        }

        private void _metricComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Clear existing input boxes
            _inputGrid.Children.Clear();

            // Get selected metric
            string selectedMetric = _metricComboBox.SelectedItem as string;

            // Create input boxes for each metric
            foreach (string property in metrics[selectedMetric].Properties())
            {
                TextBox textBox = new TextBox();
                textBox.Margin = new Thickness(5);
                textBox.Label = property.Name;
                _inputGrid.Children.Add(textBox);
            }
        }

        private void _submitButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to Progress.xaml page
            Progress progressPage = new Progress();
            this.NavigationService.Navigate(progressPage);
        }
    }
}
