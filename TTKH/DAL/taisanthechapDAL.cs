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
    class taisanthechapDAL
    {
        DataAccess db = new DataAccess();

        //public static DataTable Danhsach_TSTC(string ma_hd_vay)
        //{
        //    DataAccess db = new DataAccess();
        //    SqlParameter[] Params = new SqlParameter[]
        //        {
        //        new SqlParameter("@ma_hd_vay", ma_hd_vay)
        //        };
        //    DataTable dt = db.dt("Danhsach_TSTC", Params);
        //    return dt;
        //}

        public static DataTable DS_TSTC(string ma_hd_vay)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
                {
                new SqlParameter("@ma_hd_vay", ma_hd_vay)
                };
            DataTable dt = db.dt("DS_TSTC", Params);
            return dt;
        }

        public static Taisanthechap TSTC_THEO_MA_TSTC(int ma_ts_the_chap)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
                {
                new SqlParameter("@ma_ts_the_chap",ma_ts_the_chap)
                };
            DataTable dt = db.dt("TSTC_THEO_MA_TSTC", Params);
            DataRow row = dt.Rows[0];
            Taisanthechap tstc = new Taisanthechap(row);
            return tstc;
        }

        //public static List<Taisanthechap> Danhsach_TSTC_theo_ma_ts_the_chap(int ma_ts_the_chap)
        //{
        //    DataAccess db = new DataAccess();
        //    SqlParameter[] Params = new SqlParameter[]
        //    {
        //    new SqlParameter("@ma_ts_the_chap", ma_ts_the_chap)
        //    };
        //    DataTable dt = db.dt("Danhsach_TSTC_theo_ma_tstc", Params);

        //    List<Taisanthechap> list = new List<Taisanthechap>();

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        list.Add(new Taisanthechap(row));
        //    }
        //    return list;
        //}

        public bool THEM_TSTC(Taisanthechap tstc)
        {
            SqlParameter[] Params = new SqlParameter[] 
            {
                //new SqlParameter("@ma_ts_the_chap", tstc.ma_ts_the_chap),
                new SqlParameter("@ma_hd_vay", tstc.ma_hd_vay),
                new SqlParameter("@loai_chu_so_huu", tstc.loai_chu_so_huu),
                new SqlParameter("@loai_ts_the_chap", tstc.loai_ts_the_chap),
                new SqlParameter("@hinh_thuc_so_huu_cua_kh_vay", tstc.hinh_thuc_so_huu_cua_kh_vay),
                new SqlParameter("@hgd_ten_chong", tstc.hgd_ten_chong),
                new SqlParameter("@hgd_ns_chong", tstc.hgd_ns_chong),
                new SqlParameter("@hgd_cmnd_chong", tstc.hgd_cmnd_chong),
                new SqlParameter("@hgd_ngay_cap_cmnd_chong", tstc.hgd_ngay_cap_cmnd_chong),
                new SqlParameter("@hgd_noi_cap_cmnd_chong", tstc.hgd_noi_cap_cmnd_chong),
                new SqlParameter("@hgd_dc_chong", tstc.hgd_dc_chong),
                new SqlParameter("@hgd_hktt_chong", tstc.hgd_hktt_chong),
                new SqlParameter("@hgd_so_hk_chong", tstc.hgd_so_hk_chong),
                new SqlParameter("@hgd_noi_cap_hk_chong", tstc.hgd_noi_cap_hk_chong),
                new SqlParameter("@hgd_ngay_cap_hk_chong", tstc.hgd_ngay_cap_hk_chong),
                new SqlParameter("@hgd_ten_vo", tstc.hgd_ten_vo),
                new SqlParameter("@hgd_ns_vo", tstc.hgd_ns_vo),
                new SqlParameter("@hgd_cmnd_vo", tstc.hgd_cmnd_vo),
                new SqlParameter("@hgd_ngay_cap_cmnd_vo", tstc.hgd_ngay_cap_cmnd_vo),
                new SqlParameter("@hgd_noi_cap_cmnd_vo", tstc.hgd_noi_cap_cmnd_vo),
                new SqlParameter("@hgd_dc_vo", tstc.hgd_dc_vo),
                new SqlParameter("@hgd_hktt_vo", tstc.hgd_hktt_vo),
                new SqlParameter("@hgd_so_hk_vo", tstc.hgd_so_hk_vo),
                new SqlParameter("@hgd_noi_cap_hk_vo", tstc.hgd_noi_cap_hk_vo),
                new SqlParameter("@hgd_ngay_cap_hk_vo", tstc.hgd_ngay_cap_hk_vo),
                new SqlParameter("@hgd_dkkd", tstc.hgd_dkkd),
                new SqlParameter("@hgd_dien_thoai", tstc.hgd_dien_thoai),
                new SqlParameter("@hgd_fax", tstc.hgd_fax),
                new SqlParameter("@hgd_email", tstc.hgd_email),
                new SqlParameter("@hgd_dai_dien", tstc.hgd_dai_dien),
                new SqlParameter("@hgd_nguoi_so_huu", tstc.hgd_nguoi_so_huu),
                new SqlParameter("@cn_danh_xung", tstc.cn_danh_xung),
                new SqlParameter("@cn_ten", tstc.cn_ten),
                new SqlParameter("@cn_ns", tstc.cn_ns),
                new SqlParameter("@cn_cmnd", tstc.cn_cmnd),
                new SqlParameter("@cn_ngay_cap_cmnd", tstc.cn_ngay_cap_cmnd),
                new SqlParameter("@cn_noi_cap_cmnd", tstc.cn_noi_cap_cmnd),
                new SqlParameter("@cn_dc", tstc.cn_dc),
                new SqlParameter("@cn_hktt", tstc.cn_hktt),
                new SqlParameter("@cn_so_hk", tstc.cn_so_hk),
                new SqlParameter("@cn_noi_cap_hk", tstc.cn_noi_cap_hk),
                new SqlParameter("@cn_ngay_cap_hk", tstc.cn_ngay_cap_hk),
                new SqlParameter("@cn_dkkd", tstc.cn_dkkd),
                new SqlParameter("@cn_dien_thoai", tstc.cn_dien_thoai),
                new SqlParameter("@cn_fax", tstc.cn_fax),
                new SqlParameter("@cn_email", tstc.cn_email),
                new SqlParameter("@tc_ten", tstc.tc_ten),
                new SqlParameter("@tc_dkkd", tstc.tc_dkkd),
                new SqlParameter("@tc_dc", tstc.tc_dc),
                new SqlParameter("@tc_danh_xung_dai_dien", tstc.tc_danh_xung_dai_dien),
                new SqlParameter("@tc_dai_dien", tstc.tc_dai_dien),
                new SqlParameter("@tc_ns_dai_dien", tstc.tc_ns_dai_dien),
                new SqlParameter("@tc_chuc_vu_dai_dien", tstc.tc_chuc_vu_dai_dien),
                new SqlParameter("@tc_giay_uy_quyen", tstc.tc_giay_uy_quyen),
                new SqlParameter("@tc_dc_dai_dien", tstc.tc_dc_dai_dien),
                new SqlParameter("@tc_cmnd_dai_dien", tstc.tc_cmnd_dai_dien),
                new SqlParameter("@tc_ngay_cap_cmnd_dai_dien", tstc.tc_ngay_cap_cmnd_dai_dien),
                new SqlParameter("@tc_noi_cap_cmnd_dai_dien", tstc.tc_noi_cap_cmnd_dai_dien),
                new SqlParameter("@tc_hktt_dai_dien", tstc.tc_hktt_dai_dien),
                new SqlParameter("@tc_so_hk_dai_dien", tstc.tc_so_hk_dai_dien),
                new SqlParameter("@tc_noi_cap_hk_dai_dien", tstc.tc_noi_cap_hk_dai_dien),
                new SqlParameter("@tc_ngay_cap_hk_dai_dien", tstc.tc_ngay_cap_hk_dai_dien),
                new SqlParameter("@tc_dien_thoai", tstc.tc_dien_thoai),
                new SqlParameter("@tc_fax", tstc.tc_fax),
                new SqlParameter("@tc_email", tstc.tc_email),
                new SqlParameter("@ds_ten", tstc.ds_ten),
                new SqlParameter("@ds_nhan_hieu", tstc.ds_nhan_hieu),
                new SqlParameter("@ds_thong_tin_chung_rtf", tstc.ds_thong_tin_chung_rtf),
                new SqlParameter("@ds_thong_tin_chung", tstc.ds_thong_tin_chung),
                new SqlParameter("@ds_giay_to", tstc.ds_giay_to),
                new SqlParameter("@ds_gia_tri", tstc.ds_gia_tri),
                new SqlParameter("@bds_ten", tstc.bds_ten),
                new SqlParameter("@bds_tong_dien_tich", tstc.bds_tong_dien_tich),
                new SqlParameter("@bds_gia_tri_qsd_dat", tstc.bds_gia_tri_qsd_dat),
                new SqlParameter("@bds_dien_tich_dat_o", tstc.bds_dien_tich_dat_o),
                new SqlParameter("@bds_gia_tri_qsd_dat_o_tren_m2", tstc.bds_gia_tri_qsd_dat_o_tren_m2),
                new SqlParameter("@bds_gia_tri_qsd_dat_o", tstc.bds_gia_tri_qsd_dat_o),
                new SqlParameter("@bds_dat_khac_1", tstc.bds_dat_khac_1),
                new SqlParameter("@bds_dien_tich_dat_khac_1", tstc.bds_dien_tich_dat_khac_1),
                new SqlParameter("@bds_gia_tri_qsd_dat_khac_1_tren_m2", tstc.bds_gia_tri_qsd_dat_khac_1_tren_m2),
                new SqlParameter("@bds_gia_tri_qsd_dat_khac_1", tstc.bds_gia_tri_qsd_dat_khac_1),
                new SqlParameter("@bds_dat_khac_2", tstc.bds_dat_khac_2),
                new SqlParameter("@bds_dien_tich_dat_khac_2", tstc.bds_dien_tich_dat_khac_2),
                new SqlParameter("@bds_gia_tri_qsd_dat_khac_2_tren_m2", tstc.bds_gia_tri_qsd_dat_khac_2_tren_m2),
                new SqlParameter("@bds_gia_tri_qsd_dat_khac_2", tstc.bds_gia_tri_qsd_dat_khac_2),
                new SqlParameter("@bds_dat_khac_3", tstc.bds_dat_khac_3),
                new SqlParameter("@bds_dien_tich_dat_khac_3", tstc.bds_dien_tich_dat_khac_3),
                new SqlParameter("@bds_gia_tri_qsd_dat_khac_3_tren_m2", tstc.bds_gia_tri_qsd_dat_khac_3_tren_m2),
                new SqlParameter("@bds_gia_tri_qsd_dat_khac_3", tstc.bds_gia_tri_qsd_dat_khac_3),
                new SqlParameter("@bds_dien_tich_su_dung_rieng", tstc.bds_dien_tich_su_dung_rieng),
                new SqlParameter("@bds_dien_tich_su_dung_chung", tstc.bds_dien_tich_su_dung_chung),
                new SqlParameter("@bds_thong_tin_chung_rtf", tstc.bds_thong_tin_chung_rtf),
                new SqlParameter("@bds_thong_tin_chung", tstc.bds_thong_tin_chung),
                new SqlParameter("@bds_giay_to_rtf", tstc.bds_giay_to_rtf),
                new SqlParameter("@bds_giay_to", tstc.bds_giay_to),
                new SqlParameter("@bds_nha_thong_tin_chung_rtf", tstc.bds_nha_thong_tin_chung_rtf),
                new SqlParameter("@bds_nha_thong_tin_chung", tstc.bds_nha_thong_tin_chung),
                new SqlParameter("@bds_nha_gia_tri", tstc.bds_nha_gia_tri),
                new SqlParameter("@bds_ctxd_thong_tin_chung_rtf", tstc.bds_ctxd_thong_tin_chung_rtf),
                new SqlParameter("@bds_ctxd_thong_tin_chung", tstc.bds_ctxd_thong_tin_chung),
                new SqlParameter("@bds_ctxd_gia_tri", tstc.bds_ctxd_gia_tri),
                new SqlParameter("@bds_tsgl_khac_thong_tin_chung_rtf", tstc.bds_tsgl_khac_thong_tin_chung_rtf),
                new SqlParameter("@bds_tsgl_khac_thong_tin_chung", tstc.bds_tsgl_khac_thong_tin_chung),
                new SqlParameter("@bds_tsgl_khac_gia_tri", tstc.bds_tsgl_khac_gia_tri),
                new SqlParameter("@bds_gia_tri", tstc.bds_gia_tri),
                new SqlParameter("@tstc_khac_ten", tstc.tstc_khac_ten),
                new SqlParameter("@tstc_khac_thong_tin_chung_rtf", tstc.tstc_khac_thong_tin_chung_rtf),
                new SqlParameter("@tstc_khac_thong_tin_chung", tstc.tstc_khac_thong_tin_chung),
                new SqlParameter("@tstc_khac_gia_tri", tstc.tstc_khac_gia_tri),
                new SqlParameter("@tstc_htttl", tstc.tstc_htttl),
                new SqlParameter("@tstc_khac_giay_to", tstc.tstc_khac_giay_to),
                new SqlParameter("@bds_ctxd_2", tstc.bds_ctxd_2),
                new SqlParameter("@ma_chu_so_huu", tstc.ma_chu_so_huu)
             };
            int count = db.cmdExecNonQueryProc("THEM_TSTC", Params);
            return count > 0;
        }

        public bool CAP_NHAT_TSTC(Taisanthechap tstc)
        {
            SqlParameter[] Params = new SqlParameter[] 
            {
                new SqlParameter("@ma_ts_the_chap", tstc.ma_ts_the_chap),
                //new SqlParameter("@ma_hd_vay", tstc.ma_hd_vay),
                //new SqlParameter("@loai_chu_so_huu", tstc.loai_chu_so_huu),
                //new SqlParameter("@loai_ts_the_chap", tstc.loai_ts_the_chap),
                //new SqlParameter("@hinh_thuc_so_huu_cua_kh_vay", tstc.hinh_thuc_so_huu_cua_kh_vay),
                new SqlParameter("@hgd_ten_chong", tstc.hgd_ten_chong),
                new SqlParameter("@hgd_ns_chong", tstc.hgd_ns_chong),
                new SqlParameter("@hgd_cmnd_chong", tstc.hgd_cmnd_chong),
                new SqlParameter("@hgd_ngay_cap_cmnd_chong", tstc.hgd_ngay_cap_cmnd_chong),
                new SqlParameter("@hgd_noi_cap_cmnd_chong", tstc.hgd_noi_cap_cmnd_chong),
                new SqlParameter("@hgd_dc_chong", tstc.hgd_dc_chong),
                new SqlParameter("@hgd_hktt_chong", tstc.hgd_hktt_chong),
                new SqlParameter("@hgd_so_hk_chong", tstc.hgd_so_hk_chong),
                new SqlParameter("@hgd_noi_cap_hk_chong", tstc.hgd_noi_cap_hk_chong),
                new SqlParameter("@hgd_ngay_cap_hk_chong", tstc.hgd_ngay_cap_hk_chong),
                new SqlParameter("@hgd_ten_vo", tstc.hgd_ten_vo),
                new SqlParameter("@hgd_ns_vo", tstc.hgd_ns_vo),
                new SqlParameter("@hgd_cmnd_vo", tstc.hgd_cmnd_vo),
                new SqlParameter("@hgd_ngay_cap_cmnd_vo", tstc.hgd_ngay_cap_cmnd_vo),
                new SqlParameter("@hgd_noi_cap_cmnd_vo", tstc.hgd_noi_cap_cmnd_vo),
                new SqlParameter("@hgd_dc_vo", tstc.hgd_dc_vo),
                new SqlParameter("@hgd_hktt_vo", tstc.hgd_hktt_vo),
                new SqlParameter("@hgd_so_hk_vo", tstc.hgd_so_hk_vo),
                new SqlParameter("@hgd_noi_cap_hk_vo", tstc.hgd_noi_cap_hk_vo),
                new SqlParameter("@hgd_ngay_cap_hk_vo", tstc.hgd_ngay_cap_hk_vo),
                new SqlParameter("@hgd_dkkd", tstc.hgd_dkkd),
                new SqlParameter("@hgd_dien_thoai", tstc.hgd_dien_thoai),
                new SqlParameter("@hgd_fax", tstc.hgd_fax),
                new SqlParameter("@hgd_email", tstc.hgd_email),
                new SqlParameter("@hgd_dai_dien", tstc.hgd_dai_dien),
                new SqlParameter("@hgd_nguoi_so_huu", tstc.hgd_nguoi_so_huu),
                new SqlParameter("@cn_danh_xung", tstc.cn_danh_xung),
                new SqlParameter("@cn_ten", tstc.cn_ten),
                new SqlParameter("@cn_ns", tstc.cn_ns),
                new SqlParameter("@cn_cmnd", tstc.cn_cmnd),
                new SqlParameter("@cn_ngay_cap_cmnd", tstc.cn_ngay_cap_cmnd),
                new SqlParameter("@cn_noi_cap_cmnd", tstc.cn_noi_cap_cmnd),
                new SqlParameter("@cn_dc", tstc.cn_dc),
                new SqlParameter("@cn_hktt", tstc.cn_hktt),
                new SqlParameter("@cn_so_hk", tstc.cn_so_hk),
                new SqlParameter("@cn_noi_cap_hk", tstc.cn_noi_cap_hk),
                new SqlParameter("@cn_ngay_cap_hk", tstc.cn_ngay_cap_hk),
                new SqlParameter("@cn_dkkd", tstc.cn_dkkd),
                new SqlParameter("@cn_dien_thoai", tstc.cn_dien_thoai),
                new SqlParameter("@cn_fax", tstc.cn_fax),
                new SqlParameter("@cn_email", tstc.cn_email),
                new SqlParameter("@tc_ten", tstc.tc_ten),
                new SqlParameter("@tc_dkkd", tstc.tc_dkkd),
                new SqlParameter("@tc_dc", tstc.tc_dc),
                new SqlParameter("@tc_danh_xung_dai_dien", tstc.tc_danh_xung_dai_dien),
                new SqlParameter("@tc_dai_dien", tstc.tc_dai_dien),
                new SqlParameter("@tc_ns_dai_dien", tstc.tc_ns_dai_dien),
                new SqlParameter("@tc_chuc_vu_dai_dien", tstc.tc_chuc_vu_dai_dien),
                new SqlParameter("@tc_giay_uy_quyen", tstc.tc_giay_uy_quyen),
                new SqlParameter("@tc_dc_dai_dien", tstc.tc_dc_dai_dien),
                new SqlParameter("@tc_cmnd_dai_dien", tstc.tc_cmnd_dai_dien),
                new SqlParameter("@tc_ngay_cap_cmnd_dai_dien", tstc.tc_ngay_cap_cmnd_dai_dien),
                new SqlParameter("@tc_noi_cap_cmnd_dai_dien", tstc.tc_noi_cap_cmnd_dai_dien),
                new SqlParameter("@tc_hktt_dai_dien", tstc.tc_hktt_dai_dien),
                new SqlParameter("@tc_so_hk_dai_dien", tstc.tc_so_hk_dai_dien),
                new SqlParameter("@tc_noi_cap_hk_dai_dien", tstc.tc_noi_cap_hk_dai_dien),
                new SqlParameter("@tc_ngay_cap_hk_dai_dien", tstc.tc_ngay_cap_hk_dai_dien),
                new SqlParameter("@tc_dien_thoai", tstc.tc_dien_thoai),
                new SqlParameter("@tc_fax", tstc.tc_fax),
                new SqlParameter("@tc_email", tstc.tc_email),
                new SqlParameter("@ds_ten", tstc.ds_ten),
                new SqlParameter("@ds_nhan_hieu", tstc.ds_nhan_hieu),
                new SqlParameter("@ds_thong_tin_chung_rtf", tstc.ds_thong_tin_chung_rtf),
                new SqlParameter("@ds_thong_tin_chung", tstc.ds_thong_tin_chung),
                new SqlParameter("@ds_giay_to", tstc.ds_giay_to),
                new SqlParameter("@ds_gia_tri", tstc.ds_gia_tri),
                new SqlParameter("@bds_ten", tstc.bds_ten),
                new SqlParameter("@bds_tong_dien_tich", tstc.bds_tong_dien_tich),
                new SqlParameter("@bds_gia_tri_qsd_dat", tstc.bds_gia_tri_qsd_dat),
                new SqlParameter("@bds_dien_tich_dat_o", tstc.bds_dien_tich_dat_o),
                new SqlParameter("@bds_gia_tri_qsd_dat_o_tren_m2", tstc.bds_gia_tri_qsd_dat_o_tren_m2),
                new SqlParameter("@bds_gia_tri_qsd_dat_o", tstc.bds_gia_tri_qsd_dat_o),
                new SqlParameter("@bds_dat_khac_1", tstc.bds_dat_khac_1),
                new SqlParameter("@bds_dien_tich_dat_khac_1", tstc.bds_dien_tich_dat_khac_1),
                new SqlParameter("@bds_gia_tri_qsd_dat_khac_1_tren_m2", tstc.bds_gia_tri_qsd_dat_khac_1_tren_m2),
                new SqlParameter("@bds_gia_tri_qsd_dat_khac_1", tstc.bds_gia_tri_qsd_dat_khac_1),
                new SqlParameter("@bds_dat_khac_2", tstc.bds_dat_khac_2),
                new SqlParameter("@bds_dien_tich_dat_khac_2", tstc.bds_dien_tich_dat_khac_2),
                new SqlParameter("@bds_gia_tri_qsd_dat_khac_2_tren_m2", tstc.bds_gia_tri_qsd_dat_khac_2_tren_m2),
                new SqlParameter("@bds_gia_tri_qsd_dat_khac_2", tstc.bds_gia_tri_qsd_dat_khac_2),
                new SqlParameter("@bds_dat_khac_3", tstc.bds_dat_khac_3),
                new SqlParameter("@bds_dien_tich_dat_khac_3", tstc.bds_dien_tich_dat_khac_3),
                new SqlParameter("@bds_gia_tri_qsd_dat_khac_3_tren_m2", tstc.bds_gia_tri_qsd_dat_khac_3_tren_m2),
                new SqlParameter("@bds_gia_tri_qsd_dat_khac_3", tstc.bds_gia_tri_qsd_dat_khac_3),
                new SqlParameter("@bds_dien_tich_su_dung_rieng", tstc.bds_dien_tich_su_dung_rieng),
                new SqlParameter("@bds_dien_tich_su_dung_chung", tstc.bds_dien_tich_su_dung_chung),
                new SqlParameter("@bds_thong_tin_chung_rtf", tstc.bds_thong_tin_chung_rtf),
                new SqlParameter("@bds_thong_tin_chung", tstc.bds_thong_tin_chung),
                new SqlParameter("@bds_giay_to_rtf", tstc.bds_giay_to_rtf),
                new SqlParameter("@bds_giay_to", tstc.bds_giay_to),
                new SqlParameter("@bds_nha_thong_tin_chung_rtf", tstc.bds_nha_thong_tin_chung_rtf),
                new SqlParameter("@bds_nha_thong_tin_chung", tstc.bds_nha_thong_tin_chung),
                new SqlParameter("@bds_nha_gia_tri", tstc.bds_nha_gia_tri),
                new SqlParameter("@bds_ctxd_thong_tin_chung_rtf", tstc.bds_ctxd_thong_tin_chung_rtf),
                new SqlParameter("@bds_ctxd_thong_tin_chung", tstc.bds_ctxd_thong_tin_chung),
                new SqlParameter("@bds_ctxd_gia_tri", tstc.bds_ctxd_gia_tri),
                new SqlParameter("@bds_tsgl_khac_thong_tin_chung_rtf", tstc.bds_tsgl_khac_thong_tin_chung_rtf),
                new SqlParameter("@bds_tsgl_khac_thong_tin_chung", tstc.bds_tsgl_khac_thong_tin_chung),
                new SqlParameter("@bds_tsgl_khac_gia_tri", tstc.bds_tsgl_khac_gia_tri),
                new SqlParameter("@bds_gia_tri", tstc.bds_gia_tri),
                new SqlParameter("@tstc_khac_ten", tstc.tstc_khac_ten),
                new SqlParameter("@tstc_khac_thong_tin_chung_rtf", tstc.tstc_khac_thong_tin_chung_rtf),
                new SqlParameter("@tstc_khac_thong_tin_chung", tstc.tstc_khac_thong_tin_chung),
                new SqlParameter("@tstc_khac_gia_tri", tstc.tstc_khac_gia_tri),
                new SqlParameter("@tstc_htttl", tstc.tstc_htttl),
                new SqlParameter("@tstc_khac_giay_to", tstc.tstc_khac_giay_to),
                new SqlParameter("@bds_ctxd_2", tstc.bds_ctxd_2),
                new SqlParameter("@ma_chu_so_huu", tstc.ma_chu_so_huu)
             };
            int count = db.cmdExecNonQueryProc("CAP_NHAT_TSTC", Params);
            return count > 0;
        }

        public bool XOA_TSTC(int ma_ts_the_chap)
        {
            SqlParameter[] Params = new SqlParameter[] 
            {
                 new SqlParameter("@ma_ts_the_chap", ma_ts_the_chap)
             };
            int count = db.cmdExecNonQueryProc("XOA_TSTC", Params);
            return count > 0;
        }

        public bool XOA_TSTC_THEO_MA_HD_VAY(string ma_hd_vay)
        {
            SqlParameter[] Params = new SqlParameter[] 
            {
                 new SqlParameter("@ma_hd_vay", ma_hd_vay)
             };
            int count = db.cmdExecNonQueryProc("XOA_TSTC_THEO_MA_HD_VAY", Params);
            return count > 0;
        }
    }
}
