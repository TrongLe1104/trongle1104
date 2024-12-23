using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SachBLL
    {
        public static List<SachDTO> LaySach()
        {
            return SachDAL.LaySach();
        }
        public static bool ThemSach(SachDTO s)
        {
            return SachDAL.ThemSach(s);
        }
        public static SachDTO TimSachTheoMa(string ma)
        {
            return SachDAL.TimSachTheoMa(ma);
        }
        public static bool SuaSach(SachDTO s)
        {
            return SachDAL.SuaSach(s);
        }
        public static bool XoaSach(SachDTO s)
        {
            return SachDAL.XoaSach(s);
        }
        public static List<SachDTO> TimSachTheoTen(string ten)
        {
            return SachDAL.TimSachTheoTen(ten);
        }
    }
}
