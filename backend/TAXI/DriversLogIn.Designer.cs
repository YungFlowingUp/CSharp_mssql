namespace TAXI
{
    partial class DriversLogIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DriversLogIn));
            this.label1 = new System.Windows.Forms.Label();
            this.callSignBox = new System.Windows.Forms.TextBox();
            this.logInBtn = new System.Windows.Forms.Button();
            this.arrowBack = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.arrowBack)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(140, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Позывной";
            // 
            // callSignBox
            // 
            this.callSignBox.Location = new System.Drawing.Point(115, 77);
            this.callSignBox.Name = "callSignBox";
            this.callSignBox.Size = new System.Drawing.Size(100, 20);
            this.callSignBox.TabIndex = 1;
            this.callSignBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // logInBtn
            // 
            this.logInBtn.Location = new System.Drawing.Point(124, 137);
            this.logInBtn.Name = "logInBtn";
            this.logInBtn.Size = new System.Drawing.Size(75, 23);
            this.logInBtn.TabIndex = 2;
            this.logInBtn.Text = "Войти";
            this.logInBtn.UseVisualStyleBackColor = true;
            this.logInBtn.Click += new System.EventHandler(this.logInBtn_Click);
            // 
            // arrowBack
            // 
            this.arrowBack.Image = ((System.Drawing.Image)(resources.GetObject("arrowBack.Image")));
            this.arrowBack.Location = new System.Drawing.Point(2, 149);
            this.arrowBack.Name = "arrowBack";
            this.arrowBack.Size = new System.Drawing.Size(73, 54);
            this.arrowBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.arrowBack.TabIndex = 3;
            this.arrowBack.TabStop = false;
            this.arrowBack.Click += new System.EventHandler(this.arrowBack_Click);
            this.arrowBack.MouseEnter += new System.EventHandler(this.arrowBack_MouseEnter);
            this.arrowBack.MouseLeave += new System.EventHandler(this.arrowBack_MouseLeave);
            // 
            // DriversLogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 206);
            this.Controls.Add(this.arrowBack);
            this.Controls.Add(this.logInBtn);
            this.Controls.Add(this.callSignBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DriversLogIn";
            this.Text = "Spirit Breaker\'s Taxi";
            ((System.ComponentModel.ISupportInitialize)(this.arrowBack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox callSignBox;
        private System.Windows.Forms.Button logInBtn;
        private System.Windows.Forms.PictureBox arrowBack;
    }
}