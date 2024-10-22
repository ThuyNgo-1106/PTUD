using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_thư_viện.All_user_control
{
    public partial class Quản_lý_sách : UserControl
    {
        public Quản_lý_sách()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Themsach themsach = new Themsach();
            themsach.Show();
        }

        private void Quản_lý_sách_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            theloai theloai = new theloai();
            theloai.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Chude chude = new Chude();
            chude.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            NXB nXB = new NXB();
            nXB.Show();

        }
    }
}
