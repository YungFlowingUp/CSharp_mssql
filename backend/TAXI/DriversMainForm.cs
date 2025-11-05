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
    public partial class DriversMainForm : Form
    {
        private string connectionString;
        private int wayid;
        private int er;        

        private SqlDataAdapter sqlDataAdapter;
        private DataSet dataSet;        
        private SqlCommandBuilder sqlBuilder;        
        
        public DriversMainForm()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["TaxiBD"].ConnectionString;
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadFines();
            if (adminMainForm.chnTab == 10)
            {
                tabControl1.SelectedTab = fines;
            }
        }
        private void LoadDataCallSign()
        {
            try
            {
                string quer = "SELECT * FROM CallSign WHERE ID = " + DriversLogIn.DriversID.ToString();
                sqlDataAdapter = new SqlDataAdapter(quer, connectionString);
                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);
                sqlBuilder.GetUpdateCommand();
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "CallSign");
                dataGridView2.DataSource = dataSet.Tables["CallSign"];

                SqlConnection connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string q = "SELECT [Страховой номер машины] FROM CallSign WHERE ID = " + DriversLogIn.DriversID.ToString();
                SqlCommand command = new SqlCommand(q, connection);
                ptcBox.Text = command.ExecuteScalar().ToString();

                q = "SELECT [Водительское удостоверение] FROM CallSign WHERE ID = " + DriversLogIn.DriversID.ToString();
                SqlCommand cmd = new SqlCommand(q, connection);
                vodBox.Text = cmd.ExecuteScalar().ToString();
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
        private void LoadDataWaybill()
        {   
            try
            {
                string quer = "SELECT * FROM Waybill WHERE Позывной = " + DriversLogIn.DriversID.ToString();
                sqlDataAdapter = new SqlDataAdapter(quer, connectionString);
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "Waybill");
                dataGridView1.DataSource = dataSet.Tables["Waybill"];
                dataGridView1.ReadOnly = true;
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
                string quer = "SELECT *, 'Изменить' AS [ДЕЙСТВИЕ] FROM Fines WHERE Позывной = " + 
                    DriversLogIn.DriversID.ToString();
                sqlDataAdapter = new SqlDataAdapter(quer, connectionString);
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "Fines");
                dataGridView3.DataSource = dataSet.Tables["Fines"];
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
        private void OpenClose()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("P8switch", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@driverID", SqlDbType.Int).Value = DriversLogIn.DriversID;
                command.Parameters.AddWithValue("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                command.Parameters.AddWithValue("@er", SqlDbType.Int).Direction = ParameterDirection.Output;

                command.ExecuteNonQuery();
                SqlDataReader rdr = command.ExecuteReader();
                er = Convert.ToInt32(command.Parameters["@er"].Value);
                wayid = Convert.ToInt32(command.Parameters["@id"].Value);
                rdr.Close();

                switch (er)
                {
                    case 0:
                        sostLab.Text = "Ваш последний путевой лист не закрыт";
                        changeSostLab.Text = "Закрыть";
                        break;
                    case 1:
                        sostLab.Text = "У вас нет открытых путевых листов";
                        changeSostLab.Text = "Открыть";
                        break;
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

        private void DriversMainForm_Load(object sender, EventArgs e)
        {
            OpenClose();
        }

        private void changeSostLab_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("P8", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@driverID", SqlDbType.Int).Value = DriversLogIn.DriversID;
                command.Parameters.AddWithValue("@id", SqlDbType.Int).Value = wayid; 
                command.Parameters.AddWithValue("@er", SqlDbType.Int).Value = er;
                command.Parameters.AddWithValue("@newer", SqlDbType.Int).Direction = ParameterDirection.Output;

                command.ExecuteNonQuery();

                er = Convert.ToInt32(command.Parameters["@newer"].Value);
                OpenClose();
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

        private void resetBtn_Click(object sender, EventArgs e)
        {
            LoadDataCallSign();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
               DriversLogIn.DriversID.ToString();
                SqlCommand command = new SqlCommand("P14", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@callsign", SqlDbType.Int).Value = DriversLogIn.DriversID;
                command.Parameters.AddWithValue("@ptc", SqlDbType.Int).Value = ptcBox.Text;
                command.Parameters.AddWithValue("@vod", SqlDbType.Int).Value = vodBox.Text;

                command.ExecuteNonQuery();

                LoadDataCallSign();
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
            if (e.ColumnIndex == 9)
            {
                adminMainForm.fine = dataGridView3.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                adminMainForm.finecase = 2;
                adminFines af = new adminFines();
                Hide();
                af.ShowDialog();
                Close();
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == wayb)
            {
                LoadDataWaybill();
            }
            if (e.TabPage == callsign)
            {
                LoadDataCallSign();
            }
        }
    }
}
