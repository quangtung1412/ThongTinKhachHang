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
    class giaynhannoDAL
    {
        DataAccess db = new DataAccess();

        public bool THEM_GIAY_NHAN_NO(Giaynhanno gnn)
        {
            SqlParameter[] Params = new SqlParameter[] 
            {
                //new SqlParameter("@id_giay_nhan_no",gnn.id_giay_nhan_no),
                new SqlParameter("@ma_hd_vay",gnn.ma_hd_vay),
                new SqlParameter("@ngay_nhan_no",gnn.ngay_nhan_no),
                new SqlParameter("@du_no_truoc",gnn.du_no_truoc),
                new SqlParameter("@so_tien_nhan_no",gnn.so_tien_nhan_no),
                new SqlParameter("@du_no_hien_tai",gnn.du_no_hien_tai),
                new SqlParameter("@nguoi_thu_huong_1",gnn.nguoi_thu_huong_1),
                new SqlParameter("@so_tai_khoan_1",gnn.so_tai_khoan_1),
                new SqlParameter("@ngan_hang_1",gnn.ngan_hang_1),
                new SqlParameter("@so_tien_nhan_no_1",gnn.so_tien_nhan_no_1),
                new SqlParameter("@nguoi_thu_huong_2",gnn.nguoi_thu_huong_2),
                new SqlParameter("@so_tai_khoan_2",gnn.so_tai_khoan_2),
                new SqlParameter("@ngan_hang_2",gnn.ngan_hang_2),
                new SqlParameter("@so_tien_nhan_no_2",gnn.so_tien_nhan_no_2),
                new SqlParameter("@nguoi_thu_huong_3",gnn.nguoi_thu_huong_3),
                new SqlParameter("@so_tai_khoan_3",gnn.so_tai_khoan_3),
                new SqlParameter("@ngan_hang_3",gnn.ngan_hang_3),
                new SqlParameter("@so_tien_nhan_no_3",gnn.so_tien_nhan_no_3),
                new SqlParameter("@so_giay_nhan_no",gnn.so_giay_nhan_no),
                new SqlParameter("@han_tra_no_goc",gnn.han_tra_no_goc),
                new SqlParameter("@muc_dich_su_dung_tien_vay",gnn.muc_dich_su_dung_tien_vay),
                new SqlParameter("@chung_tu_giai_ngan",gnn.chung_tu_giai_ngan),
                new SqlParameter("@ngay_de_xuat_giai_ngan",gnn.ngay_de_xuat_giai_ngan)
             };
            int count = db.cmdExecNonQueryProc("THEM_GIAY_NHAN_NO", Params);
            return count > 0;
        }

        public bool CAP_NHAT_GIAY_NHAN_NO(Giaynhanno gnn)
        {
            SqlParameter[] Params = new SqlParameter[] 
            {
                new SqlParameter("@id_giay_nhan_no",gnn.id_giay_nhan_no),
                new SqlParameter("@ngay_nhan_no",gnn.ngay_nhan_no),
                new SqlParameter("@du_no_truoc",gnn.du_no_truoc),
                new SqlParameter("@so_tien_nhan_no",gnn.so_tien_nhan_no),
                new SqlParameter("@du_no_hien_tai",gnn.du_no_hien_tai),
                new SqlParameter("@nguoi_thu_huong_1",gnn.nguoi_thu_huong_1),
                new SqlParameter("@so_tai_khoan_1",gnn.so_tai_khoan_1),
                new SqlParameter("@ngan_hang_1",gnn.ngan_hang_1),
                new SqlParameter("@so_tien_nhan_no_1",gnn.so_tien_nhan_no_1),
                new SqlParameter("@nguoi_thu_huong_2",gnn.nguoi_thu_huong_2),
                new SqlParameter("@so_tai_khoan_2",gnn.so_tai_khoan_2),
                new SqlParameter("@ngan_hang_2",gnn.ngan_hang_2),
                new SqlParameter("@so_tien_nhan_no_2",gnn.so_tien_nhan_no_2),
                new SqlParameter("@nguoi_thu_huong_3",gnn.nguoi_thu_huong_3),
                new SqlParameter("@so_tai_khoan_3",gnn.so_tai_khoan_3),
                new SqlParameter("@ngan_hang_3",gnn.ngan_hang_3),
                new SqlParameter("@so_tien_nhan_no_3",gnn.so_tien_nhan_no_3),
                new SqlParameter("@so_giay_nhan_no",gnn.so_giay_nhan_no),
                new SqlParameter("@han_tra_no_goc",gnn.han_tra_no_goc),
                new SqlParameter("@muc_dich_su_dung_tien_vay",gnn.muc_dich_su_dung_tien_vay),
                new SqlParameter("@chung_tu_giai_ngan",gnn.chung_tu_giai_ngan),
                new SqlParameter("@ngay_de_xuat_giai_ngan",gnn.ngay_de_xuat_giai_ngan)
             };
            int count = db.cmdExecNonQueryProc("CAP_NHAT_GIAY_NHAN_NO", Params);
            return count > 0;
        }
        public bool XOA_GIAY_NHAN_NO(Int32 id_giay_nhan_no)
        {
            SqlParameter[] Params = new SqlParameter[] 
            {
                new SqlParameter("@id_giay_nhan_no",id_giay_nhan_no)
            };
            int count = db.cmdExecNonQueryProc("XOA_GIAY_NHAN_NO", Params);
            return count > 0;
        }

        public static DataTable DS_GIAY_NHAN_NO_THEO_MA_HD_VAY(string ma_hd_vay)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
                new SqlParameter("@ma_hd_vay",ma_hd_vay)
            };
            DataTable dt = db.dt("DS_GIAY_NHAN_NO_THEO_MA_HD_VAY", Params);
            return dt;
        }

        public static Giaynhanno GIAY_NHAN_NO_THEO_ID(Int32 id_giay_nhan_no)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
                new SqlParameter("@id_giay_nhan_no",id_giay_nhan_no)
            };
            DataTable dt = db.dt("GIAY_NHAN_NO_THEO_ID", Params);
            string[] thong_tin_gnn = new string[23];
            thong_tin_gnn[0] = dt.Rows[0]["ID_GIAY_NHAN_NO"].ToString();
            thong_tin_gnn[1] = dt.Rows[0]["MA_HD_VAY"].ToString();
            thong_tin_gnn[2] = dt.Rows[0]["NGAY_NHAN_NO"].ToString();
            thong_tin_gnn[3] = dt.Rows[0]["DU_NO_TRUOC"].ToString();
            thong_tin_gnn[4] = dt.Rows[0]["SO_TIEN_NHAN_NO"].ToString();
            thong_tin_gnn[5] = dt.Rows[0]["DU_NO_HIEN_TAI"].ToString();
            thong_tin_gnn[6] = dt.Rows[0]["NGUOI_THU_HUONG_1"].ToString();
            thong_tin_gnn[7] = dt.Rows[0]["SO_TAI_KHOAN_1"].ToString();
            thong_tin_gnn[8] = dt.Rows[0]["NGAN_HANG_1"].ToString();
            thong_tin_gnn[9] = dt.Rows[0]["SO_TIEN_NHAN_NO_1"].ToString();
            thong_tin_gnn[10] = dt.Rows[0]["NGUOI_THU_HUONG_2"].ToString();
            thong_tin_gnn[11] = dt.Rows[0]["SO_TAI_KHOAN_2"].ToString();
            thong_tin_gnn[12] = dt.Rows[0]["NGAN_HANG_2"].ToString();
            thong_tin_gnn[13] = dt.Rows[0]["SO_TIEN_NHAN_NO_2"].ToString();
            thong_tin_gnn[14] = dt.Rows[0]["NGUOI_THU_HUONG_3"].ToString();
            thong_tin_gnn[15] = dt.Rows[0]["SO_TAI_KHOAN_3"].ToString();
            thong_tin_gnn[16] = dt.Rows[0]["NGAN_HANG_3"].ToString();
            thong_tin_gnn[17] = dt.Rows[0]["SO_TIEN_NHAN_NO_3"].ToString();
            thong_tin_gnn[18] = dt.Rows[0]["SO_GIAY_NHAN_NO"].ToString();
            thong_tin_gnn[19] = dt.Rows[0]["HAN_TRA_NO_GOC"].ToString();
            thong_tin_gnn[20] = dt.Rows[0]["MUC_DICH_SU_DUNG_TIEN_VAY"].ToString();
            thong_tin_gnn[21] = dt.Rows[0]["CHUNG_TU_GIAI_NGAN"].ToString();
            thong_tin_gnn[22] = dt.Rows[0]["NGAY_DE_XUAT_GIAI_NGAN"].ToString();
            Giaynhanno gnn = new Giaynhanno(thong_tin_gnn);
            return gnn;             
        }
    }
}
