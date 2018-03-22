using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGRIBANKHD.Entities;
using AGRIBANKHD.DAL;

namespace AGRIBANKHD.BUS
{
    class PhonggiaodichBUS
    {
        public static List<Phonggiaodich> DS_PGD(string ma_cn)
        {
            return phonggiaodichDAL.DS_PGD(ma_cn);
        }

        public static Phonggiaodich PGD_THEO_MA(string ma_pgd)
        {
            return phonggiaodichDAL.PGD_THEO_MA(ma_pgd);
        }
    }
}
