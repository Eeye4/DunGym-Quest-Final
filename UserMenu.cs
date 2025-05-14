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
    using SiticoneNetCoreUI;

    namespace DunGym_Quest
    {
    public partial class UserMenu : UserControl
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\User\Documents\DunGymQuest.accdb";
        private string Username;
        private int currentUserId;
        private SiticonePictureBox profilePictureBox;
        public UserMenu(string currentUsername)
        {
            InitializeComponent();
            Username = currentUsername;
            tbxUsername.Text = currentUsername;

        
            changeprofile.Image = Properties.Resources.user;
            changeprofile.BackgroundImageLayout = ImageLayout.Stretch;
        }

        public void SetUsername(string username, int userId)
        {
            Username = username;
            currentUserId = userId;
            tbxUsername.Text = username;
            LoadUserProfileImage();

            Console.WriteLine($"UserMenu initialized with UserId: {currentUserId}, Username: {Username}");
            UpdateUserStats();
        }

        public void UpdateUserStats()
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

     
                    string getXPQuery = "SELECT XP FROM MemberDetails WHERE UserID = ?";
                    using (OleDbCommand getXPCmd = new OleDbCommand(getXPQuery, connection))
                    {
                        getXPCmd.Parameters.AddWithValue("?", currentUserId);
                        object result = getXPCmd.ExecuteScalar();
                        int xp = result != null ? Convert.ToInt32(result) : 0;

                        Console.WriteLine($"UserMenu - UserID: {currentUserId}, XP: {xp}");

                  
                        (string rankTitle, int level) = GetRankAndLevel(xp);

                        Console.WriteLine($"UserMenu - Level: {level}, Rank: {rankTitle}");


                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(() =>
                            {
                                tbxXp.Text = xp.ToString();
                                tbxLevel.Text = level.ToString();
                                tbxRank.Text = rankTitle;
                            }));
                        }
                        else
                        {
                            tbxXp.Text = xp.ToString();
                            tbxLevel.Text = level.ToString();
                            tbxRank.Text = rankTitle;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating user stats: {ex.Message}");
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        tbxXp.Text = "0";
                        tbxLevel.Text = "1";
                        tbxRank.Text = "Newbie";
                    }));
                }
                else
                {
                    tbxXp.Text = "0";
                    tbxLevel.Text = "1";
                    tbxRank.Text = "Newbie";
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

        private string GetRankSuffix(int rank)
        {
            if (rank >= 11 && rank <= 13)
                return "th";

            switch (rank % 10)
            {
                case 1: return "st";
                case 2: return "nd";
                case 3: return "rd";
                default: return "th";
            }
        }

        private void btnUpdateuser_Click(object sender, EventArgs e)
        {
            string newUsername = tbxNewuser.Text.Trim();

            if (string.IsNullOrEmpty(newUsername))
            {
                MessageBox.Show("Please enter a new username.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (UsernameExists(newUsername))
            {
                MessageBox.Show("This username is already taken. Please choose another.", "Username Taken", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine($"Attempting to update username for UserID: {currentUserId} to: {newUsername}");

                    string query = "UPDATE MemberDetails SET Username = ? WHERE UserID = ?";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("?", newUsername);
                        command.Parameters.AddWithValue("?", currentUserId);

                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Rows affected in MemberDetails: {rowsAffected}");

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Username updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Username = newUsername;
                            tbxUsername.Text = newUsername;
                            tbxNewuser.Clear();
                        }
                        else
                        {
                            MessageBox.Show($"Failed to update username. No matching record found for UserID: {currentUserId}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating username: {ex.Message}");
                MessageBox.Show($"Error updating username: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdatepass_Click(object sender, EventArgs e)
        {
            string oldPassword = tbxOldpass.Text;
            string newPassword = tbxNewpass.Text;
            string confirmPassword = tbxConfirmpass.Text;

            if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please fill in all password fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("New password and confirmation do not match.", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!VerifyPassword(oldPassword))
            {
                MessageBox.Show("Current password is incorrect.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE MemberDetails SET [Password] = @NewPassword WHERE UserID = @UserID";
                    string hashedNewPassword = Login.HashPassword(newPassword);

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.Add("@NewPassword", OleDbType.VarChar).Value = hashedNewPassword;
                        command.Parameters.Add("@UserID", OleDbType.Integer).Value = currentUserId;

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Password updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tbxOldpass.Clear();
                            tbxNewpass.Clear();
                            tbxConfirmpass.Clear();
                        }
                        else
                        {
                            MessageBox.Show($"Failed to update password. No matching record found for UserID: {currentUserId}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating password: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteacc_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete your account? This action cannot be undone.",
                "Confirm Account Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (OleDbConnection connection = new OleDbConnection(connectionString))
                    {
                        connection.Open();
                        Console.WriteLine($"Attempting to delete account with UserID: {currentUserId}");

                        using (OleDbTransaction transaction = connection.BeginTransaction())
                        {
                            try
                            {
          
                                string verifyQuery = "SELECT COUNT(*) FROM MemberDetails WHERE UserID = ?";
                                using (OleDbCommand verifyCommand = new OleDbCommand(verifyQuery, connection, transaction))
                                {
                                    verifyCommand.Parameters.AddWithValue("?", currentUserId);
                                    int count = Convert.ToInt32(verifyCommand.ExecuteScalar());
                                    if (count == 0)
                                    {
                                        MessageBox.Show("Account not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }

                                string deleteAchievementsQuery = "DELETE FROM UserAchievements WHERE UserID = ?";
                                using (OleDbCommand deleteAchievementsCommand = new OleDbCommand(deleteAchievementsQuery, connection, transaction))
                                {
                                    deleteAchievementsCommand.Parameters.AddWithValue("?", currentUserId);
                                    deleteAchievementsCommand.ExecuteNonQuery();
                                }

                                string deleteWorkoutLogQuery = "DELETE FROM WorkoutLog WHERE UserID = ?";
                                using (OleDbCommand deleteWorkoutLogCommand = new OleDbCommand(deleteWorkoutLogQuery, connection, transaction))
                                {
                                    deleteWorkoutLogCommand.Parameters.AddWithValue("?", currentUserId);
                                    deleteWorkoutLogCommand.ExecuteNonQuery();
                                }

                   
                                string deleteMemberQuery = "DELETE FROM MemberDetails WHERE UserID = ?";
                                using (OleDbCommand deleteMemberCommand = new OleDbCommand(deleteMemberQuery, connection, transaction))
                                {
                                    deleteMemberCommand.Parameters.AddWithValue("?", currentUserId);
                                    int rowsAffected = deleteMemberCommand.ExecuteNonQuery();
                                    Console.WriteLine($"Deleted {rowsAffected} records from MemberDetails table");

                                    if (rowsAffected > 0)
                                    {
                                        transaction.Commit();
                                        MessageBox.Show("Your account has been deleted successfully.", "Account Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        Form parentForm = this.FindForm();
                                        if (parentForm != null)
                                        {
                                            Application.Restart();
                                        }
                                    }
                                    else
                                    {
                                        transaction.Rollback();
                                        MessageBox.Show("Failed to delete account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                throw;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting account: {ex.Message}");
                    MessageBox.Show($"Error deleting account: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool UsernameExists(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return false;
            }

            if (username.Equals(Username, StringComparison.OrdinalIgnoreCase))
                return false;

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM MemberDetails WHERE Username = ?";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("?", username);
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking username: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private string GetStoredPassword()
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Password FROM MemberDetails WHERE UserID = ?";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("?", currentUserId);
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            string password = result.ToString();
                            Console.WriteLine($"Retrieved stored password hash for UserID {currentUserId}");
                            return password;
                        }
                        else
                        {
                            Console.WriteLine($"No password found for UserID {currentUserId}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving password: {ex.Message}");
                throw;
            }
            return string.Empty;
        }

        private bool VerifyPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Password verification failed: Empty password");
                return false;
            }

            try
            {
                string storedPassword = GetStoredPassword();
                if (string.IsNullOrEmpty(storedPassword))
                {
                    Console.WriteLine("Password verification failed: No stored password found");
                    return false;
                }

                string hashedInput = Login.HashPassword(password);
                Console.WriteLine($"Stored Password Hash: {storedPassword}");
                Console.WriteLine($"Input Password Hash: {hashedInput}");

                bool isMatch = hashedInput.Equals(storedPassword, StringComparison.OrdinalIgnoreCase);
                Console.WriteLine($"Password match result: {isMatch}");
                return isMatch;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in password verification: {ex.Message}");
                MessageBox.Show($"Error verifying password: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void LoadUserProfileImage()
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Profile FROM MemberDetails WHERE UserID = ?";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("?", currentUserId);
                        object result = command.ExecuteScalar();
                        if (result != null && !string.IsNullOrWhiteSpace(result.ToString()))
                        {
                            string imagePath = result.ToString();
                            if (System.IO.File.Exists(imagePath))
                            {
                                changeprofile.Image = Image.FromFile(imagePath);
                                changeprofile.BackgroundImageLayout = ImageLayout.Stretch;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading profile image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void changeprofile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = ofd.FileName;

                    try
                    {
                        using (OleDbConnection connection = new OleDbConnection(connectionString))
                        {
                            connection.Open();
                            string updateQuery = "UPDATE MemberDetails SET Profile = ? WHERE UserID = ?";
                            using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                            {
                                command.Parameters.AddWithValue("?", selectedPath);
                                command.Parameters.AddWithValue("?", currentUserId);
                                int rows = command.ExecuteNonQuery();

                                if (rows > 0)
                                {
                                    changeprofile.Image = Image.FromFile(selectedPath);
                                    changeprofile.BackgroundImageLayout = ImageLayout.Stretch;
                                    MessageBox.Show("Profile photo updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Failed to update profile photo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating profile photo: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
