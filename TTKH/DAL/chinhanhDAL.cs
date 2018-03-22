﻿using System;
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
    class chinhanhDAL
    {
        DataAccess db = new DataAccess();
        public static List<Chinhanh> DanhsachCN()
        {
            DataAccess db = new DataAccess();
            DataTable dt = db.dt("Danhsach_CN");

            List<Chinhanh> list = new List<Chinhanh>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Chinhanh(row));
            }

            return list;
        }

        public static Chinhanh CN_theo_ma(string ma_cn)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@ma_cn", ma_cn)
            };

            DataTable dt = db.dt("CN_theo_ma", Params);

            Chinhanh cn = new Chinhanh(ma_cn, dt.Rows[0]["TEN_CN"].ToString(), dt.Rows[0]["TEN_CN_DAY_DU"].ToString(), dt.Rows[0]["DIA_CHI"].ToString(), dt.Rows[0]["MST"].ToString(), dt.Rows[0]["DKKD"].ToString(), dt.Rows[0]["GUQ"].ToString(), dt.Rows[0]["MA_KHTX"].ToString());
            return cn;
        }
    }
}
