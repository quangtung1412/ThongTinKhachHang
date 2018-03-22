using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data;
using System.Globalization;
namespace AGRIBANKHD.Entities
{
    class Diemgiaodich
    {
        private Int32 _id_diem_giao_dich;
        public Int32 id_diem_giao_dich
        {
            get { return _id_diem_giao_dich; }
            set { _id_diem_giao_dich = value; }
        }

        private string _ma_chi_nhanh;
        public string ma_chi_nhanh
        {
            get { return _ma_chi_nhanh; }
            set { _ma_chi_nhanh = value; }
        }

        private string _ten_chi_nhanh;
        public string ten_chi_nhanh
        {
            get { return _ten_chi_nhanh; }
            set { _ten_chi_nhanh = value; }
        }

        private string _ma_diem_giao_dich;
        public string ma_diem_giao_dich
        {
            get { return _ma_diem_giao_dich; }
            set { _ma_diem_giao_dich = value; }
        }

        private string _ten_diem_giao_dich;
        public string ten_diem_giao_dich
        {
            get { return _ten_diem_giao_dich; }
            set { _ten_diem_giao_dich = value; }
        }

        private string _ten_he_thong_ung_dung;
        public string ten_he_thong_ung_dung
        {
            get { return _ten_he_thong_ung_dung; }
            set { _ten_he_thong_ung_dung = value; }
        }

        public Diemgiaodich (DataRow row)
        {
            this._id_diem_giao_dich = Convert.ToInt32(row["ID_DIEM_GIAO_DICH"].ToString());
            this._ma_chi_nhanh = row["MA_CHI_NHANH"].ToString();
            this._ten_chi_nhanh = row["TEN_CHI_NHANH"].ToString();
            this._ma_diem_giao_dich = row["MA_DIEM_GIAO_DICH"].ToString();
            this._ten_diem_giao_dich = row["TEN_DIEM_GIAO_DICH"].ToString();
            this._ten_he_thong_ung_dung = row["TEN_HE_THONG_UNG_DUNG"].ToString();
        }
    
        public Diemgiaodich (string[] diem_giao_dich)
        {
            this._id_diem_giao_dich = Convert.ToInt32(diem_giao_dich[0]);
            this._ma_chi_nhanh = diem_giao_dich[1];
            this._ten_chi_nhanh = diem_giao_dich[2];
            this._ma_diem_giao_dich = diem_giao_dich[3];
            this._ten_diem_giao_dich = diem_giao_dich[4];
            this._ten_he_thong_ung_dung = diem_giao_dich[5];
        }
    }
}
