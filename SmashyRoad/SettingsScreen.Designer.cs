namespace SmashyRoad
{
    partial class SettingsScreen
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
            this.hardButton = new System.Windows.Forms.Button();
            this.mediumButton = new System.Windows.Forms.Button();
            this.easyButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.backOrangeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // hardButton
            // 
            this.hardButton.BackColor = System.Drawing.Color.White;
            this.hardButton.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hardButton.Location = new System.Drawing.Point(776, 262);
            this.hardButton.Name = "hardButton";
            this.hardButton.Size = new System.Drawing.Size(262, 253);
            this.hardButton.TabIndex = 9;
            this.hardButton.Text = "Hard";
            this.hardButton.UseVisualStyleBackColor = false;
            this.hardButton.Click += new System.EventHandler(this.hardButton_Click);
            // 
            // mediumButton
            // 
            this.mediumButton.BackColor = System.Drawing.Color.White;
            this.mediumButton.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mediumButton.Location = new System.Drawing.Point(450, 262);
            this.mediumButton.Name = "mediumButton";
            this.mediumButton.Size = new System.Drawing.Size(262, 253);
            this.mediumButton.TabIndex = 8;
            this.mediumButton.Text = "Medium";
            this.mediumButton.UseVisualStyleBackColor = false;
            this.mediumButton.Click += new System.EventHandler(this.mediumButton_Click);
            // 
            // easyButton
            // 
            this.easyButton.BackColor = System.Drawing.Color.White;
            this.easyButton.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.easyButton.Location = new System.Drawing.Point(128, 262);
            this.easyButton.Name = "easyButton";
            this.easyButton.Size = new System.Drawing.Size(262, 253);
            this.easyButton.TabIndex = 7;
            this.easyButton.Text = "Easy";
            this.easyButton.UseVisualStyleBackColor = false;
            this.easyButton.Click += new System.EventHandler(this.easyButton_Click);
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.backButton.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(62, 589);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(189, 80);
            this.backButton.TabIndex = 6;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click_1);
            // 
            // backOrangeLabel
            // 
            this.backOrangeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.backOrangeLabel.Font = new System.Drawing.Font("Arial", 105.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backOrangeLabel.Location = new System.Drawing.Point(59, 36);
            this.backOrangeLabel.Name = "backOrangeLabel";
            this.backOrangeLabel.Size = new System.Drawing.Size(1027, 525);
            this.backOrangeLabel.TabIndex = 5;
            this.backOrangeLabel.Text = "DIFFICULTY";
            this.backOrangeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.backOrangeLabel.Click += new System.EventHandler(this.backOrangeLabel_Click);
            // 
            // SettingsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hardButton);
            this.Controls.Add(this.mediumButton);
            this.Controls.Add(this.easyButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.backOrangeLabel);
            this.Name = "SettingsScreen";
            this.Size = new System.Drawing.Size(1144, 704);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button hardButton;
        private System.Windows.Forms.Button mediumButton;
        private System.Windows.Forms.Button easyButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label backOrangeLabel;
    }
}
