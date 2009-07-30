namespace Remote
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItemConnect = new System.Windows.Forms.MenuItem();
            this.menuItemOptions = new System.Windows.Forms.MenuItem();
            this.menuItemAbout = new System.Windows.Forms.MenuItem();
            this.menuItemSettings = new System.Windows.Forms.MenuItem();
            this.pressButton4 = new Remote.PressButton();
            this.pressButton3 = new Remote.PressButton();
            this.pressButton2 = new Remote.PressButton();
            this.pressButton1 = new Remote.PressButton();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItemConnect);
            this.mainMenu1.MenuItems.Add(this.menuItemOptions);
            // 
            // menuItemConnect
            // 
            resources.ApplyResources(this.menuItemConnect, "menuItemConnect");
            this.menuItemConnect.Click += new System.EventHandler(this.menuItemConnect_Click);
            // 
            // menuItemOptions
            // 
            this.menuItemOptions.MenuItems.Add(this.menuItemAbout);
            this.menuItemOptions.MenuItems.Add(this.menuItemSettings);
            resources.ApplyResources(this.menuItemOptions, "menuItemOptions");
            // 
            // menuItemAbout
            // 
            resources.ApplyResources(this.menuItemAbout, "menuItemAbout");
            this.menuItemAbout.Click += new System.EventHandler(this.menuItemAbout_Click);
            // 
            // menuItemSettings
            // 
            resources.ApplyResources(this.menuItemSettings, "menuItemSettings");
            this.menuItemSettings.Click += new System.EventHandler(this.menuItemSettings_Click);
            // 
            // pressButton4
            // 
            resources.ApplyResources(this.pressButton4, "pressButton4");
            this.pressButton4.BackColor = System.Drawing.Color.DimGray;
            this.pressButton4.ForeColor = System.Drawing.Color.DarkOrange;
            this.pressButton4.Name = "pressButton4";
            this.pressButton4.Click += new System.EventHandler(this.pressButton4_Click);
            // 
            // pressButton3
            // 
            resources.ApplyResources(this.pressButton3, "pressButton3");
            this.pressButton3.BackColor = System.Drawing.Color.DimGray;
            this.pressButton3.ForeColor = System.Drawing.Color.DarkOrange;
            this.pressButton3.Name = "pressButton3";
            this.pressButton3.Click += new System.EventHandler(this.pressButton3_Click);
            // 
            // pressButton2
            // 
            resources.ApplyResources(this.pressButton2, "pressButton2");
            this.pressButton2.BackColor = System.Drawing.Color.DimGray;
            this.pressButton2.ForeColor = System.Drawing.Color.DarkOrange;
            this.pressButton2.Name = "pressButton2";
            this.pressButton2.Click += new System.EventHandler(this.pressButton2_Click);
            // 
            // pressButton1
            // 
            resources.ApplyResources(this.pressButton1, "pressButton1");
            this.pressButton1.BackColor = System.Drawing.Color.DimGray;
            this.pressButton1.ForeColor = System.Drawing.Color.DarkOrange;
            this.pressButton1.Name = "pressButton1";
            this.pressButton1.Click += new System.EventHandler(this.pressButton1_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.pressButton4);
            this.Controls.Add(this.pressButton3);
            this.Controls.Add(this.pressButton2);
            this.Controls.Add(this.pressButton1);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "MainWindow";            
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem menuItemConnect;
        private System.Windows.Forms.MenuItem menuItemOptions;
        private PressButton pressButton1;
        private PressButton pressButton2;
        private PressButton pressButton3;
        private PressButton pressButton4;
        private System.Windows.Forms.MenuItem menuItemAbout;
        private System.Windows.Forms.MenuItem menuItemSettings;
    }
}

