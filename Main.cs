using Microsoft.VisualBasic.ApplicationServices;
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

namespace DunGym_Quest
{
    public partial class Main : Form
    {
        public int CurrentUserId { get; set; }
        public string CurrentUsername { get; set; }
        

        private Dictionary<Type, UserControl> controlInstances = new Dictionary<Type, UserControl>();
        

        private UserMenu currentUserMenu;
        private Progres currentProgress;
        private Achievement currentAchievement;
        
        public Main(int userId, string username)
        {
            InitializeComponent();
            CurrentUserId = userId;
            CurrentUsername = username;
            
            currentUserMenu = new UserMenu(CurrentUsername);
            currentUserMenu.SetUsername(CurrentUsername, CurrentUserId);


            var dashboard = new Dashboard(CurrentUserId);
            controlInstances[typeof(Dashboard)] = dashboard;
            Loadusercontrol(dashboard);
        }

        private void RefreshAllStats()
        {
            if (currentUserMenu != null)
            {
                currentUserMenu.UpdateUserStats();
            }

            if (currentProgress != null)
            {
                currentProgress.UpdateProgressStats();
            }

            if (currentAchievement != null)
            {
                currentAchievement.LoadUserStats();
            }

            if (PanelMain.Controls.Count > 0)
            {
                var currentControl = PanelMain.Controls[0];
                if (currentControl is UserMenu)
                {
                    ((UserMenu)currentControl).UpdateUserStats();
                }
                else if (currentControl is Progres)
                {
                    ((Progres)currentControl).UpdateProgressStats();
                }
                else if (currentControl is Achievement)
                {
                    ((Achievement)currentControl).LoadUserStats();
                }
            }
        }

        private void exercisebtn_Click(object sender, EventArgs e)
        {
            Type controlType = typeof(Exercise);
            if (!controlInstances.ContainsKey(controlType))
            {
                var exercise = new Exercise();
                exercise.SetUserId(CurrentUserId);
                exercise.WorkoutSaved += (s, args) => {
                    if (currentProgress != null)
                    {
                        currentProgress.LoadChartData();
                        currentProgress.LoadWorkoutLog();
                    }
                };
                controlInstances[controlType] = exercise;
            }
            Loadusercontrol(controlInstances[controlType]);
        }

        private void leaderboardbtn_Click(object sender, EventArgs e)
        {
            Type controlType = typeof(Leaderboard);
            if (!controlInstances.ContainsKey(controlType))
            {
                controlInstances[controlType] = new Leaderboard();
            }
            Loadusercontrol(controlInstances[controlType]);
        }

        private void achievementbtn_Click(object sender, EventArgs e)
        {
            Type controlType = typeof(Achievement);
            if (!controlInstances.ContainsKey(controlType))
            {
                currentAchievement = new Achievement(CurrentUserId);
                currentAchievement.XPUpdated += (s, args) => RefreshAllStats();
                controlInstances[controlType] = currentAchievement;
            }
            Loadusercontrol(controlInstances[controlType]);
        }

        private void progressbtn_Click(object sender, EventArgs e)
        {
            Type controlType = typeof(Progres);
            if (!controlInstances.ContainsKey(controlType))
            {
                currentProgress = new Progres(CurrentUserId);
                controlInstances[controlType] = currentProgress;
            }
            Loadusercontrol(controlInstances[controlType]);
        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void bmibtn_Click(object sender, EventArgs e)
        {
            Type controlType = typeof(BMICalc);
            if (!controlInstances.ContainsKey(controlType))
            {
                controlInstances[controlType] = new BMICalc();
            }
            Loadusercontrol(controlInstances[controlType]);
        }

        public void Loadusercontrol(UserControl usercontrol)
        {
            if (PanelMain.Controls.Count > 0)
            {
                PanelMain.Controls.Clear();
            }

            usercontrol.Dock = DockStyle.Fill;
            PanelMain.Controls.Add(usercontrol);
            usercontrol.BringToFront();
        }

        private void dashboardbtn_Click(object sender, EventArgs e)
        {
            Type controlType = typeof(Dashboard);
            if (!controlInstances.ContainsKey(controlType))
            {
                controlInstances[controlType] = new Dashboard(CurrentUserId);
            }
            Loadusercontrol(controlInstances[controlType]);
        }

        private void userbtn_Click(object sender, EventArgs e)
        {
            Type controlType = typeof(UserMenu);
            if (!controlInstances.ContainsKey(controlType))
            {
                currentUserMenu = new UserMenu(CurrentUsername);
                currentUserMenu.SetUsername(CurrentUsername, CurrentUserId);
                controlInstances[controlType] = currentUserMenu;
            }
            Loadusercontrol(controlInstances[controlType]);
        }
    }
}