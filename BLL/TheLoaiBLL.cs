using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TheLoaiBLL
    {
        public static List<TheLoaiDTO> LayTheLoai()
        {
            return TheLoaiDAL.LayTheLoai();
        }
        public static bool ThemTheLoai(TheLoaiDTO tl)
        {
            return TheLoaiDAL.ThemTheLoai(tl);
        }
        public static TheLoaiDTO TimTheLoaiTheoMa(string ma)
        {
            return TheLoaiDAL.TimTheLoaiTheoMa(ma);
        }
        public static bool SuaTheLoai(TheLoaiDTO tl)
        {
            return TheLoaiDAL.SuaTheLoai(tl);
        }
        public static bool XoaTheLoai(TheLoaiDTO tl)
        {
            return TheLoaiDAL.XoaTheLoai(tl);
        }
        public static List<TheLoaiDTO> TimSachTheoTen(string ten)
        {
            return TheLoaiDAL.TimSachTheoTen(ten);
        }
    }
}
