using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TAXI
{
    public partial class adminMainForm : Form
    {
        private string connectionString;
        private SqlDataAdapter sqlDataAdapter;
        private DataSet dataSet;
        public static string gosnomer;
        public static string dr;
        public static int chnTab;
        public static string fine;
        public static int finecase;
        public adminMainForm()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["TaxiBD"].ConnectionString;
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadOrders();
        }
        private void adminMainForm_Load(object sender, EventArgs e)
        {
            if (chnTab == 2)
            {
                tabControl1.SelectedTab = drivers;
            }
            if (chnTab == 3)
            {
                tabControl1.SelectedTab = cars;
            }
            if (chnTab == 4)
            {
                tabControl1.SelectedTab = fines;
            }
        }

        private void LoadOrders()
        {
            try
            {
                sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Orders", connectionString);               
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "Orders");
                dataGridView1.DataSource = dataSet.Tables["Orders"];
                dataGridView1.ReadOnly = true;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                foreach (SqlError err in ex.Errors)
                {
                    MessageBox.Show(err.Message + " " + err.Number);
                }
            }
        }

        private void poiskBox_MouseLeave(object sender, EventArgs e)
        {
            if (poiskBox.Text != "")
            {
                try
                {
                    SqlConnection connection = new SqlConnection(connectionString);
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    string client = "SELECT * FROM Orders WHERE Клиент = " +
                                    poiskBox.Text;
                    sqlDataAdapter = new SqlDataAdapter(client, connectionString);
                    dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet, "Orders");
                    dataGridView1.DataSource = dataSet.Tables["Orders"];
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                        dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    foreach (SqlError err in ex.Errors)
                    {
                        MessageBox.Show(err.Message + " " + err.Number);
                    }
                }
            }
            else
                LoadOrders();
        }

        private void LoadClients()
        {
            try
            {
                sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Clients", connectionString);
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "Clients");
                dataGridView2.DataSource = dataSet.Tables["Clients"];
                dataGridView2.ReadOnly = true;
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[dataGridView2.ColumnCount - 1, i] = linkCell;
                }

                SqlConnection connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT ID FROM Clients ORDER BY ID", connection);
                SqlDataReader rdr = cmd.ExecuteReader();

                int n = 0;
                while (rdr.Read())
                {
                    clientsIDs.Items.Add(rdr[n].ToString());
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                foreach (SqlError err in ex.Errors)
                {
                    MessageBox.Show(err.Message + " " + err.Number);
                }
            }
        }

        private void LoadDrivers()
        {
            try
            {
                sqlDataAdapter = new SqlDataAdapter("SELECT *, 'Изменить' AS [ДЕЙСТВИЕ] FROM Drivers", connectionString);
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "Drivers");
                dataGridView3.DataSource = dataSet.Tables["Drivers"];
                dataGridView3.ReadOnly = true;            
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                foreach (SqlError err in ex.Errors)
                {
                    MessageBox.Show(err.Message + " " + err.Number);
                }
            }
        }
        private void LoadCars()
        {
            try
            {
                sqlDataAdapter = new SqlDataAdapter("SELECT *, 'Изменить' AS [ДЕЙСТВИЕ] FROM Cars", connectionString);
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "Cars");
                dataGridView4.DataSource = dataSet.Tables["Cars"];
                dataGridView4.ReadOnly = true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                foreach (SqlError err in ex.Errors)
                {
                    MessageBox.Show(err.Message + " " + err.Number);
                }
            }
        }
        private void LoadWaybills()
        {
            try
            {
                sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Waybill", connectionString);
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "Waybill");
                dataGridView5.DataSource = dataSet.Tables["Waybill"];
                dataGridView5.ReadOnly = true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                foreach (SqlError err in ex.Errors)
                {
                    MessageBox.Show(err.Message + " " + err.Number);
                }
            }
        }
        private void LoadFines()
        {
            try
            {
                sqlDataAdapter = new SqlDataAdapter("SELECT *, 'Изменить' AS [ДЕЙСТВИЕ] FROM Fines", connectionString);
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "Fines");
                dataGridView6.DataSource = dataSet.Tables["Fines"];
                dataGridView6.ReadOnly = true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                foreach (SqlError err in ex.Errors)
                {
                    MessageBox.Show(err.Message + " " + err.Number);
                }
            }
        }
        private void phoneCofirmBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string changePhone = "UPDATE Clients SET Телефон = " + phoneBox.Text + 
                                      " WHERE ID = " + clientsIDs.SelectedItem.ToString();
                SqlCommand cmd = new SqlCommand(changePhone, connection);
                cmd.ExecuteScalar();
                sqlDataAdapter.Update(dataSet, "Clients");
                LoadClients();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                foreach (SqlError err in ex.Errors)
                {
                    MessageBox.Show(err.Message + " " + err.Number);
                }
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if(e.TabPage == orders)
            {                
                clientsIDs.Items.Clear();
            }
            if (e.TabPage == clients)
            {
                LoadClients();
            }
            if (e.TabPage == drivers)
            {
                LoadDrivers();
            }
            if(e.TabPage == cars)
            {
                LoadCars();
            }
            if(e.TabPage == waybills)
            {
                LoadWaybills();
            }
            if(e.TabPage == fines)
            {
                LoadFines();
            }
        }

        private void clientsIDs_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string changePhoneinbox = "SELECT Телефон FROM Clients WHERE ID = " 
                                     + clientsIDs.SelectedItem.ToString();
                SqlCommand cmd = new SqlCommand(changePhoneinbox, connection);
                phoneBox.Text = cmd.ExecuteScalar().ToString();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                foreach (SqlError err in ex.Errors)
                {
                    MessageBox.Show(err.Message + " " + err.Number);
                }
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 13)
            {
                dr = dataGridView3.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                adminChangeDriver acd = new adminChangeDriver();
                Hide();
                acd.ShowDialog();
                Close();
            }
        }
        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                gosnomer = dataGridView4.Rows[e.RowIndex].Cells["Гос. номер"].Value.ToString();
                adminChangeCars acc = new adminChangeCars();
                Hide();
                acc.ShowDialog();
                Close();
            }
        }

        private void tabControl1_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            if(e.TabPage == orders)
            {
                poiskBox.Text = " ";
            }
        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                fine = dataGridView6.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                finecase = 0;
                adminFines af = new adminFines();
                Hide();
                af.ShowDialog();
                Close();
            }
            if (e.RowIndex == dataGridView6.Rows.Count - 1)
            {
                finecase = 1;
                adminFines af = new adminFines();
                Hide();
                af.ShowDialog();
                Close();
            }
        }
    }
}
