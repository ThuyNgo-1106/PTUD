using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_thư_viện.Login
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "quanly01" && txtPassword.Text == "thuvienktqd")
            {
                frmTrangchu admin = new frmTrangchu();
                admin.Show();
                this.Hide();
            }    
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng","Lỗi",MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Clear();
                txtPassword.Clear();
            }
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
