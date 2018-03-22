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
    class khachhangvayDAL
    {
        DataAccess db = new DataAccess();

        //------------------------Chung----------------------------------------------------
        public static DataTable DS_KH_VAY_THEO_MA(string ma_kh_vay)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@ma_kh_vay", ma_kh_vay),
            
            };
            DataTable dt = db.dt("DS_KH_VAY_THEO_MA", Params);

            return dt;
        }
        
        //------------------------Cá nhân----------------------------------------------------
        public static DataTable CN_DS_KH_VAY(string ma_cn, string loai_kh)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@ma_cn", ma_cn),
            new SqlParameter("@loai_kh",loai_kh)
            };
            DataTable dt = db.dt("CN_DS_KH_VAY", Params);

            return dt;
        }

        public static DataTable CN_DS_KH_VAY_THEO_MA(string ma_cn, string loai_kh, string ma_kh_vay)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@ma_cn", ma_cn),
            new SqlParameter("@loai_kh",loai_kh),
            new SqlParameter("@ma_kh_vay",ma_kh_vay)
            };
            DataTable dt = db.dt("CN_DS_KH_VAY_THEO_MA", Params);

            return dt;
        }

        public static DataTable CN_DS_KH_VAY_THEO_TEN(string ma_cn, string loai_kh, string cn_ten)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@ma_cn", ma_cn),
            new SqlParameter("@loai_kh",loai_kh),
            new SqlParameter("@cn_ten",cn_ten)
            };
            DataTable dt = db.dt("CN_DS_KH_VAY_THEO_TEN", Params);

            return dt;
        }

        public static DataTable CN_DS_KH_VAY_THEO_CMND(string ma_cn, string loai_kh, string cn_cmnd)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@ma_cn", ma_cn),
            new SqlParameter("@loai_kh",loai_kh),
            new SqlParameter("@cn_cmnd",cn_cmnd)
            };
            DataTable dt = db.dt("CN_DS_KH_VAY_THEO_CMND", Params);

            return dt;
        }


        //----------------------Hộ gia đình----------------------------------------------------------

        public static DataTable HGD_DS_KH_VAY(string ma_cn, string loai_kh)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@ma_cn", ma_cn),
            new SqlParameter("@loai_kh",loai_kh)
            };
            DataTable dt = db.dt("HGD_DS_KH_VAY", Params);

            return dt;
        }

        public static DataTable HGD_DS_KH_VAY_THEO_MA(string ma_cn, string loai_kh, string ma_kh_vay)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@ma_cn", ma_cn),
            new SqlParameter("@loai_kh",loai_kh),
            new SqlParameter("@ma_kh_vay",ma_kh_vay)
            };
            DataTable dt = db.dt("HGD_DS_KH_VAY_THEO_MA", Params);

            return dt;
        }

        public static DataTable HGD_DS_KH_VAY_THEO_TEN_CHONG(string ma_cn, string loai_kh, string hgd_ten_chong)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@ma_cn", ma_cn),
            new SqlParameter("@loai_kh",loai_kh),
            new SqlParameter("@hgd_ten_chong",hgd_ten_chong)
            };
            DataTable dt = db.dt("HGD_DS_KH_VAY_THEO_TEN_CHONG", Params);

            return dt;
        }

        public static DataTable HGD_DS_KH_VAY_THEO_TEN_VO(string ma_cn, string loai_kh, string hgd_ten_vo)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@ma_cn", ma_cn),
            new SqlParameter("@loai_kh",loai_kh),
            new SqlParameter("@hgd_ten_vo",hgd_ten_vo)
            };
            DataTable dt = db.dt("HGD_DS_KH_VAY_THEO_TEN_VO", Params);

            return dt;
        }

        public static DataTable HGD_DS_KH_VAY_THEO_CMND_CHONG(string ma_cn, string loai_kh, string hgd_cmnd_chong)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@ma_cn", ma_cn),
            new SqlParameter("@loai_kh",loai_kh),
            new SqlParameter("@hgd_cmnd_chong",hgd_cmnd_chong)
            };
            DataTable dt = db.dt("HGD_DS_KH_VAY_THEO_CMND_CHONG", Params);

            return dt;
        }

        public static DataTable HGD_DS_KH_VAY_THEO_CMND_VO(string ma_cn, string loai_kh, string hgd_cmnd_vo)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@ma_cn", ma_cn),
            new SqlParameter("@loai_kh",loai_kh),
            new SqlParameter("@hgd_cmnd_vo",hgd_cmnd_vo)
            };
            DataTable dt = db.dt("HGD_DS_KH_VAY_THEO_CMND_VO", Params);

            return dt;
        }
        
        //--------------------------Tổ chức-------------------------------------------------------

        public static DataTable TC_DS_KH_VAY(string ma_cn, string loai_kh)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@ma_cn", ma_cn),
            new SqlParameter("@loai_kh",loai_kh)
            };
            DataTable dt = db.dt("TC_DS_KH_VAY", Params);

            return dt;
        }

        public static DataTable TC_DS_KH_VAY_THEO_MA(string ma_cn, string loai_kh, string ma_kh_vay)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@ma_cn", ma_cn),
            new SqlParameter("@loai_kh",loai_kh),
            new SqlParameter("@ma_kh_vay",ma_kh_vay)
            };
            DataTable dt = db.dt("TC_DS_KH_VAY_THEO_MA", Params);

            return dt;
        }

        public static DataTable TC_DS_KH_VAY_THEO_TEN(string ma_cn, string loai_kh, string tc_ten)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@ma_cn", ma_cn),
            new SqlParameter("@loai_kh",loai_kh),
            new SqlParameter("@tc_ten",tc_ten)
            };
            DataTable dt = db.dt("TC_DS_KH_VAY_THEO_TEN", Params);

            return dt;
        }

        public static DataTable TC_DS_KH_VAY_THEO_TEN_DAI_DIEN(string ma_cn, string loai_kh, string tc_dai_dien)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@ma_cn", ma_cn),
            new SqlParameter("@loai_kh",loai_kh),
            new SqlParameter("@tc_dai_dien",tc_dai_dien)
            };
            DataTable dt = db.dt("TC_DS_KH_VAY_THEO_TEN_DAI_DIEN", Params);

            return dt;
        }

        public static DataTable TC_DS_KH_VAY_THEO_CMND_DAI_DIEN(string ma_cn, string loai_kh, string tc_cmnd_dai_dien)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@ma_cn", ma_cn),
            new SqlParameter("@loai_kh",loai_kh),
            new SqlParameter("@tc_cmnd_dai_dien",tc_cmnd_dai_dien)
            };
            DataTable dt = db.dt("TC_DS_KH_VAY_THEO_CMND_DAI_DIEN", Params);

            return dt;
        }



        public bool THEM_KH_VAY(Khachhangvay kh)
        {
            SqlParameter[] Params = new SqlParameter[] 
            {
                new SqlParameter("@ma_kh_vay", kh.ma_kh_vay),
                new SqlParameter("@loai_kh", kh.loai_kh),
                new SqlParameter("@ma_cn", kh.ma_cn),
                //Hộ gia đình
                new SqlParameter("@hgd_ten_chong", kh.hgd_ten_chong),
                new SqlParameter("@hgd_ns_chong", kh.hgd_ns_chong),
                new SqlParameter("@hgd_cmnd_chong", kh.hgd_cmnd_chong),
                new SqlParameter("@hgd_ngay_cap_cmnd_chong", kh.hgd_ngay_cap_cmnd_chong),
                new SqlParameter("@hgd_noi_cap_cmnd_chong", kh.hgd_noi_cap_cmnd_chong),
                new SqlParameter("@hgd_dc_chong", kh.hgd_dc_chong),
                new SqlParameter("@hgd_hktt_chong", kh.hgd_hktt_chong),
                new SqlParameter("@hgd_so_hk_chong ", kh.hgd_so_hk_chong ),
                new SqlParameter("@hgd_noi_cap_hk_chong ", kh.hgd_noi_cap_hk_chong ),
                new SqlParameter("@hgd_ngay_cap_hk_chong ", kh.hgd_ngay_cap_hk_chong ),
                new SqlParameter("@hgd_ten_vo ", kh.hgd_ten_vo ),
                new SqlParameter("@hgd_ns_vo ", kh.hgd_ns_vo ),
                new SqlParameter("@hgd_cmnd_vo ", kh.hgd_cmnd_vo ),
                new SqlParameter("@hgd_ngay_cap_cmnd_vo ", kh.hgd_ngay_cap_cmnd_vo ),
                new SqlParameter("@hgd_noi_cap_cmnd_vo ", kh.hgd_noi_cap_cmnd_vo ),
                new SqlParameter("@hgd_dc_vo ", kh.hgd_dc_vo ),
                new SqlParameter("@hgd_hktt_vo ", kh.hgd_hktt_vo ),
                new SqlParameter("@hgd_so_hk_vo ", kh.hgd_so_hk_vo ),
                new SqlParameter("@hgd_noi_cap_hk_vo ", kh.hgd_noi_cap_hk_vo ),
                new SqlParameter("@hgd_ngay_cap_hk_vo ", kh.hgd_ngay_cap_hk_vo ),
                new SqlParameter("@hgd_dkkd ", kh.hgd_dkkd ),
                new SqlParameter("@hgd_dien_thoai ", kh.hgd_dien_thoai ),
                new SqlParameter("@hgd_fax ", kh.hgd_fax ),
                new SqlParameter("@hgd_email ", kh.hgd_email ),
                //Cá nhân
                new SqlParameter("@cn_danh_xung ", kh.cn_danh_xung ),
                new SqlParameter("@cn_ten ", kh.cn_ten ),
                new SqlParameter("@cn_ns ", kh.cn_ns ),
                new SqlParameter("@cn_cmnd ", kh.cn_cmnd ),
                new SqlParameter("@cn_ngay_cap_cmnd ", kh.cn_ngay_cap_cmnd ),
                new SqlParameter("@cn_noi_cap_cmnd ", kh.cn_noi_cap_cmnd ),
                new SqlParameter("@cn_dc ", kh.cn_dc ),
                new SqlParameter("@cn_hktt ", kh.cn_hktt ),
                new SqlParameter("@cn_so_hk ", kh.cn_so_hk ),
                new SqlParameter("@cn_noi_cap_hk ", kh.cn_noi_cap_hk ),
                new SqlParameter("@cn_ngay_cap_hk ", kh.cn_ngay_cap_hk ),
                new SqlParameter("@cn_dkkd ", kh.cn_dkkd ),
                new SqlParameter("@cn_dien_thoai ", kh.cn_dien_thoai ),
                new SqlParameter("@cn_fax ", kh.cn_fax ),
                new SqlParameter("@cn_email ", kh.cn_email ),
                //Tổ chức
                new SqlParameter("@tc_ten ", kh.tc_ten ),
                new SqlParameter("@tc_dkkd ", kh.tc_dkkd ),
                new SqlParameter("@tc_dc ", kh.tc_dc ),
                new SqlParameter("@tc_danh_xung_dai_dien", kh.tc_danh_xung_dai_dien ),
                new SqlParameter("@tc_dai_dien", kh.tc_dai_dien ),
                new SqlParameter("@tc_ns_dai_dien", kh.tc_ns_dai_dien ),
                new SqlParameter("@tc_chuc_vu_dai_dien", kh.tc_chuc_vu_dai_dien ),
                new SqlParameter("@tc_giay_uy_quyen", kh.tc_giay_uy_quyen),
                new SqlParameter("@tc_dc_dai_dien ", kh.tc_dc_dai_dien ),
                new SqlParameter("@tc_cmnd_dai_dien ", kh.tc_cmnd_dai_dien ),
                new SqlParameter("@tc_ngay_cap_cmnd_dai_dien ", kh.tc_ngay_cap_cmnd_dai_dien ),
                new SqlParameter("@tc_noi_cap_cmnd_dai_dien ", kh.tc_noi_cap_cmnd_dai_dien ),
                new SqlParameter("@tc_hktt_dai_dien ", kh.tc_hktt_dai_dien ),
                new SqlParameter("@tc_so_hk_dai_dien ", kh.tc_so_hk_dai_dien ),
                new SqlParameter("@tc_noi_cap_hk_dai_dien ", kh.tc_noi_cap_hk_dai_dien ),
                new SqlParameter("@tc_ngay_cap_hk_dai_dien ", kh.tc_ngay_cap_hk_dai_dien ),
                new SqlParameter("@tc_dien_thoai ", kh.tc_dien_thoai ),
                new SqlParameter("@tc_fax ", kh.tc_fax ),
                new SqlParameter("@tc_email ", kh.tc_email ),
                new SqlParameter("@hgd_dai_dien", kh.hgd_dai_dien),
                new SqlParameter("@hgd_ten_viet_tat", kh.hgd_ten_viet_tat),
                new SqlParameter("@cn_ten_viet_tat", kh.cn_ten_viet_tat),
                new SqlParameter("@tc_ten_viet_tat", kh.tc_ten_viet_tat)
             };
            int count = db.cmdExecNonQueryProc("THEM_KH_VAY",Params);
            return count > 0;
        }

        //public bool TC_Them_KH_vay(Khachhangvay kh)
        //{
        //    SqlParameter[] Params = new SqlParameter[] 
        //    {
        //         new SqlParameter("@ma_kh_vay", kh.ma_kh_vay),
        //         new SqlParameter("@loai_kh",kh.loai_kh),
        //         new SqlParameter("@ma_cn", kh.ma_cn),
        //         new SqlParameter("@ten_tc",kh.ten_tc),
        //         new SqlParameter("@dkkd",kh.dkkd),
        //         new SqlParameter("@dia_chi_tc",kh.dia_chi_tc),
        //         new SqlParameter("@dai_dien",kh.dai_dien),
        //         new SqlParameter("@chuc_vu_dai_dien",kh.chuc_vu_dai_dien),
        //         new SqlParameter("@dc_dai_dien",kh.dc_dai_dien),
        //         new SqlParameter("@cmnd_dai_dien",kh.cmnd_dai_dien),
        //         new SqlParameter("@ngay_cap_cmnd_dai_dien",kh.ngay_cap_cmnd_dai_dien),
        //         new SqlParameter("@noi_cap_cmnd_dai_dien",kh.noi_cap_cmnd_dai_dien),
        //         new SqlParameter("@dien_thoai",kh.dien_thoai)
        //     };
        //    int count = db.cmdExecNonQueryProc("TC_Them_KH_VAY", Params);
        //    return count > 0;
        //}

        public bool CAP_NHAT_KH_VAY(Khachhangvay kh, string ma_kh_vay)
        {
            SqlParameter[] Params = new SqlParameter[] 
            {
                new SqlParameter("@ma_kh_vay", ma_kh_vay),
                //new SqlParameter("@loai_kh", kh.loai_kh),
                //new SqlParameter("@ma_cn", kh.ma_cn),
                //Hộ gia đình
                new SqlParameter("@hgd_ten_chong", kh.hgd_ten_chong),
                new SqlParameter("@hgd_ns_chong", kh.hgd_ns_chong),
                new SqlParameter("@hgd_cmnd_chong", kh.hgd_cmnd_chong),
                new SqlParameter("@hgd_ngay_cap_cmnd_chong", kh.hgd_ngay_cap_cmnd_chong),
                new SqlParameter("@hgd_noi_cap_cmnd_chong", kh.hgd_noi_cap_cmnd_chong),
                new SqlParameter("@hgd_dc_chong", kh.hgd_dc_chong),
                new SqlParameter("@hgd_hktt_chong", kh.hgd_hktt_chong),
                new SqlParameter("@hgd_so_hk_chong ", kh.hgd_so_hk_chong ),
                new SqlParameter("@hgd_noi_cap_hk_chong ", kh.hgd_noi_cap_hk_chong ),
                new SqlParameter("@hgd_ngay_cap_hk_chong ", kh.hgd_ngay_cap_hk_chong ),
                new SqlParameter("@hgd_ten_vo ", kh.hgd_ten_vo ),
                new SqlParameter("@hgd_ns_vo ", kh.hgd_ns_vo ),
                new SqlParameter("@hgd_cmnd_vo ", kh.hgd_cmnd_vo ),
                new SqlParameter("@hgd_ngay_cap_cmnd_vo ", kh.hgd_ngay_cap_cmnd_vo ),
                new SqlParameter("@hgd_noi_cap_cmnd_vo ", kh.hgd_noi_cap_cmnd_vo ),
                new SqlParameter("@hgd_dc_vo ", kh.hgd_dc_vo ),
                new SqlParameter("@hgd_hktt_vo ", kh.hgd_hktt_vo ),
                new SqlParameter("@hgd_so_hk_vo ", kh.hgd_so_hk_vo ),
                new SqlParameter("@hgd_noi_cap_hk_vo ", kh.hgd_noi_cap_hk_vo ),
                new SqlParameter("@hgd_ngay_cap_hk_vo ", kh.hgd_ngay_cap_hk_vo ),
                new SqlParameter("@hgd_dkkd ", kh.hgd_dkkd ),
                new SqlParameter("@hgd_dien_thoai ", kh.hgd_dien_thoai ),
                new SqlParameter("@hgd_fax ", kh.hgd_fax ),
                new SqlParameter("@hgd_email ", kh.hgd_email ),
                //Cá nhân
                new SqlParameter("@cn_danh_xung ", kh.cn_danh_xung ),
                new SqlParameter("@cn_ten ", kh.cn_ten ),
                new SqlParameter("@cn_ns ", kh.cn_ns ),
                new SqlParameter("@cn_cmnd ", kh.cn_cmnd ),
                new SqlParameter("@cn_ngay_cap_cmnd ", kh.cn_ngay_cap_cmnd ),
                new SqlParameter("@cn_noi_cap_cmnd ", kh.cn_noi_cap_cmnd ),
                new SqlParameter("@cn_dc ", kh.cn_dc ),
                new SqlParameter("@cn_hktt ", kh.cn_hktt ),
                new SqlParameter("@cn_so_hk ", kh.cn_so_hk ),
                new SqlParameter("@cn_noi_cap_hk ", kh.cn_noi_cap_hk ),
                new SqlParameter("@cn_ngay_cap_hk ", kh.cn_ngay_cap_hk ),
                new SqlParameter("@cn_dkkd ", kh.cn_dkkd ),
                new SqlParameter("@cn_dien_thoai ", kh.cn_dien_thoai ),
                new SqlParameter("@cn_fax ", kh.cn_fax ),
                new SqlParameter("@cn_email ", kh.cn_email ),
                //Tổ chức
                new SqlParameter("@tc_ten ", kh.tc_ten ),
                new SqlParameter("@tc_dkkd ", kh.tc_dkkd ),
                new SqlParameter("@tc_dc ", kh.tc_dc ),
                new SqlParameter("@tc_danh_xung_dai_dien ", kh.tc_danh_xung_dai_dien ),
                new SqlParameter("@tc_dai_dien ", kh.tc_dai_dien ),
                new SqlParameter("@tc_ns_dai_dien ", kh.tc_ns_dai_dien ),
                new SqlParameter("@tc_chuc_vu_dai_dien ", kh.tc_chuc_vu_dai_dien ),
                new SqlParameter("@tc_giay_uy_quyen", kh.tc_giay_uy_quyen),
                new SqlParameter("@tc_dc_dai_dien ", kh.tc_dc_dai_dien ),
                new SqlParameter("@tc_cmnd_dai_dien ", kh.tc_cmnd_dai_dien ),
                new SqlParameter("@tc_ngay_cap_cmnd_dai_dien ", kh.tc_ngay_cap_cmnd_dai_dien ),
                new SqlParameter("@tc_noi_cap_cmnd_dai_dien ", kh.tc_noi_cap_cmnd_dai_dien ),
                new SqlParameter("@tc_hktt_dai_dien ", kh.tc_hktt_dai_dien ),
                new SqlParameter("@tc_so_hk_dai_dien ", kh.tc_so_hk_dai_dien ),
                new SqlParameter("@tc_noi_cap_hk_dai_dien ", kh.tc_noi_cap_hk_dai_dien ),
                new SqlParameter("@tc_ngay_cap_hk_dai_dien ", kh.tc_ngay_cap_hk_dai_dien ),
                new SqlParameter("@tc_dien_thoai ", kh.tc_dien_thoai ),
                new SqlParameter("@tc_fax ", kh.tc_fax ),
                new SqlParameter("@tc_email ", kh.tc_email ),
                new SqlParameter("@hgd_dai_dien", kh.hgd_dai_dien),
                new SqlParameter("@hgd_ten_viet_tat", kh.hgd_ten_viet_tat),
                new SqlParameter("@cn_ten_viet_tat", kh.cn_ten_viet_tat),
                new SqlParameter("@tc_ten_viet_tat", kh.tc_ten_viet_tat)
             };
            int count = db.cmdExecNonQueryProc("CAP_NHAT_KH_VAY", Params);
            return count > 0;
        }

        //public bool TC_Cap_nhat_KH_vay(Khachhangvay kh, string ma_kh_vay)
        //{
        //    SqlParameter[] Params = new SqlParameter[] 
        //    {
        //         new SqlParameter("@ma_kh_vay", ma_kh_vay),
        //         new SqlParameter("@ma_cn", kh.ma_cn),
        //         new SqlParameter("@ten_tc",kh.ten_tc),
        //         new SqlParameter("@dkkd",kh.dkkd),
        //         new SqlParameter("@dia_chi_tc",kh.dia_chi_tc),
        //         new SqlParameter("@dai_dien",kh.dai_dien),
        //         new SqlParameter("@chuc_vu_dai_dien",kh.chuc_vu_dai_dien),
        //         new SqlParameter("@dc_dai_dien",kh.dc_dai_dien),
        //         new SqlParameter("@cmnd_dai_dien",kh.cmnd_dai_dien),
        //         new SqlParameter("@ngay_cap_cmnd_dai_dien",kh.ngay_cap_cmnd_dai_dien),
        //         new SqlParameter("@noi_cap_cmnd_dai_dien",kh.noi_cap_cmnd_dai_dien),
        //         new SqlParameter("@dien_thoai",kh.dien_thoai)
        //     };
        //    int count = db.cmdExecNonQueryProc("TC_Capnhat_KH_VAY", Params);
        //    return count > 0;
        //}

        public bool XOA_KH_VAY(string ma_kh_vay)
        {
            SqlParameter[] Params = new SqlParameter[] 
            {
                 new SqlParameter("@ma_kh_vay", ma_kh_vay),
             };
            int count = db.cmdExecNonQueryProc("XOA_KH_VAY", Params);
            return count > 0;
        }

        public bool KIEM_TRA_TRUNG_MA_KH(string ma_kh_vay)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@ma_kh_vay", ma_kh_vay),
            };

            DataTable dt = db.dt("KH_VAY_THEO_MA_CHECK", Params);

            return dt.Rows.Count > 0;
        }
    }
}
