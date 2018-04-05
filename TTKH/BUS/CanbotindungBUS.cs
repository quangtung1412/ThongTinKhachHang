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
    class CanbotindungBUS
    {
        canbotindungDAL dal = new canbotindungDAL();
        //public static List<Canbotindung> Danhsach_CBTD(string ma_cn)
        //{
        //    return canbotindungDAL.Danhsach_CBTD(ma_cn);
        //}

        public Canbotindung CBTD_theo_ten_dang_nhap(string ten_dang_nhap)
        {
            return canbotindungDAL.CBTD_theo_ten_dang_nhap(ten_dang_nhap);
        }

        public bool Kiem_tra_trung_ten_dang_nhap(string ten_dang_nhap)
        {
            return dal.Kiem_tra_trung_ten_dang_nhap(ten_dang_nhap);
        }
        public static DataTable tbl_CBTD(string ma_cn)
        {
            return canbotindungDAL.tbl_CBTD(ma_cn);
        }

        public static DataTable tbl_CBTD_chua_kich_hoat(string ma_cn)
        {
            return canbotindungDAL.tbl_CBTD_chua_kich_hoat(ma_cn);
        }

        public static DataTable tbl_CBTD_CV(string ma_cn, string chuc_vu)
        {
            return canbotindungDAL.tbl_CBTD_CV(ma_cn,chuc_vu);
        }

        public static DataTable tbl_CBTD_CV_chua_kich_hoat(string ma_cn, string chuc_vu)
        {
            return canbotindungDAL.tbl_CBTD_CV_chua_kich_hoat(ma_cn, chuc_vu);
        }

        public static DataTable tbl_CBTD_CV_MA_PB(string ma_cn, string chuc_vu, string ma_pb)
        {
            return canbotindungDAL.tbl_CBTD_CV_MA_PB(ma_cn, chuc_vu, ma_pb);
        }

        public bool Them_CBTD(Canbotindung cb)
        {
            return dal.Them_CBTD(cb);
        }

        public bool Capnhat_CBTD(Canbotindung cb, string ten_dang_nhap)
        {
            return dal.Capnhat_CBTD(cb,ten_dang_nhap);
        }

        public bool Xoa_CBTD(string ten_dang_nhap)
        {
            return dal.Xoa_CBTD(ten_dang_nhap);
        }

        public bool Xac_thuc_dang_nhap( string ten_dang_nhap, string mat_khau)
        {
            return dal.Xac_thuc_dang_nhap(ten_dang_nhap, mat_khau);
        }

        public bool DOI_MAT_KHAU_CBTD(string ten_dang_nhap, string mat_khau)
        {
            return dal.DOI_MAT_KHAU_CBTD(ten_dang_nhap,mat_khau);
        }
    }
}
