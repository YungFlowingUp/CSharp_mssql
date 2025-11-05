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
    public partial class DriversLogIn : Form
    {
        private string connectionString;
        public static int DriversID;
        public DriversLogIn()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["TaxiBD"].ConnectionString;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void logInBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("P4", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@call", SqlDbType.VarChar).Value = callSignBox.Text;
                command.Parameters.AddWithValue("@er", SqlDbType.Int).Direction = ParameterDirection.Output;
                command.Parameters.AddWithValue("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                
                command.ExecuteNonQuery();
                SqlDataReader rdr = command.ExecuteReader();
                int er = Convert.ToInt32(command.Parameters["@er"].Value);
                DriversID = Convert.ToInt32(command.Parameters["@id"].Value);
                rdr.Close();

                switch (er)
                {
                    case 0:
                        MessageBox.Show("Такого позывного нет");
                        break;
                    case 1:
                        Hide();
                        DriversMainForm dmf = new DriversMainForm();
                        dmf.ShowDialog();
                        Close();
                        break;
                    default:
                        MessageBox.Show("Ошибка данных");
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

        private void arrowBack_Click(object sender, EventArgs e)
        {
            Hide();
            LoginScreen ls = new LoginScreen();
            ls.ShowDialog();
            Close();
        }

        private void arrowBack_MouseEnter(object sender, EventArgs e)
        {
            arrowBack.BorderStyle = BorderStyle.FixedSingle;
        }

        private void arrowBack_MouseLeave(object sender, EventArgs e)
        {
            arrowBack.BorderStyle = BorderStyle.None;
        }
    }
}

