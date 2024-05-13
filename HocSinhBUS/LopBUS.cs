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
    public class LopBUS
    {
        private DAO.Dataproviderr _provider = new Dataproviderr();
        DAO.LopDAO data = new DAO.LopDAO();
        DAO.HocSinhDAO data2 = new DAO.HocSinhDAO();
        public DataTable getDSHStheolop(string malop)
        {
            

            return data2.getDSHocSinhTheoLop(malop);
        }
        //Lấy ds học sinh theo lớp
        public DTO.LopDTO info { get; set; }
        public DataTable getDSLop()
        {
            string sqlStr = "Select * from LOP";
         
        return _provider.executeQuery(sqlStr);
        }
        public bool insert()
        {
            try

            {
                data.insert(info.MaLop,info.TenLop,info.SiSo);
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
                data.update(info.MaLop, info.TenLop, info.SiSo);
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
                data.delete(info.MaLop);
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
