namespace DayTimer
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startPauzeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startWorkingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label = new System.Windows.Forms.Label();
            this.clock = new System.Windows.Forms.Timer(this.components);
            this.pomodoro = new System.Windows.Forms.Timer(this.components);
            this.autoHideCheckBox = new System.Windows.Forms.CheckBox();
            this.topMostCheckBox = new System.Windows.Forms.CheckBox();
            this.showWhenPauzeCheckBox = new System.Windows.Forms.CheckBox();
            this.sessionBox = new System.Windows.Forms.PictureBox();
            this.debug = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sessionBox)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Text = "DayTimer";
            this.notifyIcon.Visible = true;
            this.notifyIcon.BalloonTipClicked += new System.EventHandler(this.notifyIcon_BalloonTipClicked);
            this.notifyIcon.BalloonTipClosed += new System.EventHandler(this.notifyIcon_BalloonTipClosed);
            this.notifyIcon.DoubleClick += new System.EventHandler(this.openToolStripMenuItem_Click);
            this.notifyIcon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseMove);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.startPauzeToolStripMenuItem,
            this.startWorkingToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(147, 70);
            this.contextMenuStrip.Text = "Menu";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // startPauzeToolStripMenuItem
            // 
            this.startPauzeToolStripMenuItem.Image = global::DayTimer.Properties.Resources._3;
            this.startPauzeToolStripMenuItem.Name = "startPauzeToolStripMenuItem";
            this.startPauzeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.startPauzeToolStripMenuItem.Text = "Start Pauze";
            this.startPauzeToolStripMenuItem.Visible = false;
            this.startPauzeToolStripMenuItem.Click += new System.EventHandler(this.startPauzeToolStripMenuItem_Click);
            // 
            // startWorkingToolStripMenuItem
            // 
            this.startWorkingToolStripMenuItem.Image = global::DayTimer.Properties.Resources.Img_Working;
            this.startWorkingToolStripMenuItem.Name = "startWorkingToolStripMenuItem";
            this.startWorkingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.startWorkingToolStripMenuItem.Text = "Start Working";
            this.startWorkingToolStripMenuItem.Click += new System.EventHandler(this.startWorkingToolStripMenuItem_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label.Location = new System.Drawing.Point(0, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(35, 13);
            this.label.TabIndex = 0;
            this.label.Text = "label1";
            // 
            // clock
            // 
            this.clock.Tick += new System.EventHandler(this.clock_Tick);
            // 
            // autoHideCheckBox
            // 
            this.autoHideCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.autoHideCheckBox.AutoSize = true;
            this.autoHideCheckBox.Checked = true;
            this.autoHideCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoHideCheckBox.Location = new System.Drawing.Point(12, 108);
            this.autoHideCheckBox.Name = "autoHideCheckBox";
            this.autoHideCheckBox.Size = new System.Drawing.Size(73, 17);
            this.autoHideCheckBox.TabIndex = 1;
            this.autoHideCheckBox.Text = "Auto Hide";
            this.autoHideCheckBox.UseVisualStyleBackColor = true;
            // 
            // topMostCheckBox
            // 
            this.topMostCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.topMostCheckBox.AutoSize = true;
            this.topMostCheckBox.Location = new System.Drawing.Point(12, 85);
            this.topMostCheckBox.Name = "topMostCheckBox";
            this.topMostCheckBox.Size = new System.Drawing.Size(90, 17);
            this.topMostCheckBox.TabIndex = 2;
            this.topMostCheckBox.Text = "Keep On Top";
            this.topMostCheckBox.UseVisualStyleBackColor = true;
            // 
            // showWhenPauzeCheckBox
            // 
            this.showWhenPauzeCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.showWhenPauzeCheckBox.AutoSize = true;
            this.showWhenPauzeCheckBox.Location = new System.Drawing.Point(12, 62);
            this.showWhenPauzeCheckBox.Name = "showWhenPauzeCheckBox";
            this.showWhenPauzeCheckBox.Size = new System.Drawing.Size(153, 17);
            this.showWhenPauzeCheckBox.TabIndex = 3;
            this.showWhenPauzeCheckBox.Text = "Show when taking a break";
            this.showWhenPauzeCheckBox.UseVisualStyleBackColor = true;
            // 
            // sessionBox
            // 
            this.sessionBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sessionBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sessionBox.Location = new System.Drawing.Point(195, 93);
            this.sessionBox.Name = "sessionBox";
            this.sessionBox.Size = new System.Drawing.Size(32, 32);
            this.sessionBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sessionBox.TabIndex = 4;
            this.sessionBox.TabStop = false;
            this.sessionBox.Visible = false;
            this.sessionBox.Click += new System.EventHandler(this.sessionBox_Click);
            // 
            // debug
            // 
            this.debug.AutoSize = true;
            this.debug.Location = new System.Drawing.Point(3, 43);
            this.debug.Name = "debug";
            this.debug.Size = new System.Drawing.Size(37, 13);
            this.debug.TabIndex = 5;
            this.debug.Text = "debug";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("Marlett", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(203, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "7";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(239, 137);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.debug);
            this.Controls.Add(this.sessionBox);
            this.Controls.Add(this.label);
            this.Controls.Add(this.showWhenPauzeCheckBox);
            this.Controls.Add(this.topMostCheckBox);
            this.Controls.Add(this.autoHideCheckBox);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(255, 100);
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Day Timer";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sessionBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Timer clock;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Timer pomodoro;
        private System.Windows.Forms.ToolStripMenuItem startPauzeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startWorkingToolStripMenuItem;
        private System.Windows.Forms.CheckBox autoHideCheckBox;
        private System.Windows.Forms.CheckBox topMostCheckBox;
        private System.Windows.Forms.CheckBox showWhenPauzeCheckBox;
        private System.Windows.Forms.PictureBox sessionBox;
        private System.Windows.Forms.Label debug;
        private System.Windows.Forms.Button button1;
    }
}

