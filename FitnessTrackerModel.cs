using System.Collections.Generic;

namespace FitnessTracker
{
    public class FitnessTrackerModel
    {
        private Dictionary<string, double> _activities;
        private double _goal;
        private double _totalCaloriesBurned;

        public FitnessTrackerModel()
        {
            _activities = new Dictionary<string, double>();
        }

        public bool Login(string username, string password)
        {
            // Implement login logic here
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
            // Implement a formula to calculate calories burned based on the activity and metrics
            // For example:
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