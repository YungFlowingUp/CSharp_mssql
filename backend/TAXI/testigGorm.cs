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
    public partial class testigGorm : Form
    {
        private string connectionString;
        private SqlDataAdapter sqlDataAdapter;
        private DataSet dataSet;
        private SqlCommandBuilder sqlBuilder;
        public testigGorm()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["TaxiBD"].ConnectionString;
            LoadSme();
        }
        private void LoadSme()
        {
            try
            {
                sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Orders", connectionString); sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);
                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "Orders");
                dataGridView1.DataSource = dataSet.Tables["Orders"];
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
    }
}
