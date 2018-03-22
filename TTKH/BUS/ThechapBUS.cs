using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGRIBANKHD.Entities;
using AGRIBANKHD.DAL;

namespace AGRIBANKHD.BUS
{
    class ThechapBUS
    {
        thechapDAL dal = new thechapDAL();
        public static List<Thechap> Danhsach_TC(string ma_hd_vay, string ma_cn, string ma_kh_vay)
        {
            return thechapDAL.Danhsach_TC(ma_hd_vay,ma_cn,ma_kh_vay);
        }
    }
}
