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
    public partial class SignInForm : Form
    {
        private string connectionString;
        public SignInForm()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["TaxiBD"].ConnectionString;
            this.StartPosition = FormStartPosition.CenterScreen;
            sex.DropDownStyle = ComboBoxStyle.DropDownList;
            passBox.UseSystemPasswordChar = true;
            passBoxConfirm.UseSystemPasswordChar = true;
        }

        private void signInBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("P3", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@login", SqlDbType.VarChar).Value = logBox.Text;
                command.Parameters.AddWithValue("@pass", SqlDbType.VarChar).Value = passBox.Text;
                command.Parameters.AddWithValue("@quest", SqlDbType.VarChar).Value = questBox.Text;
                command.Parameters.AddWithValue("@answer", SqlDbType.VarChar).Value = answerBox.Text;
                command.Parameters.AddWithValue("@fam", SqlDbType.VarChar).Value = secNameBox.Text;
                command.Parameters.AddWithValue("@name", SqlDbType.VarChar).Value = firstNameBox.Text;

                if(otchestvoBox.Text == "")
                    command.Parameters.AddWithValue("@otchestvo", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    command.Parameters.AddWithValue("@otchestvo", SqlDbType.VarChar).Value = otchestvoBox.Text;
                
                if (sex.SelectedText.Length > 1)
                    command.Parameters.AddWithValue("@sex", SqlDbType.VarChar).Value = sex.SelectedItem.ToString();
                else
                    command.Parameters.AddWithValue("@sex", SqlDbType.VarChar).Value = DBNull.Value;

                command.Parameters.AddWithValue("@date", SqlDbType.Date).Value = birthdate.Value;
                command.Parameters.AddWithValue("@phone", SqlDbType.VarChar).Value = phoneBox.Text;
                command.Parameters.AddWithValue("@er", SqlDbType.Int).Direction = ParameterDirection.Output;
                command.Parameters.AddWithValue("@id", SqlDbType.Int).Direction = ParameterDirection.Output;

                command.ExecuteNonQuery();
                int er = Convert.ToInt32(command.Parameters["@er"].Value);
                LoginScreen.ClientsID = Convert.ToInt32(command.Parameters["@id"].Value);

                switch (er)
                {
                    case 0:
                        errorProv.SetError(logBox, "Такой логин уже существует");
                        break;
                    case 1:
                        errorProv.SetError(phoneBox, "Пользователь с таким номером телефона уже существует");
                        break;
                    default:
                        Hide();
                        ClientMainForm cmf = new ClientMainForm();
                        cmf.ShowDialog();
                        Close();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void logBox_Validating(object sender, CancelEventArgs e)
        {
            if (logBox.Text.Length > 15)
            {
                errorProv.SetError(logBox, "Логин может быть не длинее 15 символов!");
            }
            else if (logBox.Text.Length == 0)
            {
                errorProv.SetError(logBox, "Введите логин!");
            }
            else
            {
                errorProv.SetError(logBox, "");
            }
        }

        private void passBox_Validating(object sender, CancelEventArgs e)
        {
            if (passBox.Text.Length > 15)
            {
                errorProv.SetError(passBox, "Пароль может быть не длинее 15 символов!");
            }
            else if (passBox.Text.Length == 0)
            {
                errorProv.SetError(passBox, "Введите пароль!");
            }
            else
            {
                errorProv.SetError(passBox, "");
            }
        }

        private void passBoxConfirm_Validating(object sender, CancelEventArgs e)
        {
            if (passBox.Text != passBoxConfirm.Text)
            {
                errorProv.SetError(passBoxConfirm, "Пароли не совпадают!");
            }
            else
            {
                errorProv.SetError(passBoxConfirm, "");
            }
        }

        private void questBox_Validating(object sender, CancelEventArgs e)
        {
            if (questBox.Text.Length > 30)
            {
                errorProv.SetError(questBox, "Секретный вопрос может быть не длинее 30 символов!");
            }
            else if (questBox.Text.Length == 0)
            {
                errorProv.SetError(questBox, "Введите секретный вопрос!");
            }
            else
            {
                errorProv.SetError(questBox, "");
            }
        }

        private void answerBox_Validating(object sender, CancelEventArgs e)
        {
            if (answerBox.Text.Length > 15)
            {
                errorProv.SetError(answerBox, "Ответ на секретный вопрос может быть не длинее 15 символов!");
            }
            else if (answerBox.Text.Length == 0)
            {
                errorProv.SetError(answerBox, "Введите ответ на секретный вопрос!");
            }
            else
            {
                errorProv.SetError(answerBox, "");
            }
        }

        private void secNameBox_Validating(object sender, CancelEventArgs e)
        {
            if (secNameBox.Text.Length > 20)
            {
                errorProv.SetError(secNameBox, "К сожалению фамилия может быть не длинее 20 символов");
            }
            else if (secNameBox.Text.Length == 0)
            {
                errorProv.SetError(secNameBox, "Введите фамилию!");
            }
            else
            {
                errorProv.SetError(secNameBox, "");
            }
        }

        private void firstNameBox_Validating(object sender, CancelEventArgs e)
        {
            if (firstNameBox.Text.Length > 20)
            {
                errorProv.SetError(firstNameBox, "К сожалению имя может быть не длинее 20 символов");
            }
            else if (firstNameBox.Text.Length == 0)
            {
                errorProv.SetError(firstNameBox, "Введите имя!");
            }
            else
            {
                errorProv.SetError(firstNameBox, "");
            }
        }

        private void otchestvoBox_Validating(object sender, CancelEventArgs e)
        {
            if (otchestvoBox.Text.Length > 20)
            {
                errorProv.SetError(otchestvoBox, "К сожалению отчество может быть не длинее 20 символов");
            }
            else
            {
                errorProv.SetError(otchestvoBox, "");
            }
        }

        private void phoneBox_Validating(object sender, CancelEventArgs e)
        {
            if (phoneBox.Text.Length > 20)
            {
                errorProv.SetError(phoneBox, "Номер может состоять лишь из 11 символов");
            }
            else if (phoneBox.Text.Length == 0)
            {
                errorProv.SetError(phoneBox, "Введите номер телефона!");
            }
            else
            {
                errorProv.SetError(phoneBox, "");
            }
        }

        private void showPasses_CheckStateChanged(object sender, EventArgs e)
        {
            if (showPasses.Checked)
            {
                passBox.UseSystemPasswordChar = false;
                passBoxConfirm.UseSystemPasswordChar = false;
            }
            else
            {
                passBox.UseSystemPasswordChar = true;
                passBoxConfirm.UseSystemPasswordChar = true;
            }
        }
    }
}
