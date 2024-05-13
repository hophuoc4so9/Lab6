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
using System.IO;
using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;

namespace GUII
{
    public partial class NhapXuatFileExcel : Form
    {
        //private SqlConnection conn;
        BUS.HocSinhBUS hsBus;
        DTO.HocSinhDTO hsInfo;
        private void getData()
        {
            hsInfo.MaHS = txtMaHS.Text;
            hsInfo.TenHS = txtTenHS.Text;
            hsInfo.NgaySinh = dtpNgaySinh.Value;
            hsInfo.DiaChi = txtDiaChi.Text;
          
            hsInfo.DTB = float.Parse(txtDiemTB.Text);
            hsInfo.MaLop = (string)cmbLop.SelectedValue;
            //Gán hsInfo cho info trong HocSinhBUS
            hsBus.info = hsInfo;
        }        private void DinhDangLuoi()
        {
            dgHocSinh.ReadOnly = true;
        
            dgHocSinh.Columns[0].HeaderText = "Mã HS";
            dgHocSinh.Columns[0].Width = 70;
            dgHocSinh.Columns[1].HeaderText = "Tên HS";
            dgHocSinh.Columns[1].Width = 150;
            dgHocSinh.Columns[2].HeaderText = "Ngày sinh";
            dgHocSinh.Columns[2].Width = 90;
            dgHocSinh.Columns[3].HeaderText = "Địa chỉ";
            dgHocSinh.Columns[3].Width = 200;
            dgHocSinh.Columns[4].HeaderText = "Điểm TB";
            dgHocSinh.Columns[4].Width = 80;
            dgHocSinh.Columns[5].HeaderText = "Lớp";
            dgHocSinh.Columns[5].Width = 80;
        }

        public NhapXuatFileExcel()
        {
            InitializeComponent();
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DAO.Dataproviderr provider = new Dataproviderr();
  
            provider.connect();
           
             hsBus = new HocSinhBUS();
            hsInfo = new HocSinhDTO();
            BUS.LopBUS lop = new LopBUS();
            //Dua du lieu len combobox
            DataTable dsLop = lop.getDSLop();
            cmbLop.DataSource = dsLop;
            cmbLop.DisplayMember = dsLop.Columns[1].ColumnName; //TenLop
            
            cmbLop.ValueMember = dsLop.Columns[0].ColumnName;
            dgHocSinh.DataSource = hsBus.getDSHocSinh();
            DinhDangLuoi();
            
            //Định dạng lưới
            
        }
       
        //Khai báo các biến lấy dữ liệu từ form, có thể khai báo toàn cục ngoài hàm

        private void btnXoa_Click(object sender, EventArgs e)
        {
            getData();
            if (hsBus.delete() == true)
            {
                //Load lai danh sach hoc sinh len luoi
                dgHocSinh.DataSource = hsBus.getDSHocSinh();
                MessageBox.Show("Xóa thành công");
            }

        }

   

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void InportExcel(string path)
        {
            Excel.Application application = new Excel.Application();
            application.Application.Workbooks.Add(Type.Missing);
            for (int i = 0; i < dgHocSinh.ColumnCount; i++)
            {
                application.Cells[1, 1 + i] = dgHocSinh.Columns[i].HeaderText;
            }
            for (int i = 0; i < dgHocSinh.RowCount; i++)
            {
                for (int j = 0; j < dgHocSinh.ColumnCount; j++)
                {
                    application.Cells[i+2, 1 + j] = dgHocSinh.Rows[i].Cells[j].Value;
                }
            }
            application.Columns.AutoFit();
            application.ActiveWorkbook.SaveCopyAs(path);
            application.ActiveWorkbook.Saved = true;
        }

        private void InportExcel2(string path)
        {
            ExcelPackage.LicenseContext =OfficeOpenXml.LicenseContext.NonCommercial;
            using (ExcelPackage excel = new ExcelPackage(new FileInfo(path)))
            {
                ExcelWorksheet excelWorksheet = excel.Workbook.Worksheets[0];
                DataTable dt = new DataTable();
                for(int i=excelWorksheet.Dimension.Start.Column;i<= excelWorksheet.Dimension.End.Column;i++)
                {
                    dt.Columns.Add(excelWorksheet.Cells[1, i].Value.ToString());
                   
                }
                for (int i = excelWorksheet.Dimension.Start.Row +1; i <= excelWorksheet.Dimension.End.Row; i++)
                {
                    List<string> listRow = new List<string>();
                    for (int j = excelWorksheet.Dimension.Start.Column; j <= excelWorksheet.Dimension.End.Column; j++)
                    {
                        listRow.Add(excelWorksheet.Cells[i, j].Value.ToString());
                    }
                    dt.Rows.Add(listRow.ToArray());

                }
                dgHocSinh.DataSource = dt;
            }    
        }
        private void txtMaHS_MouseCaptureChanged(object sender, EventArgs e)
        {
          //  MessageBox.Show("di chuyển");
        }

        private void txtMaHS_Leave(object sender, EventArgs e)
        {
                    }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void dgHocSinh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void dgHocSinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewSelectedCellCollection cell =
dgHocSinh.SelectedCells;
            if (cell.Count > 0)
            {
                DataGridViewRow row = dgHocSinh.Rows[e.RowIndex];
                txtMaHS.Text = row.Cells["MaHS"].Value.ToString();
                txtTenHS.Text = row.Cells["TenHS"].Value.ToString();
                if (row.Cells["NgaySinh"].Value.ToString().Length > 0)
                    dtpNgaySinh.Value =
                   DateTime.Parse(row.Cells["NgaySinh"].Value.ToString());
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                cmbLop.Text = row.Cells["TenLop"].Value.ToString();
                txtDiemTB.Text = row.Cells["DTB"].Value.ToString();
            }

        }

        private void btnthemMoi_Click(object sender, EventArgs e)
        {
            txtMaHS.Clear();
            txtTenHS.Clear();
            txtDiaChi.Clear();
            txtDiemTB.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getData();
            if (hsBus.update() == true)
            {
                //Load lai danh sach hoc sinh len luoi
                dgHocSinh.DataSource = hsBus.getDSHocSinh();
                MessageBox.Show("Sửa thành công");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            getData();
            if (hsBus.insert() == true)
            {
                //Load lai danh sach hoc sinh len luoi
                dgHocSinh.DataSource = hsBus.getDSHocSinh();
                MessageBox.Show("Thêm thành công");
            }
        }
        private Boolean checkdata()
        {

            return true;
        }
        private Boolean checkHScotrongbang()
        {
                



                return false;
        }

        private void cmbLop_SelectedValueChanged(object sender, EventArgs e)
        {
            var s = cmbLop.Text;
        }

        private void cmbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = this.cmbLop.GetItemText(this.cmbLop.SelectedItem);
            dgHocSinh.DataSource = hsBus.getDSHocSinhtenlop(selected);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Title = "Xuất Excel";
            save.Filter = "Excel Files(*.xls)|*.xls; *.xlsx| Excel Files(*.xlsx)| *.xlsx; *.xlsx | Excel Files(*.xlsm) | *.xlsm; *.xlsx";
            if (save.ShowDialog()==DialogResult.OK)
            {
                try
                {
                    InportExcel(save.FileName);
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                } 
                

            }    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog save = new OpenFileDialog();
            save.Title = "Nhập Excel";
              save.Filter= "Excel Files(*.xls)|*.xls; *.xlsx| Excel Files(*.xlsx)| *.xlsx; *.xlsx | Excel Files(*.xlsm) | *.xlsm; *.xlsx";
            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    InportExcel2(save.FileName);
                }
                catch (Exception ex)    
                {
                    MessageBox.Show(ex.ToString());
                }


            }
        }
    }
}
