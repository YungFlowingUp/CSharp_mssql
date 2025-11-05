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
    public partial class TakeOrder : Form
    {
        private string connectionString; 
        private int orderid;
        private int callsign;
        private int imagePhon = 0;
        public TakeOrder()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["TaxiBD"].ConnectionString;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            picStop.Parent = Phon;
            picStop.BackColor = Color.Transparent;
            arrowBack.Parent = Phon;
            arrowBack.BackColor = Color.Transparent;
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                Random rnd = new Random();
                orderid = rnd.Next(1, 10);

                SqlCommand command = new SqlCommand("neword", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@orderid", SqlDbType.Int).Direction = ParameterDirection.Output;
                command.Parameters.AddWithValue("@clientid", SqlDbType.Int).Value = LoginScreen.ClientsID;
                command.Parameters.AddWithValue("@outcity", SqlDbType.VarChar).Value = fromCity.Text;
                command.Parameters.AddWithValue("@outstreet", SqlDbType.VarChar).Value = fromStreet.Text;
                command.Parameters.AddWithValue("@outhouse", SqlDbType.Int).Value = fromHouse.Text;
                command.Parameters.AddWithValue("@incity", SqlDbType.VarChar).Value = toCity.Text;
                command.Parameters.AddWithValue("@instreet", SqlDbType.VarChar).Value = toStreet.Text;
                command.Parameters.AddWithValue("@inhouse", SqlDbType.Int).Value = toHouse.Text;
                command.Parameters.AddWithValue("@comment", SqlDbType.VarChar).Value = comments.Text;
                command.Parameters.AddWithValue("@callsign", SqlDbType.Int).Value = orderid;

                command.ExecuteNonQuery();
                SqlDataReader rdr = command.ExecuteReader();
                callsign = Convert.ToInt32(command.Parameters["@callsign"].Value);
                rdr.Close();
                changeScene();
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

            private void changeScene()
            {
            foreach (TextBox tb in this.Controls.OfType<TextBox>())
            {
                if (tb.Visible == false)
                    tb.Visible = true;
                else
                    tb.Visible = false;
            }
            foreach (Label lb in this.Controls.OfType<Label>())
            {
                if (lb.Visible == false)
                    lb.Visible = true;
                else
                    lb.Visible = false;
            }

            if (confirmBtn.Visible == true)
                confirmBtn.Visible = false;
            else
                confirmBtn.Visible = true;

            if (arrowBack.Visible == false)
            {
                arrowBack.Visible = true;
                picStop.Visible = false;
                complet.Visible = false;
            }
            else
            {
                arrowBack.Visible = false;
                picStop.Visible = true;
                complet.Visible = true;
            }

            if (imagePhon == 0) 
            {
                Phon.ImageLocation = "C:\\Kyrsovay\\TAXI\\resc\\drivingGIF.gif";
                imagePhon = 1;
            }
            else
            {
                Phon.ImageLocation = "C:\\Kyrsovay\\TAXI\\resc\\orderPhone.jpg";
                imagePhon = 0;
            }
        }

        private void complet_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmn = new SqlCommand("completedrive", connection);
                cmn.CommandType = CommandType.StoredProcedure;
                cmn.Parameters.AddWithValue("@callsign", SqlDbType.Int).Value = callsign;

                cmn.ExecuteNonQuery();
                changeScene();
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
        private void picStop_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand com = new SqlCommand("stopdrive", connection);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@orderid", SqlDbType.Int).Value = orderid;                

                com.ExecuteNonQuery();
                changeScene();
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

        private void picStop_MouseEnter(object sender, EventArgs e)
        {
            picStop.BorderStyle = BorderStyle.FixedSingle;
        }

        private void picStop_MouseLeave(object sender, EventArgs e)
        {
            picStop.BorderStyle = BorderStyle.None;
        }
    }
}
