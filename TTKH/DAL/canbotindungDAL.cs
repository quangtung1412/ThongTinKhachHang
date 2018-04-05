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
    class canbotindungDAL
    {
        DataAccess db = new DataAccess();
        //public static List<Canbotindung> Danhsach_CBTD(string ma_cn)
        //{
        //    DataAccess db = new DataAccess();
        //    SqlParameter[] Params = new SqlParameter[]
        //    {
        //    new SqlParameter("@ma_cn", ma_cn)
        //    };
        //    DataTable dt = db.dt("Danhsach_CBTD", Params);

        //    List<Canbotindung> list = new List<Canbotindung>();
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        list.Add(new Canbotindung(row));
        //    }
        //    return list;
        //}

        public static Canbotindung CBTD_theo_ten_dang_nhap(string ten_dang_nhap)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@ten_dang_nhap", ten_dang_nhap)
            };
            DataTable dt = db.dt("CBTD_theo_ten_dang_nhap", Params);

            string[] thong_tin_cb = new string[13];
            thong_tin_cb[0] = dt.Rows[0]["MA_CN"].ToString();
            thong_tin_cb[1] = dt.Rows[0]["MA_PGD"].ToString();
            thong_tin_cb[2] = ten_dang_nhap;
            thong_tin_cb[3] = dt.Rows[0]["HO_TEN"].ToString();
            thong_tin_cb[4] = dt.Rows[0]["CHUC_VU"].ToString();
            thong_tin_cb[5] = dt.Rows[0]["GIAY_UY_QUYEN"].ToString();
            thong_tin_cb[6] = dt.Rows[0]["DIEN_THOAI"].ToString();
            thong_tin_cb[7] = dt.Rows[0]["FAX"].ToString();
            thong_tin_cb[8] = dt.Rows[0]["MAT_KHAU"].ToString();
            thong_tin_cb[9] = dt.Rows[0]["ADMIN"].ToString();
            thong_tin_cb[10] = dt.Rows[0]["DANH_XUNG"].ToString();
            thong_tin_cb[11] = dt.Rows[0]["MA_PB"].ToString();
            thong_tin_cb[12] = dt.Rows[0]["KICH_HOAT"].ToString();
            
            Canbotindung cb = new Canbotindung(thong_tin_cb);

            return cb;
        }

        public bool Kiem_tra_trung_ten_dang_nhap(string ten_dang_nhap)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@ten_dang_nhap", ten_dang_nhap)
            };

            DataTable dt = db.dt("CBTD_theo_ten_dang_nhap", Params);

            return dt.Rows.Count > 0;
        }

        public static DataTable tbl_CBTD(string ma_cn)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@ma_cn", ma_cn)
            };
            DataTable dt = db.dt("Danhsach_CBTD", Params);

            return dt;
        }

        public static DataTable tbl_CBTD_chua_kich_hoat(string ma_cn)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@ma_cn", ma_cn)
            };
            DataTable dt = db.dt("Danhsach_CBTD_chua_kich_hoat", Params);

            return dt;
        }

        public static DataTable tbl_CBTD_CV(string ma_cn, string chuc_vu)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@ma_cn", ma_cn),
            new SqlParameter("@chuc_vu", chuc_vu)
            };
            DataTable dt = db.dt("Danhsach_CBTD_theo_chuc_vu", Params);

            return dt;
        }

        public static DataTable tbl_CBTD_CV_chua_kich_hoat(string ma_cn, string chuc_vu)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@ma_cn", ma_cn),
            new SqlParameter("@chuc_vu", chuc_vu)
            };
            DataTable dt = db.dt("Danhsach_CBTD_theo_chuc_vu_chua_kich_hoat", Params);

            return dt;
        }

        public static DataTable tbl_CBTD_CV_MA_PB(string ma_cn, string chuc_vu, string ma_pb)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@ma_cn", ma_cn),
            new SqlParameter("@chuc_vu", chuc_vu),
            new SqlParameter("@ma_pb", ma_pb)
            };
            DataTable dt = db.dt("DS_CBTD_THEO_CV_MA_PB", Params);

            return dt;
        }

        public bool Them_CBTD(Canbotindung cb)
        {
            SqlParameter[] Params = new SqlParameter[] 
            {
                 new SqlParameter("@ma_cn", cb.ma_cn),
                 new SqlParameter("@ma_pgd", cb.ma_pgd),
                 new SqlParameter("@ten_dang_nhap", cb.ten_dang_nhap),
                 new SqlParameter("@ho_ten",cb.ho_ten),
                 new SqlParameter("@chuc_vu",cb.chuc_vu),
                 new SqlParameter("@giay_uy_quyen",cb.giay_uy_quyen),
                 new SqlParameter("@dien_thoai",cb.dien_thoai),
                 new SqlParameter("@fax",cb.fax),
                 new SqlParameter("@mat_khau",cb.mat_khau),
                 new SqlParameter("@danh_xung",cb.danh_xung),
                 new SqlParameter("@ma_pb",cb.ma_pb),
                 new SqlParameter("@kich_hoat",cb.kich_hoat)
             };
            int count = db.cmdExecNonQueryProc("Them_CBTD", Params);
            return count > 0;
        }

        public bool Capnhat_CBTD(Canbotindung cb, string ten_dang_nhap)
        {
            SqlParameter[] Params = new SqlParameter[] 
            {
                 new SqlParameter("@ma_cn", cb.ma_cn),
                 new SqlParameter("@ma_pgd", cb.ma_pgd),
                 new SqlParameter("@ten_dang_nhap", ten_dang_nhap),
                 new SqlParameter("@ho_ten",cb.ho_ten),
                 new SqlParameter("@chuc_vu",cb.chuc_vu),
                 new SqlParameter("@giay_uy_quyen",cb.giay_uy_quyen),
                 new SqlParameter("@dien_thoai",cb.dien_thoai),
                 new SqlParameter("@fax",cb.fax),
                 new SqlParameter("@mat_khau",cb.mat_khau),
                 new SqlParameter("@danh_xung",cb.danh_xung),
                 new SqlParameter("@ma_pb",cb.ma_pb),
                 new SqlParameter("@kich_hoat",cb.kich_hoat)
             };
            int count = db.cmdExecNonQueryProc("Capnhat_CBTD", Params);
            return count > 0;
        }

        public bool Xoa_CBTD(string ten_dang_nhap)
        {
            SqlParameter[] Params = new SqlParameter[] 
            {
                 new SqlParameter("@ten_dang_nhap", ten_dang_nhap),
             };
            int count = db.cmdExecNonQueryProc("Xoa_CBTD", Params);
            return count > 0;
        }

        public bool Xac_thuc_dang_nhap(string ten_dang_nhap, string mat_khau)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
                new SqlParameter("@user_id", ten_dang_nhap),
                new SqlParameter("@user_pass", mat_khau)
            };

            DataTable dt = db.dt("XAC_THUC_USER", Params);

            return dt.Rows.Count > 0;
        }

        public bool DOI_MAT_KHAU_CBTD(string ten_dang_nhap, string mat_khau)
        {
            SqlParameter[] Params = new SqlParameter[] 
            {
                 new SqlParameter("@ten_dang_nhap", ten_dang_nhap),
                 new SqlParameter("@mat_khau", mat_khau)
             };
            int count = db.cmdExecNonQueryProc("DOI_MAT_KHAU_CBTD", Params);
            return count > 0;
        }
    }
}
