using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AGRIBANKHD.Entities;
using AGRIBANKHD.DAL;

namespace AGRIBANKHD.BUS
{
    class KhachhangvayBUS
    {
        khachhangvayDAL dal = new khachhangvayDAL();

        public static DataTable DS_KH_VAY_THEO_MA(string ma_kh_vay)
        {
            return khachhangvayDAL.DS_KH_VAY_THEO_MA(ma_kh_vay);
        }

        public static DataTable CN_DS_KH_VAY(string ma_cn, string loai_kh)
        {
            return khachhangvayDAL.CN_DS_KH_VAY(ma_cn, loai_kh);
        }

        public static DataTable CN_DS_KH_VAY_THEO_MA(string ma_cn, string loai_kh, string ma_kh_vay)
        {
            return khachhangvayDAL.CN_DS_KH_VAY_THEO_MA(ma_cn, loai_kh, ma_kh_vay);
        }

        public static DataTable CN_DS_KH_VAY_THEO_TEN(string ma_cn, string loai_kh, string cn_ten)
        {
            return khachhangvayDAL.CN_DS_KH_VAY_THEO_TEN(ma_cn, loai_kh, cn_ten);
        }

        public static DataTable CN_DS_KH_VAY_THEO_CMND(string ma_cn, string loai_kh, string cn_cmnd)
        {
            return khachhangvayDAL.CN_DS_KH_VAY_THEO_CMND(ma_cn, loai_kh, cn_cmnd);
        }


        //----------------------Hộ gia đình----------------------------------------------------------

        public static DataTable HGD_DS_KH_VAY(string ma_cn, string loai_kh)
        {
            return khachhangvayDAL.HGD_DS_KH_VAY(ma_cn, loai_kh);
        }

        public static DataTable HGD_DS_KH_VAY_THEO_MA(string ma_cn, string loai_kh, string ma_kh_vay)
        {
            return khachhangvayDAL.HGD_DS_KH_VAY_THEO_MA(ma_cn, loai_kh, ma_kh_vay);
        }

        public static DataTable HGD_DS_KH_VAY_THEO_TEN_CHONG(string ma_cn, string loai_kh, string hgd_ten_chong)
        {
            return khachhangvayDAL.HGD_DS_KH_VAY_THEO_TEN_CHONG(ma_cn, loai_kh, hgd_ten_chong);
        }

        public static DataTable HGD_DS_KH_VAY_THEO_TEN_VO(string ma_cn, string loai_kh, string hgd_ten_vo)
        {
            return khachhangvayDAL.HGD_DS_KH_VAY_THEO_TEN_VO(ma_cn, loai_kh, hgd_ten_vo);
        }

        public static DataTable HGD_DS_KH_VAY_THEO_CMND_CHONG(string ma_cn, string loai_kh, string hgd_cmnd_chong)
        {
            return khachhangvayDAL.HGD_DS_KH_VAY_THEO_CMND_CHONG(ma_cn, loai_kh, hgd_cmnd_chong);
        }

        public static DataTable HGD_DS_KH_VAY_THEO_CMND_VO(string ma_cn, string loai_kh, string hgd_cmnd_vo)
        {
            return khachhangvayDAL.HGD_DS_KH_VAY_THEO_CMND_VO(ma_cn, loai_kh, hgd_cmnd_vo);
        }

        //--------------------------Tổ chức-------------------------------------------------------

        public static DataTable TC_DS_KH_VAY(string ma_cn, string loai_kh)
        {
            return khachhangvayDAL.TC_DS_KH_VAY(ma_cn, loai_kh);
        }

        public static DataTable TC_DS_KH_VAY_THEO_MA(string ma_cn, string loai_kh, string ma_kh_vay)
        {
            return khachhangvayDAL.TC_DS_KH_VAY_THEO_MA(ma_cn, loai_kh, ma_kh_vay);
        }

        public static DataTable TC_DS_KH_VAY_THEO_TEN(string ma_cn, string loai_kh, string tc_ten)
        {
            return khachhangvayDAL.TC_DS_KH_VAY_THEO_TEN(ma_cn, loai_kh, tc_ten);
        }

        public static DataTable TC_DS_KH_VAY_THEO_TEN_DAI_DIEN(string ma_cn, string loai_kh, string tc_dai_dien)
        {
            return khachhangvayDAL.TC_DS_KH_VAY_THEO_TEN_DAI_DIEN(ma_cn, loai_kh, tc_dai_dien);
        }

        public static DataTable TC_DS_KH_VAY_THEO_CMND_DAI_DIEN(string ma_cn, string loai_kh, string tc_cmnd_dai_dien)
        {
            return khachhangvayDAL.TC_DS_KH_VAY_THEO_CMND_DAI_DIEN(ma_cn, loai_kh, tc_cmnd_dai_dien);
        }

        //-----------------------Thêm/Sửa/Xóa-------------------------------------------------
        public bool THEM_KH_VAY(Khachhangvay kh)
        {
            return dal.THEM_KH_VAY(kh);
        }

        public bool CAP_NHAT_KH_VAY(Khachhangvay kh, string ma_kh_vay)
        {
            return dal.CAP_NHAT_KH_VAY(kh, ma_kh_vay);
        }

        public bool XOA_KH_VAY(string ma_kh_vay)
        {
            return dal.XOA_KH_VAY(ma_kh_vay);
        }

        public bool KIEM_TRA_TRUNG_MA_KH(string ma_kh_vay)
        {
            return dal.KIEM_TRA_TRUNG_MA_KH(ma_kh_vay);
        }

    }
}
