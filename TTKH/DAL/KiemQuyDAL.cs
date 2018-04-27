using AGRIBANKHD.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AGRIBANKHD.DAL
{
    class KiemQuyDAL
    {
        public static DataTable DV_DSNhanVien_MaCN(string macn)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("@macn", macn)
            };
            return db.dt("DV_DSNHANVIEN_MACN", Params);
        }

        public static DataTable DV_ATM_MACN()
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("@macn", Thong_tin_dang_nhap.ma_cn)
            };
            return db.dt("DV_ATM_MACN", Params);
        }

        public static DataTable DV_SEARCH_KIEMQUY(DateTime tuNgay, DateTime denNgay, string id)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[] { 
                new SqlParameter("@tungay", tuNgay),
                new SqlParameter("@denngay", denNgay),
                new SqlParameter("@id", id)
            };

            return db.dt("DV_SEARCH_KIEMQUY", Params);
        }

        public static void DV_INSERT_KIEMQUY(
            DateTime tuNgay,
            DateTime denNgay,
            string id,
            string tpKiemQuy,
            int qtTienTHT,
            int qtMonCHT,
            int qtTienCHT,
            DateTime timeTCO,
            DateTime timeCO,
            DateTime timeCI,
            int soDuTCO,
            int soDuCO,
            int soDuCI,
            string ghiChuTCO,
            string ghiChuCO,
            string ghiChuCI,
            DateTime timeSC,
            DateTime timeCE,
            int fimiSC50,
            int fimiSC100,
            int fimiSC200,
            int fimiSC500,
            int fimiCE50,
            int fimiCE100,
            int fimiCE200,
            int fimiCE500,
            int demB50,
            int demB100,
            int demB200,
            int demB500,
            int demCC50,
            int demCC100,
            int demCC200,
            int demCC500,
            int demCL50,
            int demCL100,
            int demCL200,
            int demCL500,
            int thuaThieu,
            string nguyenNhan,
            string khacPhuc
        )
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]{
            new SqlParameter("@tungay", tuNgay),
            new SqlParameter("@denngay", denNgay),
            new SqlParameter("@atmid", id),
            new SqlParameter("@canbo", tpKiemQuy),
            new SqlParameter("@qttientht", qtTienTHT),
            new SqlParameter("@qtmoncht", qtMonCHT),
            new SqlParameter("@qttiencht", qtTienCHT),
            new SqlParameter("@time_tco", timeTCO),
            new SqlParameter("@time_co", timeCO),
            new SqlParameter("@time_ci", timeCI),
            new SqlParameter("@sodu_tco", soDuTCO),
            new SqlParameter("@sodu_co", soDuCO),
            new SqlParameter("@sodu_ci", soDuCI),
            new SqlParameter("@ghichu_tco", ghiChuTCO),
            new SqlParameter("@ghichu_co", ghiChuCO),
            new SqlParameter("@ghichu_ci", ghiChuCI),
            new SqlParameter("@fimitimesc", timeSC),
            new SqlParameter("@fimitimece", timeCE),
            new SqlParameter("@fimisc50", fimiSC50),
            new SqlParameter("@fimisc100", fimiSC100),
            new SqlParameter("@fimisc200", fimiSC200),
            new SqlParameter("@fimisc500", fimiSC500),
            new SqlParameter("@fimice50", fimiCE50),
            new SqlParameter("@fimice100", fimiCE100),
            new SqlParameter("@fimice200", fimiCE200),
            new SqlParameter("@fimice500", fimiCE500),
            new SqlParameter("@demb50", demB50),
            new SqlParameter("@demb100", demB100),
            new SqlParameter("@demb200", demB200),
            new SqlParameter("@demb500", demB500),
            new SqlParameter("@demcc50", demCC50),
            new SqlParameter("@demcc100", demCC100),
            new SqlParameter("@demcc200", demCC200),
            new SqlParameter("@demcc500", demCC500),
            new SqlParameter("@demcl50", demCL50),
            new SqlParameter("@demcl100", demCL100),
            new SqlParameter("@demcl200", demCL200),
            new SqlParameter("@demcl500", demCL500),
            new SqlParameter("@thuathieu", thuaThieu),
            new SqlParameter("@nguyennhan", nguyenNhan),
            new SqlParameter("@khacphuc", khacPhuc)
            };
            db.dt("DV_INSERT_KIEMQUY", Params);
        }
    }
}
