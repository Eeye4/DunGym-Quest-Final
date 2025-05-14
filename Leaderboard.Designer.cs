namespace DunGym_Quest
{
    partial class Leaderboard
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Leaderboard));
            Leaderboardpanel = new SiticoneNetCoreUI.SiticonePanel();
            tbxLboard = new SiticoneNetCoreUI.SiticoneTextBox();
            btnPLleaderboard = new SiticoneNetCoreUI.SiticoneButton();
            btnHLleaderboard = new SiticoneNetCoreUI.SiticoneButton();
            btnWLleaderboard = new SiticoneNetCoreUI.SiticoneButton();
            btnBBleaderboard = new SiticoneNetCoreUI.SiticoneButton();
            datagridLeaderboard = new DataGridView();
            panel2 = new Panel();
            siticonePanel2 = new SiticoneNetCoreUI.SiticonePanel();
            label2 = new Label();
            siticonePictureBox1 = new SiticoneNetCoreUI.SiticonePictureBox();
            Leaderboardpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)datagridLeaderboard).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // Leaderboardpanel
            // 
            Leaderboardpanel.AcrylicTintColor = Color.FromArgb(128, 255, 255, 255);
            Leaderboardpanel.BackColor = Color.Transparent;
            Leaderboardpanel.BorderAlignment = System.Drawing.Drawing2D.PenAlignment.Center;
            Leaderboardpanel.BorderDashPattern = null;
            Leaderboardpanel.BorderGradientEndColor = Color.Purple;
            Leaderboardpanel.BorderGradientStartColor = Color.Blue;
            Leaderboardpanel.BorderThickness = 2F;
            Leaderboardpanel.Controls.Add(tbxLboard);
            Leaderboardpanel.Controls.Add(btnPLleaderboard);
            Leaderboardpanel.Controls.Add(btnHLleaderboard);
            Leaderboardpanel.Controls.Add(btnWLleaderboard);
            Leaderboardpanel.Controls.Add(btnBBleaderboard);
            Leaderboardpanel.Controls.Add(datagridLeaderboard);
            Leaderboardpanel.Controls.Add(panel2);
            Leaderboardpanel.CornerRadiusBottomLeft = 10F;
            Leaderboardpanel.CornerRadiusBottomRight = 10F;
            Leaderboardpanel.CornerRadiusTopLeft = 10F;
            Leaderboardpanel.CornerRadiusTopRight = 10F;
            Leaderboardpanel.Dock = DockStyle.Fill;
            Leaderboardpanel.EnableAcrylicEffect = false;
            Leaderboardpanel.EnableMicaEffect = false;
            Leaderboardpanel.EnableRippleEffect = false;
            Leaderboardpanel.FillColor = Color.Cornsilk;
            Leaderboardpanel.GradientColors = new Color[]
    {
    Color.White,
    Color.LightGray,
    Color.Gray
    };
            Leaderboardpanel.GradientPositions = new float[]
    {
    0F,
    0.5F,
    1F
    };
            Leaderboardpanel.Location = new Point(0, 0);
            Leaderboardpanel.Name = "Leaderboardpanel";
            Leaderboardpanel.PatternStyle = System.Drawing.Drawing2D.HatchStyle.Max;
            Leaderboardpanel.RippleAlpha = 50;
            Leaderboardpanel.RippleAlphaDecrement = 3;
            Leaderboardpanel.RippleColor = Color.FromArgb(50, 255, 255, 255);
            Leaderboardpanel.RippleMaxSize = 600F;
            Leaderboardpanel.RippleSpeed = 15F;
            Leaderboardpanel.ShowBorder = true;
            Leaderboardpanel.Size = new Size(768, 683);
            Leaderboardpanel.TabIndex = 0;
            Leaderboardpanel.TabStop = true;
            Leaderboardpanel.UseBorderGradient = false;
            Leaderboardpanel.UseMultiGradient = false;
            Leaderboardpanel.UsePatternTexture = false;
            Leaderboardpanel.UseRadialGradient = false;
            // 
            // tbxLboard
            // 
            tbxLboard.AccessibleDescription = "A customizable text input field.";
            tbxLboard.AccessibleName = "Text Box";
            tbxLboard.AccessibleRole = AccessibleRole.Text;
            tbxLboard.BackColor = Color.Transparent;
            tbxLboard.BlinkCount = 3;
            tbxLboard.BlinkShadow = false;
            tbxLboard.BorderColor1 = Color.Transparent;
            tbxLboard.BorderColor2 = Color.Transparent;
            tbxLboard.BorderFocusColor1 = Color.FromArgb(77, 77, 255);
            tbxLboard.BorderFocusColor2 = Color.FromArgb(77, 77, 255);
            tbxLboard.CanShake = true;
            tbxLboard.ContinuousBlink = false;
            tbxLboard.CursorBlinkRate = 500;
            tbxLboard.CursorColor = Color.Black;
            tbxLboard.CursorHeight = 26;
            tbxLboard.CursorOffset = 0;
            tbxLboard.CursorStyle = SiticoneNetCoreUI.Helpers.DrawingStyle.SiticoneDrawingStyle.Solid;
            tbxLboard.CursorWidth = 1;
            tbxLboard.DisabledBackColor = Color.Transparent;
            tbxLboard.DisabledBorderColor = Color.Transparent;
            tbxLboard.DisabledTextColor = Color.Transparent;
            tbxLboard.EnableDropShadow = false;
            tbxLboard.FillColor1 = Color.Transparent;
            tbxLboard.FillColor2 = Color.Transparent;
            tbxLboard.Font = new Font("Palatino Linotype", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbxLboard.ForeColor = Color.FromArgb(204, 88, 3);
            tbxLboard.HoverBorderColor1 = Color.Gray;
            tbxLboard.HoverBorderColor2 = Color.Gray;
            tbxLboard.IsEnabled = true;
            tbxLboard.IsReadOnly = true;
            tbxLboard.Location = new Point(54, 85);
            tbxLboard.Name = "tbxLboard";
            tbxLboard.PlaceholderColor = Color.Gray;
            tbxLboard.PlaceholderText = "Leaderboard";
            tbxLboard.ReadOnlyBorderColor1 = Color.LightGray;
            tbxLboard.ReadOnlyBorderColor2 = Color.LightGray;
            tbxLboard.ReadOnlyFillColor1 = Color.Transparent;
            tbxLboard.ReadOnlyFillColor2 = Color.Transparent;
            tbxLboard.ReadOnlyPlaceholderColor = Color.DarkGray;
            tbxLboard.SelectionBackColor = Color.FromArgb(77, 77, 255);
            tbxLboard.ShadowAnimationDuration = 1;
            tbxLboard.ShadowBlur = 10;
            tbxLboard.ShadowColor = Color.FromArgb(15, 0, 0, 0);
            tbxLboard.ShowBorder = false;
            tbxLboard.Size = new Size(659, 36);
            tbxLboard.SolidBorderColor = Color.LightSlateGray;
            tbxLboard.SolidBorderFocusColor = Color.FromArgb(77, 77, 255);
            tbxLboard.SolidBorderHoverColor = Color.Gray;
            tbxLboard.SolidFillColor = Color.Transparent;
            tbxLboard.TabIndex = 78;
            tbxLboard.Text = "Leaderboards";
            tbxLboard.TextAlign = SiticoneNetCoreUI.Helpers.Text.TextAlignment.Center;
            tbxLboard.TextPadding = new Padding(16, 0, 6, 0);
            tbxLboard.ValidationErrorMessage = "Invalid input.";
            tbxLboard.ValidationFunction = null;
            // 
            // btnPLleaderboard
            // 
            btnPLleaderboard.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btnPLleaderboard.AccessibleName = "Powerlifting";
            btnPLleaderboard.AutoSizeBasedOnText = false;
            btnPLleaderboard.BackColor = Color.Transparent;
            btnPLleaderboard.BadgeBackColor = Color.RebeccaPurple;
            btnPLleaderboard.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnPLleaderboard.BadgeValue = 0;
            btnPLleaderboard.BadgeValueForeColor = Color.White;
            btnPLleaderboard.BorderColor = Color.FromArgb(204, 88, 3);
            btnPLleaderboard.BorderWidth = 2;
            btnPLleaderboard.ButtonBackColor = Color.Gainsboro;
            btnPLleaderboard.ButtonImage = null;
            btnPLleaderboard.CanBeep = true;
            btnPLleaderboard.CanGlow = false;
            btnPLleaderboard.CanShake = true;
            btnPLleaderboard.ContextMenuStripEx = null;
            btnPLleaderboard.CornerRadiusBottomLeft = 8;
            btnPLleaderboard.CornerRadiusBottomRight = 8;
            btnPLleaderboard.CornerRadiusTopLeft = 8;
            btnPLleaderboard.CornerRadiusTopRight = 8;
            btnPLleaderboard.CustomCursor = Cursors.Default;
            btnPLleaderboard.DisabledTextColor = Color.White;
            btnPLleaderboard.EnableLongPress = false;
            btnPLleaderboard.EnablePressAnimation = true;
            btnPLleaderboard.EnableRippleEffect = true;
            btnPLleaderboard.EnableShadow = false;
            btnPLleaderboard.EnableTextWrapping = false;
            btnPLleaderboard.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPLleaderboard.ForeColor = Color.FromArgb(204, 88, 3);
            btnPLleaderboard.GlowColor = Color.FromArgb(100, 255, 255, 255);
            btnPLleaderboard.GlowIntensity = 100;
            btnPLleaderboard.GlowRadius = 20F;
            btnPLleaderboard.GradientBackground = false;
            btnPLleaderboard.GradientColor = Color.FromArgb(114, 168, 255);
            btnPLleaderboard.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btnPLleaderboard.HintText = null;
            btnPLleaderboard.HoverBackColor = Color.Gainsboro;
            btnPLleaderboard.HoverFontStyle = FontStyle.Regular;
            btnPLleaderboard.HoverTextColor = Color.White;
            btnPLleaderboard.HoverTransitionDuration = 250;
            btnPLleaderboard.ImageAlign = ContentAlignment.MiddleLeft;
            btnPLleaderboard.ImagePadding = 5;
            btnPLleaderboard.ImageSize = new Size(16, 16);
            btnPLleaderboard.IsRadial = false;
            btnPLleaderboard.IsReadOnly = false;
            btnPLleaderboard.IsToggleButton = false;
            btnPLleaderboard.IsToggled = false;
            btnPLleaderboard.Location = new Point(69, 127);
            btnPLleaderboard.LongPressDurationMS = 1000;
            btnPLleaderboard.Name = "btnPLleaderboard";
            btnPLleaderboard.NormalFontStyle = FontStyle.Regular;
            btnPLleaderboard.ParticleColor = Color.FromArgb(200, 200, 200);
            btnPLleaderboard.ParticleCount = 15;
            btnPLleaderboard.PressAnimationScale = 0.97F;
            btnPLleaderboard.PressedBackColor = Color.FromArgb(204, 88, 3);
            btnPLleaderboard.PressedFontStyle = FontStyle.Regular;
            btnPLleaderboard.PressTransitionDuration = 150;
            btnPLleaderboard.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btnPLleaderboard.RippleColor = Color.FromArgb(255, 255, 255);
            btnPLleaderboard.RippleOpacity = 0.3F;
            btnPLleaderboard.RippleRadiusMultiplier = 0.6F;
            btnPLleaderboard.ShadowBlur = 5;
            btnPLleaderboard.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btnPLleaderboard.ShadowOffset = new Point(2, 2);
            btnPLleaderboard.ShakeDuration = 500;
            btnPLleaderboard.ShakeIntensity = 5;
            btnPLleaderboard.Size = new Size(147, 36);
            btnPLleaderboard.TabIndex = 77;
            btnPLleaderboard.Text = "Powerlifting";
            btnPLleaderboard.TextAlign = ContentAlignment.MiddleCenter;
            btnPLleaderboard.TextColor = Color.FromArgb(204, 88, 3);
            btnPLleaderboard.TooltipText = null;
            btnPLleaderboard.UseAdvancedRendering = true;
            btnPLleaderboard.UseParticles = false;
            btnPLleaderboard.Click += btnPLleaderboard_Click;
            // 
            // btnHLleaderboard
            // 
            btnHLleaderboard.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btnHLleaderboard.AccessibleName = "Healthy Living";
            btnHLleaderboard.AutoSizeBasedOnText = false;
            btnHLleaderboard.BackColor = Color.Transparent;
            btnHLleaderboard.BadgeBackColor = Color.RebeccaPurple;
            btnHLleaderboard.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnHLleaderboard.BadgeValue = 0;
            btnHLleaderboard.BadgeValueForeColor = Color.White;
            btnHLleaderboard.BorderColor = Color.FromArgb(204, 88, 3);
            btnHLleaderboard.BorderWidth = 2;
            btnHLleaderboard.ButtonBackColor = Color.Gainsboro;
            btnHLleaderboard.ButtonImage = null;
            btnHLleaderboard.CanBeep = true;
            btnHLleaderboard.CanGlow = false;
            btnHLleaderboard.CanShake = true;
            btnHLleaderboard.ContextMenuStripEx = null;
            btnHLleaderboard.CornerRadiusBottomLeft = 8;
            btnHLleaderboard.CornerRadiusBottomRight = 8;
            btnHLleaderboard.CornerRadiusTopLeft = 8;
            btnHLleaderboard.CornerRadiusTopRight = 8;
            btnHLleaderboard.CustomCursor = Cursors.Default;
            btnHLleaderboard.DisabledTextColor = Color.White;
            btnHLleaderboard.EnableLongPress = false;
            btnHLleaderboard.EnablePressAnimation = true;
            btnHLleaderboard.EnableRippleEffect = true;
            btnHLleaderboard.EnableShadow = false;
            btnHLleaderboard.EnableTextWrapping = false;
            btnHLleaderboard.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHLleaderboard.ForeColor = Color.White;
            btnHLleaderboard.GlowColor = Color.FromArgb(100, 255, 255, 255);
            btnHLleaderboard.GlowIntensity = 100;
            btnHLleaderboard.GlowRadius = 20F;
            btnHLleaderboard.GradientBackground = false;
            btnHLleaderboard.GradientColor = Color.FromArgb(114, 168, 255);
            btnHLleaderboard.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btnHLleaderboard.HintText = null;
            btnHLleaderboard.HoverBackColor = Color.FromArgb(204, 88, 3);
            btnHLleaderboard.HoverFontStyle = FontStyle.Regular;
            btnHLleaderboard.HoverTextColor = Color.White;
            btnHLleaderboard.HoverTransitionDuration = 250;
            btnHLleaderboard.ImageAlign = ContentAlignment.MiddleLeft;
            btnHLleaderboard.ImagePadding = 5;
            btnHLleaderboard.ImageSize = new Size(16, 16);
            btnHLleaderboard.IsRadial = false;
            btnHLleaderboard.IsReadOnly = false;
            btnHLleaderboard.IsToggleButton = false;
            btnHLleaderboard.IsToggled = false;
            btnHLleaderboard.Location = new Point(531, 127);
            btnHLleaderboard.LongPressDurationMS = 1000;
            btnHLleaderboard.Name = "btnHLleaderboard";
            btnHLleaderboard.NormalFontStyle = FontStyle.Regular;
            btnHLleaderboard.ParticleColor = Color.FromArgb(200, 200, 200);
            btnHLleaderboard.ParticleCount = 15;
            btnHLleaderboard.PressAnimationScale = 0.97F;
            btnHLleaderboard.PressedBackColor = Color.FromArgb(204, 88, 3);
            btnHLleaderboard.PressedFontStyle = FontStyle.Regular;
            btnHLleaderboard.PressTransitionDuration = 150;
            btnHLleaderboard.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btnHLleaderboard.RippleColor = Color.FromArgb(255, 255, 255);
            btnHLleaderboard.RippleOpacity = 0.3F;
            btnHLleaderboard.RippleRadiusMultiplier = 0.6F;
            btnHLleaderboard.ShadowBlur = 5;
            btnHLleaderboard.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btnHLleaderboard.ShadowOffset = new Point(2, 2);
            btnHLleaderboard.ShakeDuration = 500;
            btnHLleaderboard.ShakeIntensity = 5;
            btnHLleaderboard.Size = new Size(147, 36);
            btnHLleaderboard.TabIndex = 76;
            btnHLleaderboard.Text = "Healthy Living";
            btnHLleaderboard.TextAlign = ContentAlignment.MiddleCenter;
            btnHLleaderboard.TextColor = Color.FromArgb(204, 88, 3);
            btnHLleaderboard.TooltipText = null;
            btnHLleaderboard.UseAdvancedRendering = true;
            btnHLleaderboard.UseParticles = false;
            btnHLleaderboard.Click += btnHLleaderboard_Click;
            // 
            // btnWLleaderboard
            // 
            btnWLleaderboard.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btnWLleaderboard.AccessibleName = "Weight Loss";
            btnWLleaderboard.AutoSizeBasedOnText = false;
            btnWLleaderboard.BackColor = Color.Transparent;
            btnWLleaderboard.BadgeBackColor = Color.RebeccaPurple;
            btnWLleaderboard.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnWLleaderboard.BadgeValue = 0;
            btnWLleaderboard.BadgeValueForeColor = Color.White;
            btnWLleaderboard.BorderColor = Color.FromArgb(204, 88, 3);
            btnWLleaderboard.BorderWidth = 2;
            btnWLleaderboard.ButtonBackColor = Color.Gainsboro;
            btnWLleaderboard.ButtonImage = null;
            btnWLleaderboard.CanBeep = true;
            btnWLleaderboard.CanGlow = false;
            btnWLleaderboard.CanShake = true;
            btnWLleaderboard.ContextMenuStripEx = null;
            btnWLleaderboard.CornerRadiusBottomLeft = 8;
            btnWLleaderboard.CornerRadiusBottomRight = 8;
            btnWLleaderboard.CornerRadiusTopLeft = 8;
            btnWLleaderboard.CornerRadiusTopRight = 8;
            btnWLleaderboard.CustomCursor = Cursors.Default;
            btnWLleaderboard.DisabledTextColor = Color.White;
            btnWLleaderboard.EnableLongPress = false;
            btnWLleaderboard.EnablePressAnimation = true;
            btnWLleaderboard.EnableRippleEffect = true;
            btnWLleaderboard.EnableShadow = false;
            btnWLleaderboard.EnableTextWrapping = false;
            btnWLleaderboard.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnWLleaderboard.ForeColor = Color.White;
            btnWLleaderboard.GlowColor = Color.FromArgb(100, 255, 255, 255);
            btnWLleaderboard.GlowIntensity = 100;
            btnWLleaderboard.GlowRadius = 20F;
            btnWLleaderboard.GradientBackground = false;
            btnWLleaderboard.GradientColor = Color.FromArgb(114, 168, 255);
            btnWLleaderboard.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btnWLleaderboard.HintText = null;
            btnWLleaderboard.HoverBackColor = Color.FromArgb(204, 88, 3);
            btnWLleaderboard.HoverFontStyle = FontStyle.Regular;
            btnWLleaderboard.HoverTextColor = Color.White;
            btnWLleaderboard.HoverTransitionDuration = 250;
            btnWLleaderboard.ImageAlign = ContentAlignment.MiddleLeft;
            btnWLleaderboard.ImagePadding = 5;
            btnWLleaderboard.ImageSize = new Size(16, 16);
            btnWLleaderboard.IsRadial = false;
            btnWLleaderboard.IsReadOnly = false;
            btnWLleaderboard.IsToggleButton = false;
            btnWLleaderboard.IsToggled = false;
            btnWLleaderboard.Location = new Point(378, 127);
            btnWLleaderboard.LongPressDurationMS = 1000;
            btnWLleaderboard.Name = "btnWLleaderboard";
            btnWLleaderboard.NormalFontStyle = FontStyle.Regular;
            btnWLleaderboard.ParticleColor = Color.FromArgb(200, 200, 200);
            btnWLleaderboard.ParticleCount = 15;
            btnWLleaderboard.PressAnimationScale = 0.97F;
            btnWLleaderboard.PressedBackColor = Color.FromArgb(204, 88, 3);
            btnWLleaderboard.PressedFontStyle = FontStyle.Regular;
            btnWLleaderboard.PressTransitionDuration = 150;
            btnWLleaderboard.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btnWLleaderboard.RippleColor = Color.FromArgb(255, 255, 255);
            btnWLleaderboard.RippleOpacity = 0.3F;
            btnWLleaderboard.RippleRadiusMultiplier = 0.6F;
            btnWLleaderboard.ShadowBlur = 5;
            btnWLleaderboard.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btnWLleaderboard.ShadowOffset = new Point(2, 2);
            btnWLleaderboard.ShakeDuration = 500;
            btnWLleaderboard.ShakeIntensity = 5;
            btnWLleaderboard.Size = new Size(147, 36);
            btnWLleaderboard.TabIndex = 75;
            btnWLleaderboard.Text = "Weight Loss";
            btnWLleaderboard.TextAlign = ContentAlignment.MiddleCenter;
            btnWLleaderboard.TextColor = Color.FromArgb(204, 88, 3);
            btnWLleaderboard.TooltipText = null;
            btnWLleaderboard.UseAdvancedRendering = true;
            btnWLleaderboard.UseParticles = false;
            btnWLleaderboard.Click += btnWLleaderboard_Click;
            // 
            // btnBBleaderboard
            // 
            btnBBleaderboard.AccessibleDescription = "The default button control that accept input though the mouse, touch and keyboard";
            btnBBleaderboard.AccessibleName = "Bodybuilding";
            btnBBleaderboard.AutoSizeBasedOnText = false;
            btnBBleaderboard.BackColor = Color.Transparent;
            btnBBleaderboard.BadgeBackColor = Color.RebeccaPurple;
            btnBBleaderboard.BadgeFont = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnBBleaderboard.BadgeValue = 0;
            btnBBleaderboard.BadgeValueForeColor = Color.White;
            btnBBleaderboard.BorderColor = Color.FromArgb(204, 88, 3);
            btnBBleaderboard.BorderWidth = 2;
            btnBBleaderboard.ButtonBackColor = Color.Gainsboro;
            btnBBleaderboard.ButtonImage = null;
            btnBBleaderboard.CanBeep = true;
            btnBBleaderboard.CanGlow = false;
            btnBBleaderboard.CanShake = true;
            btnBBleaderboard.ContextMenuStripEx = null;
            btnBBleaderboard.CornerRadiusBottomLeft = 8;
            btnBBleaderboard.CornerRadiusBottomRight = 8;
            btnBBleaderboard.CornerRadiusTopLeft = 8;
            btnBBleaderboard.CornerRadiusTopRight = 8;
            btnBBleaderboard.CustomCursor = Cursors.Default;
            btnBBleaderboard.DisabledTextColor = Color.White;
            btnBBleaderboard.EnableLongPress = false;
            btnBBleaderboard.EnablePressAnimation = true;
            btnBBleaderboard.EnableRippleEffect = true;
            btnBBleaderboard.EnableShadow = false;
            btnBBleaderboard.EnableTextWrapping = false;
            btnBBleaderboard.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBBleaderboard.ForeColor = Color.White;
            btnBBleaderboard.GlowColor = Color.FromArgb(100, 255, 255, 255);
            btnBBleaderboard.GlowIntensity = 100;
            btnBBleaderboard.GlowRadius = 20F;
            btnBBleaderboard.GradientBackground = false;
            btnBBleaderboard.GradientColor = Color.FromArgb(114, 168, 255);
            btnBBleaderboard.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            btnBBleaderboard.HintText = null;
            btnBBleaderboard.HoverBackColor = Color.FromArgb(204, 88, 3);
            btnBBleaderboard.HoverFontStyle = FontStyle.Regular;
            btnBBleaderboard.HoverTextColor = Color.White;
            btnBBleaderboard.HoverTransitionDuration = 250;
            btnBBleaderboard.ImageAlign = ContentAlignment.MiddleLeft;
            btnBBleaderboard.ImagePadding = 5;
            btnBBleaderboard.ImageSize = new Size(16, 16);
            btnBBleaderboard.IsRadial = false;
            btnBBleaderboard.IsReadOnly = false;
            btnBBleaderboard.IsToggleButton = false;
            btnBBleaderboard.IsToggled = false;
            btnBBleaderboard.Location = new Point(222, 127);
            btnBBleaderboard.LongPressDurationMS = 1000;
            btnBBleaderboard.Name = "btnBBleaderboard";
            btnBBleaderboard.NormalFontStyle = FontStyle.Regular;
            btnBBleaderboard.ParticleColor = Color.FromArgb(200, 200, 200);
            btnBBleaderboard.ParticleCount = 15;
            btnBBleaderboard.PressAnimationScale = 0.97F;
            btnBBleaderboard.PressedBackColor = Color.FromArgb(204, 88, 3);
            btnBBleaderboard.PressedFontStyle = FontStyle.Regular;
            btnBBleaderboard.PressTransitionDuration = 150;
            btnBBleaderboard.ReadOnlyTextColor = Color.FromArgb(100, 100, 100);
            btnBBleaderboard.RippleColor = Color.FromArgb(255, 255, 255);
            btnBBleaderboard.RippleOpacity = 0.3F;
            btnBBleaderboard.RippleRadiusMultiplier = 0.6F;
            btnBBleaderboard.ShadowBlur = 5;
            btnBBleaderboard.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            btnBBleaderboard.ShadowOffset = new Point(2, 2);
            btnBBleaderboard.ShakeDuration = 500;
            btnBBleaderboard.ShakeIntensity = 5;
            btnBBleaderboard.Size = new Size(147, 36);
            btnBBleaderboard.TabIndex = 74;
            btnBBleaderboard.Text = "Bodybuilding";
            btnBBleaderboard.TextAlign = ContentAlignment.MiddleCenter;
            btnBBleaderboard.TextColor = Color.FromArgb(204, 88, 3);
            btnBBleaderboard.TooltipText = null;
            btnBBleaderboard.UseAdvancedRendering = true;
            btnBBleaderboard.UseParticles = false;
            btnBBleaderboard.Click += btnBBleaderboard_Click;
            // 
            // datagridLeaderboard
            // 
            datagridLeaderboard.AllowUserToAddRows = false;
            datagridLeaderboard.AllowUserToDeleteRows = false;
            datagridLeaderboard.AllowUserToResizeColumns = false;
            datagridLeaderboard.AllowUserToResizeRows = false;
            datagridLeaderboard.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            datagridLeaderboard.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            datagridLeaderboard.BackgroundColor = Color.White;
            datagridLeaderboard.ColumnHeadersHeight = 29;
            datagridLeaderboard.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Palatino Linotype", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            datagridLeaderboard.DefaultCellStyle = dataGridViewCellStyle1;
            datagridLeaderboard.GridColor = Color.Black;
            datagridLeaderboard.Location = new Point(54, 169);
            datagridLeaderboard.Name = "datagridLeaderboard";
            datagridLeaderboard.ReadOnly = true;
            datagridLeaderboard.RowHeadersWidth = 51;
            datagridLeaderboard.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            datagridLeaderboard.Size = new Size(659, 483);
            datagridLeaderboard.TabIndex = 73;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(siticonePanel2);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(siticonePictureBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(768, 67);
            panel2.TabIndex = 72;
            // 
            // siticonePanel2
            // 
            siticonePanel2.AcrylicTintColor = Color.FromArgb(128, 255, 255, 255);
            siticonePanel2.BackColor = Color.Transparent;
            siticonePanel2.BorderAlignment = System.Drawing.Drawing2D.PenAlignment.Center;
            siticonePanel2.BorderDashPattern = null;
            siticonePanel2.BorderGradientEndColor = Color.Purple;
            siticonePanel2.BorderGradientStartColor = Color.Blue;
            siticonePanel2.BorderThickness = 2F;
            siticonePanel2.CornerRadiusBottomLeft = 10F;
            siticonePanel2.CornerRadiusBottomRight = 10F;
            siticonePanel2.CornerRadiusTopLeft = 10F;
            siticonePanel2.CornerRadiusTopRight = 10F;
            siticonePanel2.EnableAcrylicEffect = false;
            siticonePanel2.EnableMicaEffect = false;
            siticonePanel2.EnableRippleEffect = false;
            siticonePanel2.FillColor = Color.White;
            siticonePanel2.GradientColors = new Color[]
    {
    Color.White,
    Color.LightGray,
    Color.Gray
    };
            siticonePanel2.GradientPositions = new float[]
    {
    0F,
    0.5F,
    1F
    };
            siticonePanel2.Location = new Point(5, 67);
            siticonePanel2.Margin = new Padding(3, 4, 3, 4);
            siticonePanel2.Name = "siticonePanel2";
            siticonePanel2.PatternStyle = System.Drawing.Drawing2D.HatchStyle.Max;
            siticonePanel2.RippleAlpha = 50;
            siticonePanel2.RippleAlphaDecrement = 3;
            siticonePanel2.RippleColor = Color.FromArgb(50, 255, 255, 255);
            siticonePanel2.RippleMaxSize = 600F;
            siticonePanel2.RippleSpeed = 15F;
            siticonePanel2.ShowBorder = true;
            siticonePanel2.Size = new Size(688, 575);
            siticonePanel2.TabIndex = 6;
            siticonePanel2.TabStop = true;
            siticonePanel2.UseBorderGradient = false;
            siticonePanel2.UseMultiGradient = false;
            siticonePanel2.UsePatternTexture = false;
            siticonePanel2.UseRadialGradient = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Lucida Fax", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(5, 16);
            label2.Name = "label2";
            label2.Size = new Size(209, 32);
            label2.TabIndex = 16;
            label2.Text = "Leaderboards";
            // 
            // siticonePictureBox1
            // 
            siticonePictureBox1.BackColor = Color.Transparent;
            siticonePictureBox1.BackgroundImage = Properties.Resources._3;
            siticonePictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            siticonePictureBox1.BorderColor = Color.Black;
            siticonePictureBox1.BorderWidth = 1;
            siticonePictureBox1.Brightness = 1F;
            siticonePictureBox1.Contrast = 1F;
            siticonePictureBox1.CornerRadius = 0;
            siticonePictureBox1.DraggingSpeed = 3.15F;
            siticonePictureBox1.EnableAsyncLoading = false;
            siticonePictureBox1.EnableCaching = false;
            siticonePictureBox1.EnableDragDrop = false;
            siticonePictureBox1.EnableExtendedImageSources = false;
            siticonePictureBox1.EnableFilters = false;
            siticonePictureBox1.EnableFlipping = false;
            siticonePictureBox1.EnableGlow = false;
            siticonePictureBox1.EnableHighDpiSupport = false;
            siticonePictureBox1.EnableMouseInteraction = false;
            siticonePictureBox1.EnablePlaceholder = false;
            siticonePictureBox1.EnableRotation = false;
            siticonePictureBox1.EnableShadow = false;
            siticonePictureBox1.EnableSlideshow = false;
            siticonePictureBox1.FlipHorizontal = false;
            siticonePictureBox1.FlipVertical = false;
            siticonePictureBox1.Grayscale = false;
            siticonePictureBox1.Image = null;
            siticonePictureBox1.ImageOpacity = 1F;
            siticonePictureBox1.Images = (List<Image>)resources.GetObject("siticonePictureBox1.Images");
            siticonePictureBox1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            siticonePictureBox1.IsCircular = false;
            siticonePictureBox1.Location = new Point(205, 4);
            siticonePictureBox1.MaintainAspectRatio = true;
            siticonePictureBox1.Margin = new Padding(3, 4, 3, 4);
            siticonePictureBox1.Name = "siticonePictureBox1";
            siticonePictureBox1.PlaceholderImage = null;
            siticonePictureBox1.RotationAngle = 0F;
            siticonePictureBox1.Saturation = 1F;
            siticonePictureBox1.ShowBorder = true;
            siticonePictureBox1.Size = new Size(81, 55);
            siticonePictureBox1.SizeMode = SiticoneNetCoreUI.SiticonePictureBoxSizeMode.Normal;
            siticonePictureBox1.TabIndex = 13;
            siticonePictureBox1.Text = "siticonePictureBox1";
            // 
            // Leaderboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Leaderboardpanel);
            Name = "Leaderboard";
            Size = new Size(768, 683);
            Leaderboardpanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)datagridLeaderboard).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SiticoneNetCoreUI.SiticonePanel Leaderboardpanel;
        private SiticoneNetCoreUI.SiticoneButton btnPLleaderboard;
        private SiticoneNetCoreUI.SiticoneButton btnHLleaderboard;
        private SiticoneNetCoreUI.SiticoneButton btnWLleaderboard;
        private SiticoneNetCoreUI.SiticoneButton btnBBleaderboard;
        private DataGridView datagridLeaderboard;
        private Panel panel2;
        private SiticoneNetCoreUI.SiticonePanel siticonePanel2;
        private SiticoneNetCoreUI.SiticoneButton siticoneButton7;
        private Label label2;
        private SiticoneNetCoreUI.SiticonePictureBox siticonePictureBox1;
        private SiticoneNetCoreUI.SiticoneTextBox tbxLboard;
    }
}
