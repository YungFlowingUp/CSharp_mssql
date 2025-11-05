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
    public partial class adminChangeCars : Form
    {
        private string connectionString;
        public adminChangeCars()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["TaxiBD"].ConnectionString;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void adminChangeCars_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand cmn = new SqlCommand("P10", connection);
                cmn.CommandType = CommandType.StoredProcedure;
                cmn.Parameters.AddWithValue("@gosnomer", SqlDbType.VarChar).Value = adminMainForm.gosnomer;
                SqlDataReader rdr = cmn.ExecuteReader();

                while (rdr.Read())
                {
                    textBox1.Text = rdr[0].ToString();
                    textBox2.Text = rdr[1].ToString();
                    textBox3.Text = rdr[2].ToString();
                    textBox4.Text = rdr[3].ToString();                    
                }
                rdr.Close();                
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand cmn = new SqlCommand("P11", connection);
                cmn.CommandType = CommandType.StoredProcedure;
                cmn.Parameters.AddWithValue("@gosnomer", SqlDbType.VarChar).Value = adminMainForm.gosnomer;
                cmn.Parameters.AddWithValue("@class", SqlDbType.Int).Value = textBox2.Text;
                cmn.Parameters.AddWithValue("@remont", SqlDbType.VarChar).Value = textBox4.Text;

                cmn.ExecuteNonQuery();

                this.Hide();
                adminMainForm.chnTab = 3;
                adminMainForm amf = new adminMainForm();
                amf.ShowDialog();
                this.Close();
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
