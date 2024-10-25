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
    public partial class ShowInfo : Form
    {
        function fn = new function();
        String query;
        public ShowInfo()
        {
            InitializeComponent();
        }

        private void ShowInfo_Load(object sender, EventArgs e)
        {
            this.Location = new Point(520, 122);

        }

        public void clearAll()
        {
            txtMobile.Clear();
            txtName.Clear();            
            txtEmail.Clear();
            txtPermanent.Clear();
            txtCollege.Clear();
            txtIdProof.Clear();
            txtRoomNo.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            query = "SELECT * FROM newStudent WHERE mobile = " + txtMobile.Text + "";
            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows.Count != 0)
            {
                txtName.Text = ds.Tables[0].Rows[0][2].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0][5].ToString();
                txtPermanent.Text = ds.Tables[0].Rows[0][6].ToString();
                txtCollege.Text = ds.Tables[0].Rows[0][7].ToString();
                txtIdProof.Text = ds.Tables[0].Rows[0][8].ToString();
                txtRoomNo.Text = ds.Tables[0].Rows[0][9].ToString();
                txtName.ReadOnly = true;
                txtEmail.ReadOnly = true;
                txtPermanent.ReadOnly = true;
                txtCollege.ReadOnly = true;
                txtIdProof.ReadOnly = true;
                txtRoomNo.ReadOnly = true;
            }
            else
            {
                clearAll();
                MessageBox.Show("Số điện thoại này không tồn tại.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
