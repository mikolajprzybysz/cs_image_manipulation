namespace ImageManipulation
{
    partial class brightnessContrastWindow
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
            this.brightnessLabel = new System.Windows.Forms.Label();
            this.brightnessTrackBar = new System.Windows.Forms.TrackBar();
            this.brightnessTextBox = new System.Windows.Forms.TextBox();
            this.contrastLabel = new System.Windows.Forms.Label();
            this.contrastTrackBar = new System.Windows.Forms.TrackBar();
            this.contrastTextBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contrastTrackBar)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // brightnessLabel
            // 
            this.brightnessLabel.AutoSize = true;
            this.brightnessLabel.Location = new System.Drawing.Point(17, 12);
            this.brightnessLabel.Name = "brightnessLabel";
            this.brightnessLabel.Size = new System.Drawing.Size(56, 13);
            this.brightnessLabel.TabIndex = 0;
            this.brightnessLabel.Text = "Brightness";
            // 
            // brightnessTrackBar
            // 
            this.brightnessTrackBar.Location = new System.Drawing.Point(12, 34);
            this.brightnessTrackBar.Maximum = 100;
            this.brightnessTrackBar.Minimum = -100;
            this.brightnessTrackBar.Name = "brightnessTrackBar";
            this.brightnessTrackBar.Size = new System.Drawing.Size(203, 45);
            this.brightnessTrackBar.TabIndex = 1;
            this.brightnessTrackBar.ValueChanged += new System.EventHandler(this.brightnessChange);
            // 
            // brightnessTextBox
            // 
            this.brightnessTextBox.Location = new System.Drawing.Point(154, 9);
            this.brightnessTextBox.Name = "brightnessTextBox";
            this.brightnessTextBox.ReadOnly = true;
            this.brightnessTextBox.Size = new System.Drawing.Size(49, 20);
            this.brightnessTextBox.TabIndex = 2;
            this.brightnessTextBox.Text = "0";
            // 
            // contrastLabel
            // 
            this.contrastLabel.AutoSize = true;
            this.contrastLabel.Location = new System.Drawing.Point(3, 5);
            this.contrastLabel.Name = "contrastLabel";
            this.contrastLabel.Size = new System.Drawing.Size(46, 13);
            this.contrastLabel.TabIndex = 0;
            this.contrastLabel.Text = "Contrast";
            // 
            // contrastTrackBar
            // 
            this.contrastTrackBar.Location = new System.Drawing.Point(-2, 24);
            this.contrastTrackBar.Maximum = 100;
            this.contrastTrackBar.Minimum = -100;
            this.contrastTrackBar.Name = "contrastTrackBar";
            this.contrastTrackBar.Size = new System.Drawing.Size(203, 45);
            this.contrastTrackBar.TabIndex = 1;
            this.contrastTrackBar.ValueChanged += new System.EventHandler(this.contrastChange);
            // 
            // contrastTextBox
            // 
            this.contrastTextBox.Location = new System.Drawing.Point(140, 2);
            this.contrastTextBox.Name = "contrastTextBox";
            this.contrastTextBox.ReadOnly = true;
            this.contrastTextBox.Size = new System.Drawing.Size(49, 20);
            this.contrastTextBox.TabIndex = 2;
            this.contrastTextBox.Text = "0";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(220, 37);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(60, 21);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(220, 9);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(60, 21);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.contrastTrackBar);
            this.panel1.Controls.Add(this.contrastLabel);
            this.panel1.Controls.Add(this.contrastTextBox);
            this.panel1.Location = new System.Drawing.Point(13, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(209, 66);
            this.panel1.TabIndex = 4;
            // 
            // brightnessWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 102);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.brightnessTextBox);
            this.Controls.Add(this.brightnessTrackBar);
            this.Controls.Add(this.brightnessLabel);
            this.Name = "brightnessWindow";
            this.Text = "Brightness/Contrast";
            ((System.ComponentModel.ISupportInitialize)(this.brightnessTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contrastTrackBar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label brightnessLabel;
        private System.Windows.Forms.TrackBar brightnessTrackBar;
        private System.Windows.Forms.TextBox brightnessTextBox;
        private System.Windows.Forms.Label contrastLabel;
        private System.Windows.Forms.TrackBar contrastTrackBar;
        private System.Windows.Forms.TextBox contrastTextBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Panel panel1;
    }
}