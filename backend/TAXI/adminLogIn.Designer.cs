namespace TAXI
{
    partial class adminLogIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(adminLogIn));
            this.LogInBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.logInBox = new System.Windows.Forms.TextBox();
            this.passBox = new System.Windows.Forms.TextBox();
            this.arrowBack = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.arrowBack)).BeginInit();
            this.SuspendLayout();
            // 
            // LogInBtn
            // 
            this.LogInBtn.Location = new System.Drawing.Point(127, 215);
            this.LogInBtn.Name = "LogInBtn";
            this.LogInBtn.Size = new System.Drawing.Size(75, 23);
            this.LogInBtn.TabIndex = 0;
            this.LogInBtn.Text = "Войти";
            this.LogInBtn.UseVisualStyleBackColor = true;
            this.LogInBtn.Click += new System.EventHandler(this.LogInBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(143, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(143, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Пароль";
            // 
            // logInBox
            // 
            this.logInBox.Location = new System.Drawing.Point(115, 86);
            this.logInBox.Name = "logInBox";
            this.logInBox.Size = new System.Drawing.Size(100, 20);
            this.logInBox.TabIndex = 3;
            // 
            // passBox
            // 
            this.passBox.Location = new System.Drawing.Point(115, 160);
            this.passBox.Name = "passBox";
            this.passBox.Size = new System.Drawing.Size(100, 20);
            this.passBox.TabIndex = 4;
            // 
            // arrowBack
            // 
            this.arrowBack.BackColor = System.Drawing.Color.Transparent;
            this.arrowBack.Image = ((System.Drawing.Image)(resources.GetObject("arrowBack.Image")));
            this.arrowBack.Location = new System.Drawing.Point(3, 256);
            this.arrowBack.Name = "arrowBack";
            this.arrowBack.Size = new System.Drawing.Size(70, 68);
            this.arrowBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.arrowBack.TabIndex = 5;
            this.arrowBack.TabStop = false;
            this.arrowBack.Click += new System.EventHandler(this.arrowBack_Click);
            this.arrowBack.MouseEnter += new System.EventHandler(this.arrowBack_MouseEnter);
            this.arrowBack.MouseLeave += new System.EventHandler(this.arrowBack_MouseLeave);
            // 
            // adminLogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 327);
            this.Controls.Add(this.arrowBack);
            this.Controls.Add(this.passBox);
            this.Controls.Add(this.logInBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LogInBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "adminLogIn";
            this.Text = "Spirit Breaker\'s Taxi";
            ((System.ComponentModel.ISupportInitialize)(this.arrowBack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LogInBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox logInBox;
        private System.Windows.Forms.TextBox passBox;
        private System.Windows.Forms.PictureBox arrowBack;
    }
}