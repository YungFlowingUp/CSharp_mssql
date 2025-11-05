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
    public partial class adminFines : Form
    {
        private string connectionString;
        public adminFines()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["TaxiBD"].ConnectionString;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void adminFines_Load(object sender, EventArgs e)
        {
            if (adminMainForm.finecase == 0 || adminMainForm.finecase == 2)
            {
                foreach (TextBox tb in this.Controls.OfType<TextBox>())
                {
                    tb.ReadOnly = true;
                }
                ins.Visible = false;

                try
                {
                    SqlConnection connection = new SqlConnection(connectionString);
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    string quer = "SELECT * FROM Fines WHERE ID = " + adminMainForm.fine;
                    SqlCommand cmn = new SqlCommand(quer, connection);
                    SqlDataReader rdr = cmn.ExecuteReader();

                    while (rdr.Read())
                    {
                        textBox1.Text = rdr[1].ToString();
                        textBox2.Text = rdr[2].ToString();
                        textBox3.Text = rdr[3].ToString();
                        textBox4.Text = rdr[4].ToString();
                        textBox5.Text = rdr[5].ToString();
                        textBox6.Text = rdr[6].ToString();
                        textBox7.Text = rdr[7].ToString();
                        textBox8.Text = rdr[8].ToString();
                    }
                    rdr.Close();
                    if (textBox7.Text == "Да")
                    {
                        upd.Visible = false;
                    }
                    else
                    {
                        textBox3.ReadOnly = false;
                        textBox4.ReadOnly = false;
                        textBox7.ReadOnly = false;
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
            if (adminMainForm.finecase == 1)
            {
                upd.Visible = false;
                del.Visible = false;
            }
            if (adminMainForm.finecase == 2)
            {
                foreach (TextBox tb in this.Controls.OfType<TextBox>())
                {
                    tb.ReadOnly = true;
                }
                textBox7.ReadOnly = false;
                del.Visible = false;
                ins.Visible = false;
                upd.Visible = true;
            }
        }

        private void upd_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand cmn = new SqlCommand("P12upd", connection);
                cmn.CommandType = CommandType.StoredProcedure;
                cmn.Parameters.AddWithValue("@id", SqlDbType.Int).Value = adminMainForm.fine;
                cmn.Parameters.AddWithValue("@narush", SqlDbType.VarChar).Value = textBox3.Text;
                cmn.Parameters.AddWithValue("@cost", SqlDbType.Money).Value = Convert.ToDecimal(textBox4.Text);
                cmn.Parameters.AddWithValue("@status", SqlDbType.VarChar).Value = textBox7.Text;
                cmn.ExecuteNonQuery();

                this.Hide();
                if (adminMainForm.finecase != 2) 
                {
                    adminMainForm.chnTab = 4;
                    adminMainForm amf = new adminMainForm();
                    amf.ShowDialog();
                }
                else
                {
                    adminMainForm.chnTab = 10;
                    DriversMainForm dmf = new DriversMainForm();
                    dmf.ShowDialog();
                }
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

        private void del_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить эту строку?", "Удаление",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    SqlConnection connection = new SqlConnection(connectionString);
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    string del = "DELETE FROM Fines WHERE ID = " + adminMainForm.fine;
                    SqlCommand cmn = new SqlCommand(del, connection);
                    cmn.ExecuteNonQuery();

                    this.Hide();
                    adminMainForm.chnTab = 4;
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

        private void ins_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand cmn = new SqlCommand("P12ins", connection);
                cmn.CommandType = CommandType.StoredProcedure;
                cmn.Parameters.AddWithValue("@callsign", SqlDbType.Int).Value = textBox1.Text;
                cmn.Parameters.AddWithValue("@gosnomer", SqlDbType.VarChar).Value = textBox2.Text;
                cmn.Parameters.AddWithValue("@narush", SqlDbType.Money).Value = textBox3.Text;
                cmn.Parameters.AddWithValue("@cost", SqlDbType.Money).Value = textBox4.Text;
                cmn.Parameters.AddWithValue("@datenarush", SqlDbType.Date).Value = textBox5.Text;
                cmn.Parameters.AddWithValue("@timenarush", SqlDbType.Time).Value = textBox6.Text;
                cmn.Parameters.AddWithValue("@status", SqlDbType.VarChar).Value = textBox7.Text;

                if (textBox8.Text == "")
                    cmn.Parameters.AddWithValue("@dateplatej", SqlDbType.Date).Value = DBNull.Value;
                else
                    cmn.Parameters.AddWithValue("@dateplatej", SqlDbType.Date).Value = textBox8.Text;

                cmn.ExecuteNonQuery();

                this.Hide();
                adminMainForm.chnTab = 4;
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
