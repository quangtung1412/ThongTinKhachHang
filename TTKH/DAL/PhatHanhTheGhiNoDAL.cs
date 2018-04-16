using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AGRIBANKHD.Entities;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using AGRIBANKHD.Utilities;

namespace AGRIBANKHD.DAL
{
    class PhatHanhTheGhiNoDAL
    {
        public static KhachHangDV TimKiemKH_TheoMaKH(string makh) {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@makh", makh)
            };
            DataTable dt = db.dt("DV_TimKiemKH_TheoMaKH", Params);
            if (dt.Rows.Count == 0)
                return null;
            else
            {
                KhachHangDV kh = new KhachHangDV(dt.Rows[0]);
                return kh;
            }
        }

        public static KhachHangDV TimKiemKH_TheoCMND(string cmnd)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@cmnd", cmnd)
            };
            DataTable dt = db.dt("DV_TimKiemKH_TheoCMND", Params);
            if (dt.Rows.Count == 0)
                return null;
            else
            {
                KhachHangDV kh = new KhachHangDV(dt.Rows[0]);
                return kh;
            }
        }

        public static DataTable TimSoTK(string makh) {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@makh", makh)
            };
            DataTable dt = db.dt("TimSoTK", Params);
            return dt;
        }

        public static void ThemKH(KhachHangDV kh, string so_tk) {
            DataAccess db = new DataAccess();
            int gt = 0;
            if (kh.gioi_tinh) gt = 1;

            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@cmnd", kh.cmt),
            new SqlParameter("@hoten", kh.ho_ten),
            new SqlParameter("@makh", kh.ma_KH),
            new SqlParameter("@dienthoai", kh.dien_thoai),
            new SqlParameter("@email", kh.email),
            new SqlParameter("@diachi", kh.dia_chi),
            new SqlParameter("@ngaysinh", kh.ngay_sinh),
            new SqlParameter("@ngaycap", kh.ngay_cap),
            new SqlParameter("@noicap", kh.noi_cap),
            new SqlParameter("@quoctich", kh.quoc_tich),
            new SqlParameter("@sotk", so_tk),
            new SqlParameter("@gioitinh", gt)
            };
            db.dt("ThemKH", Params);
        }

        public static void SuaKH(KhachHangDV kh, string so_tk)
        {
            DataAccess db = new DataAccess();

            int gt = 0;
            if (kh.gioi_tinh) gt = 1;

            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@cmnd", kh.cmt),
            new SqlParameter("@hoten", kh.ho_ten),
            new SqlParameter("@makh", kh.ma_KH),
            new SqlParameter("@dienthoai", kh.dien_thoai),
            new SqlParameter("@email", kh.email),
            new SqlParameter("@diachi", kh.dia_chi),
            new SqlParameter("@ngaysinh", kh.ngay_sinh),
            new SqlParameter("@ngaycap", kh.ngay_cap),
            new SqlParameter("@noicap", kh.noi_cap),
            new SqlParameter("@quoctich", kh.quoc_tich),
            new SqlParameter("@sotk", so_tk),
            new SqlParameter("@gioitinh", gt)
            };
            db.dt("SuaKH", Params);
        }

        public static NguoiDaiDien[] DanhSachNguoiDaiDien(string mapb)
        {
            try
            {
                DataAccess db = new DataAccess();
                SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("@mapb", mapb)
                };
                DataTable dt = db.dt("DS_NGUOI_DAI_DIEN", Params);
                NguoiDaiDien[] dsNguoiDaiDien = new NguoiDaiDien[dt.Rows.Count];
                for (int i = 0; i < dsNguoiDaiDien.Length; i++)
                {
                    dsNguoiDaiDien[i] = new NguoiDaiDien(dt.Rows[i]);
                }
                return dsNguoiDaiDien;
            }
            catch
            {
                DAL.ErrorMessageDAL.DataAccessError();
                return null;
            }

        }

        public static void DangKyThe(string soTK, string loaiThe, string hangThe, string hinhThucPhatHanh, string hinhThucNhanThe, string dtdd, int hmgd, int baoHiem, string user, string mapb)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]{
                    new SqlParameter("@sotk", soTK),
                    new SqlParameter("@loaithe", loaiThe),
                    new SqlParameter("@hangthe", hangThe),
                    new SqlParameter("@hinhthucphathanh", hinhThucPhatHanh),
                    new SqlParameter("@hinhthucnhanthe", hinhThucNhanThe),
                    new SqlParameter("@dtdd", dtdd),
                    new SqlParameter("@hmgd", hmgd),
                    new SqlParameter("@baohiem", baoHiem),
                    new SqlParameter("@userid", user),
                    new SqlParameter("@mapb", mapb)
                };
            db.dt("DV_INSERT_THEODOITHE", Params);
        }

        public static DataTable TimThe(string soTK, string loaiThe)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]{
                    new SqlParameter("@sotk", soTK),
                    new SqlParameter("@loaithe", loaiThe)
            };
            DataTable dt = db.dt("DV_TIMTHE", Params);
            return dt;
        }


        public static string LayTenPhongBan(string maPb)
        {
            try
            {
                DataAccess db = new DataAccess();
                SqlParameter[] Params = new SqlParameter[]{
                    new SqlParameter("@mapb", maPb)
                };
                DataTable dt = db.dt("DV_LAYTENPHONGBAN", Params);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["TENPB"].ToString();
                }
                return Thong_tin_dang_nhap.ten_cn;
            }
            catch
            {
                return "";
            }
        }

    }
}
