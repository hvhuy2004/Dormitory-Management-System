using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChuongTrinhQuanLyKyTucXa_Version3
{
    public partial class Dashboard1 : Form
    {
        public Dashboard1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Close();
            f1.Show();
        }

        private void btnShowInfo_Click(object sender, EventArgs e)
        {
            ShowInfo sf = new ShowInfo();
            sf.Show();
        }

        private void Dashboard1_Load(object sender, EventArgs e)
        {

        }

        private void btnListRoom_Click(object sender, EventArgs e)
        {
            ListRoom ls = new ListRoom();
            ls.Show();
        }
    }
}
