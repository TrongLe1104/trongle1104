using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HoaDonBanBLL
    {
        public static List<HoaDonBanDTO> LayHoaDon()
        {
            return HoaDonDAL.LayHoaDon();
        }
        public static bool ThemHDB(HoaDonBanDTO hdb)
        {
            return HoaDonDAL.ThemHDB(hdb);
        }
        public static HoaDonBanDTO TimHDBTheoMa(string ma)
        {
            return HoaDonDAL.TimHDBTheoMa(ma);
        }
        public static bool SuaHDB(HoaDonBanDTO hdb)
        {
            return HoaDonDAL.SuaHDB(hdb);
        }
        public static bool XoaHDB(HoaDonBanDTO hdb)
        {
            return HoaDonDAL.XoaHDB(hdb);
        }
    }
}
