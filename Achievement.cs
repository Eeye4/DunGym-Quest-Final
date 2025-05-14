using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace DunGym_Quest
{
    public partial class Achievement : UserControl
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\User\Documents\DunGymQuest.accdb";
        private int currentUserId;
        private Color completedColor = Color.FromArgb(204, 88, 3);


        public event EventHandler XPUpdated;

        public Achievement(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
            LoadUserStats();
            UpdateCompletionCounter(); 
            LoadCompletedAchievements();
            ShowSelectedWeekPanel(1);
        }

        public void LoadUserStats()
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT m.XP, 
                                   (SELECT COUNT(*) FROM UserAchievements WHERE UserID = @UserID) as CompletedCount 
                                   FROM MemberDetails m WHERE m.UserID = @UserID";
                    
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.Add("@UserID", OleDbType.Integer).Value = currentUserId;
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int xp = Convert.ToInt32(reader["XP"]);
                                (string rankTitle, int level) = GetRankAndLevel(xp);


                                UpdateUserRank(rankTitle, level);

                                if (this.InvokeRequired)
                                {
                                    this.Invoke(new Action(() => {
                                        lblxp.Text = xp.ToString();
                                        lblrank.Text = rankTitle;
                                        lblcompleted.Text = $"{reader["CompletedCount"]}/24";
                                    }));
                                }
                                else
                                {
                                    lblxp.Text = xp.ToString();
                                    lblrank.Text = rankTitle;
                                    lblcompleted.Text = $"{reader["CompletedCount"]}/24";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user stats: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateUserRank(string rankTitle, int level)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string updateQuery = "UPDATE MemberDetails SET [Rank] = @Rank, [Level] = @Level WHERE UserID = @UserID";
                    using (OleDbCommand cmd = new OleDbCommand(updateQuery, conn))
                    {
                        cmd.Parameters.Add("@Rank", OleDbType.VarChar).Value = rankTitle;
                        cmd.Parameters.Add("@Level", OleDbType.Integer).Value = level;
                        cmd.Parameters.Add("@UserID", OleDbType.Integer).Value = currentUserId;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating rank: {ex.Message}");
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

        private void LoadCompletedAchievements()
        {
            try
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                    string query = "SELECT AchievementID FROM UserAchievements WHERE UserID = @UserID";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.Add("@UserID", OleDbType.Integer).Value = currentUserId;
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int achievementId = Convert.ToInt32(reader["AchievementID"]);
                                int weekNumber = ((achievementId - 1) / 6) + 1;
                                int challengeNumber = ((achievementId - 1) % 6) + 1;

                                if (this.InvokeRequired)
                                {
                                    this.Invoke(new Action(() => UpdatePanelAndButton(weekNumber, challengeNumber, true)));
                                }
                                else
                                {
                                    UpdatePanelAndButton(weekNumber, challengeNumber, true);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading achievements: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdatePanelAndButton(int weekNumber, int challengeNumber, bool completed)
        {
            try
            {
   
                Panel weekPanel = Controls.Find($"week{weekNumber}panel", true).FirstOrDefault() as Panel;
                if (weekPanel != null)
                {
          
                    string challengePanelName = $"week{weekNumber}c{challengeNumber}";
                    Panel challengePanel = null;

         
                    foreach (Control control in weekPanel.Controls)
                    {
                        if (control is Panel && control.Name == challengePanelName)
                        {
                            challengePanel = (Panel)control;
                            break;
                        }
                    }

                    if (challengePanel != null)
                    {
                        if (completed)
                        {
                            Color borderColor = Color.FromArgb(204, 88, 3);
                            challengePanel.BackColor = Color.Transparent;
                            
                            if (challengePanel.GetType().GetProperty("BorderGradientEndColor") != null)
                            {
                                challengePanel.GetType().GetProperty("BorderGradientEndColor").SetValue(challengePanel, borderColor);
                                challengePanel.GetType().GetProperty("BorderGradientStartColor").SetValue(challengePanel, borderColor);
                            }

          
                            string buttonName = $"finishBtn{((weekNumber-1)*6) + challengeNumber}";
                            foreach (Control control in challengePanel.Controls)
                            {
              
                                if (control.Name.Equals(buttonName, StringComparison.OrdinalIgnoreCase))
                                {
                                    control.Visible = false;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            challengePanel.BackColor = Color.Silver;
                        }

                
                        challengePanel.Invalidate();
                        challengePanel.Update();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating UI: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCompletionCounter()
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM UserAchievements WHERE UserID = @UserID";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                        cmd.Parameters.Add("@UserID", OleDbType.Integer).Value = currentUserId;
                        int completedCount = Convert.ToInt32(cmd.ExecuteScalar());
                        
                 
                        if (lblcompleted.InvokeRequired)
                        {
                            lblcompleted.Invoke(new Action(() => lblcompleted.Text = $"{completedCount}/24"));
                        }
                        else
                        {
                            lblcompleted.Text = $"{completedCount}/24";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating completion counter: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NotifyXPUpdate()
        {
      
            XPUpdated?.Invoke(this, EventArgs.Empty);
        }

        private void CompleteAchievement(int achievementId)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    using (OleDbTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                      
                            string checkQuery = "SELECT COUNT(*) FROM UserAchievements WHERE UserID = @UserID AND AchievementID = @AchievementID";
                            using (OleDbCommand checkCmd = new OleDbCommand(checkQuery, conn, transaction))
                            {
                                checkCmd.Parameters.Add("@UserID", OleDbType.Integer).Value = currentUserId;
                                checkCmd.Parameters.Add("@AchievementID", OleDbType.Integer).Value = achievementId;
                                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                                if (count > 0) return; 
                            }

            
                            string insertQuery = "INSERT INTO UserAchievements (UserID, AchievementID, CompletionDate) VALUES (@UserID, @AchievementID, @CompletionDate)";
                            using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, conn, transaction))
                    {
                                insertCmd.Parameters.Add("@UserID", OleDbType.Integer).Value = currentUserId;
                                insertCmd.Parameters.Add("@AchievementID", OleDbType.Integer).Value = achievementId;
                                insertCmd.Parameters.Add("@CompletionDate", OleDbType.Date).Value = DateTime.Now;
                                insertCmd.ExecuteNonQuery();
                            }

           
                            string xpQuery = "SELECT XP FROM Achievements WHERE AchievementID = @AchievementID";
                            int xpEarned = 0;
                            using (OleDbCommand xpCmd = new OleDbCommand(xpQuery, conn, transaction))
                        {
                                xpCmd.Parameters.Add("@AchievementID", OleDbType.Integer).Value = achievementId;
                                object result = xpCmd.ExecuteScalar();
                                if (result != null && result != DBNull.Value)
                                {
                                    xpEarned = Convert.ToInt32(result);
                                }
                            }

                            string updateXpQuery = "UPDATE MemberDetails SET XP = XP + @XPEarned WHERE UserID = @UserID";
                            using (OleDbCommand updateCmd = new OleDbCommand(updateXpQuery, conn, transaction))
                            {
                                updateCmd.Parameters.Add("@XPEarned", OleDbType.Integer).Value = xpEarned;
                                updateCmd.Parameters.Add("@UserID", OleDbType.Integer).Value = currentUserId;
                                updateCmd.ExecuteNonQuery();
                            }

                            transaction.Commit();

                            if (this.InvokeRequired)
                            {
                                this.Invoke(new Action(() => {
                                    LoadUserStats();
                                    UpdateCompletionCounter();
                                    NotifyXPUpdate();
                                }));
                            }
                            else
                            {
                                LoadUserStats();
                                UpdateCompletionCounter();
                                NotifyXPUpdate();
                            }

                            int weekNumber = ((achievementId - 1) / 6) + 1;
                            int challengeNumber = ((achievementId - 1) % 6) + 1;
                            
                            if (this.InvokeRequired)
                            {
                                this.Invoke(new Action(() => UpdatePanelAndButton(weekNumber, challengeNumber, true)));
                            }
                            else
                            {
                                UpdatePanelAndButton(weekNumber, challengeNumber, true);
                            }
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error completing achievement: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

        private void ShowSelectedWeekPanel(int weekNumber)
        {

            week1panel.Visible = false;
            week2panel.Visible = false;
            week3panel.Visible = false;
            week4panel.Visible = false;

       
            switch (weekNumber)
            {
                case 1:
                    week1panel.Visible = true;
                    break;
                case 2:
                    week2panel.Visible = true;
                    break;
                case 3:
                    week3panel.Visible = true;
                    break;
                case 4:
                    week4panel.Visible = true;
                    break;
            }
        }

        private void week1btn_Click(object sender, EventArgs e)
        {
            ShowSelectedWeekPanel(1);
        }

        private void week2btn_Click(object sender, EventArgs e)
        {
            ShowSelectedWeekPanel(2);
        }

        private void week3btn_Click(object sender, EventArgs e)
        {
            ShowSelectedWeekPanel(3);
        }

        private void week4btn_Click(object sender, EventArgs e)
        {
            ShowSelectedWeekPanel(4);
        }

        private void HandleFinishButtonClick(int achievementId)
        {
            try
            {
                DialogResult firstConfirmation = MessageBox.Show(
                    "Did you actually complete this challenge?",
                    "Challenge Completion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (firstConfirmation == DialogResult.Yes)
                {
                    DialogResult secondConfirmation = MessageBox.Show(
                        "God is watching, did you really complete the challenge?",
                        "Final Confirmation",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (secondConfirmation == DialogResult.Yes)
                    {
                        CompleteAchievement(achievementId);
                        
   
                        int weekNumber = ((achievementId - 1) / 6) + 1;
                        int challengeNumber = ((achievementId - 1) % 6) + 1;
                        
     
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(() => {
                                UpdatePanelAndButton(weekNumber, challengeNumber, true);
                                UpdateCompletionCounter();
                            }));
                        }
                        else
                        {
                            UpdatePanelAndButton(weekNumber, challengeNumber, true);
                            UpdateCompletionCounter();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error handling button click: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void finishBtn1_Click(object sender, EventArgs e)
        {
            HandleFinishButtonClick(1);
        }

        private void finishBtn2_Click(object sender, EventArgs e)
        {
            HandleFinishButtonClick(2);
        }

        private void finishBtn3_Click(object sender, EventArgs e)
        {
            HandleFinishButtonClick(3);
        }

        private void finishBtn4_Click(object sender, EventArgs e)
        {
            HandleFinishButtonClick(4);
        }

        private void finishBtn5_Click(object sender, EventArgs e)
        {
            HandleFinishButtonClick(5);
        }

        private void finishBtn6_Click(object sender, EventArgs e)
        {
            HandleFinishButtonClick(6);
        }

        private void finishBtn7_Click(object sender, EventArgs e)
        {
            HandleFinishButtonClick(7);
        }

        private void finishBtn8_Click(object sender, EventArgs e)
        {
            HandleFinishButtonClick(8);
        }

        private void finishBtn9_Click(object sender, EventArgs e)
        {
            HandleFinishButtonClick(9);
        }

        private void finishBtn10_Click(object sender, EventArgs e)
        {
            HandleFinishButtonClick(10);
        }

        private void finishBtn11_Click(object sender, EventArgs e)
        {
            HandleFinishButtonClick(11);
        }

        private void finishBtn12_Click(object sender, EventArgs e)
        {
            HandleFinishButtonClick(12);
        }

        private void finishBtn13_Click(object sender, EventArgs e)
        {
            HandleFinishButtonClick(13);
        }

        private void finishBtn14_Click(object sender, EventArgs e)
        {
            HandleFinishButtonClick(14);
        }

        private void finishBtn15_Click(object sender, EventArgs e)
        {
            HandleFinishButtonClick(15);
        }

        private void finishBtn16_Click(object sender, EventArgs e)
        {
            HandleFinishButtonClick(16);
        }

        private void finishBtn17_Click(object sender, EventArgs e)
        {
            HandleFinishButtonClick(17);
        }

        private void finishBtn18_Click(object sender, EventArgs e)
        {
            HandleFinishButtonClick(18);
        }

        private void finishBtn19_Click(object sender, EventArgs e)
        {
            HandleFinishButtonClick(19);
        }

        private void finishBtn20_Click(object sender, EventArgs e)
        {
            HandleFinishButtonClick(20);
        }

        private void finishBtn21_Click(object sender, EventArgs e)
        {
            HandleFinishButtonClick(21);
        }

        private void finishBtn22_Click(object sender, EventArgs e)
        {
            HandleFinishButtonClick(22);
        }

        private void finishBtn23_Click(object sender, EventArgs e)
        {
            HandleFinishButtonClick(23);
        }

        private void finishBtn24_Click(object sender, EventArgs e)
        {
            HandleFinishButtonClick(24);
        }
    }
}
