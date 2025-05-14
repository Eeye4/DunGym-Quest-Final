using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.Charts.WinForms;

namespace DunGym_Quest
{
    public partial class Progres : UserControl
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\User\Documents\DunGymQuest.accdb";
        private int currentUserId;

        public Progres(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
       
            InitializeCharts();
            
       
            combobox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            combobox.SelectedIndex = 0;
        
            UpdateProgressStats();
            LoadWorkoutLog();
            
            LoadChartData();
        }

        private void InitializeCharts()
        {
      
            weightlosschart.Title.Text = "Weight Progress";
            weightlosschart.XAxes.GridLines.Display = false;
            weightlosschart.YAxes.GridLines.Display = true;
            weightlosschart.YAxes.Ticks.Font = new Guna.Charts.WinForms.ChartFont("Arial", 8);
            weightlosschart.XAxes.Ticks.Font = new Guna.Charts.WinForms.ChartFont("Arial", 8);
            weightlosschart.Legend.Display = true;
            weightlosschart.Legend.Position = Guna.Charts.WinForms.LegendPosition.Top;

   
            weightliftedchart.Title.Text = "Total Weight Lifted";
            weightliftedchart.XAxes.GridLines.Display = false;
            weightliftedchart.YAxes.GridLines.Display = true;
            weightliftedchart.YAxes.Ticks.Font = new Guna.Charts.WinForms.ChartFont("Arial", 8);
            weightliftedchart.XAxes.Ticks.Font = new Guna.Charts.WinForms.ChartFont("Arial", 8);
            weightliftedchart.Legend.Display = true;
            weightliftedchart.Legend.Position = Guna.Charts.WinForms.LegendPosition.Top;

         
            weightlosschart.Datasets.Clear();
            weightliftedchart.Datasets.Clear();
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadChartData();
        }

        public void LoadChartData()
        {
            if (!IsDisposed && IsHandleCreated)
            {
        
                weightlosschart.Datasets.Clear();
                weightliftedchart.Datasets.Clear();
           
                LoadWeightData();
                LoadWeightLiftedData();
                

                weightlosschart.Update();
                weightliftedchart.Update();
            }
        }

        public void LoadWeightData()
        {
            if (IsDisposed || !IsHandleCreated) return;

            try
            {
                string timeFilter = GetTimeFilter();
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string query = $"SELECT Date, Bodyweight FROM WorkoutLog WHERE UserID = ? AND Bodyweight > 0 {timeFilter} ORDER BY Date ASC";
                    using (OleDbCommand cmd = new OleDbCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("?", currentUserId);
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            var dailyWeights = new Dictionary<string, double>();
                            var dailyDateTime = new Dictionary<string, DateTime>();
                            while (reader.Read())
                            {
                                DateTime dt = reader.GetDateTime(0);
                                string dateKey = GetDateKey(dt);
                                double weight = reader.GetDouble(1);
                                dailyWeights[dateKey] = weight;
                                dailyDateTime[dateKey] = dt;
                            }

                            var sorted = dailyDateTime.OrderBy(x => x.Value).ToList();
                            var dates = new List<string>();
                            var weights = new List<double>();
                            foreach (var kvp in sorted)
                            {
                                dates.Add(FormatDate(kvp.Value));
                                weights.Add(dailyWeights[kvp.Key]);
                            }

                            if (dates.Count > 0)
                            {
                                UpdateWeightChart(dates, weights);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading weight data: {ex.Message}");
            }
        }

        public void LoadWeightLiftedData()
        {
            if (IsDisposed || !IsHandleCreated) return;

            try
            {
                string timeFilter = GetTimeFilter();
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string query = $@"SELECT Date, Weight, [Reps/Duration], Sets 
                                    FROM WorkoutLog 
                                    WHERE UserID = ? AND Weight > 0 {timeFilter} 
                                    ORDER BY Date ASC";

                    using (OleDbCommand cmd = new OleDbCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("?", currentUserId);
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            var dailyTotals = new Dictionary<string, double>();
                            var dailyDateTime = new Dictionary<string, DateTime>();

                            while (reader.Read())
                            {
                                DateTime dt = reader.GetDateTime(0);
                                string dateKey = GetDateKey(dt);
                                double weight = reader.GetDouble(1);
                                int reps = reader.GetInt32(2);
                                int sets = reader.GetInt32(3);
                                double totalWeight = weight * sets; // Calculate total weight for this exercise

                                if (!dailyTotals.ContainsKey(dateKey))
                                {
                                    dailyTotals[dateKey] = 0;
                                    dailyDateTime[dateKey] = dt;
                                }
                                dailyTotals[dateKey] += totalWeight;
                            }

                            var sorted = dailyDateTime.OrderBy(x => x.Value).ToList();
                            var dates = new List<string>();
                            var totals = new List<double>();
                            foreach (var kvp in sorted)
                            {
                                dates.Add(FormatDate(kvp.Value));
                                totals.Add(dailyTotals[kvp.Key]);
                            }

                            if (dates.Count > 0)
                            {
                                UpdateWeightLiftedChart(dates, totals);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading weight lifted data: {ex.Message}");
            }
        }

        private string GetTimeFilter()
        {
            string period = combobox.SelectedItem?.ToString() ?? "Daily";
            DateTime now = DateTime.Now;
            switch (period)
            {
                case "Weekly":
                    return $"AND Date >= #{now.AddDays(-7):MM/dd/yyyy}#";
                case "Monthly":
                    return $"AND Date >= #{now.AddMonths(-1):MM/dd/yyyy}#";
                default: // Daily
                    return $"AND Date >= #{now.AddDays(-30):MM/dd/yyyy}#";
            }
        }

        private string GetDateKey(DateTime dt)
        {
            string period = combobox.SelectedItem?.ToString() ?? "Daily";
            switch (period)
            {
                case "Weekly":
                   
                    DateTime startOfWeek = dt.AddDays(-(int)dt.DayOfWeek);
                    return startOfWeek.ToString("yyyy-MM-dd");
                case "Monthly":
                    return $"{dt.Year}-{dt.Month}";
                default: 
                    return dt.ToString("yyyy-MM-dd");
            }
        }

        private string FormatDate(DateTime dt)
        {
            string period = combobox.SelectedItem?.ToString() ?? "Daily";
            switch (period)
            {
                case "Weekly":
       
                    DateTime startOfWeek = dt.AddDays(-(int)dt.DayOfWeek);
                    return startOfWeek.ToString("MM/dd");
                case "Monthly":
                    return dt.ToString("MMM yyyy");
                default: 
                    return dt.ToString("MM/dd");
            }
        }

        private void UpdateWeightChart(List<string> dates, List<double> weights)
        {
            try
            {
                if (!IsDisposed && IsHandleCreated && weightlosschart != null)
                {
                    weightlosschart.Datasets.Clear();
                    var dataset = new Guna.Charts.WinForms.GunaLineDataset();
                    dataset.Label = "Weight (kg)";
                    dataset.PointRadius = 5;
                    dataset.PointStyle = Guna.Charts.WinForms.PointStyle.Circle;
                    dataset.BorderColor = Color.FromArgb(204, 88, 3);
                    dataset.FillColor = Color.FromArgb(204, 88, 3);
                    dataset.BorderWidth = 2;

                    for (int i = 0; i < dates.Count; i++)
                    {
                        dataset.DataPoints.Add(dates[i], weights[i]);
                    }

                    weightlosschart.Datasets.Add(dataset);
                    weightlosschart.Update();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating weight chart: {ex.Message}");
            }
        }

        private void UpdateWeightLiftedChart(List<string> dates, List<double> totals)
        {
            try
            {
                if (!IsDisposed && IsHandleCreated && weightliftedchart != null)
                {
                    weightliftedchart.Datasets.Clear();
                    var dataset = new Guna.Charts.WinForms.GunaLineDataset();
                    dataset.Label = "Total Weight Lifted (kg)";
                    dataset.PointRadius = 5;
                    dataset.PointStyle = Guna.Charts.WinForms.PointStyle.Circle;
                    dataset.BorderColor = Color.FromArgb(204, 88, 3);
                    dataset.FillColor = Color.FromArgb(204, 88, 3);
                    dataset.BorderWidth = 2;

                    for (int i = 0; i < dates.Count; i++)
                    {
                        dataset.DataPoints.Add(dates[i], totals[i]);
                    }

                    weightliftedchart.Datasets.Add(dataset);
                    weightliftedchart.Update();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating weight lifted chart: {ex.Message}");
            }
        }

        public void UpdateProgressStats()
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string getXPQuery = "SELECT XP FROM MemberDetails WHERE UserID = @UserID";
                    using (OleDbCommand getXPCmd = new OleDbCommand(getXPQuery, connection))
                    {
                        getXPCmd.Parameters.Add("@UserID", OleDbType.Integer).Value = currentUserId;
                        object result = getXPCmd.ExecuteScalar();
                        int xp = result != null ? Convert.ToInt32(result) : 0;

                        Console.WriteLine($"Progres - UserID: {currentUserId}, XP: {xp}");

              
                        (string rankTitle, int level) = GetRankAndLevel(xp);

                        Console.WriteLine($"Progres - Level: {level}, Rank: {rankTitle}");

                        string getStreakQuery = "SELECT [Login Streak] FROM MemberDetails WHERE UserID = @UserID";
                        using (OleDbCommand getStreakCmd = new OleDbCommand(getStreakQuery, connection))
                        {
                            getStreakCmd.Parameters.Add("@UserID", OleDbType.Integer).Value = currentUserId;
                            object streakResult = getStreakCmd.ExecuteScalar();
                            int streak = streakResult != null ? Convert.ToInt32(streakResult) : 0;

                            Console.WriteLine($"Progres - Login Streak: {streak}");

      
                            if (this.InvokeRequired)
                            {
                                this.Invoke(new Action(() => {
                                    lblXP.Text = xp.ToString();
                                    lblLevel.Text = level.ToString();
                                    lblStreak.Text = streak.ToString();
                                }));
                            }
                            else
                            {
                                lblXP.Text = xp.ToString();
                                lblLevel.Text = level.ToString();
                                lblStreak.Text = streak.ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating progress stats: {ex.Message}");
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => {
                        lblXP.Text = "0";
                        lblLevel.Text = "1";
                        lblStreak.Text = "0";
                    }));
                }
                else
                {
                    lblXP.Text = "0";
                    lblLevel.Text = "1";
                    lblStreak.Text = "0";
                }
            }
        }

        private (string rankTitle, int level) GetRankAndLevel(int xp)
        {
            if (xp >= 10000) return ("Dungym God", 55);
            if (xp >= 9000) return ("Mythic Overlord", 50);
            if (xp >= 8000) return ("Legendary Hero", 45);
            if (xp >= 7000) return ("Dragon Slayer", 40);
            if (xp >= 6000) return ("Dungym Champion", 35);
            if (xp >= 5000) return ("Elite Guardian", 30);
            if (xp >= 4000) return ("Dungym Knight", 25);
            if (xp >= 3000) return ("Skilled Squire", 20);
            if (xp >= 2000) return ("Apprentice Warrior", 15);
            if (xp >= 1000) return ("Dungym Novice", 10);
            return ("Newbie", 1);
        }

        public void LoadWorkoutLog()
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM WorkoutLog WHERE UserID = ?";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", currentUserId);
                        OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        workoutlog.DataSource = dt; 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading workout log: " + ex.Message);
            }
        }
    }
}
