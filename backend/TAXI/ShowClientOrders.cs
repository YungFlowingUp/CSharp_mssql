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
    public partial class ShowClientOrders : Form
    {
        private string connectionString;
        public ShowClientOrders()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["TaxiBD"].ConnectionString;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void ShowClientOrders_Load(object sender, EventArgs e)
        {
            infLab.Text = "Клиент ";
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string client = "SELECT Фамилия, Имя, Телефон FROM Clients WHERE ID = " + 
                                LoginScreen.ClientsID.ToString();
                SqlCommand cmd = new SqlCommand(client, connection);

                string query = "SELECT Orders.ID, CallSign.Позывной, Статус, [Дата получения]," +
                               "[Время полученя], [Город отправления], [Улица отправления],"  +
                               "[Дом отправления],[Город назначения], [Улица назначения]," +
                               "[Дом назначения], [Комментарии к заказу] " +
                               "FROM Orders JOIN CallSign ON Orders.Позывной = CallSign.ID " +
                               "WHERE Orders.Клиент = " + LoginScreen.ClientsID.ToString();
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader rdr = cmd.ExecuteReader();                

                while (rdr.Read())
                {
                    infLab.Text += rdr[0].ToString() + " ";
                    infLab.Text += rdr[1].ToString() + " ";
                    infLab.Text += "| Контактный номер (+";
                    infLab.Text += rdr[2].ToString() + ")";
                }
                rdr.Close();

                SqlDataReader reader = command.ExecuteReader();
                List<string[]> data = new List<string[]>();
                while (reader.Read())
                {
                    data.Add(new string[12]);

                    data[data.Count - 1][0] = reader[0].ToString();
                    data[data.Count - 1][1] = reader[1].ToString();
                    data[data.Count - 1][2] = reader[2].ToString();
                    data[data.Count - 1][3] = reader[3].ToString();
                    data[data.Count - 1][4] = reader[4].ToString();
                    data[data.Count - 1][5] = reader[5].ToString();
                    data[data.Count - 1][6] = reader[6].ToString();
                    data[data.Count - 1][7] = reader[7].ToString();
                    data[data.Count - 1][8] = reader[8].ToString();
                    data[data.Count - 1][9] = reader[9].ToString();
                    data[data.Count - 1][10] = reader[10].ToString();
                    data[data.Count - 1][11] = reader[11].ToString();
                }
                reader.Close();                

                foreach (string[] s in data)
                    dataGridView1.Rows.Add(s);
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
            ClientMainForm cmf = new ClientMainForm();
            cmf.ShowDialog();
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
