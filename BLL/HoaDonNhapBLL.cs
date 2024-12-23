using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HoaDonNhapBLL
    {
        public static List<HoaDonNhap> LayHDNhap()
        {
            return HoaDonNhapDAL.LayHDNhap();
        }
        public static bool ThemHDN(HoaDonNhap hdb)
        {
            return HoaDonNhapDAL.ThemHDN(hdb);
        }
        public static HoaDonNhap TimHDNTheoMa(string ma)
        {
            return HoaDonNhapDAL.TimHDNTheoMa(ma);
        }
        public static bool SuaHDN(HoaDonNhap hdb)
        {
            return HoaDonNhapDAL.SuaHDN(hdb);
        }
        public static bool XoaHDN(HoaDonNhap hdb)
        {
            return HoaDonNhapDAL.XoaHDN(hdb);
        }
    }
}
