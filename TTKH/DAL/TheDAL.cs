using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;

namespace AGRIBANKHD.DAL
{
    class TheDAL
    {
        public static DataTable TheChuaNhan(string tuNgay, string denNgay)
        {
            DateTime _tuNgay = DateTime.ParseExact(tuNgay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime _denNgay = DateTime.ParseExact(denNgay, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@tungay", _tuNgay),
            new SqlParameter("@denngay", _denNgay)
            };
            DataTable dt = db.dt("DV_THECHUANHAN", Params);

            return dt;
        }

        public static DataTable TheDaNhanChuaGiao(string tuNgay, string denNgay)
        {
            DateTime _tuNgay = DateTime.ParseExact(tuNgay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime _denNgay = DateTime.ParseExact(denNgay, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@tungay", _tuNgay),
            new SqlParameter("@denngay", _denNgay)
            };
            DataTable dt = db.dt("DV_THEDANHAN_CHUAGIAO", Params);

            return dt;
        }

        public static DataTable TheDaGiao(string tuNgay, string denNgay)
        {
            DateTime _tuNgay = DateTime.ParseExact(tuNgay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime _denNgay = DateTime.ParseExact(denNgay, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@tungay", _tuNgay),
            new SqlParameter("@denngay", _denNgay)
            };
            DataTable dt = db.dt("DV_THEDAGIAO", Params);

            return dt;
        }
    }
}
