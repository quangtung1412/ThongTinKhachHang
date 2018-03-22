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
    class rtbcontentDAL
    {
        DataAccess db = new DataAccess();

        public static DataTable tbl_RTB_CONTENT()
        {
            DataAccess db = new DataAccess();
            
            DataTable dt = db.dt("DS_RTB_CONTENT");

            return dt;
        }

        public bool Them_RTB_CONTENT(RtbContent rtb)
        {
            SqlParameter[] Params = new SqlParameter[] 
            {
                new SqlParameter("@bds_thong_tin_chung",rtb.bds_thong_tin_chung),                new SqlParameter("@bds_giay_to",rtb.bds_giay_to),                new SqlParameter("@bds_nha_thong_tin_chung",rtb.bds_nha_thong_tin_chung),                new SqlParameter("@bds_ctxd_thong_tin_chung",rtb.bds_ctxd_thong_tin_chung),                new SqlParameter("@bds_tsgl_khac_thong_tin_chung",rtb.bds_tsgl_khac_thong_tin_chung),                new SqlParameter("@ds_thong_tin_chung",rtb.ds_thong_tin_chung),                new SqlParameter("@ds_giay_to",rtb.ds_giay_to),                new SqlParameter("@tstc_khac_thong_tin_chung",rtb.tstc_khac_thong_tin_chung),                new SqlParameter("@tstc_khac_giay_to",rtb.tstc_khac_giay_to)
             };
            int count = db.cmdExecNonQueryProc("THEM_RTB_CONTENT", Params);
            return count > 0;
        }
    }
}
