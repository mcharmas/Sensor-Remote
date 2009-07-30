namespace Remote
{
    partial class MediaTab
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
            this.volTimer = new System.Windows.Forms.Timer();
            this.nextButton = new Remote.PressButton();
            this.stopButton = new Remote.PressButton();
            this.playButton = new Remote.PressButton();
            this.prevButton = new Remote.PressButton();
            this.volButton = new Remote.MyButton();
            this.muteButton = new Remote.PressButton();
            this.SuspendLayout();
            // 
            // volTimer
            // 
            this.volTimer.Tick += new System.EventHandler(this.volTimer_Tick);
            // 
            // nextButton
            // 
            this.nextButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.nextButton.BackColor = System.Drawing.Color.DimGray;
            this.nextButton.command = "MEDIA NEXT;";
            this.nextButton.ForeColor = System.Drawing.Color.DarkOrange;
            this.nextButton.Location = new System.Drawing.Point(363, 22);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(112, 114);
            this.nextButton.TabIndex = 8;
            this.nextButton.Text = "Next";
            this.nextButton.Click += new System.EventHandler(this.commandButtonClicked);
            // 
            // stopButton
            // 
            this.stopButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.stopButton.BackColor = System.Drawing.Color.DimGray;
            this.stopButton.command = "MEDIA STOP;";
            this.stopButton.ForeColor = System.Drawing.Color.DarkOrange;
            this.stopButton.Location = new System.Drawing.Point(125, 22);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(112, 114);
            this.stopButton.TabIndex = 7;
            this.stopButton.Text = "Stop";
            this.stopButton.Click += new System.EventHandler(this.commandButtonClicked);
            // 
            // playButton
            // 
            this.playButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.playButton.BackColor = System.Drawing.Color.DimGray;
            this.playButton.command = "MEDIA PLAY;";
            this.playButton.ForeColor = System.Drawing.Color.DarkOrange;
            this.playButton.Location = new System.Drawing.Point(77, 142);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(321, 128);
            this.playButton.TabIndex = 9;
            this.playButton.Text = "Play";
            this.playButton.Click += new System.EventHandler(this.commandButtonClicked);
            // 
            // prevButton
            // 
            this.prevButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.prevButton.BackColor = System.Drawing.Color.DimGray;
            this.prevButton.command = "MEDIA PREV;";
            this.prevButton.ForeColor = System.Drawing.Color.DarkOrange;
            this.prevButton.Location = new System.Drawing.Point(6, 22);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(112, 114);
            this.prevButton.TabIndex = 6;
            this.prevButton.Text = "Prev";
            this.prevButton.Click += new System.EventHandler(this.commandButtonClicked);
            // 
            // volButton
            // 
            this.volButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.volButton.BackColor = System.Drawing.Color.DarkGray;
            this.volButton.Location = new System.Drawing.Point(24, 276);
            this.volButton.Name = "volButton";
            this.volButton.Size = new System.Drawing.Size(422, 123);
            this.volButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.volButton_MouseDown);
            this.volButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.volButton_MouseUp);
            // 
            // muteButton
            // 
            this.muteButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.muteButton.BackColor = System.Drawing.Color.DimGray;
            this.muteButton.command = "MEDIA MUTE;";
            this.muteButton.ForeColor = System.Drawing.Color.DarkOrange;
            this.muteButton.Location = new System.Drawing.Point(244, 22);
            this.muteButton.Name = "muteButton";
            this.muteButton.Size = new System.Drawing.Size(112, 114);
            this.muteButton.TabIndex = 5;
            this.muteButton.Text = "Mute";
            this.muteButton.Click += new System.EventHandler(this.commandButtonClicked);
            // 
            // MediaTab
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.prevButton);
            this.Controls.Add(this.volButton);
            this.Controls.Add(this.muteButton);
            this.Name = "MediaTab";
            this.Size = new System.Drawing.Size(480, 640);
            this.ResumeLayout(false);

        }

        #endregion

        private PressButton playButton;
        private PressButton nextButton;
        private PressButton stopButton;
        private PressButton prevButton;
        private PressButton muteButton;
        private MyButton volButton;
        private System.Windows.Forms.Timer volTimer;
    }
}
