using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class LopDAO
    {
        private Dataproviderr _provider = new Dataproviderr();
        //Lấy ds học sinh theo lớp
        public DataTable getDSLop()
        {
            string sqlStr = "Select * from LOP";
            return _provider.executeQuery(sqlStr);
        }

        public void insert(string maLop,string tenlop,int siso)
        {
            string strInsert = "insert into Lop values(N'" + maLop +  "',N'" + tenlop + "'," + siso + ")";
            _provider.executeNonQuery(strInsert);
        }
        public void update(string maLop, string tenlop, int siso)
        {
            string strUpdate = "update Lop set tenlop =N'" + tenlop +"',siso="+siso+ " where maLop ='" + maLop + "'";
            _provider.executeNonQuery(strUpdate);
        }
        public void delete(string maLop)
        {
            string strDelete = "delete from Lop where maLop ='" + maLop + "'";
            _provider.executeNonQuery(strDelete);
        }

    }
}
