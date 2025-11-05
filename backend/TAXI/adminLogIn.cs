using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TAXI
{
    public partial class adminLogIn : Form
    {
        private string buhLogin = "admin";
        private string buhPass = "admin";

        public adminLogIn()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            passBox.UseSystemPasswordChar = true;
        }

        private void LogInBtn_Click(object sender, EventArgs e)
        {
            if (logInBox.Text == buhLogin && passBox.Text == buhPass)
            {
                Hide();
                adminMainForm amf = new adminMainForm();
                amf.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("Неправильны логин и/или пароль");
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
