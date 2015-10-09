namespace Ta7lilProject
{
    partial class Welcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.interpolation = new System.Windows.Forms.Button();
            this.integration = new System.Windows.Forms.Button();
            this.Deriveation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(42, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(388, 321);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // interpolation
            // 
            this.interpolation.Location = new System.Drawing.Point(334, 384);
            this.interpolation.Name = "interpolation";
            this.interpolation.Size = new System.Drawing.Size(96, 23);
            this.interpolation.TabIndex = 1;
            this.interpolation.Text = "Interpolation";
            this.interpolation.UseVisualStyleBackColor = true;
            this.interpolation.Click += new System.EventHandler(this.interpolation_Click);
            // 
            // integration
            // 
            this.integration.Location = new System.Drawing.Point(42, 384);
            this.integration.Name = "integration";
            this.integration.Size = new System.Drawing.Size(96, 23);
            this.integration.TabIndex = 2;
            this.integration.Text = "Integration";
            this.integration.UseVisualStyleBackColor = true;
            this.integration.Click += new System.EventHandler(this.integration_Click);
            // 
            // Deriveation
            // 
            this.Deriveation.Location = new System.Drawing.Point(185, 427);
            this.Deriveation.Name = "Deriveation";
            this.Deriveation.Size = new System.Drawing.Size(91, 23);
            this.Deriveation.TabIndex = 3;
            this.Deriveation.Text = "Deriveation";
            this.Deriveation.UseVisualStyleBackColor = true;
            this.Deriveation.Click += new System.EventHandler(this.Deriveation_Click);
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 462);
            this.Controls.Add(this.Deriveation);
            this.Controls.Add(this.integration);
            this.Controls.Add(this.interpolation);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Welcome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome";
            this.Load += new System.EventHandler(this.Welcome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button interpolation;
        private System.Windows.Forms.Button integration;
        private System.Windows.Forms.Button Deriveation;
    }
}

