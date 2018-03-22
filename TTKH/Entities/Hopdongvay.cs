using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data;
using System.Globalization;
namespace AGRIBANKHD.Entities
{
    class Hopdongvay
    {
        #region Instance Properties

        private string _ma_hd_vay;
        public string ma_hd_vay
        {
            get { return _ma_hd_vay; }
            set { _ma_hd_vay = value; }
        }

        private string _ma_cn;
        public string ma_cn
        {
            get { return _ma_cn; }
            set { _ma_cn = value; }
        }

        private string _ma_kh_vay;
        public string ma_kh_vay
        {
            get { return _ma_kh_vay; }
            set { _ma_kh_vay = value; }
        }

        private string _phuong_thuc;
        public string phuong_thuc
        {
            get { return _phuong_thuc; }
            set { _phuong_thuc = value; }
        }

        private Int64 _tong_han_muc_tin_dung;
        public Int64 tong_han_muc_tin_dung
        {
            get { return _tong_han_muc_tin_dung; }
            set { _tong_han_muc_tin_dung = value; }
        }

        private Int64 _han_muc_tin_dung;
        public Int64 han_muc_tin_dung
        {
            get { return _han_muc_tin_dung; }
            set { _han_muc_tin_dung = value; }
        }

        private Int64 _han_muc_bao_lanh;
        public Int64 han_muc_bao_lanh
        {
            get { return _han_muc_bao_lanh; }
            set { _han_muc_bao_lanh = value; }
        }

        private string _muc_dich_vay;
        public string muc_dich_vay
        {
            get { return _muc_dich_vay; }
            set { _muc_dich_vay = value; }
        }

        private string _lai_suat;
        public string lai_suat
        {
            get { return _lai_suat; }
            set { _lai_suat = value; }
        }

        private string _phuong_thuc_tra_lai;
        public string phuong_thuc_tra_lai
        {
            get { return _phuong_thuc_tra_lai; }
            set { _phuong_thuc_tra_lai = value; }
        }

        private string _phuong_thuc_tra_goc;
        public string phuong_thuc_tra_goc
        {
            get { return _phuong_thuc_tra_goc; }
            set { _phuong_thuc_tra_goc = value; }
        }

        private string _thoi_han_vay;
        public string thoi_han_vay
        {
            get { return _thoi_han_vay; }
            set { _thoi_han_vay = value; }
        }

        private string _han_tra_no_cuoi;
        public string han_tra_no_cuoi
        {
            get { return _han_tra_no_cuoi; }
            set { _han_tra_no_cuoi = value; }
        }

        private string _thoi_han_rut_von;
        public string thoi_han_rut_von
        {
            get { return _thoi_han_rut_von; }
            set { _thoi_han_rut_von = value; }
        }

        private string _thoi_gian_an_han;
        public string thoi_gian_an_han
        {
            get { return _thoi_gian_an_han; }
            set { _thoi_gian_an_han = value; }
        }

        private string _bao_dam_tien_vay;
        public string bao_dam_tien_vay
        {
            get { return _bao_dam_tien_vay; }
            set { _bao_dam_tien_vay = value; }
        }

        private string _hinh_thuc_bao_dam;
        public string hinh_thuc_bao_dam
        {
            get { return _hinh_thuc_bao_dam; }
            set { _hinh_thuc_bao_dam = value; }
        }

        private string _tai_san_bao_dam;
        public string tai_san_bao_dam
        {
            get { return _tai_san_bao_dam; }
            set { _tai_san_bao_dam = value; }
        }

        private Int64 _gia_tri_tai_san_bao_dam;
        public Int64 gia_tri_tai_san_bao_dam
        {
            get { return _gia_tri_tai_san_bao_dam; }
            set { _gia_tri_tai_san_bao_dam = value; }
        }

        private string _dai_dien_agribank;
        public string dai_dien_agribank
        {
            get { return _dai_dien_agribank; }
            set { _dai_dien_agribank = value; }
        }

        private string _kiem_soat_tin_dung;
        public string kiem_soat_tin_dung
        {
            get { return _kiem_soat_tin_dung; }
            set { _kiem_soat_tin_dung = value; }
        }

        private string _can_bo_tin_dung;
        public string can_bo_tin_dung
        {
            get { return _can_bo_tin_dung; }
            set { _can_bo_tin_dung = value; }
        }

        private string _ma_hd_vay_cu;
        public string ma_hd_vay_cu
        {
            get { return _ma_hd_vay_cu; }
            set { _ma_hd_vay_cu = value; }
        }

        private string _ngay_hd_vay_cu;
        public string ngay_hd_vay_cu
        {
            get { return _ngay_hd_vay_cu; }
            set { _ngay_hd_vay_cu = value; }
        }

        private string _ngay_hd_vay;
        public string ngay_hd_vay
        {
            get { return _ngay_hd_vay; }
            set { _ngay_hd_vay = value; }
        }

        #endregion Instance Properties

        public Hopdongvay(string[] hop_dong_vay)
        {
            this._ma_hd_vay = hop_dong_vay[0];
            this._ma_cn = hop_dong_vay[1];
            this._ma_kh_vay = hop_dong_vay[2];
            this._phuong_thuc = hop_dong_vay[3];
            this._tong_han_muc_tin_dung = Convert.ToInt64(hop_dong_vay[4]);
            this._han_muc_tin_dung = Convert.ToInt64(hop_dong_vay[5]);
            this._han_muc_bao_lanh = Convert.ToInt64(hop_dong_vay[6]);
            this._muc_dich_vay = hop_dong_vay[7];
            this._lai_suat = hop_dong_vay[8];
            this._phuong_thuc_tra_lai = hop_dong_vay[9];
            this._phuong_thuc_tra_goc = hop_dong_vay[10];
            this._thoi_han_vay = hop_dong_vay[11];
            this._han_tra_no_cuoi = hop_dong_vay[12];
            this._thoi_han_rut_von = hop_dong_vay[13];
            this._thoi_gian_an_han = hop_dong_vay[14];
            this._bao_dam_tien_vay = hop_dong_vay[15];
            this._hinh_thuc_bao_dam = hop_dong_vay[16];
            this._tai_san_bao_dam = hop_dong_vay[17];
            this._gia_tri_tai_san_bao_dam = Convert.ToInt64(hop_dong_vay[18]);
            this._dai_dien_agribank = hop_dong_vay[19];
            this._kiem_soat_tin_dung = hop_dong_vay[20];
            this._can_bo_tin_dung = hop_dong_vay[21];
            this._ma_hd_vay_cu = hop_dong_vay[22];
            this._ngay_hd_vay_cu = hop_dong_vay[23];
            this._ngay_hd_vay = hop_dong_vay[24];
        }
        
        public Hopdongvay(DataRow row)
        {
            this._ma_hd_vay = row["MA_HD_VAY"].ToString();
            this._ma_cn = row["MA_CN"].ToString();
            this._ma_kh_vay = row["MA_KH_VAY"].ToString();
            this._phuong_thuc = row["PHUONG_THUC"].ToString();
            this._tong_han_muc_tin_dung = Convert.ToInt64(row["TONG_HAN_MUC_TIN_DUNG"].ToString());
            this._han_muc_tin_dung = Convert.ToInt64(row["HAN_MUC_TIN_DUNG"].ToString());
            this._han_muc_bao_lanh = Convert.ToInt64(row["HAN_MUC_BAO_LANH"].ToString());
            this._muc_dich_vay = row["MUC_DICH_VAY"].ToString();
            this._lai_suat = row["LAI_SUAT"].ToString();
            this._phuong_thuc_tra_lai = row["PHUONG_THUC_TRA_LAI"].ToString();
            this._phuong_thuc_tra_goc = row["PHUONG_THUC_TRA_GOC"].ToString();
            this._thoi_han_vay = row["THOI_HAN_VAY"].ToString();
            this._han_tra_no_cuoi = row["HAN_TRA_NO_CUOI"].ToString();
            this._thoi_han_rut_von = row["THOI_HAN_RUT_VON"].ToString();
            this._thoi_gian_an_han = row["THOI_GIAN_AN_HAN"].ToString();
            this._bao_dam_tien_vay = row["BAO_DAM_TIEN_VAY"].ToString();
            this._hinh_thuc_bao_dam = row["HINH_THUC_BAO_DAM"].ToString();
            this._tai_san_bao_dam = row["TAI_SAN_BAO_DAM"].ToString();
            this._gia_tri_tai_san_bao_dam = Convert.ToInt64(row["GIA_TRI_TAI_SAN_BAO_DAM"].ToString());
            this._dai_dien_agribank = row["DAI_DIEN_AGRIBANK"].ToString();
            this._kiem_soat_tin_dung = row["KIEM_SOAT_TIN_DUNG"].ToString();
            this._can_bo_tin_dung = row["CAN_BO_TIN_DUNG"].ToString();
            this._ma_hd_vay_cu = row["MA_HD_VAY_CU"].ToString();
            this._ngay_hd_vay_cu = row["NGAY_HD_VAY_CU"].ToString();
            this._ngay_hd_vay = row["NGAY_HD_VAY"].ToString();
        }
    }
}
