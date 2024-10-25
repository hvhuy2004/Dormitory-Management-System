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
    public partial class Form1 : Form
    {
        function fn = new function();
        String query;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            query = "SELECT * FROM admin WHERE username = '" + txtUsername.Text + "' AND pass = '" + txtPassword.Text + "'";
            
            DataSet ds = fn.getData(query);
            
            if (ds.Tables[0].Rows.Count != 0)
            {
                Dashboard dbs = new Dashboard();
                dbs.Show();
                this.Hide();
            }
            else
            {
                String hashedPassword = HashPassword(txtPassword.Text);
                query = "SELECT * FROM newStudent WHERE username = '" + txtUsername.Text + "' AND pass = '" + hashedPassword + "'";

                DataSet ds1 = fn.getData(query);

                if (ds1.Tables[0].Rows.Count != 0)
                {
                    Dashboard1 dbs1 = new Dashboard1();
                    dbs1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Tài khoản này không tồn tại.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

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
    }
}
