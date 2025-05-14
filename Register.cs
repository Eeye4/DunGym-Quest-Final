using System;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Drawing;

namespace DunGym_Quest
{
    public partial class Register : Form
    {
        private string selectedPhotoPath = null;
        private readonly string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\User\Documents\DunGymQuest.accdb";

        public Register()
        {
            InitializeComponent();
            tbxPassword.PasswordChar = '*';
            tbxVerifypass.PasswordChar = '*';
            

            tbxPassword.TextChanged += VerifyPasswords;
            tbxVerifypass.TextChanged += VerifyPasswords;
        }

        private void VerifyPasswords(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxPassword.Text) || string.IsNullOrEmpty(tbxVerifypass.Text))
            {
                verifylbl.Text = "";
                return;
            }

            if (tbxPassword.Text == tbxVerifypass.Text)
            {
                verifylbl.Text = "Password matched";
                verifylbl.ForeColor = Color.Green;
            }
            else
            {
                verifylbl.Text = "Password does not match";
                verifylbl.ForeColor = Color.Red;
            }
        }

        private void signinbtn_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void registerbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxUsername.Text) ||
                string.IsNullOrWhiteSpace(tbxPassword.Text) ||
                string.IsNullOrWhiteSpace(tbxFname.Text) ||
                string.IsNullOrWhiteSpace(tbxLname.Text) ||
                string.IsNullOrWhiteSpace(tbxAge.Text) ||
                string.IsNullOrWhiteSpace(tbxWeight.Text) ||
                string.IsNullOrWhiteSpace(tbxHeight.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!rdbMale.Checked && !rdbFemale.Checked)
            {
                MessageBox.Show("Please select a gender.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbxPassword.Text != tbxVerifypass.Text)
            {
                MessageBox.Show("Passwords do not match. Please verify your password.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbxPassword.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM MemberDetails WHERE Username = ?";
                    using (OleDbCommand checkCmd = new OleDbCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("?", tbxUsername.Text);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("Username already exists. Please choose a different username.",
                                "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }


                    string hashedPassword = Login.GetHashedPassword(tbxPassword.Text);


                    string query = "INSERT INTO MemberDetails ([Username], [Password], [First Name], [Last Name], [Age], " +
               "[Birthdate], [Gender], [Weight], [Height], [Registration Date], [Last Login], [Profile]) " +
               "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {

                        string gender = rdbMale.Checked ? "Male" : "Female";


                        int age;
                        double weight, height;

                        if (!int.TryParse(tbxAge.Text, out age))
                        {
                            MessageBox.Show("Please enter a valid age.", "Input Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (!double.TryParse(tbxWeight.Text, out weight))
                        {
                            MessageBox.Show("Please enter a valid weight.", "Input Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (!double.TryParse(tbxHeight.Text, out height))
                        {
                            MessageBox.Show("Please enter a valid height.", "Input Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        cmd.Parameters.AddWithValue("?", tbxUsername.Text);
                        cmd.Parameters.AddWithValue("?", hashedPassword);
                        cmd.Parameters.AddWithValue("?", tbxFname.Text);
                        cmd.Parameters.AddWithValue("?", tbxLname.Text);
                        cmd.Parameters.AddWithValue("?", age);
                        cmd.Parameters.AddWithValue("?", dtpBday.Value.Date);
                        cmd.Parameters.AddWithValue("?", gender);
                        cmd.Parameters.AddWithValue("?", weight);
                        cmd.Parameters.AddWithValue("?", height);
                        cmd.Parameters.AddWithValue("?", DateTime.Now.Date);
                        cmd.Parameters.AddWithValue("?", DBNull.Value);
                        cmd.Parameters.AddWithValue("?", string.IsNullOrEmpty(selectedPhotoPath) ? "" : selectedPhotoPath);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Registration Successful! You can now log in.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);


                    Login login = new Login();
                    this.Hide();
                    login.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void photoupload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Profile Picture";
            ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                photoupload.Image = Image.FromFile(ofd.FileName);
                photoupload.BackgroundImageLayout = ImageLayout.Stretch;
                selectedPhotoPath = ofd.FileName; 
            }
        }
    }
}