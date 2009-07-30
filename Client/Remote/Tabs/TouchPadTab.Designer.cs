namespace Remote
{
    partial class TouchPadTab
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
            this.touchPad1 = new Remote.TouchPad();
            this.pressButtonLeft = new Remote.PressButton();
            this.pressButtonRight = new Remote.PressButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // touchPad1
            // 
            this.touchPad1.BackColor = System.Drawing.Color.Gray;
            this.touchPad1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.touchPad1.Location = new System.Drawing.Point(0, 0);
            this.touchPad1.Name = "touchPad1";
            this.touchPad1.Size = new System.Drawing.Size(240, 240);
            // 
            // pressButtonLeft
            // 
            this.pressButtonLeft.BackColor = System.Drawing.Color.DimGray;
            this.pressButtonLeft.command = "LDOWN;LUP;";
            this.pressButtonLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pressButtonLeft.ForeColor = System.Drawing.Color.DarkOrange;
            this.pressButtonLeft.Location = new System.Drawing.Point(0, 0);
            this.pressButtonLeft.Name = "pressButtonLeft";
            this.pressButtonLeft.Size = new System.Drawing.Size(110, 32);
            this.pressButtonLeft.TabIndex = 1;
            this.pressButtonLeft.Text = "Left";
            this.pressButtonLeft.Click += new System.EventHandler(this.commandButtonClick);
            // 
            // pressButtonRight
            // 
            this.pressButtonRight.BackColor = System.Drawing.Color.DimGray;
            this.pressButtonRight.command = "RDOWN;RUP;";
            this.pressButtonRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pressButtonRight.ForeColor = System.Drawing.Color.DarkOrange;
            this.pressButtonRight.Location = new System.Drawing.Point(130, 0);
            this.pressButtonRight.Name = "pressButtonRight";
            this.pressButtonRight.Size = new System.Drawing.Size(110, 32);
            this.pressButtonRight.TabIndex = 2;
            this.pressButtonRight.Text = "Right";
            this.pressButtonRight.Click += new System.EventHandler(this.commandButtonClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.pressButtonLeft);
            this.panel1.Controls.Add(this.pressButtonRight);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 208);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 32);
            // 
            // TouchPadTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.touchPad1);
            this.Name = "TouchPadTab";
            this.Size = new System.Drawing.Size(240, 240);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TouchPad touchPad1;
        private PressButton pressButtonLeft;
        private PressButton pressButtonRight;
        private System.Windows.Forms.Panel panel1;
    }
}
