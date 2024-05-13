using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;


namespace DAO
{
    public class HocSinhDAO
    {
        private Dataproviderr _provider = new Dataproviderr();
        //Lấy toàn bộ danh sách học sinh
        public DataTable getDSHocSinh()
        {
            string sqlStr = "Select h.MaHS, h.TenHS, h.NgaySinh, h.DiaChi, h.DTB, l.TenLop From HOCSINH h, LOP l Where h.MaLop = l.MaLop";
        return _provider.executeQuery(sqlStr);
          
        }
        public DataTable getDSHocSinhTheoLop(string malop)
        {
            string sqlStr = "Select h.MaHS, h.TenHS, h.NgaySinh, h.DiaChi, h.DTB, l.TenLop From HOCSINH h, LOP l Where h.MaLop = l.MaLop and l.MaLop = '"+malop +"'";
            return _provider.executeQuery(sqlStr);

        }
        public DataTable getDSHocSinhTheoTEnLop(string malop)
        {
            string sqlStr = "Select h.MaHS, h.TenHS, h.NgaySinh, h.DiaChi, h.DTB, l.TenLop From HOCSINH h, LOP l Where h.MaLop = l.MaLop and l.TenLop = '" + malop + "'";
            return _provider.executeQuery(sqlStr);

        }
        //Lấy ds học sinh theo lớp
        public DataTable getDSHocSinh(string sMalop)
        {
            string sqlStr = "Select * from HocSinh Where Malop='"
           + sMalop + "'";
            return _provider.executeQuery(sqlStr);
        }
        public void insert(string maHS, string tenHS, DateTime ngaySinh,
       string diaChi, float dtb, string maLop)
        {
            string strInsert = "insert into HocSinh values('"
            + maHS + "',N'" + tenHS + "','" +
            ngaySinh + "',N'" + diaChi + "'," +
            dtb + ",'" + maLop + "')";
            _provider.executeNonQuery(strInsert);
        }
        public void update(string maHS, string tenHS, DateTime ngaySinh,
       string diaChi, float dtb, string maLop)
        {
            string strUpdate = "update HocSinh set TenHS =N'" + tenHS +
            "',NgaySinh='" + ngaySinh + "',DiaChi=N'" +
           diaChi + "', DTB=" + dtb + ",MaLop='" +
           maLop + "'where maHS ='" + maHS + "'";
            _provider.executeNonQuery(strUpdate);
        }
        public void delete(string maHS)
        {
            string strDelete = "delete from HocSinh where maHS ='" +
           maHS + "'";
            _provider.executeNonQuery(strDelete);
        }
    }

}
