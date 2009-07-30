namespace Remote
{
    partial class SMouseTab
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
            this.timer = new System.Windows.Forms.Timer();
            this.pressButton12 = new Remote.PressButton();
            this.rightButton = new Remote.MyButton();
            this.scrollButton = new Remote.MyButton();
            this.leftButton = new Remote.MyButton();
            this.pressButton11 = new Remote.PressButton();
            this.pressButton13 = new Remote.PressButton();
            this.moveButton = new Remote.MyButton();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // pressButton12
            // 
            this.pressButton12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pressButton12.BackColor = System.Drawing.Color.DimGray;
            this.pressButton12.command = "KEY %{F4};";
            this.pressButton12.ForeColor = System.Drawing.Color.DarkOrange;
            this.pressButton12.Location = new System.Drawing.Point(327, 530);
            this.pressButton12.Name = "pressButton12";
            this.pressButton12.Size = new System.Drawing.Size(150, 107);
            this.pressButton12.TabIndex = 5;
            this.pressButton12.Text = "Close";
            this.pressButton12.Click += new System.EventHandler(this.commandButtonClicked);
            // 
            // rightButton
            // 
            this.rightButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rightButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.rightButton.downCommand = "RDOWN;";
            this.rightButton.Location = new System.Drawing.Point(307, 3);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(170, 194);
            this.rightButton.upCommand = "RUP;";
            this.rightButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonDown);
            this.rightButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonUp);
            // 
            // scrollButton
            // 
            this.scrollButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scrollButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.scrollButton.Location = new System.Drawing.Point(179, 3);
            this.scrollButton.Name = "scrollButton";
            this.scrollButton.Size = new System.Drawing.Size(122, 194);
            this.scrollButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonDown);
            this.scrollButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonUp);
            // 
            // leftButton
            // 
            this.leftButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.leftButton.downCommand = "LDOWN;";
            this.leftButton.Location = new System.Drawing.Point(3, 3);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(170, 194);
            this.leftButton.upCommand = "LUP;";
            this.leftButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonDown);
            this.leftButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonUp);
            // 
            // pressButton11
            // 
            this.pressButton11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pressButton11.BackColor = System.Drawing.Color.DimGray;
            this.pressButton11.command = "KEY ^{ESC};";
            this.pressButton11.ForeColor = System.Drawing.Color.DarkOrange;
            this.pressButton11.Location = new System.Drawing.Point(3, 530);
            this.pressButton11.Name = "pressButton11";
            this.pressButton11.Size = new System.Drawing.Size(150, 107);
            this.pressButton11.TabIndex = 4;
            this.pressButton11.Text = "Win";
            this.pressButton11.Click += new System.EventHandler(this.commandButtonClicked);
            // 
            // pressButton13
            // 
            this.pressButton13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pressButton13.BackColor = System.Drawing.Color.DimGray;
            this.pressButton13.command = "KEY {MINIMIZE};";
            this.pressButton13.ForeColor = System.Drawing.Color.DarkOrange;
            this.pressButton13.Location = new System.Drawing.Point(158, 530);
            this.pressButton13.Name = "pressButton13";
            this.pressButton13.Size = new System.Drawing.Size(163, 107);
            this.pressButton13.TabIndex = 6;
            this.pressButton13.Text = "Minimize";
            this.pressButton13.Click += new System.EventHandler(this.commandButtonClicked);
            // 
            // moveButton
            // 
            this.moveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.moveButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.moveButton.Location = new System.Drawing.Point(3, 203);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(474, 321);
            this.moveButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonDown);
            this.moveButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonUp);
            // 
            // SMouseTab
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.pressButton12);
            this.Controls.Add(this.rightButton);
            this.Controls.Add(this.scrollButton);
            this.Controls.Add(this.leftButton);
            this.Controls.Add(this.pressButton11);
            this.Controls.Add(this.pressButton13);
            this.Controls.Add(this.moveButton);
            this.Name = "SMouseTab";
            this.Size = new System.Drawing.Size(480, 640);
            this.ResumeLayout(false);

        }

        #endregion

        private MyButton leftButton;
        private MyButton scrollButton;
        private MyButton rightButton;
        private PressButton pressButton11;
        private PressButton pressButton13;
        private PressButton pressButton12;
        private MyButton moveButton;
        private System.Windows.Forms.Timer timer;
    }
}
