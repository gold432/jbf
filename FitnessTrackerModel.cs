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
        public int i = 0;
        private double _totalCaloriesBurned;

        public FitnessTrackerModel()
        {
            _activities = new Dictionary<string, double>();
        }

        public class User
        {
            public required string Password { get; set; }
            public List<Activity>? Activities { get; set; }
        }

        public class Activity
        {
            public string Name { get; set; }
            public int M1 { get; set; }
            public int M2 { get; set; }
            public int M3 { get; set; }

            public Activity(string name, int m1, int m2, int m3) {
                Name = name;
                M1 = m1;
                M2 = m2;
                M3 = m3;
            }
        }

        public class Metric {
            public string Name { get; set; }
            public string Value { get; set; }
        }

        public bool Login(string username, string password, FitnessTrackerModel model)
        {
            string jsonString = File.ReadAllText("users.json");
            Dictionary<string, User> users = JsonSerializer.Deserialize<Dictionary<string, User>>(jsonString);

            if (users.TryGetValue(username, out User user))
            {
                if (user.Password == password)
                {
                    ((MainWindow)Application.Current.MainWindow).GoToPage(new GoalSettingPage(model));
                    return true;
                }
                else
                {

                    MessageBox.Show("Wrong password.");
                    i++;
                    if (i == 3)
                    {
                        MessageBox.Show("You have exceeded the maximum number of login attempts");
                        Environment.Exit(0);
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }

            }
            else
            {
                MessageBox.Show("That user does not exist");
                return false;
            }


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

            Dictionary<string, User> users = GetUsers();

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

        public double CalculateTotalCaloriesBurned()
        {
            double calories_burned = 0;
            Dictionary<string, User> users = GetUsers();
            foreach (KeyValuePair<string, User> user in users) {
                foreach (Activity activity in user.Value.Activities) {
                    calories_burned += CalculateCaloriesBurned(activity.Name, activity.M1, activity.M2, activity.M3);
                }
            }
            return calories_burned;
        }

        public Dictionary<string, User> GetUsers()
        {
            string jsonString = File.ReadAllText("users.json");
            Dictionary<string, User> users = JsonSerializer.Deserialize<Dictionary<string, User>>(jsonString) ?? new Dictionary<string, User>();
            return users;
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