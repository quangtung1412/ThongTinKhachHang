using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AGRIBANKHD.Entities;
using System.Data.SqlClient;
using System.Data;

namespace AGRIBANKHD.DAL
{
    class PhatHanhTheGhiNoDAL
    {
        public static Khachhang TimKiemKH(string maKH) {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@maKH", maKH)
            };
            DataTable dt = db.dt("PhatHanhTheGhiNo_TimKiemKH", Params);

            return new Khachhang(dt.Rows[0]);
        }
    }
}
