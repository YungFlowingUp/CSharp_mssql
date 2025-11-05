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
    public partial class ClientMainForm : Form
    {
        private int takeOrderWidth;
        private int takeOrderHeight;
        private int showOrdersWidth;
        private int showOrdersHeight;
        public ClientMainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;                        
        }

        private void ClientMainForm_Load(object sender, EventArgs e)
        {
            takeOrderLab.Parent = TakeOrder;
            showOrdersLab.Parent = showOrders;
            takeOrderLab.BackColor = Color.Transparent;
            showOrdersLab.BackColor = Color.Transparent;
        }

        private void TakeOrder_Click(object sender, EventArgs e)
        {
            Hide();
            TakeOrder to = new TakeOrder();
            to.ShowDialog();
            Close();
        }
        private void showOrders_Click(object sender, EventArgs e)
        {
            Hide();
            ShowClientOrders sco = new ShowClientOrders();
            sco.ShowDialog();
            Close();
        }

        private void TakeOrder_MouseEnter(object sender, EventArgs e)
        {
            takeOrderWidth = TakeOrder.Size.Width;
            takeOrderHeight = TakeOrder.Size.Height;
            TakeOrder.Size = new System.Drawing.Size(Convert.ToInt32(takeOrderWidth * 1.03), 
                Convert.ToInt32(takeOrderHeight * 1.15));
            TakeOrder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void TakeOrder_MouseLeave(object sender, EventArgs e)
        {
            TakeOrder.Size = new System.Drawing.Size(takeOrderWidth, takeOrderHeight);
            TakeOrder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }      

        private void showOrders_MouseEnter(object sender, EventArgs e)
        {
            showOrdersWidth = showOrders.Size.Width;
            showOrdersHeight = showOrders.Size.Height;
            showOrders.Size = new System.Drawing.Size(Convert.ToInt32(showOrdersWidth * 1.05),
                Convert.ToInt32(showOrdersHeight * 1.05));
            TakeOrder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        private void showOrders_MouseLeave(object sender, EventArgs e)
        {
            showOrders.Size = new System.Drawing.Size(showOrdersWidth, showOrdersHeight);
            TakeOrder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }
    }
}
