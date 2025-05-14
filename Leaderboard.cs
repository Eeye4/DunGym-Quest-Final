using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace DunGym_Quest
{
    public partial class Leaderboard : UserControl
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\User\Documents\DunGymQuest.accdb";
        private System.Windows.Forms.Timer refreshTimer;
        private string currentFitnessGoal = "Powerlifting";

        public Leaderboard()
        {
            InitializeComponent();
            InitializeTimer();
            LoadLeaderboard("Powerlifting Leaderboard", "Powerlifting");
        }

        private void InitializeTimer()
        {
    
            refreshTimer = new System.Windows.Forms.Timer();
            refreshTimer.Interval = 5000;
            refreshTimer.Tick += new EventHandler(RefreshTimer_Tick);
            refreshTimer.Start();
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            if (!IsDisposed && IsHandleCreated)
            {
                LoadLeaderboard(tbxLboard.Text, currentFitnessGoal);
            }
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            if (refreshTimer != null)
            {
                refreshTimer.Stop();
                refreshTimer.Tick -= RefreshTimer_Tick;
                refreshTimer.Dispose();
            }
            base.OnHandleDestroyed(e);
        }

        private void LoadLeaderboard(string leaderboardTitle, string fitnessGoal)
        {
            if (IsDisposed) return;

            currentFitnessGoal = fitnessGoal;
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT UserID, Username, [First Name], [Last Name], XP, [Rank], [Level], [Fitness Goals]
                        FROM MemberDetails
                        WHERE [Fitness Goals] = ?
                        ORDER BY XP DESC";

                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("?", fitnessGoal);

                    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

              
                    dt.Columns.Add("Position", typeof(int));
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["Position"] = i + 1;
                    }


                    dt.Columns["Position"].SetOrdinal(0);

                    if (!IsDisposed && IsHandleCreated)
                    {
                        datagridLeaderboard.DataSource = dt;
                        tbxLboard.Text = leaderboardTitle;

                        datagridLeaderboard.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                        datagridLeaderboard.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;

                        if (datagridLeaderboard.Rows.Count > 0)
                        {
                            if (datagridLeaderboard.Rows.Count > 0)
                            {
                                datagridLeaderboard.Rows[0].DefaultCellStyle.BackColor = System.Drawing.Color.Gold;
                                datagridLeaderboard.Rows[0].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                            }
                            if (datagridLeaderboard.Rows.Count > 1)
                            {
                                datagridLeaderboard.Rows[1].DefaultCellStyle.BackColor = System.Drawing.Color.Silver;
                                datagridLeaderboard.Rows[1].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                            }
                            if (datagridLeaderboard.Rows.Count > 2)
                            {
                                datagridLeaderboard.Rows[2].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(205, 127, 50); 
                                datagridLeaderboard.Rows[2].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (!IsDisposed)
                    {
                        MessageBox.Show("Error loading data: " + ex.Message);
                    }
                }
            }
        }

        private void btnPLleaderboard_Click(object sender, EventArgs e)
        {
            LoadLeaderboard("Powerlifting Leaderboard", "Powerlifting");
        }

        private void btnBBleaderboard_Click(object sender, EventArgs e)
        {
            LoadLeaderboard("Bodybuilding Leaderboard", "Bodybuilding");
        }

        private void btnWLleaderboard_Click(object sender, EventArgs e)
        {
            LoadLeaderboard("Weight Loss Leaderboard", "Weight Loss");
        }

        private void btnHLleaderboard_Click(object sender, EventArgs e)
        {
            LoadLeaderboard("Healthy Living Leaderboard", "Healthy Living");
        }
    }
}
