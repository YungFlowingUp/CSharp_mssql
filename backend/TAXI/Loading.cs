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
    public partial class Loading : Form
    {
        private Timer timer;
        private Timer timer1;
        private Timer timer2;
        private char[] welcomeText = "SPIRIT BREAKER".ToCharArray();
        private char[] newGenText = "Такси! Нового Поколения!".ToCharArray();
        private int timer1Counter = 0;
        private int timer2Counter = 0;
        private double op = 0.3;
        public Loading()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.Text = "";            
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            SpiritLabel.Text = null;
            TaxiLab.Text = null;
            SpiritLabel.Parent = Phon;
            TaxiLab.Parent = Phon;
            SpiritLabel.BackColor = Color.Transparent;
            TaxiLab.BackColor = Color.Transparent;
            timer = new Timer();
            timer.Interval = 4250;
            timer.Tick += new EventHandler(Timer_Tick);
            timer1 = new Timer();
            timer1.Interval = 150;
            timer1.Tick += new EventHandler(Timer1_Tick);
            timer2 = new Timer();
            timer2.Interval = 50;
            timer2.Tick += new EventHandler(Timer2_Tick);
            timer.Start();
            timer1.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            Hide();            
            LoginScreen ls = new LoginScreen();
            ls.ShowDialog();
            Close();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                this.Opacity = op;
                SpiritLabel.Text += welcomeText[timer1Counter];
            }
            catch (IndexOutOfRangeException)
            {
                timer1.Stop();
                timer2.Start();
            }
            finally
            {
                op += 0.1;
                timer1Counter++;
            }
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                TaxiLab.Text += newGenText[timer2Counter];
            }
            catch (IndexOutOfRangeException)
            {
                timer2.Stop();
            }
            finally
            {
                timer2Counter++;
            }
        }       
    }
}
