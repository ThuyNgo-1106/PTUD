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
    public partial class UCquanlymuontra : UserControl
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd =new SqlCommand();
        DataTable dt = new DataTable();
        DataTable comdt = new DataTable();
        string sql, constr;
        public UCquanlymuontra()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Phieuphat phieuphat = new Phieuphat();
            phieuphat.Show();
        }
        private void label2_Click(object sender, EventArgs e)
        {
           
        }
        private void comtentruong_SelectedIndexChanged(object sender, EventArgs e)
        {   
           
            sql = "select distinct " + comtentruong.Text + " from PhieuMuon";
            da=new SqlDataAdapter(sql,conn);
            comdt.Clear();
            da.Fill(comdt);
            comgt.DataSource = comdt;
            comgt.DisplayMember = comtentruong.Text;
            
        }
        private void label10_Click(object sender, EventArgs e)
        {

        }
        private void guna2Button6_Click(object sender, EventArgs e)
        {
            sql = "Select Ma_Phieu_Muon,Ma_Doc_Gia,Ma_Kieu_Muon,Ngay_Muon,Han_Tra,Ngay_Thuc_Tra,Ma_Thu_Thu from PhieuMuon order by Ma_Phieu_Muon";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grddata.DataSource = dt;
            grddata.Refresh();
            NapCT();
        }
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            sql = "SELECT Ma_Phieu_Muon, Ma_Doc_Gia, Ma_Kieu_Muon, Ngay_Muon, Han_Tra, Ngay_Thuc_Tra, Ma_Thu_Thu " +
             "FROM PhieuMuon " +
             "WHERE " + comtentruong.Text + " = '" + comgt.Text + "' " +
             "ORDER BY Ma_Phieu_Muon";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grddata.DataSource = dt;
            grddata.Refresh();
            NapCT();
        }

        private void grddata_CellContentClick(object sender, EventArgs e)
        {

        }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }




        private void UCquanlymuontra_Load(object sender, EventArgs e)
        {
            constr = "Data Source=DESKTOP-72B0U97\\SQLEXPRESS;Initial Catalog=QLthuvien;Integrated Security=True";
            conn.ConnectionString = constr;
            conn.Open();
            sql = "Select Ma_Phieu_Muon,Ma_Doc_Gia,Ma_Kieu_Muon,Ngay_Muon,Han_Tra,Ngay_Thuc_Tra,Ma_Thu_Thu from PhieuMuon order by Ma_Phieu_Muon";
            da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            grddata.DataSource = dt;
            grddata.Refresh();
            NapCT();
            comtentruong.Text = "Ma_Phieu_Muon";
            txtmaphieu.ReadOnly = true;
            txtmadocgia.ReadOnly = true;
            txtthuthu.ReadOnly = true;
            cbmakieumuon.Enabled = false;
            datengaymuon.Enabled = false;
            datehantra.Enabled = false;
            datethuctra.Enabled = false;
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void grddata_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            NapCT();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            txtmaphieu.ReadOnly = false;
            txtmadocgia.ReadOnly = false;
            txtthuthu.ReadOnly = false;
            cbmakieumuon.Enabled = true;
            datengaymuon.Enabled = true;
            datehantra.Enabled = true;

            datethuctra.Enabled = true;
            string maPhieuMuon = txtmaphieu.Text;
            bool isDuplicate = false;

            
                sql = "insert into PhieuMuon(Ma_Phieu_Muon,Ma_Doc_Gia,Ma_Kieu_Muon,Ngay_Muon,Ngay_Thuc_Tra,Ma_Thu_Thu)"
                    + " Values('" + txtmaphieu.Text + "','" + txtmadocgia.Text + "','"
                    + cbmakieumuon.Text + "','" + datengaymuon.Text + "','"
                   + datengaymuon.Text + "','" + txtthuthu.Text + "')";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void btnaddnew_Click(object sender, EventArgs e)
        {
            txtmaphieu.Text = "";
            txtmadocgia.Text = "";
            cbmakieumuon.Text = "";
            txtthuthu.Text = "";
            datehantra.Text = "";
            datengaymuon.Text = "";
            datethuctra.Text = "";
            txtmaphieu.Focus();


        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void cbmathuthu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btndelete_Click(object sender, EventArgs e) 
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi hiện thời?", "Xác nhận"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
            {
                sql = "Delete from PhieuMuon where Ma_Phieu_Muon='" + txtmaphieu.Text + "'";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                NapLai();

            }
        }

        public void NapCT()
        {
            int i = grddata.CurrentRow.Index;
            txtmaphieu.Text = grddata.Rows[i].Cells["Ma_Phieu_Muon"].Value.ToString();
            txtmadocgia.Text = grddata.Rows[i].Cells["Ma_Doc_Gia"].Value.ToString();
           cbmakieumuon.Text = grddata.Rows[i].Cells["Ma_Kieu_Muon"].Value.ToString();
            datengaymuon.Text = grddata.Rows[i].Cells["Ngay_Muon"].Value.ToString();
            datehantra.Text = grddata.Rows[i].Cells["Han_Tra"].Value.ToString();
            datethuctra.Text = grddata.Rows[i].Cells["Ngay_Thuc_Tra"].Value.ToString();
            txtthuthu.Text = grddata.Rows[i].Cells["Ma_Thu_Thu"].Value.ToString();
        }

        private void datethuctra_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            txtmaphieu.ReadOnly = false;
            txtmadocgia.ReadOnly = false;
            txtthuthu.ReadOnly = false;
            cbmakieumuon.Enabled = true;
            datengaymuon.Enabled = true;
            datehantra.Enabled = true;
            datethuctra.Enabled = true;
        }

        public void NapLai()
        {
            sql = "Select Ma_Phieu_Muon,Ma_Doc_Gia,Ma_Kieu_Muon,Ngay_Muon,Han_Tra,Ngay_Thuc_Tra,Ma_Thu_Thu from PhieuMuon order by Ma_Phieu_Muon";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grddata.DataSource = dt;
            grddata.Refresh();
            NapCT();
        }
    }
}
