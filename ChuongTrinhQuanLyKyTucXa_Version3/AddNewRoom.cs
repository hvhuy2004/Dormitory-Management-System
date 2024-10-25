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
    public partial class AddNewRoom : Form
    {
        function fn = new function();
        String query;
        public AddNewRoom()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddNewRoom_Load(object sender, EventArgs e)
        {
            this.Location = new Point(520, 122);
            labelRoom .Visible = false;
            labelRoomExist.Visible = false;

            query = "SELECT * FROM rooms";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            query = "SELECT * FROM rooms WHERE  roomNo=" + txtRoomNo1.Text + "";
            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows.Count == 0)
            {
                String status;
                if (checkBox1.Checked)
                {
                    status = "YES";
                }
                else
                {
                    status = "NO";
                }
                labelRoomExist.Visible = false;
                query = "INSERT INTO rooms (roomNo, roomStatus) values (" + txtRoomNo1.Text + ",'" + status + "')";
                fn.setData(query, "Đã thêm phòng.");
                AddNewRoom_Load(this, null);
            }
            else
            {
                labelRoomExist.Text = "Phòng đã có.";
                labelRoomExist.Visible = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            query = "SELECT * FROM rooms WHERE roomNo=" + txtRoomNo2.Text + "";
            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows.Count == 0)
            {
                labelRoom.Text = "Phòng này không tồn tại.";
                labelRoom.Visible = true;
                checkBox2.Checked = false;
            }
            else
            {
                labelRoom.Text = "Phòng này đã tìm thấy.";
                labelRoom.Visible = true;
                if (ds.Tables[0].Rows[0][1].ToString() == "YES")
                {
                    checkBox2.Checked = true;
                }else
                {
                    checkBox2.Visible = false;
                }    

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String status;
            if (checkBox2.Checked)
            {
                status = "Yes";
            }
            else
            {
                status = "No";
            }
            query = "update rooms set roomStatus='" + status + "' where roomNo =" + txtRoomNo2.Text + "";
            fn.setData(query, "Cập nhật chi tiết thành công.");
            AddNewRoom_Load(this, null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (labelRoom.Text== "Phòng này đã tìm thấy.")
            {
                query = "delete rooms where roomNo =" + txtRoomNo2.Text + "";
                fn.setData(query, "Đã xóa chi tiết phòng.");
                AddNewRoom_Load(this, null);
            } else
            {
                MessageBox.Show("Thử xóa lại, không thấy phòng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
