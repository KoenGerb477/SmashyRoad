namespace SmashyRoad
{
    partial class HighScoreScreen
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
            this.easyLabel = new System.Windows.Forms.Label();
            this.mediumLabel = new System.Windows.Forms.Label();
            this.hardLabel = new System.Windows.Forms.Label();
            this.easyScoresLabel = new System.Windows.Forms.Label();
            this.mediumScoresLabel = new System.Windows.Forms.Label();
            this.hardScoresLabel = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // easyLabel
            // 
            this.easyLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.easyLabel.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.easyLabel.Location = new System.Drawing.Point(35, 44);
            this.easyLabel.Name = "easyLabel";
            this.easyLabel.Size = new System.Drawing.Size(338, 122);
            this.easyLabel.TabIndex = 6;
            this.easyLabel.Text = "Easy";
            this.easyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mediumLabel
            // 
            this.mediumLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.mediumLabel.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mediumLabel.Location = new System.Drawing.Point(402, 44);
            this.mediumLabel.Name = "mediumLabel";
            this.mediumLabel.Size = new System.Drawing.Size(336, 122);
            this.mediumLabel.TabIndex = 7;
            this.mediumLabel.Text = "Medium";
            this.mediumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hardLabel
            // 
            this.hardLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.hardLabel.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hardLabel.Location = new System.Drawing.Point(764, 44);
            this.hardLabel.Name = "hardLabel";
            this.hardLabel.Size = new System.Drawing.Size(340, 122);
            this.hardLabel.TabIndex = 8;
            this.hardLabel.Text = "Hard";
            this.hardLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // easyScoresLabel
            // 
            this.easyScoresLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.easyScoresLabel.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.easyScoresLabel.Location = new System.Drawing.Point(35, 179);
            this.easyScoresLabel.Name = "easyScoresLabel";
            this.easyScoresLabel.Size = new System.Drawing.Size(338, 331);
            this.easyScoresLabel.TabIndex = 9;
            // 
            // mediumScoresLabel
            // 
            this.mediumScoresLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.mediumScoresLabel.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mediumScoresLabel.Location = new System.Drawing.Point(402, 179);
            this.mediumScoresLabel.Name = "mediumScoresLabel";
            this.mediumScoresLabel.Size = new System.Drawing.Size(336, 331);
            this.mediumScoresLabel.TabIndex = 10;
            // 
            // hardScoresLabel
            // 
            this.hardScoresLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.hardScoresLabel.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hardScoresLabel.Location = new System.Drawing.Point(764, 179);
            this.hardScoresLabel.Name = "hardScoresLabel";
            this.hardScoresLabel.Size = new System.Drawing.Size(340, 331);
            this.hardScoresLabel.TabIndex = 11;
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.backButton.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(29, 569);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(189, 80);
            this.backButton.TabIndex = 12;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // HighScoreScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.hardScoresLabel);
            this.Controls.Add(this.mediumScoresLabel);
            this.Controls.Add(this.easyScoresLabel);
            this.Controls.Add(this.hardLabel);
            this.Controls.Add(this.mediumLabel);
            this.Controls.Add(this.easyLabel);
            this.Name = "HighScoreScreen";
            this.Size = new System.Drawing.Size(1144, 704);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label easyLabel;
        private System.Windows.Forms.Label mediumLabel;
        private System.Windows.Forms.Label hardLabel;
        private System.Windows.Forms.Label easyScoresLabel;
        private System.Windows.Forms.Label mediumScoresLabel;
        private System.Windows.Forms.Label hardScoresLabel;
        private System.Windows.Forms.Button backButton;
    }
}
