using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data;
using System.Globalization;

namespace AGRIBANKHD.Entities
{
    class Giaynhanno
    {
        private Int32 _id_giay_nhan_no;
        public Int32 id_giay_nhan_no
        {
            get { return _id_giay_nhan_no; }
            set { _id_giay_nhan_no = value; }
        }

        private string _ma_hd_vay;
        public string ma_hd_vay
        {
            get { return _ma_hd_vay; }
            set { _ma_hd_vay = value; }
        }

        private string _ngay_nhan_no;
        public string ngay_nhan_no
        {
            get { return _ngay_nhan_no; }
            set { _ngay_nhan_no = value; }
        }

        private Int64 _du_no_truoc;
        public Int64 du_no_truoc
        {
            get { return _du_no_truoc; }
            set { _du_no_truoc = value; }
        }

        private Int64 _so_tien_nhan_no;
        public Int64 so_tien_nhan_no
        {
            get { return _so_tien_nhan_no; }
            set { _so_tien_nhan_no = value; }
        }

        private Int64 _du_no_hien_tai;
        public Int64 du_no_hien_tai
        {
            get { return _du_no_hien_tai; }
            set { _du_no_hien_tai = value; }
        }

        private string _nguoi_thu_huong_1;
        public string nguoi_thu_huong_1
        {
            get { return _nguoi_thu_huong_1; }
            set { _nguoi_thu_huong_1 = value; }
        }

        private string _so_tai_khoan_1;
        public string so_tai_khoan_1
        {
            get { return _so_tai_khoan_1; }
            set { _so_tai_khoan_1 = value; }
        }

        private string _ngan_hang_1;
        public string ngan_hang_1
        {
            get { return _ngan_hang_1; }
            set { _ngan_hang_1 = value; }
        }

        private Int64 _so_tien_nhan_no_1;
        public Int64 so_tien_nhan_no_1
        {
            get { return _so_tien_nhan_no_1; }
            set { _so_tien_nhan_no_1 = value; }
        }

        private string _nguoi_thu_huong_2;
        public string nguoi_thu_huong_2
        {
            get { return _nguoi_thu_huong_2; }
            set { _nguoi_thu_huong_2 = value; }
        }

        private string _so_tai_khoan_2;
        public string so_tai_khoan_2
        {
            get { return _so_tai_khoan_2; }
            set { _so_tai_khoan_2 = value; }
        }

        private string _ngan_hang_2;
        public string ngan_hang_2
        {
            get { return _ngan_hang_2; }
            set { _ngan_hang_2 = value; }
        }

        private Int64 _so_tien_nhan_no_2;
        public Int64 so_tien_nhan_no_2
        {
            get { return _so_tien_nhan_no_2; }
            set { _so_tien_nhan_no_2 = value; }
        }

        private string _nguoi_thu_huong_3;
        public string nguoi_thu_huong_3
        {
            get { return _nguoi_thu_huong_3; }
            set { _nguoi_thu_huong_3 = value; }
        }

        private string _so_tai_khoan_3;
        public string so_tai_khoan_3
        {
            get { return _so_tai_khoan_3; }
            set { _so_tai_khoan_3 = value; }
        }

        private string _ngan_hang_3;
        public string ngan_hang_3
        {
            get { return _ngan_hang_3; }
            set { _ngan_hang_3 = value; }
        }

        private Int64 _so_tien_nhan_no_3;
        public Int64 so_tien_nhan_no_3
        {
            get { return _so_tien_nhan_no_3; }
            set { _so_tien_nhan_no_3 = value; }
        }

        private string _so_giay_nhan_no;
        public string so_giay_nhan_no
        {
            get { return _so_giay_nhan_no; }
            set { _so_giay_nhan_no = value; }
        }

        private string _han_tra_no_goc;
        public string han_tra_no_goc
        {
            get { return _han_tra_no_goc; }
            set { _han_tra_no_goc = value; }
        }

        private string _muc_dich_su_dung_tien_vay;
        public string muc_dich_su_dung_tien_vay
        {
            get { return _muc_dich_su_dung_tien_vay; }
            set { _muc_dich_su_dung_tien_vay = value; }
        }

        private string _chung_tu_giai_ngan;
        public string chung_tu_giai_ngan
        {
            get { return _chung_tu_giai_ngan; }
            set { _chung_tu_giai_ngan = value; }
        }

        private string _ngay_de_xuat_giai_ngan;
        public string ngay_de_xuat_giai_ngan
        {
            get { return _ngay_de_xuat_giai_ngan; }
            set { _ngay_de_xuat_giai_ngan = value; }
        }
        public Giaynhanno(string[] giay_nhan_no)
        {
            this._id_giay_nhan_no = Convert.ToInt32(giay_nhan_no[0]);
            this._ma_hd_vay = giay_nhan_no[1];
            this._ngay_nhan_no = giay_nhan_no[2];
            this._du_no_truoc = Convert.ToInt64(giay_nhan_no[3]);
            this._so_tien_nhan_no = Convert.ToInt64(giay_nhan_no[4]);
            this._du_no_hien_tai = Convert.ToInt64(giay_nhan_no[5]);
            this._nguoi_thu_huong_1 = giay_nhan_no[6];
            this._so_tai_khoan_1 = giay_nhan_no[7];
            this._ngan_hang_1 = giay_nhan_no[8];
            this._so_tien_nhan_no_1 = Convert.ToInt64(giay_nhan_no[9]);
            this._nguoi_thu_huong_2 = giay_nhan_no[10];
            this._so_tai_khoan_2 = giay_nhan_no[11];
            this._ngan_hang_2 = giay_nhan_no[12];
            this._so_tien_nhan_no_2 = Convert.ToInt64(giay_nhan_no[13]);
            this._nguoi_thu_huong_3 = giay_nhan_no[14];
            this._so_tai_khoan_3 = giay_nhan_no[15];
            this._ngan_hang_3 = giay_nhan_no[16];
            this._so_tien_nhan_no_3 = Convert.ToInt64(giay_nhan_no[17]);
            this._so_giay_nhan_no = giay_nhan_no[18];
            this._han_tra_no_goc = giay_nhan_no[19];
            this._muc_dich_su_dung_tien_vay = giay_nhan_no[20];
            this._chung_tu_giai_ngan = giay_nhan_no[21];
            this._ngay_de_xuat_giai_ngan = giay_nhan_no[22];
        }

        public Giaynhanno(DataRow row)
        {
            this._id_giay_nhan_no = Convert.ToInt32(row["ID_GIAY_NHAN_NO"].ToString());
            this._ma_hd_vay = row["MA_HD_VAY"].ToString();
            this._ngay_nhan_no = row["NGAY_NHAN_NO"].ToString();
            this._du_no_truoc = Convert.ToInt64(row["DU_NO_TRUOC"].ToString());
            this._so_tien_nhan_no = Convert.ToInt64(row["SO_TIEN_NHAN_NO"].ToString());
            this._du_no_hien_tai = Convert.ToInt64(row["DU_NO_HIEN_TAI"].ToString());
            this._nguoi_thu_huong_1 = row["NGUOI_THU_HUONG_1"].ToString();
            this._so_tai_khoan_1 = row["SO_TAI_KHOAN_1"].ToString();
            this._ngan_hang_1 = row["NGAN_HANG_1"].ToString();
            this._so_tien_nhan_no_1 = Convert.ToInt64(row["SO_TIEN_NHAN_NO_1"].ToString());
            this._nguoi_thu_huong_2 = row["NGUOI_THU_HUONG_2"].ToString();
            this._so_tai_khoan_2 = row["SO_TAI_KHOAN_2"].ToString();
            this._ngan_hang_2 = row["NGAN_HANG_2"].ToString();
            this._so_tien_nhan_no_2 = Convert.ToInt64(row["SO_TIEN_NHAN_NO_2"].ToString());
            this._nguoi_thu_huong_3 = row["NGUOI_THU_HUONG_3"].ToString();
            this._so_tai_khoan_3 = row["SO_TAI_KHOAN_3"].ToString();
            this._ngan_hang_3 = row["NGAN_HANG_3"].ToString();
            this._so_tien_nhan_no_3 = Convert.ToInt64(row["SO_TIEN_NHAN_NO_3"].ToString());
            this._so_giay_nhan_no = row["SO_GIAY_NHAN_NO"].ToString();
            this._han_tra_no_goc = row["HAN_TRA_NO_GOC"].ToString();
            this._muc_dich_su_dung_tien_vay = row["MUC_DICH_SU_DUNG_TIEN_VAY"].ToString();
            this._chung_tu_giai_ngan = row["CHUNG_TU_GIAI_NGAN"].ToString();
            this._ngay_de_xuat_giai_ngan = row["NGAY_DE_XUAT_GIAI_NGAN"].ToString();
        }
    }
}
