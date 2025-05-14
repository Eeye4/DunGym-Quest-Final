using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Linq;

namespace DunGym_Quest
{
    public partial class Exercise : UserControl
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\User\Documents\DunGymQuest.accdb";
        private int currentUserId;
        private int exerciseNumber;
        private string selectedDay = "";


        public event EventHandler WorkoutSaved;

        public Exercise()
        {
            InitializeComponent();
            ExerciseGrid.CellClick += ExerciseGrid_CellClick;

            nextexbtn.Click -= nextexbtn_Click_1;
            finishexbtn.Click -= finishexbtn_Click_1;
            nextexbtn.Click += nextexbtn_Click_1;
            finishexbtn.Click += finishexbtn_Click_1;
        }

        public void SetUserId(int userId)
        {
            currentUserId = userId;
        }

        private void LoadExercises(string tableName)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    string query = $"SELECT * FROM [{tableName}]";
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ExerciseGrid.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading exercises: " + ex.Message);
            }
        }

        private void btnPLexercises_Click(object sender, EventArgs e)
        {
            LoadExercises("ExercisePL");
        }

        private void btnBBexercises_Click(object sender, EventArgs e)
        {
            LoadExercises("ExerciseBB");
        }

        private void btnWLexercises_Click(object sender, EventArgs e)
        {
            LoadExercises("ExerciseWL");
        }

        private void btnHLexercises_Click(object sender, EventArgs e)
        {
            LoadExercises("ExerciseHL");
        }

        private void ExerciseGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string exerciseText = ExerciseGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString() ?? "";
                tbxExercise.Text = exerciseText;
                exerciseNumber = e.RowIndex + 1;

                selectedDay = ExerciseGrid.Columns[e.ColumnIndex].HeaderText;
            }
        }

        private void nextexbtn_Click_1(object sender, EventArgs e)
        {
            SaveWorkout(false);
        }

        private void finishexbtn_Click_1(object sender, EventArgs e)
        {
            SaveWorkout(true);
        }

        private void SaveWorkout(bool isFinishing)
        {
            try
            {
                int sets = string.IsNullOrWhiteSpace(tbxSets.Text) ? 0 : int.Parse(tbxSets.Text);
                int reps = string.IsNullOrWhiteSpace(tbxReps.Text) ? 0 : int.Parse(tbxReps.Text);
                double weight = string.IsNullOrWhiteSpace(tbxWeights.Text) ? 0 : double.Parse(tbxWeights.Text);
                double bodyweight = string.IsNullOrWhiteSpace(tbxBodyweight.Text) ? 0 : double.Parse(tbxBodyweight.Text);

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO WorkoutLog 
                                   ([UserID], [ExerciseNumber], [ExerciseName], [Sets], [Reps/Duration], [Weight], [Bodyweight], [Notes], [Date], [DayofWeek]) 
                                   VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", currentUserId);
                        cmd.Parameters.AddWithValue("?", exerciseNumber);
                        cmd.Parameters.AddWithValue("?", tbxExercise.Text ?? "");
                        cmd.Parameters.AddWithValue("?", sets);
                        cmd.Parameters.AddWithValue("?", reps);
                        cmd.Parameters.AddWithValue("?", weight);
                        cmd.Parameters.AddWithValue("?", bodyweight);
                        cmd.Parameters.AddWithValue("?", tbxNotes.Text ?? "");
                        cmd.Parameters.AddWithValue("?", DateTime.Now.Date);
                        cmd.Parameters.AddWithValue("?", selectedDay);

                        cmd.ExecuteNonQuery();
                    }
                }


                WorkoutSaved?.Invoke(this, EventArgs.Empty);

                if (isFinishing)
                {
                    MessageBox.Show("Congratulations! You've completed your workout for today! 💪\nKeep up the great work and stay consistent!",
                                  "Workout Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (this.Parent != null)
                        this.Parent.Controls.Remove(this);
                }
                else
                {
                    MessageBox.Show("Exercise logged successfully! Ready for the next one!",
                                  "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving workout: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputFields()
        {
            tbxExercise.Clear();
            tbxSets.Clear();
            tbxReps.Clear();
            tbxWeights.Clear();
            tbxBodyweight.Clear();
            tbxNotes.Clear();
            exerciseNumber = 0; 
        }

        private void videobtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
        "Do you want to open the Google Drive link?",
        "Confirmation",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
    );

            if (result == DialogResult.Yes)
            {
                string url = "https://drive.google.com/drive/folders/1Gdvv-JNgAkBgD7-yk4EDbz7RnLbIefw-?usp=drive_link";
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
        }
    }
}
