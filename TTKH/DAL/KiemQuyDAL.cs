using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AGRIBANKHD.DAL
{
    class KiemQuyDAL
    {
        public static DataTable DV_DSNhanVien_MaCN(string macn)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("@macn", macn)
            };
            return db.dt("DV_DSNHANVIEN_MACN", Params);
        }
    }
}
