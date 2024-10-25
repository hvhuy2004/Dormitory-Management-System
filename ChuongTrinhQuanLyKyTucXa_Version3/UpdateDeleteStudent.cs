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
    public partial class UpdateDeleteStudent : Form
    {
        function fn = new function();
        String query;
        public UpdateDeleteStudent()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateDeleteStudent_Load(object sender, EventArgs e)
        {
            this.Location = new Point(520, 122);

        }

        public void clearAll()
        {
            txtMobile.Clear();
            txtName.Clear();
            txtUser.Clear();
            txtPass.Clear();
            txtEmail.Clear();
            txtPermanent.Clear();
            txtCollege.Clear();
            txtIdproof.Clear();
            txtRoomNo.Clear();
            comboxLiving.SelectedIndex = -1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            query = "SELECT * FROM newStudent WHERE mobile = " + txtMobile.Text + "";
            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows.Count != 0)
            {
                txtName.Text = ds.Tables[0].Rows[0][2].ToString();
                txtUser.Text = ds.Tables[0].Rows[0][3].ToString();
                txtPass.Text = ds.Tables[0].Rows[0][4].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0][5].ToString();
                txtPermanent.Text = ds.Tables[0].Rows[0][6].ToString();
                txtCollege.Text = ds.Tables[0].Rows[0][7].ToString();
                txtIdproof.Text = ds.Tables[0].Rows[0][8].ToString();
                txtRoomNo.Text = ds.Tables[0].Rows[0][9].ToString();
                comboxLiving.Text = ds.Tables[0].Rows[0][10].ToString();

                txtUser.ReadOnly = true;
                txtPass.ReadOnly = true;
                txtRoomNo.ReadOnly = true;
            }
            else
            {
                clearAll();
                MessageBox.Show("Số điện thoại này không tồn tại.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtMobile.Text != "" && txtName.Text != "" && txtUser.Text != "" && txtPass.Text != "" && txtEmail.Text != "" && txtPermanent.Text != "" && txtCollege.Text != "")
            {
                Int64 mobile = Int64.Parse(txtMobile.Text);
                String name = txtName.Text;
                String username = txtUser.Text;
                String pass = txtPass.Text;
                String email = txtEmail.Text;
                String paddress = txtPermanent.Text;
                String college = txtCollege.Text;
                String idproof = txtIdproof.Text;
                Int64 roomNo = Int64.Parse(txtRoomNo.Text);
                String livingStatus = comboxLiving.Text;

                query = "update newStudent set name= '" + name + "', username= '" + username + "', pass= '" + pass + "', email= '" + email + "', paddress= '" + paddress + "', college= '" + college + "', idproof='" + idproof + "', roomNo= " + roomNo + ",living = '" + livingStatus + "' where mobile = " + mobile + " update rooms set Booked = '" + livingStatus + "' where roomNo = " + roomNo + "";
                fn.setData(query, "Cập nhật thành công.");
            }
            else
            {
                MessageBox.Show("Vui lòng điền thông tin đầy đủ", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // Retrieve the room number of the student to be deleted
                query = "SELECT roomNo FROM newStudent WHERE mobile = " + txtMobile.Text;
                DataSet ds = fn.getData(query);

                if (ds.Tables[0].Rows.Count != 0)
                {
                    Int64 roomNo = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

                    // Delete the student record
                    query = "DELETE FROM newStudent WHERE mobile = " + txtMobile.Text;
                    fn.setData(query, "Đã xóa hồ sơ sinh viên.");

                    // Update the room status to 'No'
                    query = "UPDATE rooms SET Booked = 'No', roomStatus = 'Yes' WHERE roomNo = " + roomNo;
                    fn.setData(query, "Đã cập nhật trạng thái phòng.");

                    clearAll();
                }
                else
                {
                    MessageBox.Show("Số điện thoại này không tồn tại.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void comboxLiving_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
