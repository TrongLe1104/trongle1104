using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class KhachHangBLL
    {
        public static List<KhachHangDTO> LayKhachHang()
        {
            return KhachHangDAL.LayKhachHang();
        }
        public static bool ThemKH(KhachHangDTO kh)
        {
            return KhachHangDAL.ThemKH(kh);
        }
        public static KhachHangDTO TimKHTheoMa(string ma)
        {
            return KhachHangDAL.TimKHTheoMa(ma);
        }
        public static bool SuaKH(KhachHangDTO kh)
        {
            return KhachHangDAL.SuaKH(kh);
        }
        public static bool XoaKH(KhachHangDTO kh)
        {
            return KhachHangDAL.XoaKH(kh);
        }
        public static List<KhachHangDTO> TimKHTheoTen(string ten)
        {
            return KhachHangDAL.TimKHTheoTen(ten);
        }
    }
}
