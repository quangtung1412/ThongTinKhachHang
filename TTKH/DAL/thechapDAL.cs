using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AGRIBANKHD.Entities;
using System.Data.SqlClient;
using System.Globalization;
namespace AGRIBANKHD.DAL
{
    class thechapDAL
    {
        public static List<Thechap> Danhsach_TC(string ma_hd_vay, string ma_cn, string ma_kh_vay)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@ma_hd_vay", ma_hd_vay),
            new SqlParameter("@ma_cn",ma_cn),
            new SqlParameter("@ma_kh_vay",ma_hd_vay)
            };
            DataTable dt = db.dt("Danhsach_TC", Params);

            List<Thechap> list = new List<Thechap>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Thechap(row));
            }
            return list;
        }
    }
}
