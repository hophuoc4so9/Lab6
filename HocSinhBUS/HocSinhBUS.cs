    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
using System.Data;
using System.Data.SqlClient;
namespace BUS
{
   public class HocSinhBUS
    {
        DAO.HocSinhDAO data = new DAO.HocSinhDAO();

        public DTO.HocSinhDTO info { get; set; }
        public DataTable getDSHocSinh()
        {
            return data.getDSHocSinh();
        }
        public DataTable getDSHocSinh(string sMalop)
        {
            return data.getDSHocSinh(sMalop);
        }
        public DataTable getDSHocSinhtenlop(string Tenlop)
        {
            return data.getDSHocSinhTheoTEnLop(Tenlop);
        }
        public bool insert()
        {
            try

            {
                data.insert(info.MaHS, info.TenHS, info.NgaySinh,
               info.DiaChi, info.DTB, info.MaLop);
                return true;
            }
 catch (Exception ex)
            {
              //  MessageBox.Show("Lỗi thêm dữ liệu" + ex.Message);
                return false;
            }
        }
        public bool update()
        {
            try
            {
                data.update(info.MaHS, info.TenHS, info.NgaySinh,
               info.DiaChi, info.DTB, info.MaLop);
                return true;
            }
            catch (Exception ex)
            {
          //      MessageBox.Show("Lỗi updata dữ liệu" + ex.Message);
                return false;
            }
        }
        public bool delete()
        {
            try
            {
                data.delete(info.MaHS);
                return true;
            }
            catch (Exception ex)
            {
             //   MessageBox.Show("Lỗi Xóa dữ liệu" + ex.Message);
               return false;
            }
        }
    }
}
