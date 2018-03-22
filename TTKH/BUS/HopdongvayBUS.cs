using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGRIBANKHD.Entities;
using AGRIBANKHD.DAL;
using System.Data;

namespace AGRIBANKHD.BUS
{
    class HopdongvayBUS
    {
        hopdongvayDAL dal = new hopdongvayDAL();

        public static List<Hopdongvay> HD_VAY_theoma_CN(string ma_cn)
        {
            return hopdongvayDAL.HD_VAY_theoma_CN(ma_cn);
        }

        public static List<Hopdongvay> HD_VAY_theoma_HD(string ma_hd_vay, string ma_cn)
        {
            return hopdongvayDAL.HD_VAY_theoma_HD(ma_hd_vay, ma_cn);
        }

        public static List<Hopdongvay> HD_VAY_theoma_KH(string ma_kh_vay, string ma_cn)
        {
            return hopdongvayDAL.HD_VAY_theoma_KH(ma_kh_vay, ma_cn);
        }

        //List hợp đồng vay theo mã chi nhánh và mã cán bộ tín dụng
        public static List<Hopdongvay> HD_VAY_theomaCN_va_CBTD(string can_bo_tin_dung, string ma_cn)
        {
            return hopdongvayDAL.HD_VAY_theomaCN_va_CBTD(can_bo_tin_dung, ma_cn);
        }

        //List hợp đồng vay theo mã hợp đồng và cán bộ tín dụng
        public static List<Hopdongvay> HD_VAY_theoma_HD_va_CBTD(string ma_hd_vay, string ma_cn, string can_bo_tin_dung)
        {
            return hopdongvayDAL.HD_VAY_theoma_HD_va_CBTD(ma_hd_vay, ma_cn, can_bo_tin_dung);
        }

        //List hợp đồng vay theo mã khách hàng và cán bộ tín dụng
        public static List<Hopdongvay> HD_VAY_theoma_KH_va_CBTD(string ma_kh_vay, string ma_cn, string can_bo_tin_dung)
        {
            return hopdongvayDAL.HD_VAY_theoma_KH_va_CBTD(ma_kh_vay,ma_cn,can_bo_tin_dung);
        }

        public bool THEM_HD_VAY(Hopdongvay hd)
        {
            return dal.THEM_HD_VAY(hd);
        }

        public bool CAP_NHAT_HD_VAY(Hopdongvay hd)
        {
            return dal.CAP_NHAT_HD_VAY(hd);
        }

        public bool CAP_NHAT_NGAY_HD_VAY(string ma_hd_vay, string ngay_hd_vay)
        {
            return dal.CAP_NHAT_NGAY_HD_VAY(ma_hd_vay, ngay_hd_vay);
        }

        public bool XOA_HD_VAY(string ma_hd_vay, string ma_cn)
        {
            return dal.XOA_HD_VAY(ma_hd_vay, ma_cn);
        }

        public bool XOA_HD_VAY_THEO_MA_KH(string ma_kh_vay)
        {
            return dal.XOA_HD_VAY_THEO_MA_KH(ma_kh_vay);
        }

        public bool Kiem_tra_trung_ma_hd(string ma_hd_vay)
        {
            return dal.Kiem_tra_trung_ma_hd(ma_hd_vay);
        }

        public static DataTable HD_VAY_MACN(string ma_cn, string loai_kh)
        {
            return hopdongvayDAL.HD_VAY_MACN(ma_cn, loai_kh);
        }

        public static DataTable HD_VAY_MACN_CBTD(string ma_cn, string loai_kh, string can_bo_tin_dung)
        {
            return hopdongvayDAL.HD_VAY_MACN_CBTD(ma_cn, loai_kh, can_bo_tin_dung);
        }

        public static DataTable HD_VAY_MAHD(string ma_cn, string loai_kh, string ma_hd_vay)
        {
            return hopdongvayDAL.HD_VAY_MAHD(ma_cn, loai_kh, ma_hd_vay);
        }

        public static DataTable HD_VAY_MAHD_CBTD(string ma_cn, string loai_kh, string ma_hd_vay, string can_bo_tin_dung)
        {
            return hopdongvayDAL.HD_VAY_MAHD_CBTD(ma_cn, loai_kh, ma_hd_vay, can_bo_tin_dung);
        }

        public static DataTable HD_VAY_MAKH(string ma_cn, string loai_kh, string ma_kh_vay)
        {
            return hopdongvayDAL.HD_VAY_MAKH(ma_cn, loai_kh, ma_kh_vay);
        }

        public static DataTable HD_VAY_MAKH_CBTD(string ma_cn, string loai_kh, string ma_kh_vay, string can_bo_tin_dung)
        {
            return hopdongvayDAL.HD_VAY_MAKH_CBTD(ma_cn, loai_kh, ma_kh_vay, can_bo_tin_dung);
        }

        public static DataTable HD_VAY_TENKH_CN(string ma_cn, string loai_kh, string tenkh)
        {
            return hopdongvayDAL.HD_VAY_TENKH_CN(ma_cn, loai_kh, tenkh);
        }

        public static DataTable HD_VAY_TENKH_CN_CBTD(string ma_cn, string loai_kh, string tenkh, string can_bo_tin_dung)
        {
            return hopdongvayDAL.HD_VAY_TENKH_CN_CBTD(ma_cn, loai_kh, tenkh, can_bo_tin_dung);
        }

        public static DataTable HD_VAY_TENKH_TC(string ma_cn, string loai_kh, string tenkh)
        {
            return hopdongvayDAL.HD_VAY_TENKH_TC(ma_cn, loai_kh, tenkh);
        }

        public static DataTable HD_VAY_TENKH_TC_CBTD(string ma_cn, string loai_kh, string tenkh, string can_bo_tin_dung)
        {
            return hopdongvayDAL.HD_VAY_TENKH_TC_CBTD(ma_cn, loai_kh, tenkh, can_bo_tin_dung);
        }

        public static DataTable HD_VAY_TENKH_HGD(string ma_cn, string loai_kh, string tenkh)
        {
            return hopdongvayDAL.HD_VAY_TENKH_HGD(ma_cn, loai_kh, tenkh);
        }

        public static DataTable HD_VAY_TENKH_HGD_CBTD(string ma_cn, string loai_kh, string tenkh, string can_bo_tin_dung)
        {
            return hopdongvayDAL.HD_VAY_TENKH_HGD_CBTD(ma_cn, loai_kh, tenkh, can_bo_tin_dung);
        }

        public static DataTable HD_VAY_CMT_CN(string ma_cn, string loai_kh, string cmnd)
        {
            return hopdongvayDAL.HD_VAY_CMT_CN(ma_cn, loai_kh, cmnd);
        }

        public static DataTable HD_VAY_CMT_CN_CBTD(string ma_cn, string loai_kh, string cmnd, string can_bo_tin_dung)
        {
            return hopdongvayDAL.HD_VAY_CMT_CN_CBTD(ma_cn, loai_kh, cmnd, can_bo_tin_dung);
        }

        public static DataTable HD_VAY_CMT_TC(string ma_cn, string loai_kh, string cmnd)
        {
            return hopdongvayDAL.HD_VAY_CMT_TC(ma_cn, loai_kh, cmnd);
        }

        public static DataTable HD_VAY_CMT_TC_CBTD(string ma_cn, string loai_kh, string cmnd, string can_bo_tin_dung)
        {
            return hopdongvayDAL.HD_VAY_CMT_TC_CBTD(ma_cn, loai_kh, cmnd, can_bo_tin_dung);
        }

        public static DataTable HD_VAY_CMT_HGD(string ma_cn, string loai_kh, string cmnd)
        {
            return hopdongvayDAL.HD_VAY_CMT_HGD(ma_cn, loai_kh, cmnd);
        }

        public static DataTable HD_VAY_CMT_HGD_CBTD(string ma_cn, string loai_kh, string cmnd, string can_bo_tin_dung)
        {
            return hopdongvayDAL.HD_VAY_CMT_HGD_CBTD(ma_cn, loai_kh, cmnd, can_bo_tin_dung);
        }

        public static DataTable HD_VAY_MACN_MAPB(string ma_cn, string loai_kh, string ma_pb)
        {
            return hopdongvayDAL.HD_VAY_MACN_MAPB(ma_cn, loai_kh, ma_pb);
        }

        public static DataTable HD_VAY_MAHD_MAPB(string ma_cn, string loai_kh, string ma_hd_vay, string ma_pb)
        {
            return hopdongvayDAL.HD_VAY_MAHD_MAPB(ma_cn, loai_kh, ma_hd_vay, ma_pb);
        }

        public static DataTable HD_VAY_MAKH_MAPB(string ma_cn, string loai_kh, string ma_kh_vay, string ma_pb)
        {
            return hopdongvayDAL.HD_VAY_MAKH_MAPB(ma_cn, loai_kh, ma_kh_vay, ma_pb);
        }

        public static DataTable HD_VAY_TENKH_CN_MAPB(string ma_cn, string loai_kh, string tenkh, string ma_pb)
        {
            return hopdongvayDAL.HD_VAY_TENKH_CN_MAPB(ma_cn, loai_kh, tenkh, ma_pb);
        }

        public static DataTable HD_VAY_TENKH_TC_MAPB(string ma_cn, string loai_kh, string tenkh, string ma_pb)
        {
            return hopdongvayDAL.HD_VAY_TENKH_TC_MAPB(ma_cn, loai_kh, tenkh, ma_pb);
        }

        public static DataTable HD_VAY_TENKH_HGD_MAPB(string ma_cn, string loai_kh, string tenkh, string ma_pb)
        {
            return hopdongvayDAL.HD_VAY_TENKH_HGD_MAPB(ma_cn, loai_kh, tenkh, ma_pb);
        }

        public static DataTable HD_VAY_CMT_CN_MAPB(string ma_cn, string loai_kh, string cmnd, string ma_pb)
        {
            return hopdongvayDAL.HD_VAY_CMT_CN_MAPB(ma_cn, loai_kh, cmnd, ma_pb);
        }

        public static DataTable HD_VAY_CMT_TC_MAPB(string ma_cn, string loai_kh, string cmnd, string ma_pb)
        {
            return hopdongvayDAL.HD_VAY_CMT_TC_MAPB(ma_cn, loai_kh, cmnd, ma_pb);
        }

        public static DataTable HD_VAY_CMT_HGD_MAPB(string ma_cn, string loai_kh, string cmnd, string ma_pb)
        {
            return hopdongvayDAL.HD_VAY_CMT_TC_MAPB(ma_cn, loai_kh, cmnd, ma_pb);
        }
    }
}
