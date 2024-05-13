using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BUS;
using DTO;
using DAO;
namespace GUII
{
    public partial class frmLop : Form
    {
   
        BUS.LopBUS hsBus;
        DTO.LopDTO hsInfo;
        private void DinhDangLuoi()
        {
            dgHocSinh.ReadOnly = true;

            dgHocSinh.Columns[0].HeaderText = "Mã Lớp";
            dgHocSinh.Columns[0].Width = 70;
            dgHocSinh.Columns[1].HeaderText = "Tên Tên lớp";
            dgHocSinh.Columns[1].Width = 150;
            dgHocSinh.Columns[2].HeaderText = "Sỉ số";
            dgHocSinh.Columns[2].Width = 90;
      
        }
        private void getData()
        {
            hsInfo.MaLop = txtMaHS.Text;
            hsInfo.TenLop = txtTenHS.Text;
            hsInfo.SiSo = int.Parse( numericUpDown1.Value.ToString());
           
            
            //Gán hsInfo cho info trong HocSinhBUS
            hsBus.info = hsInfo;
        }
        public frmLop()
        {
            InitializeComponent();
        }
        private void DinhDangLuoi2()
        {
            dataGridView1.ReadOnly = true;

            dataGridView1.Columns[0].HeaderText = "Mã HS";
            dataGridView1.Columns[0].Width = 70;
            dataGridView1.Columns[1].HeaderText = "Tên HS";
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].HeaderText = "Ngày sinh";
            dataGridView1.Columns[2].Width = 90;
            dataGridView1.Columns[3].HeaderText = "Địa chỉ";
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].HeaderText = "Điểm TB";
            dataGridView1.Columns[4].Width = 80;
            dataGridView1.Columns[5].HeaderText = "Lớp";
            dataGridView1.Columns[5].Width = 80;
        }
        private void frmLop_Load(object sender, EventArgs e)
        {
            DAO.Dataproviderr provider = new Dataproviderr();

            provider.connect();

            hsBus = new LopBUS();
            hsInfo = new LopDTO();
            BUS.LopBUS lop = new LopBUS();
            //Dua du lieu len combobox
            DataTable dsLop = lop.getDSLop();
           
            dgHocSinh.DataSource = hsBus.getDSLop();
            DinhDangLuoi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            getData();
            if (hsBus.delete() == true)
            {
                //Load lai danh sach hoc sinh len luoi
                dgHocSinh.DataSource = hsBus.getDSLop();
                MessageBox.Show("Xóa thành công");
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnthemMoi_Click(object sender, EventArgs e)
        {
            txtMaHS.Clear();
            txtTenHS.Clear();
            numericUpDown1.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getData();
            if (hsBus.update() == true)
            {
                //Load lai danh sach hoc sinh len luoi
                dgHocSinh.DataSource = hsBus.getDSLop();
                MessageBox.Show("Sửa thành công");
            }
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            getData();
            if (hsBus.insert() == true)
            {
                //Load lai danh sach hoc sinh len luoi
                dgHocSinh.DataSource = hsBus.getDSLop();
                MessageBox.Show("Thêm thành công");
            }
        }

        private void dgHocSinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewSelectedCellCollection cell = dgHocSinh.SelectedCells;
            if (cell.Count > 0)
            {
                DataGridViewRow row = dgHocSinh.Rows[e.RowIndex];
                txtMaHS.Text = row.Cells["MaLop"].Value.ToString();
                txtTenHS.Text = row.Cells["TenLop"].Value.ToString();
                numericUpDown1.Value = int.Parse(row.Cells["SiSo"].Value.ToString());
                dataGridView1.DataSource = hsBus.getDSHStheolop(txtMaHS.Text);
                DinhDangLuoi2();
            }
        }

        private void dgHocSinh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
