namespace TAXI
{
    partial class DriversMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DriversMainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.opclo = new System.Windows.Forms.TabPage();
            this.changeSostLab = new System.Windows.Forms.Label();
            this.sostLab = new System.Windows.Forms.Label();
            this.wayb = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.callsign = new System.Windows.Forms.TabPage();
            this.resetBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.vodBox = new System.Windows.Forms.TextBox();
            this.ptcBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.fines = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.opclo.SuspendLayout();
            this.wayb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.callsign.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.fines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.opclo);
            this.tabControl1.Controls.Add(this.wayb);
            this.tabControl1.Controls.Add(this.callsign);
            this.tabControl1.Controls.Add(this.fines);
            this.tabControl1.Location = new System.Drawing.Point(-2, -2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(846, 454);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // opclo
            // 
            this.opclo.Controls.Add(this.changeSostLab);
            this.opclo.Controls.Add(this.sostLab);
            this.opclo.Location = new System.Drawing.Point(4, 22);
            this.opclo.Name = "opclo";
            this.opclo.Padding = new System.Windows.Forms.Padding(3);
            this.opclo.Size = new System.Drawing.Size(838, 428);
            this.opclo.TabIndex = 0;
            this.opclo.Text = "Открыть/закрыть путлист";
            this.opclo.UseVisualStyleBackColor = true;
            // 
            // changeSostLab
            // 
            this.changeSostLab.AutoSize = true;
            this.changeSostLab.Font = new System.Drawing.Font("Palatino Linotype", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changeSostLab.Location = new System.Drawing.Point(345, 207);
            this.changeSostLab.Name = "changeSostLab";
            this.changeSostLab.Size = new System.Drawing.Size(89, 35);
            this.changeSostLab.TabIndex = 1;
            this.changeSostLab.Text = "label2";
            this.changeSostLab.Click += new System.EventHandler(this.changeSostLab_Click);
            // 
            // sostLab
            // 
            this.sostLab.AutoSize = true;
            this.sostLab.Font = new System.Drawing.Font("Palatino Linotype", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sostLab.Location = new System.Drawing.Point(191, 92);
            this.sostLab.Name = "sostLab";
            this.sostLab.Size = new System.Drawing.Size(113, 37);
            this.sostLab.TabIndex = 0;
            this.sostLab.Text = "ПРимер";
            // 
            // wayb
            // 
            this.wayb.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.wayb.Controls.Add(this.dataGridView1);
            this.wayb.Location = new System.Drawing.Point(4, 22);
            this.wayb.Name = "wayb";
            this.wayb.Padding = new System.Windows.Forms.Padding(3);
            this.wayb.Size = new System.Drawing.Size(838, 428);
            this.wayb.TabIndex = 1;
            this.wayb.Text = "Путевые листы";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(-4, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(845, 432);
            this.dataGridView1.TabIndex = 0;
            // 
            // callsign
            // 
            this.callsign.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.callsign.Controls.Add(this.resetBtn);
            this.callsign.Controls.Add(this.saveBtn);
            this.callsign.Controls.Add(this.vodBox);
            this.callsign.Controls.Add(this.ptcBox);
            this.callsign.Controls.Add(this.label2);
            this.callsign.Controls.Add(this.label1);
            this.callsign.Controls.Add(this.dataGridView2);
            this.callsign.Location = new System.Drawing.Point(4, 22);
            this.callsign.Name = "callsign";
            this.callsign.Size = new System.Drawing.Size(838, 428);
            this.callsign.TabIndex = 2;
            this.callsign.Text = "Позывной";
            // 
            // resetBtn
            // 
            this.resetBtn.Location = new System.Drawing.Point(346, 298);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(75, 23);
            this.resetBtn.TabIndex = 6;
            this.resetBtn.Text = "Отменить";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveBtn.Location = new System.Drawing.Point(311, 231);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(150, 49);
            this.saveBtn.TabIndex = 5;
            this.saveBtn.Text = "Сохранить изменения";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // vodBox
            // 
            this.vodBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.vodBox.Location = new System.Drawing.Point(484, 181);
            this.vodBox.Name = "vodBox";
            this.vodBox.Size = new System.Drawing.Size(119, 21);
            this.vodBox.TabIndex = 4;
            // 
            // ptcBox
            // 
            this.ptcBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ptcBox.Location = new System.Drawing.Point(172, 181);
            this.ptcBox.Name = "ptcBox";
            this.ptcBox.Size = new System.Drawing.Size(119, 21);
            this.ptcBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(446, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Водительское удостоверение";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(212, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "ПТС";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(-8, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(852, 114);
            this.dataGridView2.TabIndex = 0;
            // 
            // fines
            // 
            this.fines.Controls.Add(this.dataGridView3);
            this.fines.Location = new System.Drawing.Point(4, 22);
            this.fines.Name = "fines";
            this.fines.Size = new System.Drawing.Size(838, 428);
            this.fines.TabIndex = 3;
            this.fines.Text = "Штрафы";
            this.fines.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(0, 0);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(838, 428);
            this.dataGridView3.TabIndex = 0;
            this.dataGridView3.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellClick);
            // 
            // DriversMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 450);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DriversMainForm";
            this.Text = "Spirit Breaker\'s Taxi";
            this.Load += new System.EventHandler(this.DriversMainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.opclo.ResumeLayout(false);
            this.opclo.PerformLayout();
            this.wayb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.callsign.ResumeLayout(false);
            this.callsign.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.fines.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage opclo;
        private System.Windows.Forms.TabPage wayb;
        private System.Windows.Forms.TabPage callsign;
        private System.Windows.Forms.Label changeSostLab;
        private System.Windows.Forms.Label sostLab;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TabPage fines;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TextBox vodBox;
        private System.Windows.Forms.TextBox ptcBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}