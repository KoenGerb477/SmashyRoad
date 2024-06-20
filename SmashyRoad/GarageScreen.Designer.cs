namespace SmashyRoad
{
    partial class GarageScreen
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
            this.car1 = new System.Windows.Forms.Button();
            this.car2Button = new System.Windows.Forms.Button();
            this.car3Button = new System.Windows.Forms.Button();
            this.car6Button = new System.Windows.Forms.Button();
            this.car5Button = new System.Windows.Forms.Button();
            this.car4Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // car1
            // 
            this.car1.BackColor = System.Drawing.Color.Blue;
            this.car1.Location = new System.Drawing.Point(90, 20);
            this.car1.Name = "car1";
            this.car1.Size = new System.Drawing.Size(294, 272);
            this.car1.TabIndex = 7;
            this.car1.UseVisualStyleBackColor = false;
            this.car1.Click += new System.EventHandler(this.car1_Click);
            // 
            // car2Button
            // 
            this.car2Button.BackColor = System.Drawing.Color.Red;
            this.car2Button.Location = new System.Drawing.Point(425, 20);
            this.car2Button.Name = "car2Button";
            this.car2Button.Size = new System.Drawing.Size(294, 272);
            this.car2Button.TabIndex = 8;
            this.car2Button.UseVisualStyleBackColor = false;
            this.car2Button.Click += new System.EventHandler(this.car2Button_Click);
            // 
            // car3Button
            // 
            this.car3Button.BackColor = System.Drawing.Color.Lime;
            this.car3Button.Location = new System.Drawing.Point(776, 20);
            this.car3Button.Name = "car3Button";
            this.car3Button.Size = new System.Drawing.Size(294, 272);
            this.car3Button.TabIndex = 9;
            this.car3Button.UseVisualStyleBackColor = false;
            this.car3Button.Click += new System.EventHandler(this.car3Button_Click);
            // 
            // car6Button
            // 
            this.car6Button.Location = new System.Drawing.Point(776, 308);
            this.car6Button.Name = "car6Button";
            this.car6Button.Size = new System.Drawing.Size(294, 272);
            this.car6Button.TabIndex = 12;
            this.car6Button.UseVisualStyleBackColor = true;
            this.car6Button.Click += new System.EventHandler(this.car6Button_Click);
            // 
            // car5Button
            // 
            this.car5Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.car5Button.Location = new System.Drawing.Point(425, 308);
            this.car5Button.Name = "car5Button";
            this.car5Button.Size = new System.Drawing.Size(294, 272);
            this.car5Button.TabIndex = 11;
            this.car5Button.UseVisualStyleBackColor = false;
            this.car5Button.Click += new System.EventHandler(this.car5Button_Click);
            // 
            // car4Button
            // 
            this.car4Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.car4Button.Location = new System.Drawing.Point(90, 308);
            this.car4Button.Name = "car4Button";
            this.car4Button.Size = new System.Drawing.Size(294, 272);
            this.car4Button.TabIndex = 10;
            this.car4Button.UseVisualStyleBackColor = false;
            this.car4Button.Click += new System.EventHandler(this.car4Button_Click);
            // 
            // GarageScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.car6Button);
            this.Controls.Add(this.car5Button);
            this.Controls.Add(this.car4Button);
            this.Controls.Add(this.car3Button);
            this.Controls.Add(this.car2Button);
            this.Controls.Add(this.car1);
            this.Name = "GarageScreen";
            this.Size = new System.Drawing.Size(1144, 704);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button car1;
        private System.Windows.Forms.Button car2Button;
        private System.Windows.Forms.Button car3Button;
        private System.Windows.Forms.Button car6Button;
        private System.Windows.Forms.Button car5Button;
        private System.Windows.Forms.Button car4Button;
    }
}
