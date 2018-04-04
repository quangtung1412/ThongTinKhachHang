using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AGRIBANKHD.Entities;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace AGRIBANKHD.DAL
{
    class PhatHanhTheGhiNoDAL
    {
        public static KhachHangDV TimKiemKH(string soCmnd) {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@cmnd", soCmnd)
            };
            DataTable dt = db.dt("PhatHanhTheGhiNo_TimKiemKH", Params);
            if (dt.Rows.Count == 0)
                return null;
            else
            {
                KhachHangDV kh = new KhachHangDV(dt.Rows[0]);
                return kh;
            }
        }

        public static DataTable TimSoTK(string cmnd) {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]
            {
            new SqlParameter("@cmnd", cmnd)
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
    }
}
