namespace TAXI
{
    partial class ClientMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientMainForm));
            this.TakeOrder = new System.Windows.Forms.PictureBox();
            this.showOrders = new System.Windows.Forms.PictureBox();
            this.takeOrderLab = new System.Windows.Forms.Label();
            this.showOrdersLab = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TakeOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.showOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // TakeOrder
            // 
            this.TakeOrder.Image = ((System.Drawing.Image)(resources.GetObject("TakeOrder.Image")));
            this.TakeOrder.Location = new System.Drawing.Point(-7, 0);
            this.TakeOrder.Name = "TakeOrder";
            this.TakeOrder.Size = new System.Drawing.Size(352, 385);
            this.TakeOrder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TakeOrder.TabIndex = 0;
            this.TakeOrder.TabStop = false;
            this.TakeOrder.Click += new System.EventHandler(this.TakeOrder_Click);
            this.TakeOrder.MouseEnter += new System.EventHandler(this.TakeOrder_MouseEnter);
            this.TakeOrder.MouseLeave += new System.EventHandler(this.TakeOrder_MouseLeave);
            // 
            // showOrders
            // 
            this.showOrders.BackColor = System.Drawing.SystemColors.Control;
            this.showOrders.Image = ((System.Drawing.Image)(resources.GetObject("showOrders.Image")));
            this.showOrders.Location = new System.Drawing.Point(341, 0);
            this.showOrders.Name = "showOrders";
            this.showOrders.Size = new System.Drawing.Size(339, 385);
            this.showOrders.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.showOrders.TabIndex = 1;
            this.showOrders.TabStop = false;
            this.showOrders.Click += new System.EventHandler(this.showOrders_Click);
            this.showOrders.MouseEnter += new System.EventHandler(this.showOrders_MouseEnter);
            this.showOrders.MouseLeave += new System.EventHandler(this.showOrders_MouseLeave);
            // 
            // takeOrderLab
            // 
            this.takeOrderLab.AutoSize = true;
            this.takeOrderLab.BackColor = System.Drawing.Color.Gainsboro;
            this.takeOrderLab.Font = new System.Drawing.Font("Javanese Text", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.takeOrderLab.Location = new System.Drawing.Point(25, 9);
            this.takeOrderLab.Name = "takeOrderLab";
            this.takeOrderLab.Size = new System.Drawing.Size(280, 62);
            this.takeOrderLab.TabIndex = 2;
            this.takeOrderLab.Text = "Заказать такси";
            // 
            // showOrdersLab
            // 
            this.showOrdersLab.AutoSize = true;
            this.showOrdersLab.BackColor = System.Drawing.Color.Gainsboro;
            this.showOrdersLab.Font = new System.Drawing.Font("Javanese Text", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showOrdersLab.Location = new System.Drawing.Point(12, 9);
            this.showOrdersLab.Name = "showOrdersLab";
            this.showOrdersLab.Size = new System.Drawing.Size(307, 62);
            this.showOrdersLab.TabIndex = 3;
            this.showOrdersLab.Text = "История заказов";
            // 
            // ClientMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 384);
            this.Controls.Add(this.showOrdersLab);
            this.Controls.Add(this.takeOrderLab);
            this.Controls.Add(this.showOrders);
            this.Controls.Add(this.TakeOrder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClientMainForm";
            this.Text = "Spirit Breaker\'s Taxi";
            this.Load += new System.EventHandler(this.ClientMainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TakeOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.showOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox TakeOrder;
        private System.Windows.Forms.PictureBox showOrders;
        private System.Windows.Forms.Label takeOrderLab;
        private System.Windows.Forms.Label showOrdersLab;
    }
}