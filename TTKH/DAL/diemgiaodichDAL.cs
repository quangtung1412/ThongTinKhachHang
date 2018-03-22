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
    class diemgiaodichDAL
    {
        DataAccess db = new DataAccess();

        public bool THEM_DIEM_GIAO_DICH(Diemgiaodich dgg)
        {
            SqlParameter[] Params = new SqlParameter[] 
            {
                //new SqlParameter("@id_diem_giao_dich",dgg.id_diem_giao_dich),
                new SqlParameter("@ma_chi_nhanh",dgg.ma_chi_nhanh),
                new SqlParameter("@ten_chi_nhanh",dgg.ten_chi_nhanh),
                new SqlParameter("@ma_diem_giao_dich",dgg.ma_diem_giao_dich),
                new SqlParameter("@ten_diem_giao_dich",dgg.ten_diem_giao_dich),
                new SqlParameter("@ten_he_thong_ung_dung",dgg.ten_he_thong_ung_dung)
             };
            int count = db.cmdExecNonQueryProc("THEM_DIEM_GIAO_DICH", Params);
            return count > 0;
        }

        public bool CAP_NHAT_DIEM_GIAO_DICH(Diemgiaodich dgg)
        {
            SqlParameter[] Params = new SqlParameter[] 
            {
                new SqlParameter("@id_diem_giao_dich",dgg.id_diem_giao_dich),
                new SqlParameter("@ma_chi_nhanh",dgg.ma_chi_nhanh),
                new SqlParameter("@ten_chi_nhanh",dgg.ten_chi_nhanh),
                new SqlParameter("@ma_diem_giao_dich",dgg.ma_diem_giao_dich),
                new SqlParameter("@ten_diem_giao_dich",dgg.ten_diem_giao_dich),
                new SqlParameter("@ten_he_thong_ung_dung",dgg.ten_he_thong_ung_dung)
             };
            int count = db.cmdExecNonQueryProc("CAP_NHAT_DIEM_GIAO_DICH", Params);
            return count > 0;
        }

        public bool XOA_DIEM_GIAO_DICH(Int32 id_diem_giao_dich)
        {
            SqlParameter[] Params = new SqlParameter[] 
            {
                new SqlParameter("@id_diem_giao_dich",id_diem_giao_dich)
            };
            int count = db.cmdExecNonQueryProc("XOA_DIEM_GIAO_DICH", Params);
            return count > 0;
        }

        public static Diemgiaodich DIEM_GIAO_DICH_THEO_ID(Int32 id_diem_giao_dich)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
                new SqlParameter("@id_diem_giao_dich",id_diem_giao_dich)
            };
            DataTable dt = db.dt("DIEM_GIAO_DICH_THEO_ID", Params);
            string[] diem_giao_dich = new string[6];
            diem_giao_dich[0] = dt.Rows[0]["ID_DIEM_GIAO_DICH"].ToString();
            diem_giao_dich[1] = dt.Rows[0]["MA_CHI_NHANH"].ToString();
            diem_giao_dich[2] = dt.Rows[0]["TEN_CHI_NHANH"].ToString();
            diem_giao_dich[3] = dt.Rows[0]["MA_DIEM_GIAO_DICH"].ToString();
            diem_giao_dich[4] = dt.Rows[0]["TEN_DIEM_GIAO_DICH"].ToString();
            diem_giao_dich[5] = dt.Rows[0]["TEN_HE_THONG_UNG_DUNG"].ToString();
            Diemgiaodich dgg = new Diemgiaodich(diem_giao_dich);
            return dgg;
        }
    }
}
