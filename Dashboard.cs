using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using SiticoneNetCoreUI;

namespace DunGym_Quest
{
    public partial class Dashboard : UserControl
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\User\Documents\DunGymQuest.accdb";
        private int currentUserId; 
       
     

        public Dashboard(int userId)
        {
            InitializeComponent();
            currentUserId = userId;

        }


        private void powerliftingbtn_Click(object sender, EventArgs e)
        {
            ConfirmSelection(powerliftingbtn, "Powerlifting");
        }

        private void bodybuildingbtn_Click(object sender, EventArgs e)
        {
            ConfirmSelection(bodybuildingbtn, "Bodybuilding");
        }

        private void weightlossbtn_Click(object sender, EventArgs e)
        {
            ConfirmSelection(weightlossbtn, "Weight Loss");
        }

        private void healthylivingbtn_Click(object sender, EventArgs e)
        {
            ConfirmSelection(healthylivingbtn, "Healthy Living");
        }

        private void ConfirmSelection(SiticoneButton selectedButton, string goalName)
        {
            DialogResult result = MessageBox.Show(
                $"Are you sure you want to select {goalName} as your fitness goal?",
                "Confirm Fitness Goal",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
            
                selectedButton.Text = "SELECTED";
                powerliftingbtn.Enabled = (selectedButton == powerliftingbtn);
                bodybuildingbtn.Enabled = (selectedButton == bodybuildingbtn);
                weightlossbtn.Enabled = (selectedButton == weightlossbtn);
                healthylivingbtn.Enabled = (selectedButton == healthylivingbtn);

               
                SaveGoalToDatabase(goalName);
            }
        }

        private void SaveGoalToDatabase(string goalName)
        {
            try
            {
                if (currentUserId <= 0)
                {
                    MessageBox.Show("Error: User ID not set. Cannot save goal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    
                    string updateQuery = "UPDATE MemberDetails SET [Fitness Goals] = ? WHERE UserID = ?";

                    using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("?", goalName);
                        command.Parameters.AddWithValue("?", currentUserId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Fitness goal saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No user record found to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving goal: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}