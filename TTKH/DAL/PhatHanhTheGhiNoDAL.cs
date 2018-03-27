using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AGRIBANKHD.Entities;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace AGRIBANKHD.DAL
{
    class PhatHanhTheGhiNoDAL
    {
        public static KhachHangDV TimKiemKH(string soCmnd) {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@soCmnd", soCmnd)
            };
            DataTable dt = db.dt("PhatHanhTheGhiNo_TimKiemKH", Params);
            if (dt.Rows.Count == 0)
                return null;
            else
            {
                KhachHangDV kh = new KhachHangDV(dt.Rows[0]);
                return kh;
            }
        }
    }
}
