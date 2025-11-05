using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace TAXI
{
    public partial class LoginScreen : Form
    {
        private string connectionString;
        public static string Login;
        public static string Pass;
        public static int ClientsID;        

        public LoginScreen()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["TaxiBD"].ConnectionString;
            this.StartPosition = FormStartPosition.CenterScreen;
            passBox.UseSystemPasswordChar = true;
        }
        private void LoginScreen_Activated(object sender, EventArgs e)
        {
            loginBox.Text = Login;
            passBox.Text = Pass;
        }
        private void LogIn_Click(object sender, EventArgs e)
        {
            Login = loginBox.Text;
            Pass = passBox.Text;
            try
            {                
                SqlConnection connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }                
                SqlCommand command = new SqlCommand("P1", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@login", SqlDbType.VarChar).Value = loginBox.Text;
                command.Parameters.AddWithValue("@pass", SqlDbType.VarChar).Value = passBox.Text;
                command.Parameters.AddWithValue("@rval", SqlDbType.Int).Direction = ParameterDirection.Output;
                command.Parameters.AddWithValue("@id", SqlDbType.Int).Direction = ParameterDirection.Output;

                command.ExecuteNonQuery();
                SqlDataReader rdr = command.ExecuteReader();                
                int rvalue = Convert.ToInt32(command.Parameters["@rval"].Value);                      
                
                rdr.Close();               

                switch (rvalue)
                {
                    case 0:
                        MessageBox.Show("Пароль неверный");
                        break;
                    case 1:
                        ClientsID = Convert.ToInt32(command.Parameters["@id"].Value);
                        Hide();
                        ClientMainForm cmf = new ClientMainForm();
                        cmf.ShowDialog();
                        Close();
                        break;
                    case 2:
                        MessageBox.Show("Пользователя с таким логином не существует");
                        break;
                    default:
                        MessageBox.Show("Данные введены неправильно");
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

        private void SignIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            SignInForm sif = new SignInForm();
            sif.ShowDialog();
            Close();
        }

        private void ForgotPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgetQuest fq = new ForgetQuest();
            fq.Log.Text = loginBox.Text;
            fq.ShowDialog();
        }

        private void carPicture_Click(object sender, EventArgs e)
        {
            Hide();
            DriversLogIn dli = new DriversLogIn();
            dli.ShowDialog();
            Close();
        }

        private void buhgPicture_Click(object sender, EventArgs e)
        {
            Hide();
            adminLogIn ali = new adminLogIn();
            ali.ShowDialog();
            Close();
        }

        private void carPicture_MouseEnter(object sender, EventArgs e)
        {
            carPicture.BorderStyle = BorderStyle.FixedSingle;
        }

        private void carPicture_MouseLeave(object sender, EventArgs e)
        {
            carPicture.BorderStyle = BorderStyle.None;
        }

        private void buhgPicture_MouseEnter(object sender, EventArgs e)
        {
            buhgPicture.BorderStyle = BorderStyle.FixedSingle;
        }

        private void buhgPicture_MouseLeave(object sender, EventArgs e)
        {
            buhgPicture.BorderStyle = BorderStyle.FixedSingle;
        }

        private void loginBox_Validating(object sender, CancelEventArgs e)
        {
            if (loginBox.Text.Length > 15)
            {
                errorProv.SetError(loginBox, "Логин не может содержать более 15 символов");
            }
            else if (loginBox.Text.Length == 0)
            {
                errorProv.SetError(loginBox, "Введите логин!");
            }
            else
                errorProv.SetError(loginBox, "");
        }

        private void passBox_Validating(object sender, CancelEventArgs e)
        {
            if (passBox.Text.Length > 15)
            {
                errorProv.SetError(passBox, "Пароль не может содержать более 15 символов");
            }
            else if (passBox.Text.Length == 0)
            {
                errorProv.SetError(passBox, "Введите пароль!");
            }
            else
                errorProv.SetError(passBox, "");
        }

        private void checkPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPass.Checked)
            {
                passBox.UseSystemPasswordChar = false;
            }
            else
            {
                passBox.UseSystemPasswordChar = true;
            }
        }
    }
}
