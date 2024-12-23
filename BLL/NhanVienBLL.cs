using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NhanVienBLL
    {
        public static List<NhanVienDTO> LayNhanVien()
        {
            return NhanVienDAL.LayNhanVien();
        }
        public static bool ThemNV(NhanVienDTO nv)
        {
            return NhanVienDAL.ThemNV(nv);
        }
        public static NhanVienDTO TimNVTheoMa(string ma)
        {
            return NhanVienDAL.TimNVTheoMa(ma);
        }
        public static bool SuaNV(NhanVienDTO nv)
        {
            return NhanVienDAL.SuaNV(nv);
        }
        public static bool XoaNV(NhanVienDTO nv)
        {
            return NhanVienDAL.XoaNV(nv);
        }
        public static List<NhanVienDTO> TimNVTheoTen(string ten)
        {
            return NhanVienDAL.TimNVTheoTen(ten);
        }
    }
}

