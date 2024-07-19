using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
namespace FitnessTracker
{
    public class FitnessTrackerModel
    {
        private Dictionary<string, double> _activities;
        int failedAttempts = 0;
        private double _goal;
        private double _totalCaloriesBurned;

        public FitnessTrackerModel()
        {
            _activities = new Dictionary<string, double>();
        }

        public class User
        {
            public required string Password { get; set; }
        }

        public bool Login(string username, string password, FitnessTrackerModel model)
        {
            string jsonString = File.ReadAllText("users.json");
            Dictionary<string, User> users = JsonSerializer.Deserialize<Dictionary<string, User>>(jsonString);

            for (int i = 0; i < 3; i++)
            {
                if (users.TryGetValue(username, out User user))
                {
                    if (user.Password == password)
                    {
                        ((MainWindow)Application.Current.MainWindow).GoToPage(new GoalSettingPage(model));
                    }
                    else
                    {

                        MessageBox.Show("Wrong password.");
                    }

                }
                else
                {
                    MessageBox.Show("That user does not exist");
                }
            }

            MessageBox.Show("You have exceeded the maximum number of login attempts");
            return false;
        }

        public bool Register(string username, string password, FitnessTrackerModel model)
        {
            if (password.Length < 12)
            {
                MessageBox.Show("Password is less than 12 characters.");
                return false;
            }
            bool hasLowercase = password.Any(c => char.IsLower(c));
            bool hasUppercase = password.Any(c => char.IsUpper(c));

            if (!hasLowercase)
            {
                MessageBox.Show("The password is required to have a lower-case character.");
                return false;
            }
            if (!hasUppercase)
            {
                MessageBox.Show("The password is required to have an upper-case character.");
                return false;
            }

            string jsonString = File.ReadAllText("users.json");
            Dictionary<string, User> users = JsonSerializer.Deserialize<Dictionary<string, User>>(jsonString) ?? new Dictionary<string, User>();

            // Add a new user
            users.Add(username, new User { Password = password });

            // Write the updated users back to the file
            string newJson = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("users.json", newJson);
            ((MainWindow)Application.Current.MainWindow).GoToPage(new GoalSettingPage(model));

            return true;
        }

        public void SetGoal(int goal)
        {
            _goal = goal;
        }

        public void RecordActivity(string activity, double metric1, double metric2, double metric3)
        {
            _activities[activity] = CalculateCaloriesBurned(activity, metric1, metric2, metric3);
            AddCaloriesBurned(_activities[activity]);
        }

        public double GetTotalCaloriesBurned()
        {
            return _totalCaloriesBurned;
        }

        public double GetGoal()
        {
            return _goal;
        }

        public void AddCaloriesBurned(double calories)
        {
            _totalCaloriesBurned += calories;
        }

        private double CalculateCaloriesBurned(string activity, double metric1, double metric2, double metric3)
        {
            if (activity == "Walking")
            {
                return metric1 * 0.5 + metric2 * 0.2 + metric3 * 0.3;
            }
            else if (activity == "Swimming")
            {
                return metric1 * 0.7 + metric2 * 0.3 + metric3 * 0.4;
            }
            if (activity == "Running")
            {
                return metric1 * 0.5 + metric2 * 0.2 + metric3 * 0.3;
            }
            else if (activity == "Sit-Ups")
            {
                return metric1 * 0.7 + metric2 * 0.3 + metric3 * 0.4;
            }
            if (activity == "Jumping-Jacks")
            {
                return metric1 * 0.5 + metric2 * 0.2 + metric3 * 0.3;
            }
            else if (activity == "Press-Ups")
            {
                return metric1 * 0.7 + metric2 * 0.3 + metric3 * 0.4;
            }
            // Add more activities and formulas here
            return 0;
        }
    }
}