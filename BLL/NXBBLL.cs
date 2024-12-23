using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BLL.NXBBLL;

namespace BLL
{
    public class NXBBLL
    {
        public static List<NXBDTO> LayNXB()
        {
            return NXBDAL.LayNXB();
        }
        public static bool ThemNXB(NXBDTO nxb)
        {
            return NXBDAL.ThemNXB(nxb);
        }
        public static NXBDTO TimNXBTheoMa(string ma)
        {
            return NXBDAL.TimNXBTheoMa(ma);
        }
        public static bool SuaNXB(NXBDTO nxb)
        {
            return NXBDAL.SuaNXB(nxb);
        }
        public static bool XoaNXB(NXBDTO nxb)
        {
            return NXBDAL.XoaNXB(nxb);
        }
        public static List<NXBDTO> TimSachTheoTen(string ten)
        {
            return NXBDAL.TimSachTheoTen(ten);
        }
    }
}
