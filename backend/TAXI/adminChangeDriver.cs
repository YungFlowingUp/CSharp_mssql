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
    public partial class adminChangeDriver : Form
    {
        private string connectionString;
        public adminChangeDriver()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["TaxiBD"].ConnectionString;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void adminChangeDriver_Load(object sender, EventArgs e)
        {
            foreach(TextBox tb in this.Controls.OfType<TextBox>())
            {
                tb.ReadOnly = true;
            }
            textBox5.ReadOnly = false;
            textBox8.ReadOnly = false;
            textBox10.ReadOnly = false;
            textBox11.ReadOnly = false;
            textBox12.ReadOnly = false;
            textBox13.ReadOnly = false;
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string quer = "SELECT * FROM Drivers WHERE ID = " + adminMainForm.dr;
                SqlCommand cmn = new SqlCommand(quer, connection);
                SqlDataReader rdr = cmn.ExecuteReader();

                while (rdr.Read())
                {
                    textBox1.Text = rdr[0].ToString();
                    textBox2.Text = rdr[1].ToString();
                    textBox3.Text = rdr[2].ToString();
                    textBox4.Text = rdr[3].ToString();
                    textBox5.Text = rdr[4].ToString();
                    textBox6.Text = rdr[5].ToString();
                    textBox7.Text = rdr[6].ToString();
                    textBox8.Text = rdr[7].ToString();
                    textBox9.Text = rdr[8].ToString();
                    textBox10.Text = rdr[9].ToString();
                    textBox11.Text = rdr[10].ToString();
                    textBox12.Text = rdr[11].ToString();
                    textBox13.Text = rdr[12].ToString();
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
                SqlCommand cmn = new SqlCommand("P9", connection);
                cmn.CommandType = CommandType.StoredProcedure;
                cmn.Parameters.AddWithValue("@id", SqlDbType.Int).Value = adminMainForm.dr;
                cmn.Parameters.AddWithValue("@phone", SqlDbType.VarChar).Value = textBox8.Text;
                cmn.Parameters.AddWithValue("@nabol", SqlDbType.VarChar).Value = textBox10.Text;
                cmn.Parameters.AddWithValue("@otpysk", SqlDbType.VarChar).Value = textBox11.Text;
                cmn.Parameters.AddWithValue("@yvolen", SqlDbType.VarChar).Value = textBox12.Text;
                cmn.ExecuteNonQuery();

                this.Hide();
                adminMainForm.chnTab = 2;
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
