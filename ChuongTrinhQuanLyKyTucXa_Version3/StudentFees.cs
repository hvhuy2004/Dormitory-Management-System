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
    public partial class StudentFees : Form
    {
        function fn = new function();
        String query;
        public StudentFees()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void StudentFees_Load(object sender, EventArgs e)
        {
            this.Location = new Point(520, 122);
            dataTimePicker.Format = DateTimePickerFormat.Custom;
            dataTimePicker.CustomFormat = "MMMM yyyy";
        }

        public void setDataGrid(Int64 mobile)
        {
            query = "SELECT * FROM fees WHERE mobileNo =" + mobile + "";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void ClearAll()
        {
            txtMobile.Clear();
            txtName.Clear();
            txtAmount.Clear();
            txtRoomNo.Clear();
            txtEmailId.Clear();
            guna2DataGridView1.DataSource = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtMobile.Text != "")
            {
                query = "SELECT name, email, roomNo from newStudent WHERE mobile =" + txtMobile.Text + "";
                DataSet ds = fn.getData(query);

                if (ds.Tables[0].Rows.Count != 0)
                {
                    txtName.Text = ds.Tables[0].Rows[0][0].ToString();
                    txtEmailId.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtRoomNo.Text = ds.Tables[0].Rows[0][2].ToString();
                    setDataGrid(Int64.Parse(txtMobile.Text));
                }
                else
                {
                    MessageBox.Show("Hồ sơ này không tồn tại.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (txtMobile.Text != "" && txtAmount.Text != "")
            {
                query = "SELECT * FROM fees WHERE mobileNo = " + Int64.Parse(txtMobile.Text) + " and fmonth='" + dataTimePicker.Text + "'";
                DataSet ds = fn.getData(query); 

                if (ds.Tables[0].Rows.Count == 0)
                {
                    Int64 mobile = Int64.Parse(txtMobile.Text);
                    String month = dataTimePicker.Text;
                    Int64 amount = Int64.Parse(txtAmount.Text);

                    query = "insert into fees values (" + mobile + ", '" + month + "', " + amount + ")";
                    fn.setData(query, "Phí đã trả.");
                    ClearAll();
                }
                else
                {
                    MessageBox.Show("Không có lệ phí của " + dataTimePicker.Text + " Còn lại.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
    }
}
