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
    class hopdongvayDAL
    {
        DataAccess db = new DataAccess();
        
        //List hợp đồng vay theo mã chi nhánh
        public static List<Hopdongvay> HD_VAY_theoma_CN(string ma_cn)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@ma_cn", ma_cn)
            };
            DataTable dt = db.dt("HD_VAY_theoma_CN", Params);

            List<Hopdongvay> list = new List<Hopdongvay>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Hopdongvay(row));
            }
            return list;
        }

        //List hợp đồng vay theo mã hợp đồng
        public static List<Hopdongvay> HD_VAY_theoma_HD(string ma_hd_vay, string ma_cn)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@ma_hd_vay", ma_hd_vay),
            new SqlParameter("@ma_cn", ma_cn)
            };
            DataTable dt = db.dt("HD_VAY_theoma_HD", Params);

            List<Hopdongvay> list = new List<Hopdongvay>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Hopdongvay(row));
            }
            return list;
        }
        //Hợp đồng vay theo mã hợp đồng

        //List hợp đồng vay theo mã khách hàng
        public static List<Hopdongvay> HD_VAY_theoma_KH(string ma_kh_vay, string ma_cn)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@ma_kh_vay", ma_kh_vay),
            new SqlParameter("@ma_cn", ma_cn)
            };
            DataTable dt = db.dt("HD_VAY_theoma_KH", Params);

            List<Hopdongvay> list = new List<Hopdongvay>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Hopdongvay(row));
            }
            return list;
        }
        //List hợp đồng vay theo mã chi nhánh và mã cán bộ tín dụng
        public static List<Hopdongvay> HD_VAY_theomaCN_va_CBTD(string can_bo_tin_dung, string ma_cn)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@can_bo_tin_dung", can_bo_tin_dung),
            new SqlParameter("@ma_cn", ma_cn)
            };
            DataTable dt = db.dt("HD_VAY_theoma_CN_va_CBTD", Params);

            List<Hopdongvay> list = new List<Hopdongvay>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Hopdongvay(row));
            }
            return list;
        }

        //List hợp đồng vay theo mã hợp đồng và cán bộ tín dụng
        public static List<Hopdongvay> HD_VAY_theoma_HD_va_CBTD(string ma_hd_vay, string ma_cn, string can_bo_tin_dung)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@ma_hd_vay", ma_hd_vay),
            new SqlParameter("@ma_cn", ma_cn),
            new SqlParameter("@can_bo_tin_dung", can_bo_tin_dung)
            };
            DataTable dt = db.dt("HD_VAY_theoma_HD_va_CBTD", Params);

            List<Hopdongvay> list = new List<Hopdongvay>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Hopdongvay(row));
            }
            return list;
        }

        //List hợp đồng vay theo mã khách hàng và cán bộ tín dụng
        public static List<Hopdongvay> HD_VAY_theoma_KH_va_CBTD(string ma_kh_vay, string ma_cn, string can_bo_tin_dung)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@ma_kh_vay", ma_kh_vay),
            new SqlParameter("@ma_cn", ma_cn),
            new SqlParameter("@can_bo_tin_dung", can_bo_tin_dung)
            };
            DataTable dt = db.dt("HD_VAY_theoma_KH_va_CBTD", Params);

            List<Hopdongvay> list = new List<Hopdongvay>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Hopdongvay(row));
            }
            return list;
        }

        public bool THEM_HD_VAY(Hopdongvay hd)
        {
            SqlParameter[] Params = new SqlParameter[] 
            {
                new SqlParameter("@ma_hd_vay", hd.ma_hd_vay),
                new SqlParameter("@ma_cn", hd.ma_cn),
                new SqlParameter("@ma_kh_vay", hd.ma_kh_vay),
                new SqlParameter("@phuong_thuc", hd.phuong_thuc),
                new SqlParameter("@tong_han_muc_tin_dung", hd.tong_han_muc_tin_dung),
                new SqlParameter("@han_muc_tin_dung", hd.han_muc_tin_dung),
                new SqlParameter("@han_muc_bao_lanh", hd.han_muc_bao_lanh),
                new SqlParameter("@muc_dich_vay", hd.muc_dich_vay),
                new SqlParameter("@lai_suat", hd.lai_suat),
                new SqlParameter("@phuong_thuc_tra_lai", hd.phuong_thuc_tra_lai),
                new SqlParameter("@phuong_thuc_tra_goc", hd.phuong_thuc_tra_goc),
                new SqlParameter("@thoi_han_vay", hd.thoi_han_vay),
                new SqlParameter("@han_tra_no_cuoi", hd.han_tra_no_cuoi),
                new SqlParameter("@thoi_han_rut_von", hd.thoi_han_rut_von),
                new SqlParameter("@thoi_gian_an_han", hd.thoi_gian_an_han),
                new SqlParameter("@bao_dam_tien_vay", hd.bao_dam_tien_vay),
                new SqlParameter("@hinh_thuc_bao_dam", hd.hinh_thuc_bao_dam),
                new SqlParameter("@tai_san_bao_dam", hd.tai_san_bao_dam),
                new SqlParameter("@gia_tri_tai_san_bao_dam", hd.gia_tri_tai_san_bao_dam),
                new SqlParameter("@dai_dien_agribank", hd.dai_dien_agribank),
                new SqlParameter("@kiem_soat_tin_dung", hd.kiem_soat_tin_dung),
                new SqlParameter("@can_bo_tin_dung", hd.can_bo_tin_dung),
                new SqlParameter("@ma_hd_vay_cu", hd.ma_hd_vay_cu),
                new SqlParameter("@ngay_hd_vay_cu", hd.ngay_hd_vay_cu),
                new SqlParameter("@ngay_hd_vay", hd.ngay_hd_vay)
             };
            int count = db.cmdExecNonQueryProc("THEM_HD_VAY", Params);
            return count > 0;
        }

        public bool CAP_NHAT_HD_VAY(Hopdongvay hd)
        {
            SqlParameter[] Params = new SqlParameter[] 
            {
                new SqlParameter("@ma_hd_vay", hd.ma_hd_vay),
                //new SqlParameter("@ma_cn", hd.ma_cn),
                //new SqlParameter("@ma_kh_vay", hd.ma_kh_vay),
                new SqlParameter("@phuong_thuc", hd.phuong_thuc),
                new SqlParameter("@tong_han_muc_tin_dung", hd.tong_han_muc_tin_dung),
                new SqlParameter("@han_muc_tin_dung", hd.han_muc_tin_dung),
                new SqlParameter("@han_muc_bao_lanh", hd.han_muc_bao_lanh),
                new SqlParameter("@muc_dich_vay", hd.muc_dich_vay),
                new SqlParameter("@lai_suat", hd.lai_suat),
                new SqlParameter("@phuong_thuc_tra_lai", hd.phuong_thuc_tra_lai),
                new SqlParameter("@phuong_thuc_tra_goc", hd.phuong_thuc_tra_goc),
                new SqlParameter("@thoi_han_vay", hd.thoi_han_vay),
                new SqlParameter("@han_tra_no_cuoi", hd.han_tra_no_cuoi),
                new SqlParameter("@thoi_han_rut_von", hd.thoi_han_rut_von),
                new SqlParameter("@thoi_gian_an_han", hd.thoi_gian_an_han),
                new SqlParameter("@bao_dam_tien_vay", hd.bao_dam_tien_vay),
                new SqlParameter("@hinh_thuc_bao_dam", hd.hinh_thuc_bao_dam),
                new SqlParameter("@tai_san_bao_dam", hd.tai_san_bao_dam),
                new SqlParameter("@gia_tri_tai_san_bao_dam", hd.gia_tri_tai_san_bao_dam),
                new SqlParameter("@dai_dien_agribank", hd.dai_dien_agribank),
                new SqlParameter("@kiem_soat_tin_dung", hd.kiem_soat_tin_dung),
                new SqlParameter("@can_bo_tin_dung", hd.can_bo_tin_dung),
                new SqlParameter("@ma_hd_vay_cu", hd.ma_hd_vay_cu),
                new SqlParameter("@ngay_hd_vay_cu", hd.ngay_hd_vay_cu),
                new SqlParameter("@ngay_hd_vay", hd.ngay_hd_vay)
             };
            int count = db.cmdExecNonQueryProc("CAP_NHAT_HD_VAY", Params);
            return count > 0;
        }

        public bool CAP_NHAT_NGAY_HD_VAY(string ma_hd_vay, string ngay_hd_vay)
        {
            SqlParameter[] Params = new SqlParameter[] 
            {
                new SqlParameter("@ma_hd_vay", ma_hd_vay),
                new SqlParameter("@ngay_hd_vay", ngay_hd_vay)
             };
            int count = db.cmdExecNonQueryProc("CAP_NHAT_NGAY_HD_VAY", Params);
            return count > 0;
        }

        public bool XOA_HD_VAY(string ma_hd_vay, string ma_cn)
        {
            SqlParameter[] Params = new SqlParameter[] 
            {
                 new SqlParameter("@ma_hd_vay", ma_hd_vay),
                 new SqlParameter("@ma_cn", ma_cn),
             };
            int count = db.cmdExecNonQueryProc("XOA_HD_VAY", Params);
            return count > 0;
        }

        public bool XOA_HD_VAY_THEO_MA_KH(string ma_kh_vay)
        {
            SqlParameter[] Params = new SqlParameter[] 
            {
                 new SqlParameter("@ma_kh_vay", ma_kh_vay),
             };
            int count = db.cmdExecNonQueryProc("XOA_HD_VAY_THEO_MA_KH", Params);
            return count > 0;
        }

        public bool Kiem_tra_trung_ma_hd(string ma_hd_vay)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@ma_hd_vay", ma_hd_vay)
            };

            DataTable dt = db.dt("HD_VAY_theoma_HD_check", Params);

            return dt.Rows.Count > 0;
        }

        public static DataTable HD_VAY_MACN(string ma_cn, string loai_kh)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
                {
                new SqlParameter("@ma_cn", ma_cn),
                new SqlParameter("@loai_kh", loai_kh)
                };
            DataTable dt = db.dt("HD_VAY_MACN", Params);
            return dt;
        }

        public static DataTable HD_VAY_MACN_CBTD(string ma_cn, string loai_kh, string can_bo_tin_dung)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
                {
                new SqlParameter("@ma_cn", ma_cn),
                new SqlParameter("@loai_kh", loai_kh),
                new SqlParameter("@can_bo_tin_dung", can_bo_tin_dung)
                };
            DataTable dt = db.dt("HD_VAY_MACN_CBTD", Params);
            return dt;
        }

        public static DataTable HD_VAY_MAHD(string ma_cn, string loai_kh, string ma_hd_vay)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
                {
                new SqlParameter("@ma_cn", ma_cn),
                new SqlParameter("@loai_kh", loai_kh),
                new SqlParameter("@ma_hd_vay", ma_hd_vay)
                };
            DataTable dt = db.dt("HD_VAY_MAHD", Params);
            return dt;
        }

        public static DataTable HD_VAY_MAHD_CBTD(string ma_cn, string loai_kh, string ma_hd_vay, string can_bo_tin_dung)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
                {
                new SqlParameter("@ma_cn", ma_cn),
                new SqlParameter("@loai_kh", loai_kh),
                new SqlParameter("@ma_hd_vay", ma_hd_vay),
                new SqlParameter("@can_bo_tin_dung", can_bo_tin_dung)
                };
            DataTable dt = db.dt("HD_VAY_MAHD_CBTD", Params);
            return dt;
        }

        public static DataTable HD_VAY_MAKH(string ma_cn, string loai_kh, string ma_kh_vay)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
                {
                new SqlParameter("@ma_cn", ma_cn),
                new SqlParameter("@loai_kh", loai_kh),
                new SqlParameter("@ma_kh_vay", ma_kh_vay)
                };
            DataTable dt = db.dt("HD_VAY_MAKH", Params);
            return dt;
        }

        public static DataTable HD_VAY_MAKH_CBTD(string ma_cn, string loai_kh, string ma_kh_vay, string can_bo_tin_dung)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
                {
                new SqlParameter("@ma_cn", ma_cn),
                new SqlParameter("@loai_kh", loai_kh),
                new SqlParameter("@ma_kh_vay", ma_kh_vay),
                new SqlParameter("@can_bo_tin_dung", can_bo_tin_dung)
                };
            DataTable dt = db.dt("HD_VAY_MAKH_CBTD", Params);
            return dt;
        }

        public static DataTable HD_VAY_TENKH_CN(string ma_cn, string loai_kh, string tenkh)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
                {
                new SqlParameter("@ma_cn", ma_cn),
                new SqlParameter("@loai_kh", loai_kh),
                new SqlParameter("@tenkh", tenkh)
                };
            DataTable dt = db.dt("HD_VAY_TENKH_CN", Params);
            return dt;
        }

        public static DataTable HD_VAY_TENKH_CN_CBTD(string ma_cn, string loai_kh, string tenkh, string can_bo_tin_dung)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
                {
                new SqlParameter("@ma_cn", ma_cn),
                new SqlParameter("@loai_kh", loai_kh),
                new SqlParameter("@tenkh", tenkh),
                new SqlParameter("@can_bo_tin_dung", can_bo_tin_dung)
                };
            DataTable dt = db.dt("HD_VAY_TENKH_CN_CBTD", Params);
            return dt;
        }

        public static DataTable HD_VAY_TENKH_TC(string ma_cn, string loai_kh, string tenkh)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
                {
                new SqlParameter("@ma_cn", ma_cn),
                new SqlParameter("@loai_kh", loai_kh),
                new SqlParameter("@tenkh", tenkh)
                };
            DataTable dt = db.dt("HD_VAY_TENKH_TC", Params);
            return dt;
        }

        public static DataTable HD_VAY_TENKH_TC_CBTD(string ma_cn, string loai_kh, string tenkh, string can_bo_tin_dung)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
                {
                new SqlParameter("@ma_cn", ma_cn),
                new SqlParameter("@loai_kh", loai_kh),
                new SqlParameter("@tenkh", tenkh),
                new SqlParameter("@can_bo_tin_dung", can_bo_tin_dung)
                };
            DataTable dt = db.dt("HD_VAY_TENKH_TC_CBTD", Params);
            return dt;
        }

        public static DataTable HD_VAY_TENKH_HGD(string ma_cn, string loai_kh, string tenkh)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
                {
                new SqlParameter("@ma_cn", ma_cn),
                new SqlParameter("@loai_kh", loai_kh),
                new SqlParameter("@tenkh", tenkh)
                };
            DataTable dt = db.dt("HD_VAY_TENKH_HGD", Params);
            return dt;
        }

        public static DataTable HD_VAY_TENKH_HGD_CBTD(string ma_cn, string loai_kh, string tenkh, string can_bo_tin_dung)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
                {
                new SqlParameter("@ma_cn", ma_cn),
                new SqlParameter("@loai_kh", loai_kh),
                new SqlParameter("@tenkh", tenkh),
                new SqlParameter("@can_bo_tin_dung", can_bo_tin_dung)
                };
            DataTable dt = db.dt("HD_VAY_TENKH_HGD_CBTD", Params);
            return dt;
        }

        public static DataTable HD_VAY_CMT_CN(string ma_cn, string loai_kh, string cmnd)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
                {
                new SqlParameter("@ma_cn", ma_cn),
                new SqlParameter("@loai_kh", loai_kh),
                new SqlParameter("@cmnd", cmnd)
                };
            DataTable dt = db.dt("HD_VAY_CMT_CN", Params);
            return dt;
        }

        public static DataTable HD_VAY_CMT_CN_CBTD(string ma_cn, string loai_kh, string cmnd, string can_bo_tin_dung)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
                {
                new SqlParameter("@ma_cn", ma_cn),
                new SqlParameter("@loai_kh", loai_kh),
                new SqlParameter("@cmnd", cmnd),
                new SqlParameter("@can_bo_tin_dung", can_bo_tin_dung)
                };
            DataTable dt = db.dt("HD_VAY_CMT_CN_CBTD", Params);
            return dt;
        }

        public static DataTable HD_VAY_CMT_TC(string ma_cn, string loai_kh, string cmnd)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
                {
                new SqlParameter("@ma_cn", ma_cn),
                new SqlParameter("@loai_kh", loai_kh),
                new SqlParameter("@cmnd", cmnd)
                };
            DataTable dt = db.dt("HD_VAY_CMT_TC", Params);
            return dt;
        }

        public static DataTable HD_VAY_CMT_TC_CBTD(string ma_cn, string loai_kh, string cmnd, string can_bo_tin_dung)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
                {
                new SqlParameter("@ma_cn", ma_cn),
                new SqlParameter("@loai_kh", loai_kh),
                new SqlParameter("@cmnd", cmnd),
                new SqlParameter("@can_bo_tin_dung", can_bo_tin_dung)
                };
            DataTable dt = db.dt("HD_VAY_CMT_TC_CBTD", Params);
            return dt;
        }

        public static DataTable HD_VAY_CMT_HGD(string ma_cn, string loai_kh, string cmnd)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
                {
                new SqlParameter("@ma_cn", ma_cn),
                new SqlParameter("@loai_kh", loai_kh),
                new SqlParameter("@cmnd", cmnd)
                };
            DataTable dt = db.dt("HD_VAY_CMT_HGD", Params);
            return dt;
        }

        public static DataTable HD_VAY_CMT_HGD_CBTD(string ma_cn, string loai_kh, string cmnd, string can_bo_tin_dung)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
                {
                new SqlParameter("@ma_cn", ma_cn),
                new SqlParameter("@loai_kh", loai_kh),
                new SqlParameter("@cmnd", cmnd),
                new SqlParameter("@can_bo_tin_dung", can_bo_tin_dung)
                };
            DataTable dt = db.dt("HD_VAY_CMT_HGD_CBTD", Params);
            return dt;
        }

        public static DataTable HD_VAY_MACN_MAPB(string ma_cn, string loai_kh, string ma_pb)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
                {
                new SqlParameter("@ma_cn", ma_cn),
                new SqlParameter("@loai_kh", loai_kh),
                new SqlParameter("@ma_pb", ma_pb)
                };
            DataTable dt = db.dt("HD_VAY_MACN_MAPB", Params);
            return dt;
        }

        public static DataTable HD_VAY_MAHD_MAPB(string ma_cn, string loai_kh, string ma_hd_vay, string ma_pb)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
                {
                new SqlParameter("@ma_cn", ma_cn),
                new SqlParameter("@loai_kh", loai_kh),
                new SqlParameter("@ma_hd_vay", ma_hd_vay),
                new SqlParameter("@ma_pb", ma_pb)
                };
            DataTable dt = db.dt("HD_VAY_MAHD_MAPB", Params);
            return dt;
        }

        public static DataTable HD_VAY_MAKH_MAPB(string ma_cn, string loai_kh, string ma_kh_vay, string ma_pb)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
                {
                new SqlParameter("@ma_cn", ma_cn),
                new SqlParameter("@loai_kh", loai_kh),
                new SqlParameter("@ma_kh_vay", ma_kh_vay),
                new SqlParameter("@ma_pb", ma_pb)
                };
            DataTable dt = db.dt("HD_VAY_MAKH_MAPB", Params);
            return dt;
        }

        public static DataTable HD_VAY_TENKH_CN_MAPB(string ma_cn, string loai_kh, string tenkh, string ma_pb)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
                {
                new SqlParameter("@ma_cn", ma_cn),
                new SqlParameter("@loai_kh", loai_kh),
                new SqlParameter("@tenkh", tenkh),
                new SqlParameter("@ma_pb", ma_pb)
                };
            DataTable dt = db.dt("HD_VAY_TENKH_CN_MAPB", Params);
            return dt;
        }

        public static DataTable HD_VAY_TENKH_TC_MAPB(string ma_cn, string loai_kh, string tenkh, string ma_pb)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
                {
                new SqlParameter("@ma_cn", ma_cn),
                new SqlParameter("@loai_kh", loai_kh),
                new SqlParameter("@tenkh", tenkh),
                new SqlParameter("@ma_pb", ma_pb)
                };
            DataTable dt = db.dt("HD_VAY_TENKH_TC_MAPB", Params);
            return dt;
        }

        public static DataTable HD_VAY_TENKH_HGD_MAPB(string ma_cn, string loai_kh, string tenkh, string ma_pb)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
                {
                new SqlParameter("@ma_cn", ma_cn),
                new SqlParameter("@loai_kh", loai_kh),
                new SqlParameter("@tenkh", tenkh),
                new SqlParameter("@ma_pb", ma_pb)
                };
            DataTable dt = db.dt("HD_VAY_TENKH_HGD_MAPB", Params);
            return dt;
        }

        public static DataTable HD_VAY_CMT_CN_MAPB(string ma_cn, string loai_kh, string cmnd, string ma_pb)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
                {
                new SqlParameter("@ma_cn", ma_cn),
                new SqlParameter("@loai_kh", loai_kh),
                new SqlParameter("@cmnd", cmnd),
                new SqlParameter("@ma_pb", ma_pb)
                };
            DataTable dt = db.dt("HD_VAY_CMT_CN_MAPB", Params);
            return dt;
        }

        public static DataTable HD_VAY_CMT_TC_MAPB(string ma_cn, string loai_kh, string cmnd, string ma_pb)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
                {
                new SqlParameter("@ma_cn", ma_cn),
                new SqlParameter("@loai_kh", loai_kh),
                new SqlParameter("@cmnd", cmnd),
                new SqlParameter("@ma_pb", ma_pb)
                };
            DataTable dt = db.dt("HD_VAY_CMT_TC_MAPB", Params);
            return dt;
        }

        public static DataTable HD_VAY_CMT_HGD_MAPB(string ma_cn, string loai_kh, string cmnd, string ma_pb)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
                {
                new SqlParameter("@ma_cn", ma_cn),
                new SqlParameter("@loai_kh", loai_kh),
                new SqlParameter("@cmnd", cmnd),
                new SqlParameter("@ma_pb", ma_pb)
                };
            DataTable dt = db.dt("HD_VAY_CMT_HGD_MAPB", Params);
            return dt;
        }
    }
}
