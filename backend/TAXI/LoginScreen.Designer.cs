namespace TAXI
{
    partial class LoginScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginScreen));
            this.LoginLab = new System.Windows.Forms.Label();
            this.ClientLab = new System.Windows.Forms.Label();
            this.loginBox = new System.Windows.Forms.TextBox();
            this.passBox = new System.Windows.Forms.TextBox();
            this.PasLab = new System.Windows.Forms.Label();
            this.LogIn = new System.Windows.Forms.Button();
            this.checkPass = new System.Windows.Forms.CheckBox();
            this.carPicture = new System.Windows.Forms.PictureBox();
            this.buhgPicture = new System.Windows.Forms.PictureBox();
            this.SignIn = new System.Windows.Forms.LinkLabel();
            this.ForgotPass = new System.Windows.Forms.LinkLabel();
            this.errorProv = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.carPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buhgPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProv)).BeginInit();
            this.SuspendLayout();
            // 
            // LoginLab
            // 
            this.LoginLab.AutoSize = true;
            this.LoginLab.BackColor = System.Drawing.Color.Transparent;
            this.LoginLab.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginLab.Location = new System.Drawing.Point(170, 107);
            this.LoginLab.Name = "LoginLab";
            this.LoginLab.Size = new System.Drawing.Size(57, 15);
            this.LoginLab.TabIndex = 0;
            this.LoginLab.Text = "ЛОГИН";
            // 
            // ClientLab
            // 
            this.ClientLab.AutoSize = true;
            this.ClientLab.BackColor = System.Drawing.Color.Transparent;
            this.ClientLab.Font = new System.Drawing.Font("Segoe Print", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientLab.Location = new System.Drawing.Point(163, 9);
            this.ClientLab.Name = "ClientLab";
            this.ClientLab.Size = new System.Drawing.Size(263, 57);
            this.ClientLab.TabIndex = 1;
            this.ClientLab.Text = "Для клиентов";
            // 
            // loginBox
            // 
            this.loginBox.Location = new System.Drawing.Point(239, 105);
            this.loginBox.Name = "loginBox";
            this.loginBox.Size = new System.Drawing.Size(100, 20);
            this.loginBox.TabIndex = 2;
            this.loginBox.Validating += new System.ComponentModel.CancelEventHandler(this.loginBox_Validating);
            // 
            // passBox
            // 
            this.passBox.Location = new System.Drawing.Point(239, 175);
            this.passBox.Name = "passBox";
            this.passBox.Size = new System.Drawing.Size(100, 20);
            this.passBox.TabIndex = 3;
            this.passBox.Validating += new System.ComponentModel.CancelEventHandler(this.passBox_Validating);
            // 
            // PasLab
            // 
            this.PasLab.AutoSize = true;
            this.PasLab.BackColor = System.Drawing.Color.Transparent;
            this.PasLab.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasLab.Location = new System.Drawing.Point(168, 177);
            this.PasLab.Name = "PasLab";
            this.PasLab.Size = new System.Drawing.Size(65, 15);
            this.PasLab.TabIndex = 4;
            this.PasLab.Text = "ПАРОЛЬ";
            // 
            // LogIn
            // 
            this.LogIn.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.LogIn.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LogIn.Location = new System.Drawing.Point(253, 251);
            this.LogIn.Name = "LogIn";
            this.LogIn.Size = new System.Drawing.Size(75, 23);
            this.LogIn.TabIndex = 5;
            this.LogIn.Text = "Войти";
            this.LogIn.UseVisualStyleBackColor = false;
            this.LogIn.Click += new System.EventHandler(this.LogIn_Click);
            // 
            // checkPass
            // 
            this.checkPass.AutoSize = true;
            this.checkPass.BackColor = System.Drawing.Color.Transparent;
            this.checkPass.Location = new System.Drawing.Point(239, 212);
            this.checkPass.Name = "checkPass";
            this.checkPass.Size = new System.Drawing.Size(114, 17);
            this.checkPass.TabIndex = 6;
            this.checkPass.Text = "Показать пароль";
            this.checkPass.UseVisualStyleBackColor = false;
            this.checkPass.CheckedChanged += new System.EventHandler(this.checkPass_CheckedChanged);
            // 
            // carPicture
            // 
            this.carPicture.BackColor = System.Drawing.Color.Transparent;
            this.carPicture.Image = ((System.Drawing.Image)(resources.GetObject("carPicture.Image")));
            this.carPicture.Location = new System.Drawing.Point(12, 316);
            this.carPicture.Name = "carPicture";
            this.carPicture.Size = new System.Drawing.Size(188, 132);
            this.carPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.carPicture.TabIndex = 10;
            this.carPicture.TabStop = false;
            this.carPicture.Click += new System.EventHandler(this.carPicture_Click);
            this.carPicture.MouseEnter += new System.EventHandler(this.carPicture_MouseEnter);
            this.carPicture.MouseLeave += new System.EventHandler(this.carPicture_MouseLeave);
            // 
            // buhgPicture
            // 
            this.buhgPicture.BackColor = System.Drawing.Color.Transparent;
            this.buhgPicture.Image = ((System.Drawing.Image)(resources.GetObject("buhgPicture.Image")));
            this.buhgPicture.Location = new System.Drawing.Point(374, 316);
            this.buhgPicture.Name = "buhgPicture";
            this.buhgPicture.Size = new System.Drawing.Size(196, 132);
            this.buhgPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buhgPicture.TabIndex = 11;
            this.buhgPicture.TabStop = false;
            this.buhgPicture.Click += new System.EventHandler(this.buhgPicture_Click);
            this.buhgPicture.MouseEnter += new System.EventHandler(this.buhgPicture_MouseEnter);
            this.buhgPicture.MouseLeave += new System.EventHandler(this.buhgPicture_MouseLeave);
            // 
            // SignIn
            // 
            this.SignIn.AutoSize = true;
            this.SignIn.BackColor = System.Drawing.Color.Transparent;
            this.SignIn.LinkColor = System.Drawing.Color.PowderBlue;
            this.SignIn.Location = new System.Drawing.Point(183, 288);
            this.SignIn.Name = "SignIn";
            this.SignIn.Size = new System.Drawing.Size(75, 13);
            this.SignIn.TabIndex = 12;
            this.SignIn.TabStop = true;
            this.SignIn.Text = "Нет аккаунта";
            this.SignIn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SignIn_LinkClicked);
            // 
            // ForgotPass
            // 
            this.ForgotPass.AutoSize = true;
            this.ForgotPass.BackColor = System.Drawing.Color.Transparent;
            this.ForgotPass.LinkColor = System.Drawing.Color.PowderBlue;
            this.ForgotPass.Location = new System.Drawing.Point(328, 288);
            this.ForgotPass.Name = "ForgotPass";
            this.ForgotPass.Size = new System.Drawing.Size(79, 13);
            this.ForgotPass.TabIndex = 13;
            this.ForgotPass.TabStop = true;
            this.ForgotPass.Text = "Забыл пароль";
            this.ForgotPass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ForgotPass_LinkClicked);
            // 
            // errorProv
            // 
            this.errorProv.ContainerControl = this;
            // 
            // LoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(582, 450);
            this.Controls.Add(this.ForgotPass);
            this.Controls.Add(this.SignIn);
            this.Controls.Add(this.buhgPicture);
            this.Controls.Add(this.carPicture);
            this.Controls.Add(this.checkPass);
            this.Controls.Add(this.LogIn);
            this.Controls.Add(this.PasLab);
            this.Controls.Add(this.passBox);
            this.Controls.Add(this.loginBox);
            this.Controls.Add(this.ClientLab);
            this.Controls.Add(this.LoginLab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginScreen";
            this.Text = "Spirit Breaker\'s Taxi";
            this.Activated += new System.EventHandler(this.LoginScreen_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.carPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buhgPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LoginLab;
        private System.Windows.Forms.Label ClientLab;
        private System.Windows.Forms.TextBox loginBox;
        private System.Windows.Forms.TextBox passBox;
        private System.Windows.Forms.Label PasLab;
        private System.Windows.Forms.Button LogIn;
        private System.Windows.Forms.CheckBox checkPass;
        private System.Windows.Forms.PictureBox carPicture;
        private System.Windows.Forms.PictureBox buhgPicture;
        private System.Windows.Forms.LinkLabel SignIn;
        private System.Windows.Forms.LinkLabel ForgotPass;
        private System.Windows.Forms.ErrorProvider errorProv;
    }
}