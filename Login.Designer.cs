namespace DunGym_Quest
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            loginbtn = new Button();
            label1 = new Label();
            label2 = new Label();
            tbxUsername = new TextBox();
            tbxPassword = new TextBox();
            label3 = new Label();
            registerbtn = new Button();
            siticoneLabel4 = new SiticoneNetCoreUI.SiticoneLabel();
            SuspendLayout();
            // 
            // loginbtn
            // 
            loginbtn.BackColor = Color.SaddleBrown;
            loginbtn.Font = new Font("Palatino Linotype", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            loginbtn.ForeColor = Color.Gold;
            loginbtn.Location = new Point(74, 359);
            loginbtn.Margin = new Padding(3, 4, 3, 4);
            loginbtn.Name = "loginbtn";
            loginbtn.Size = new Size(122, 39);
            loginbtn.TabIndex = 0;
            loginbtn.Text = "LOGIN";
            loginbtn.UseVisualStyleBackColor = false;
            loginbtn.Click += loginbtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Matura MT Script Capitals", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Goldenrod;
            label1.Location = new Point(20, 84);
            label1.Name = "label1";
            label1.Size = new Size(390, 62);
            label1.TabIndex = 2;
            label1.Text = "DunGym Quest";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Lucida Console", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DarkGoldenrod;
            label2.Location = new Point(53, 235);
            label2.Name = "label2";
            label2.Size = new Size(136, 24);
            label2.TabIndex = 3;
            label2.Text = "Username:";
            // 
            // tbxUsername
            // 
            tbxUsername.BackColor = Color.DarkGoldenrod;
            tbxUsername.Location = new Point(173, 229);
            tbxUsername.Margin = new Padding(3, 4, 3, 4);
            tbxUsername.Name = "tbxUsername";
            tbxUsername.Size = new Size(187, 27);
            tbxUsername.TabIndex = 4;
            // 
            // tbxPassword
            // 
            tbxPassword.BackColor = Color.DarkGoldenrod;
            tbxPassword.Location = new Point(173, 268);
            tbxPassword.Margin = new Padding(3, 4, 3, 4);
            tbxPassword.Name = "tbxPassword";
            tbxPassword.Size = new Size(187, 27);
            tbxPassword.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Lucida Console", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DarkGoldenrod;
            label3.Location = new Point(53, 273);
            label3.Name = "label3";
            label3.Size = new Size(136, 24);
            label3.TabIndex = 5;
            label3.Text = "Password:";
            // 
            // registerbtn
            // 
            registerbtn.BackColor = Color.SaddleBrown;
            registerbtn.Font = new Font("Palatino Linotype", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            registerbtn.ForeColor = Color.Gold;
            registerbtn.Location = new Point(238, 359);
            registerbtn.Margin = new Padding(3, 4, 3, 4);
            registerbtn.Name = "registerbtn";
            registerbtn.Size = new Size(122, 39);
            registerbtn.TabIndex = 7;
            registerbtn.Text = "REGISTER";
            registerbtn.UseVisualStyleBackColor = false;
            registerbtn.Click += registerbtn_Click_1;
            // 
            // siticoneLabel4
            // 
            siticoneLabel4.BackColor = Color.Transparent;
            siticoneLabel4.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            siticoneLabel4.ForeColor = Color.White;
            siticoneLabel4.Location = new Point(222, 402);
            siticoneLabel4.Name = "siticoneLabel4";
            siticoneLabel4.Size = new Size(151, 29);
            siticoneLabel4.TabIndex = 54;
            siticoneLabel4.Text = "Don't have an account?";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(422, 547);
            Controls.Add(siticoneLabel4);
            Controls.Add(registerbtn);
            Controls.Add(tbxPassword);
            Controls.Add(label3);
            Controls.Add(tbxUsername);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(loginbtn);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button loginbtn;
        private Label label1;
        private Label label2;
        private TextBox tbxUsername;
        private TextBox tbxPassword;
        private Label label3;
        private Button registerbtn;
        private SiticoneNetCoreUI.SiticoneLabel siticoneLabel4;
    }
}
