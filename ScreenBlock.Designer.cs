namespace DayTimer
{
    partial class ScreenBlock
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
            this.workButton = new System.Windows.Forms.Button();
            this.pauzeButton = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.debug = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // workButton
            // 
            this.workButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.workButton.Location = new System.Drawing.Point(3, 3);
            this.workButton.Name = "workButton";
            this.workButton.Size = new System.Drawing.Size(75, 23);
            this.workButton.TabIndex = 0;
            this.workButton.Text = "Work";
            this.workButton.UseVisualStyleBackColor = true;
            // 
            // pauzeButton
            // 
            this.pauzeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.pauzeButton.Location = new System.Drawing.Point(136, 3);
            this.pauzeButton.Name = "pauzeButton";
            this.pauzeButton.Size = new System.Drawing.Size(75, 23);
            this.pauzeButton.TabIndex = 1;
            this.pauzeButton.Text = "Snooze";
            this.pauzeButton.UseVisualStyleBackColor = true;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // numericUpDown
            // 
            this.numericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown.Location = new System.Drawing.Point(84, 8);
            this.numericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(46, 16);
            this.numericUpDown.TabIndex = 2;
            this.numericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.workButton);
            this.panel1.Controls.Add(this.pauzeButton);
            this.panel1.Controls.Add(this.numericUpDown);
            this.panel1.Location = new System.Drawing.Point(1, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(214, 29);
            this.panel1.TabIndex = 3;
            // 
            // debug
            // 
            this.debug.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.debug.Location = new System.Drawing.Point(1, 9);
            this.debug.Name = "debug";
            this.debug.Size = new System.Drawing.Size(214, 12);
            this.debug.TabIndex = 4;
            this.debug.Text = "label1";
            this.debug.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ScreenBlock
            // 
            this.AcceptButton = this.workButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.pauzeButton;
            this.ClientSize = new System.Drawing.Size(217, 76);
            this.Controls.Add(this.debug);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScreenBlock";
            this.Text = "ScreenBlock";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button workButton;
        private System.Windows.Forms.Button pauzeButton;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label debug;
    }
}