namespace TAXI
{
    partial class ShowClientOrders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowClientOrders));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.callsign = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ins = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arrowBack = new System.Windows.Forms.PictureBox();
            this.infLab = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrowBack)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Tan;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.callsign,
            this.status,
            this.date,
            this.time,
            this.outc,
            this.outs,
            this.outh,
            this.inc,
            this.ins,
            this.inh,
            this.comment});
            this.dataGridView1.Location = new System.Drawing.Point(1, -1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(944, 345);
            this.dataGridView1.TabIndex = 2;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 25;
            // 
            // callsign
            // 
            this.callsign.HeaderText = "Позывной";
            this.callsign.Name = "callsign";
            this.callsign.ReadOnly = true;
            this.callsign.Width = 75;
            // 
            // status
            // 
            this.status.HeaderText = "Статус";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 75;
            // 
            // date
            // 
            this.date.HeaderText = "Дата";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.Width = 75;
            // 
            // time
            // 
            this.time.HeaderText = "Время";
            this.time.Name = "time";
            this.time.ReadOnly = true;
            this.time.Width = 75;
            // 
            // outc
            // 
            this.outc.HeaderText = "Город отправления";
            this.outc.Name = "outc";
            this.outc.ReadOnly = true;
            this.outc.Width = 80;
            // 
            // outs
            // 
            this.outs.HeaderText = "Улица отправления";
            this.outs.Name = "outs";
            this.outs.ReadOnly = true;
            this.outs.Width = 90;
            // 
            // outh
            // 
            this.outh.HeaderText = "Дом";
            this.outh.Name = "outh";
            this.outh.ReadOnly = true;
            this.outh.Width = 35;
            // 
            // inc
            // 
            this.inc.HeaderText = "Город назначения";
            this.inc.Name = "inc";
            this.inc.ReadOnly = true;
            this.inc.Width = 80;
            // 
            // ins
            // 
            this.ins.HeaderText = "Улица назначения";
            this.ins.Name = "ins";
            this.ins.ReadOnly = true;
            this.ins.Width = 90;
            // 
            // inh
            // 
            this.inh.HeaderText = "Дом";
            this.inh.Name = "inh";
            this.inh.ReadOnly = true;
            this.inh.Width = 35;
            // 
            // comment
            // 
            this.comment.HeaderText = "Комментарии";
            this.comment.Name = "comment";
            this.comment.ReadOnly = true;
            this.comment.Width = 160;
            // 
            // arrowBack
            // 
            this.arrowBack.Image = ((System.Drawing.Image)(resources.GetObject("arrowBack.Image")));
            this.arrowBack.Location = new System.Drawing.Point(1, 350);
            this.arrowBack.Name = "arrowBack";
            this.arrowBack.Size = new System.Drawing.Size(99, 68);
            this.arrowBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.arrowBack.TabIndex = 3;
            this.arrowBack.TabStop = false;
            this.arrowBack.Click += new System.EventHandler(this.arrowBack_Click);
            this.arrowBack.MouseEnter += new System.EventHandler(this.arrowBack_MouseEnter);
            this.arrowBack.MouseLeave += new System.EventHandler(this.arrowBack_MouseLeave);
            // 
            // infLab
            // 
            this.infLab.AutoSize = true;
            this.infLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infLab.Location = new System.Drawing.Point(172, 365);
            this.infLab.Name = "infLab";
            this.infLab.Size = new System.Drawing.Size(71, 25);
            this.infLab.TabIndex = 4;
            this.infLab.Text = "infLab";
            // 
            // ShowClientOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(938, 419);
            this.Controls.Add(this.infLab);
            this.Controls.Add(this.arrowBack);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShowClientOrders";
            this.Text = "Spirit Breaker\'s Taxi";
            this.Load += new System.EventHandler(this.ShowClientOrders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrowBack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn callsign;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn outc;
        private System.Windows.Forms.DataGridViewTextBoxColumn outs;
        private System.Windows.Forms.DataGridViewTextBoxColumn outh;
        private System.Windows.Forms.DataGridViewTextBoxColumn inc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ins;
        private System.Windows.Forms.DataGridViewTextBoxColumn inh;
        private System.Windows.Forms.DataGridViewTextBoxColumn comment;
        private System.Windows.Forms.PictureBox arrowBack;
        private System.Windows.Forms.Label infLab;
    }
}