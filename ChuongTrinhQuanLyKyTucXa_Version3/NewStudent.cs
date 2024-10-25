using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChuongTrinhQuanLyKyTucXa_Version3
{
    public partial class NewStudent : Form
    {
        function fn = new function();
        String query;
        public NewStudent()
        {
            InitializeComponent();
        }

        private void NewStudent_Load(object sender, EventArgs e)
        {
            this.Location = new Point(520, 122);
            query = "SELECT roomNo from rooms WHERE roomStatus = 'Yes' AND Booked = 'No'";

            DataSet ds = fn.getData(query);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Int64 room = Int64.Parse(ds.Tables[0].Rows[i][0].ToString());
                comboRoomNo.Items.Add(room);
            }
        }

        private void clearAll()
        {
            txtMobile.Clear();
            txtName.Clear();
            txtUser.Clear();
            txtPass.Clear();
            txtEmail.Clear();
            txtPermanent.Clear();
            txtCollege.Clear();
            txtIdProof.Clear();
            comboRoomNo.SelectedIndex = -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMobile.Text != "" && txtName.Text != "" && txtUser.Text != "" && txtPass.Text != "" && txtEmail.Text != "" && txtPermanent.Text != "" && txtCollege.Text != "" && txtIdProof.Text != "" && comboRoomNo.SelectedIndex != -1)
            {
                Int64 mobile = Int64.Parse(txtMobile.Text);
                String name = txtName.Text;
                String username = txtUser.Text;
                String pass = txtPass.Text;
                String email = txtEmail.Text;
                String paddress = txtPermanent.Text;
                String college = txtCollege.Text;
                String idproof = txtIdProof.Text;
                Int64 roomNo = Int64.Parse(comboRoomNo.Text);

                // Hash the password
                String hashedPassword = HashPassword(pass);

                query = "insert into newStudent(mobile, name, username, pass, email, paddress, college, idproof, roomNo) values (" + mobile + ", '" + name + "','" + username + "','" + hashedPassword + "','" + email + "','" + paddress + "','" + college + "','" + idproof + "'," + roomNo + ") update rooms set Booked = 'Yes' where roomNo = " + roomNo + "";
                fn.setData(query, "Sinh viên đăng kí thành công.");
                clearAll();

            }
            else
            {
                MessageBox.Show("Vui lòng điền thông tin đầy đủ", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void comboRoomNo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
