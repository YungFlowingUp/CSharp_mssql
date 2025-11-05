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
    public partial class ForgetQuest : Form
    {
        private string connectionString;
        private string answer;
        private string pass;
        private string quest;
        public ForgetQuest()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["TaxiBD"].ConnectionString;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void ForgetQuest_Load(object sender, EventArgs e)
        {
            proc();
        }

        private void Log_Leave(object sender, EventArgs e)
        {
            proc();
        }
        private void proc()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("P2", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@login", SqlDbType.VarChar).Value = Log.Text.ToString();
                command.Parameters.AddWithValue("@er", SqlDbType.Int).Direction = ParameterDirection.Output;

                command.ExecuteNonQuery();
                SqlDataReader rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    pass = rdr[0].ToString();
                    quest = rdr[1].ToString();
                    answer = rdr[2].ToString();
                }
 
                int er = Convert.ToInt32(command.Parameters["@er"].Value);    
                switch (er)
                {
                    case 1:
                        failLab.Text = "Логин не существует";
                        break;                    
                    default:
                        failLab.Text = " ";
                        secQuest.Text = quest;
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

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            if (answerBox.Text == answer)
            {
                Hide();
                LoginScreen.Login = Log.Text;
                LoginScreen.Pass = pass;
                Close();
            }
            else
                MessageBox.Show("Неправильный ответ на Секретный вопрос");
        }
    }
}
