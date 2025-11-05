namespace TAXI
{
    partial class adminMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(adminMainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.orders = new System.Windows.Forms.TabPage();
            this.poiskOrderLab = new System.Windows.Forms.Label();
            this.poiskBox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clients = new System.Windows.Forms.TabPage();
            this.phoneCofirmBtn = new System.Windows.Forms.Button();
            this.phoneBox = new System.Windows.Forms.TextBox();
            this.clientsIDs = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.drivers = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.cars = new System.Windows.Forms.TabPage();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.waybills = new System.Windows.Forms.TabPage();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.fines = new System.Windows.Forms.TabPage();
            this.dataGridView6 = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.orders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.clients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.drivers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.cars.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.waybills.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            this.fines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.orders);
            this.tabControl1.Controls.Add(this.clients);
            this.tabControl1.Controls.Add(this.drivers);
            this.tabControl1.Controls.Add(this.cars);
            this.tabControl1.Controls.Add(this.waybills);
            this.tabControl1.Controls.Add(this.fines);
            this.tabControl1.Location = new System.Drawing.Point(0, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(930, 506);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            this.tabControl1.Deselecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Deselecting);
            // 
            // orders
            // 
            this.orders.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.orders.Controls.Add(this.poiskOrderLab);
            this.orders.Controls.Add(this.poiskBox);
            this.orders.Controls.Add(this.dataGridView1);
            this.orders.Location = new System.Drawing.Point(4, 22);
            this.orders.Name = "orders";
            this.orders.Padding = new System.Windows.Forms.Padding(3);
            this.orders.Size = new System.Drawing.Size(922, 480);
            this.orders.TabIndex = 0;
            this.orders.Text = "Заказы";
            // 
            // poiskOrderLab
            // 
            this.poiskOrderLab.AutoSize = true;
            this.poiskOrderLab.Location = new System.Drawing.Point(292, 9);
            this.poiskOrderLab.Name = "poiskOrderLab";
            this.poiskOrderLab.Size = new System.Drawing.Size(129, 13);
            this.poiskOrderLab.TabIndex = 2;
            this.poiskOrderLab.Text = "Найти заказ по клиенту";
            // 
            // poiskBox
            // 
            this.poiskBox.Location = new System.Drawing.Point(485, 6);
            this.poiskBox.Name = "poiskBox";
            this.poiskBox.Size = new System.Drawing.Size(84, 20);
            this.poiskBox.TabIndex = 1;
            this.poiskBox.MouseLeave += new System.EventHandler(this.poiskBox_MouseLeave);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 32);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(922, 445);
            this.dataGridView1.TabIndex = 0;
            // 
            // clients
            // 
            this.clients.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.clients.Controls.Add(this.phoneCofirmBtn);
            this.clients.Controls.Add(this.phoneBox);
            this.clients.Controls.Add(this.clientsIDs);
            this.clients.Controls.Add(this.label1);
            this.clients.Controls.Add(this.dataGridView2);
            this.clients.Location = new System.Drawing.Point(4, 22);
            this.clients.Name = "clients";
            this.clients.Padding = new System.Windows.Forms.Padding(3);
            this.clients.Size = new System.Drawing.Size(922, 480);
            this.clients.TabIndex = 1;
            this.clients.Text = "Клиенты";
            // 
            // phoneCofirmBtn
            // 
            this.phoneCofirmBtn.Location = new System.Drawing.Point(400, 452);
            this.phoneCofirmBtn.Name = "phoneCofirmBtn";
            this.phoneCofirmBtn.Size = new System.Drawing.Size(101, 23);
            this.phoneCofirmBtn.TabIndex = 4;
            this.phoneCofirmBtn.Text = "Подтвердить";
            this.phoneCofirmBtn.UseVisualStyleBackColor = true;
            this.phoneCofirmBtn.Click += new System.EventHandler(this.phoneCofirmBtn_Click);
            // 
            // phoneBox
            // 
            this.phoneBox.Location = new System.Drawing.Point(444, 425);
            this.phoneBox.Name = "phoneBox";
            this.phoneBox.Size = new System.Drawing.Size(97, 20);
            this.phoneBox.TabIndex = 3;
            // 
            // clientsIDs
            // 
            this.clientsIDs.FormattingEnabled = true;
            this.clientsIDs.Location = new System.Drawing.Point(375, 425);
            this.clientsIDs.Name = "clientsIDs";
            this.clientsIDs.Size = new System.Drawing.Size(53, 21);
            this.clientsIDs.TabIndex = 2;
            this.clientsIDs.SelectedIndexChanged += new System.EventHandler(this.clientsIDs_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(385, 400);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Изменить номер клиента";
            // 
            // dataGridView2
            // 
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(922, 386);
            this.dataGridView2.TabIndex = 0;
            // 
            // drivers
            // 
            this.drivers.Controls.Add(this.dataGridView3);
            this.drivers.Location = new System.Drawing.Point(4, 22);
            this.drivers.Name = "drivers";
            this.drivers.Size = new System.Drawing.Size(922, 480);
            this.drivers.TabIndex = 3;
            this.drivers.Text = "Водители";
            this.drivers.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(-4, 0);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(930, 480);
            this.dataGridView3.TabIndex = 0;
            this.dataGridView3.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellClick);
            // 
            // cars
            // 
            this.cars.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.cars.Controls.Add(this.dataGridView4);
            this.cars.Location = new System.Drawing.Point(4, 22);
            this.cars.Name = "cars";
            this.cars.Size = new System.Drawing.Size(922, 480);
            this.cars.TabIndex = 2;
            this.cars.Text = "Машины";
            // 
            // dataGridView4
            // 
            this.dataGridView4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Location = new System.Drawing.Point(0, 0);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(926, 415);
            this.dataGridView4.TabIndex = 0;
            this.dataGridView4.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView4_CellClick);
            // 
            // waybills
            // 
            this.waybills.Controls.Add(this.dataGridView5);
            this.waybills.Location = new System.Drawing.Point(4, 22);
            this.waybills.Name = "waybills";
            this.waybills.Size = new System.Drawing.Size(922, 480);
            this.waybills.TabIndex = 4;
            this.waybills.Text = "Путевые листы";
            this.waybills.UseVisualStyleBackColor = true;
            // 
            // dataGridView5
            // 
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Location = new System.Drawing.Point(0, 0);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.Size = new System.Drawing.Size(926, 484);
            this.dataGridView5.TabIndex = 0;
            // 
            // fines
            // 
            this.fines.Controls.Add(this.dataGridView6);
            this.fines.Location = new System.Drawing.Point(4, 22);
            this.fines.Name = "fines";
            this.fines.Padding = new System.Windows.Forms.Padding(3);
            this.fines.Size = new System.Drawing.Size(922, 480);
            this.fines.TabIndex = 5;
            this.fines.Text = "Штрафы";
            this.fines.UseVisualStyleBackColor = true;
            // 
            // dataGridView6
            // 
            this.dataGridView6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView6.Location = new System.Drawing.Point(-4, 0);
            this.dataGridView6.Name = "dataGridView6";
            this.dataGridView6.Size = new System.Drawing.Size(926, 480);
            this.dataGridView6.TabIndex = 0;
            this.dataGridView6.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView6_CellClick);
            // 
            // adminMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 501);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "adminMainForm";
            this.Text = "Spirit Breaker\'s Taxi";
            this.Load += new System.EventHandler(this.adminMainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.orders.ResumeLayout(false);
            this.orders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.clients.ResumeLayout(false);
            this.clients.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.drivers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.cars.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.waybills.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            this.fines.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage orders;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage clients;
        private System.Windows.Forms.TabPage drivers;
        private System.Windows.Forms.TabPage cars;
        private System.Windows.Forms.TabPage waybills;
        private System.Windows.Forms.Label poiskOrderLab;
        private System.Windows.Forms.TextBox poiskBox;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button phoneCofirmBtn;
        private System.Windows.Forms.TextBox phoneBox;
        private System.Windows.Forms.ComboBox clientsIDs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.DataGridView dataGridView5;
        private System.Windows.Forms.TabPage fines;
        private System.Windows.Forms.DataGridView dataGridView6;
    }
}