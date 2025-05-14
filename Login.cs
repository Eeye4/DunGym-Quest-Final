using System;
using System.Data;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace DunGym_Quest
{
    public partial class Login : Form
    {
        private readonly string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\User\Documents\DunGymQuest.accdb";

        public Login()
        {
            InitializeComponent();

            tbxPassword.PasswordChar = '*';
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            string username = tbxUsername.Text.Trim();
            string password = tbxPassword.Text;
            int userId = -1;
            string fetchedUsername = "";

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Login Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidateUser(username, password))
            {

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT UserID FROM MemberDetails WHERE Username = ?";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("?", username);

                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            userId = Convert.ToInt32(result);
                        }
                        else
                        {
                            MessageBox.Show("Unable to retrieve UserID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Username FROM MemberDetails WHERE UserID = ?";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("?", userId);
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            fetchedUsername = result.ToString();
                        }
                    }
                }

                UpdateLastLogin(userId, username);

                Main main = new Main(userId,fetchedUsername);
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.",
                    "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void registerbtn_Click_1(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }

        private bool ValidateUser(string username, string password)
        {
            bool isValid = false;

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT [Password] FROM MemberDetails WHERE [Username] = ?";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", username);

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            string storedPassword = result.ToString();

                            string hashedInputPassword = HashPassword(password);
                            isValid = (hashedInputPassword == storedPassword);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Login Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isValid;
        }

        private void UpdateLastLogin(int userId, string username)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    
                    string updateLoginTimeQuery = "UPDATE MemberDetails SET [Last Login] = ? WHERE UserID = ?";
                    using (OleDbCommand updateLoginTimeCmd = new OleDbCommand(updateLoginTimeQuery, connection))
                    {
                        updateLoginTimeCmd.Parameters.Add("?", OleDbType.Date).Value = DateTime.Now;
                        updateLoginTimeCmd.Parameters.Add("?", OleDbType.Integer).Value = userId;
                        updateLoginTimeCmd.ExecuteNonQuery();
                    }

                    string checkStatsQuery = "SELECT XP, [Login Streak], [Level], Rank FROM MemberDetails WHERE UserID = ?";
                    using (OleDbCommand checkStatsCmd = new OleDbCommand(checkStatsQuery, connection))
                    {
                        checkStatsCmd.Parameters.Add("?", OleDbType.Integer).Value = userId;
                        using (OleDbDataReader reader = checkStatsCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                 
                                int currentXP = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                                int currentStreak = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                                int currentLevel = reader.IsDBNull(2) ? 1 : reader.GetInt32(2);
                                string currentRank = reader.IsDBNull(3) ? "Newbie" : reader.GetString(3);

                            
                                int newXP = currentXP + 100;
                                int newStreak = currentStreak + 1;
                                (string newRank, int newLevel) = GetRankAndLevel(newXP);

                       
                                string updateStatsQuery = @"
                                    UPDATE MemberDetails 
                                    SET XP = ?,
                                        [Login Streak] = ?,
                                        [Level] = ?,
                                        Rank = ?
                                    WHERE UserID = ?";

                                using (OleDbCommand updateStatsCmd = new OleDbCommand(updateStatsQuery, connection))
                                {
                                    updateStatsCmd.Parameters.Add("?", OleDbType.Integer).Value = newXP;
                                    updateStatsCmd.Parameters.Add("?", OleDbType.Integer).Value = newStreak;
                                    updateStatsCmd.Parameters.Add("?", OleDbType.Integer).Value = newLevel;
                                    updateStatsCmd.Parameters.Add("?", OleDbType.VarChar).Value = newRank;
                                    updateStatsCmd.Parameters.Add("?", OleDbType.Integer).Value = userId;
                                    updateStatsCmd.ExecuteNonQuery();
                                }
                            }
                            else
                            {

                                string insertQuery = @"
                                    INSERT INTO MemberDetails 
                                    (UserID, Username, XP, [Login Streak], [Level], Rank, [Last Login]) 
                                    VALUES (?, ?, ?, ?, ?, ?, ?)";

                                using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, connection))
                                {
                                    insertCmd.Parameters.Add("?", OleDbType.Integer).Value = userId;
                                    insertCmd.Parameters.Add("?", OleDbType.VarChar).Value = username;
                                    insertCmd.Parameters.Add("?", OleDbType.Integer).Value = 100;
                                    insertCmd.Parameters.Add("?", OleDbType.Integer).Value = 1;
                                    insertCmd.Parameters.Add("?", OleDbType.Integer).Value = 1;
                                    insertCmd.Parameters.Add("?", OleDbType.VarChar).Value = "Newbie";
                                    insertCmd.Parameters.Add("?", OleDbType.Date).Value = DateTime.Now;
                                    insertCmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating last login and stats: {ex.Message}");
                MessageBox.Show($"Error updating user stats: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }


        public static string GetHashedPassword(string password)
        {
            return HashPassword(password);
        }
    }
}