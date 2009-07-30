namespace Remote
{
    partial class SettingsForm
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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.checkBoxVibrate = new System.Windows.Forms.CheckBox();
            this.checkBoxConnect = new System.Windows.Forms.CheckBox();
            this.radioButtonTCP = new System.Windows.Forms.RadioButton();
            this.radioButtonSerial = new System.Windows.Forms.RadioButton();
            this.panelTCP = new System.Windows.Forms.Panel();
            this.panelSerial = new System.Windows.Forms.Panel();
            this.comboBoxPorts = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxInvert = new System.Windows.Forms.CheckBox();
            this.panelTCP.SuspendLayout();
            this.panelSerial.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            this.mainMenu1.MenuItems.Add(this.menuItem2);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Save";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "Cancel";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(17, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.Text = "Server IP:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(17, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.Text = "Server port:";
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(99, 10);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(100, 21);
            this.textBoxIP.TabIndex = 4;
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(99, 37);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(100, 21);
            this.textBoxPort.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(17, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.Text = "Password:";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(99, 64);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(100, 21);
            this.textBoxPassword.TabIndex = 7;
            // 
            // checkBoxVibrate
            // 
            this.checkBoxVibrate.Location = new System.Drawing.Point(13, 130);
            this.checkBoxVibrate.Name = "checkBoxVibrate";
            this.checkBoxVibrate.Size = new System.Drawing.Size(83, 20);
            this.checkBoxVibrate.TabIndex = 8;
            this.checkBoxVibrate.Text = "Vibrate";
            // 
            // checkBoxConnect
            // 
            this.checkBoxConnect.Location = new System.Drawing.Point(13, 156);
            this.checkBoxConnect.Name = "checkBoxConnect";
            this.checkBoxConnect.Size = new System.Drawing.Size(148, 20);
            this.checkBoxConnect.TabIndex = 9;
            this.checkBoxConnect.Text = "Connect on startup";
            // 
            // radioButtonTCP
            // 
            this.radioButtonTCP.Location = new System.Drawing.Point(31, 3);
            this.radioButtonTCP.Name = "radioButtonTCP";
            this.radioButtonTCP.Size = new System.Drawing.Size(100, 20);
            this.radioButtonTCP.TabIndex = 13;
            this.radioButtonTCP.Text = "TCP/IP";
            this.radioButtonTCP.CheckedChanged += new System.EventHandler(this.radioButtonTCP_CheckedChanged);
            // 
            // radioButtonSerial
            // 
            this.radioButtonSerial.Location = new System.Drawing.Point(137, 3);
            this.radioButtonSerial.Name = "radioButtonSerial";
            this.radioButtonSerial.Size = new System.Drawing.Size(100, 20);
            this.radioButtonSerial.TabIndex = 14;
            this.radioButtonSerial.Text = "Serial";
            // 
            // panelTCP
            // 
            this.panelTCP.Controls.Add(this.label1);
            this.panelTCP.Controls.Add(this.label2);
            this.panelTCP.Controls.Add(this.textBoxIP);
            this.panelTCP.Controls.Add(this.textBoxPort);
            this.panelTCP.Controls.Add(this.label3);
            this.panelTCP.Controls.Add(this.textBoxPassword);
            this.panelTCP.Location = new System.Drawing.Point(13, 29);
            this.panelTCP.Name = "panelTCP";
            this.panelTCP.Size = new System.Drawing.Size(213, 94);
            // 
            // panelSerial
            // 
            this.panelSerial.Controls.Add(this.comboBoxPorts);
            this.panelSerial.Controls.Add(this.label4);
            this.panelSerial.Location = new System.Drawing.Point(13, 29);
            this.panelSerial.Name = "panelSerial";
            this.panelSerial.Size = new System.Drawing.Size(213, 95);
            // 
            // comboBoxPorts
            // 
            this.comboBoxPorts.Location = new System.Drawing.Point(73, 16);
            this.comboBoxPorts.Name = "comboBoxPorts";
            this.comboBoxPorts.Size = new System.Drawing.Size(100, 22);
            this.comboBoxPorts.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(27, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.Text = "Port:";
            // 
            // checkBoxInvert
            // 
            this.checkBoxInvert.Location = new System.Drawing.Point(13, 182);
            this.checkBoxInvert.Name = "checkBoxInvert";
            this.checkBoxInvert.Size = new System.Drawing.Size(148, 20);
            this.checkBoxInvert.TabIndex = 15;
            this.checkBoxInvert.Text = "Invert up and down";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.checkBoxInvert);
            this.Controls.Add(this.panelSerial);
            this.Controls.Add(this.panelTCP);
            this.Controls.Add(this.radioButtonSerial);
            this.Controls.Add(this.radioButtonTCP);
            this.Controls.Add(this.checkBoxConnect);
            this.Controls.Add(this.checkBoxVibrate);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.panelTCP.ResumeLayout(false);
            this.panelSerial.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.CheckBox checkBoxVibrate;
        private System.Windows.Forms.CheckBox checkBoxConnect;
        private System.Windows.Forms.RadioButton radioButtonTCP;
        private System.Windows.Forms.RadioButton radioButtonSerial;
        private System.Windows.Forms.Panel panelTCP;
        private System.Windows.Forms.Panel panelSerial;
        private System.Windows.Forms.ComboBox comboBoxPorts;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxInvert;
    }
}