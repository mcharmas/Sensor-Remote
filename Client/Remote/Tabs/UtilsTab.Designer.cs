namespace Remote
{
    partial class UtilsTab
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
            this.pressButton10 = new Remote.PressButton();
            this.pressButton9 = new Remote.PressButton();
            this.pressButton8 = new Remote.PressButton();
            this.pressButton7 = new Remote.PressButton();
            this.pressButton6 = new Remote.PressButton();
            this.pressButton5 = new Remote.PressButton();
            this.pressButton4 = new Remote.PressButton();
            this.pressButton3 = new Remote.PressButton();
            this.pressButton1 = new Remote.PressButton();
            this.SuspendLayout();
            // 
            // pressButton10
            // 
            this.pressButton10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pressButton10.BackColor = System.Drawing.Color.DimGray;
            this.pressButton10.command = "KEY ^{ESC};";
            this.pressButton10.ForeColor = System.Drawing.Color.DarkOrange;
            this.pressButton10.Location = new System.Drawing.Point(8, 140);
            this.pressButton10.Name = "pressButton10";
            this.pressButton10.Size = new System.Drawing.Size(50, 50);
            this.pressButton10.TabIndex = 17;
            this.pressButton10.Text = "Win";
            this.pressButton10.Click += new System.EventHandler(this.commandButtonClicked);
            // 
            // pressButton9
            // 
            this.pressButton9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pressButton9.BackColor = System.Drawing.Color.DimGray;
            this.pressButton9.command = "KEY %{F4};";
            this.pressButton9.ForeColor = System.Drawing.Color.DarkOrange;
            this.pressButton9.Location = new System.Drawing.Point(8, 8);
            this.pressButton9.Name = "pressButton9";
            this.pressButton9.Size = new System.Drawing.Size(50, 50);
            this.pressButton9.TabIndex = 16;
            this.pressButton9.Text = "Close";
            this.pressButton9.Click += new System.EventHandler(this.commandButtonClicked);
            // 
            // pressButton8
            // 
            this.pressButton8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pressButton8.BackColor = System.Drawing.Color.DimGray;
            this.pressButton8.command = "KEY {PGDN};";
            this.pressButton8.ForeColor = System.Drawing.Color.DarkOrange;
            this.pressButton8.Location = new System.Drawing.Point(142, 140);
            this.pressButton8.Name = "pressButton8";
            this.pressButton8.Size = new System.Drawing.Size(50, 50);
            this.pressButton8.TabIndex = 15;
            this.pressButton8.Text = "PgDn";
            this.pressButton8.Click += new System.EventHandler(this.commandButtonClicked);
            // 
            // pressButton7
            // 
            this.pressButton7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pressButton7.BackColor = System.Drawing.Color.DimGray;
            this.pressButton7.command = "KEY {DOWN};";
            this.pressButton7.ForeColor = System.Drawing.Color.DarkOrange;
            this.pressButton7.Location = new System.Drawing.Point(75, 130);
            this.pressButton7.Name = "pressButton7";
            this.pressButton7.Size = new System.Drawing.Size(50, 50);
            this.pressButton7.TabIndex = 14;
            this.pressButton7.Click += new System.EventHandler(this.commandButtonClicked);
            // 
            // pressButton6
            // 
            this.pressButton6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pressButton6.BackColor = System.Drawing.Color.DimGray;
            this.pressButton6.command = "KEY {ENTER};";
            this.pressButton6.ForeColor = System.Drawing.Color.DarkOrange;
            this.pressButton6.Location = new System.Drawing.Point(75, 74);
            this.pressButton6.Name = "pressButton6";
            this.pressButton6.Size = new System.Drawing.Size(50, 50);
            this.pressButton6.TabIndex = 13;
            this.pressButton6.Click += new System.EventHandler(this.commandButtonClicked);
            // 
            // pressButton5
            // 
            this.pressButton5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pressButton5.BackColor = System.Drawing.Color.DimGray;
            this.pressButton5.command = "KEY {LEFT};";
            this.pressButton5.ForeColor = System.Drawing.Color.DarkOrange;
            this.pressButton5.Location = new System.Drawing.Point(19, 74);
            this.pressButton5.Name = "pressButton5";
            this.pressButton5.Size = new System.Drawing.Size(50, 50);
            this.pressButton5.TabIndex = 12;
            this.pressButton5.Click += new System.EventHandler(this.commandButtonClicked);
            // 
            // pressButton4
            // 
            this.pressButton4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pressButton4.BackColor = System.Drawing.Color.DimGray;
            this.pressButton4.command = "KEY {RIGHT};";
            this.pressButton4.ForeColor = System.Drawing.Color.DarkOrange;
            this.pressButton4.Location = new System.Drawing.Point(131, 74);
            this.pressButton4.Name = "pressButton4";
            this.pressButton4.Size = new System.Drawing.Size(50, 50);
            this.pressButton4.TabIndex = 11;
            this.pressButton4.Click += new System.EventHandler(this.commandButtonClicked);
            // 
            // pressButton3
            // 
            this.pressButton3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pressButton3.BackColor = System.Drawing.Color.DimGray;
            this.pressButton3.command = "KEY {UP};";
            this.pressButton3.ForeColor = System.Drawing.Color.DarkOrange;
            this.pressButton3.Location = new System.Drawing.Point(75, 18);
            this.pressButton3.Name = "pressButton3";
            this.pressButton3.Size = new System.Drawing.Size(50, 50);
            this.pressButton3.TabIndex = 10;
            this.pressButton3.Click += new System.EventHandler(this.commandButtonClicked);
            // 
            // pressButton1
            // 
            this.pressButton1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pressButton1.BackColor = System.Drawing.Color.DimGray;
            this.pressButton1.command = "KEY {PGUP};";
            this.pressButton1.ForeColor = System.Drawing.Color.DarkOrange;
            this.pressButton1.Location = new System.Drawing.Point(142, 8);
            this.pressButton1.Name = "pressButton1";
            this.pressButton1.Size = new System.Drawing.Size(50, 50);
            this.pressButton1.TabIndex = 9;
            this.pressButton1.Text = "PgUp";
            this.pressButton1.Click += new System.EventHandler(this.commandButtonClicked);
            // 
            // UtilsTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.pressButton10);
            this.Controls.Add(this.pressButton9);
            this.Controls.Add(this.pressButton8);
            this.Controls.Add(this.pressButton7);
            this.Controls.Add(this.pressButton6);
            this.Controls.Add(this.pressButton5);
            this.Controls.Add(this.pressButton4);
            this.Controls.Add(this.pressButton3);
            this.Controls.Add(this.pressButton1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "UtilsTab";
            this.Size = new System.Drawing.Size(201, 198);
            this.ResumeLayout(false);

        }

        #endregion

        private PressButton pressButton10;
        private PressButton pressButton9;
        private PressButton pressButton8;
        private PressButton pressButton7;
        private PressButton pressButton6;
        private PressButton pressButton5;
        private PressButton pressButton4;
        private PressButton pressButton3;
        private PressButton pressButton1;
    }
}
