using System;
using System.Windows.Forms;

namespace DunGym_Quest
{
    public partial class BMICalc : UserControl
    {
        private System.Windows.Forms.Timer timerPlus = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer timerMinus = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer timerWeightPlus = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer timerWeightMinus = new System.Windows.Forms.Timer();

        public BMICalc()
        {
            InitializeComponent();
            tbxAge.Text = "0";
            tbxWeight.Text = "0";

            timerPlus.Interval = 100;
            timerPlus.Tick += TimerPlus_Tick;

            timerMinus.Interval = 100;
            timerMinus.Tick += TimerMinus_Tick;

            timerWeightPlus.Interval = 100;
            timerWeightPlus.Tick += TimerWeightPlus_Tick;

            timerWeightMinus.Interval = 100;
            timerWeightMinus.Tick += TimerWeightMinus_Tick;


            btnAgeplus.MouseDown += btnAgeplus_MouseDown;
            btnAgeplus.MouseUp += btnAgeplus_MouseUp;

            btnAgeminus.MouseDown += btnAgeminus_MouseDown;
            btnAgeminus.MouseUp += btnAgeminus_MouseUp;

            btnWeightplus.MouseDown += btnWeightplus_MouseDown;
            btnWeightplus.MouseUp += btnWeightplus_MouseUp;

            btnWeightminus.MouseDown += btnWeightminus_MouseDown;
            btnWeightminus.MouseUp += btnWeightminus_MouseUp;

            sliderHeight.Maximum = 350;
            sliderHeight.Minimum = 0; 

            tbxHeight.Text = sliderHeight.Value.ToString();

            sliderHeight.ValueChanged += sliderHeight_ValueChanged;
        }

        private void btnAgeminus_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tbxAge.Text, out int age) && age > 0)
            {
                age--;
                tbxAge.Text = age.ToString("00");
            }
        }

        private void btnAgeplus_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tbxAge.Text, out int age))
            {
                age++;
                tbxAge.Text = age.ToString("00");
            }
        }

        private void btnWeightminus_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tbxWeight.Text, out int weight) && weight > 0)
            {
                weight--;
                tbxWeight.Text = weight.ToString("00");
            }
        }

        private void btnWeightplus_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tbxWeight.Text, out int weight))
            {
                weight++;
                tbxWeight.Text = weight.ToString("00");
            }
        }

        private void TimerPlus_Tick(object sender, EventArgs e)
        {
            btnAgeplus_Click(null, null);
        }

        private void TimerMinus_Tick(object sender, EventArgs e)
        {
            btnAgeminus_Click(null, null);
        }

        private void TimerWeightPlus_Tick(object sender, EventArgs e)
        {
            btnWeightplus_Click(null, null);
        }

        private void TimerWeightMinus_Tick(object sender, EventArgs e)
        {
            btnWeightminus_Click(null, null);
        }

        private void btnAgeminus_MouseDown(object sender, MouseEventArgs e)
        {
            timerMinus.Start();
        }

        private void btnAgeplus_MouseDown(object sender, MouseEventArgs e)
        {
            timerPlus.Start();
        }

        private void btnAgeminus_MouseUp(object sender, MouseEventArgs e)
        {
            timerMinus.Stop();
        }

        private void btnAgeplus_MouseUp(object sender, MouseEventArgs e)
        {
            timerPlus.Stop();
        }

        private void btnWeightminus_MouseDown(object sender, MouseEventArgs e)
        {
            timerWeightMinus.Start();
        }

        private void btnWeightplus_MouseDown(object sender, MouseEventArgs e)
        {
            timerWeightPlus.Start();
        }

        private void btnWeightminus_MouseUp(object sender, MouseEventArgs e)
        {
            timerWeightMinus.Stop();
        }

        private void btnWeightplus_MouseUp(object sender, MouseEventArgs e)
        {
            timerWeightPlus.Stop();
        }

        private void sliderHeight_ValueChanged(object sender, EventArgs e)
        {
            tbxHeight.Text = sliderHeight.Value.ToString();
        }

        private void btnCalculatebmi_Click(object sender, EventArgs e)
        {
            if (double.TryParse(tbxWeight.Text, out double weight) &&
                double.TryParse(tbxHeight.Text, out double height) && height > 0)
            {
                double bmi = weight / ((height / 100) * (height / 100));

                tbxBmiresult.Text = bmi.ToString("0.00");

                // Determine BMI classification
                if (bmi < 18.5)
                {
                    tbxBmiclassification.Text = "Underweight";
                }
                else if (bmi >= 18.5 && bmi < 24.9)
                {
                    tbxBmiclassification.Text = "Normal weight";
                }
                else if (bmi >= 24.9 && bmi < 29.9)
                {
                    tbxBmiclassification.Text = "Overweight";
                }
                else if (bmi >= 29.0 && bmi < 34.9)
                {
                    tbxBmiclassification.Text = "Obese I";
                }
                else
                {
                    tbxBmiclassification.Text = "Obese II";
                }
            }
            else
            {

                MessageBox.Show("Please enter valid numeric values for Weight and Height.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
