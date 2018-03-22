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
    class phonggiaodichDAL
    {
        DataAccess db = new DataAccess();
        public static List<Phonggiaodich> DS_PGD(string ma_cn)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@ma_cn", ma_cn)
            };
            DataTable dt = db.dt("DS_PGD", Params);

            List<Phonggiaodich> list = new List<Phonggiaodich>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Phonggiaodich(row));
            }

            return list;
        }

        public static Phonggiaodich PGD_THEO_MA(string ma_pgd)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@ma_pgd", ma_pgd)
            };

            DataTable dt = db.dt("PGD_THEO_MA", Params);

            Phonggiaodich pgd = new Phonggiaodich(dt.Rows[0]["MA_CN"].ToString(), dt.Rows[0]["MA_PGD"].ToString(), dt.Rows[0]["TEN_PGD"].ToString(), dt.Rows[0]["TEN_CN"].ToString(), dt.Rows[0]["TEN_CN_DAY_DU"].ToString(), dt.Rows[0]["DIA_CHI"].ToString(), dt.Rows[0]["MST"].ToString(), dt.Rows[0]["DKKD"].ToString(), dt.Rows[0]["GUQ"].ToString(), dt.Rows[0]["MA_KHTX"].ToString());
            return pgd;
        }
    }
}
