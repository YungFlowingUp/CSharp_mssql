namespace TAXI
{
    partial class Loading
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loading));
            this.Phon = new System.Windows.Forms.PictureBox();
            this.SpiritLabel = new System.Windows.Forms.Label();
            this.TaxiLab = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Phon)).BeginInit();
            this.SuspendLayout();
            // 
            // Phon
            // 
            this.Phon.Image = ((System.Drawing.Image)(resources.GetObject("Phon.Image")));
            this.Phon.Location = new System.Drawing.Point(-2, 0);
            this.Phon.Name = "Phon";
            this.Phon.Size = new System.Drawing.Size(801, 600);
            this.Phon.TabIndex = 0;
            this.Phon.TabStop = false;
            // 
            // SpiritLabel
            // 
            this.SpiritLabel.AutoSize = true;
            this.SpiritLabel.BackColor = System.Drawing.Color.Transparent;
            this.SpiritLabel.Font = new System.Drawing.Font("Viner Hand ITC", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpiritLabel.ForeColor = System.Drawing.Color.Chartreuse;
            this.SpiritLabel.Location = new System.Drawing.Point(88, 68);
            this.SpiritLabel.Name = "SpiritLabel";
            this.SpiritLabel.Size = new System.Drawing.Size(0, 103);
            this.SpiritLabel.TabIndex = 1;
            // 
            // TaxiLab
            // 
            this.TaxiLab.AutoSize = true;
            this.TaxiLab.BackColor = System.Drawing.Color.Transparent;
            this.TaxiLab.Font = new System.Drawing.Font("Modern No. 20", 47.99999F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaxiLab.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.TaxiLab.Location = new System.Drawing.Point(57, 524);
            this.TaxiLab.Name = "TaxiLab";
            this.TaxiLab.Size = new System.Drawing.Size(0, 65);
            this.TaxiLab.TabIndex = 2;
            // 
            // Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 598);
            this.Controls.Add(this.TaxiLab);
            this.Controls.Add(this.SpiritLabel);
            this.Controls.Add(this.Phon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Loading";
            this.Text = "Spirit Breaker\'s Taxi";
            this.Load += new System.EventHandler(this.Loading_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Phon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Phon;
        private System.Windows.Forms.Label SpiritLabel;
        private System.Windows.Forms.Label TaxiLab;
    }
}

