using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_thư_viện.All_user_control
{
    public partial class UC_quanlydocgia : UserControl
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        DataTable comdt = new DataTable();
        DataTable dtLop = new DataTable();
        DataTable dtKhoaVien = new DataTable();
        DataTable dtChucVu = new DataTable();
        string sql, constr;

      
        public UC_quanlydocgia()
        {
            InitializeComponent();
        }

        
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            NapCT();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
        }





      

        private void UC_quanlydocgia_Load(object sender, EventArgs e)
        {
             constr = "Data Source=DESKTOP-17HI96A;Initial Catalog=QLthuvien;Integrated Security=True";// thay thành 
            conn.ConnectionString = constr;
            conn.Open();
            sql = "SELECT Ma_Doc_Gia, Ho_Ten, Ma_Lop, Ma_Khoa_Vien, SDT, Chuc_Vu FROM DocGia ORDER BY Ma_Doc_Gia";  // them cac cai du lieu minh can 
            da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            grdData.DataSource = dt;
            grdData.Refresh();
            NapCT();
            //comTenTruong.Text = "Ma_Doc_Gia";
           

            sql = "select distinct Ma_Lop from DocGia ";
            da = new SqlDataAdapter(sql, conn);
            dtLop.Clear();
            da.Fill(dtLop);
            comLop.DataSource = dtLop;
            comLop.DisplayMember = "Ma_Lop";

            sql = "select distinct Chuc_Vu from DocGia ";
            da = new SqlDataAdapter(sql, conn);
            dtChucVu.Clear();
            da.Fill(dtChucVu);
            comChucVu.DataSource = dtChucVu;
            comChucVu.DisplayMember = "Chuc_Vu";

            sql = "select distinct Ma_Khoa_Vien from DocGia ";
            da = new SqlDataAdapter(sql, conn);
            dtKhoaVien.Clear();
            da.Fill(dtKhoaVien);
            
            comKhoaVien.DataSource = dtKhoaVien;
            comKhoaVien.DisplayMember = "Ma_Khoa_Vien";

        }
        
        public void NapCT()
        {
            
                int i = grdData.CurrentRow.Index;
                //lấy dòng hiện thời 
                txtMaDocGia.Text = grdData.Rows[i].Cells["Ma_Doc_Gia"].Value.ToString();
                txtHoTen.Text = grdData.Rows[i].Cells["Ho_Ten"].Value.ToString();
                txtSDT.Text = grdData.Rows[i].Cells["SDT"].Value.ToString();
                txtKhoaVien.Text = grdData.Rows[i].Cells["Ma_Khoa_Vien"].Value.ToString();
                txtLop.Text = grdData.Rows[i].Cells["Ma_Lop"].Value.ToString();
                txtChucVu.Text = grdData.Rows[i].Cells["Chuc_Vu"].Value.ToString();
            
        }
        public void NapLai()
        {
            sql = "SELECT Ma_Doc_Gia, Ho_Ten, Ma_Lop, Ma_Khoa_Vien, SDT, Chuc_Vu FROM DocGia ORDER BY Ma_Doc_Gia";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdData.DataSource = dt;
            grdData.Refresh();
            NapCT();
        }
        private void grdData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            NapCT(); // Gọi phương thức để cập nhật dữ liệu vào các trường
        }

        private void btndelete_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi hiện thời?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "Delete from DocGia where Ma_Doc_Gia='" + txtMaDocGia.Text + "'";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                NapLai();
            }
        }

        private void combLop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void grdData_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            NapCT();
        }

        private void btnaddnew_Click_1(object sender, EventArgs e)
        {
            txtMaDocGia.Text = "";
            txtHoTen.Text = "";
            txtLop.Visible = false;
            comLop.Visible = true;
            txtKhoaVien.Visible = false;
            comKhoaVien.Visible = true;
            txtSDT.Text = "";
            txtChucVu.Visible =false;
            comChucVu.Visible = true;
            txtMaDocGia.Focus(); 
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            sql = "insert into DocGia(Ma_Doc_Gia, Ho_Ten, Ma_Lop, Ma_Khoa_Vien, SDT, Chuc_Vu)"
              + " Values('" + txtMaDocGia.Text + "',N'" + txtHoTen.Text + "',N'"
              + comLop.Text + "',N'" + comKhoaVien.Text + "','" + txtSDT.Text + "',N'"
             + comChucVu.Text + "')";
            cmd = new SqlCommand(sql, conn); 
            cmd.ExecuteNonQuery(); 
            MessageBox.Show("Đã cập nhật thành công!");
            NapLai();
            txtLop.Visible = true;
            comLop.Visible = false;
            txtKhoaVien.Visible = true;
            comKhoaVien.Visible = false;
            txtChucVu.Visible = true;
            comChucVu.Visible = false;
            txtMaDocGia.Focus();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {

        }

        private void comTenTruong_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void comTenTruong_SelectedIndexChanged(object sender, EventArgs e)
        {
           if (comTenTruong.Text != "Ho_Ten")
             {
                 sql = "select distinct " + comTenTruong.Text + " from DocGia"; da = new SqlDataAdapter(sql, conn);
                 da = new SqlDataAdapter(sql, conn); 
                 comdt.Clear();
                 da.Fill(comdt);
                 comGT.DataSource = comdt;
                 comGT.DisplayMember = comTenTruong.Text;

             }
             else
             {
                 comGT.DisplayMember = comTenTruong.Text;
                 sql = "select distinct Ma_Doc_Gia, Ho_Ten from DocGia"; da = new SqlDataAdapter(sql, conn);
                 comdt.Clear();
                 da.Fill(comdt);
                 comGT.DataSource = comdt;
                 comGT.DisplayMember = "Ho_Ten"; 
                 comGT.ValueMember = "Ma_Doc_Gia";
             }
        }
        private void combotentruong_SelectedIndexChanged(object sender, EventArgs e)
        {           /* if (comTenTruong.Text == "Ho_Ten")
            {
                sql = "select distinct " + comTenTruong.Text + " from DocGia";
                da = new SqlDataAdapter(sql, conn);
                comdt.Clear();
                da.Fill(comdt);
                comGT.DataSource = comdt;
                comGT.DisplayMember = comTenTruong.Text;
            }
            else
            {
                comGT.DisplayMember = comTenTruong.Text;
                sql = "select distinct Ma_Doc_Gia, Ho_Ten from DocGia";
                da = new SqlDataAdapter(sql, conn);
                comdt.Clear();
                da.Fill(comdt);
                comGT.DataSource = comdt;
                comGT.DisplayMember = "Ho_Ten";
                comGT.ValueMember = "Ma_Doc_Gia";
            }*/
        }

        private void comGT_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (comTenTruong.Text != "HoTen")
            {
                sql = "SELECT Ma_Doc_Gia, Ho_Ten, Ma_Lop, Ma_Khoa_Vien, SDT, Chuc_Vu FROM DocGia WHERE " + comTenTruong.Text + " = '" + comGT.Text + "'";
                /*" ORDER BY Ma_Doc_Gia";*/
                da = new SqlDataAdapter(sql, conn);
                dt.Clear();
                da.Fill(dt);
                grdData.DataSource = dt;
                grdData.Refresh();
                NapCT();
            }
            else
            {
                sql = "SELECT Ma_Doc_Gia, Ho_Ten, Ma_Lop, Ma_Khoa_Vien, SDT, Chuc_Vu FROM DocGia" 
                +"where Ma_Doc_Gia='"+comGT.SelectedValue +"'";
                da = new SqlDataAdapter(sql, conn);
                dt.Clear();
                da.Fill(dt);
                grdData.DataSource = dt;
                grdData.Refresh();
                NapCT();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            sql = "SELECT Ma_Doc_Gia, Ho_Ten, Ma_Lop, Ma_Khoa_Vien, SDT, Chuc_Vu FROM DocGia ORDER BY Ma_Doc_Gia";  // them cac cai du lieu minh can 
            da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            grdData.DataSource = dt;
            grdData.Refresh();
            NapCT();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NapCT();        }
    }
}
