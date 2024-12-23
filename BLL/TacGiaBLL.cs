using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TacGiaBLL
    {
        public static List<TacGiaDTO> LayTacGia()
        {
            return TacGiaDAL.LayTacGia();
        }
        public static bool ThemTacGia(TacGiaDTO tg)
        {
            return TacGiaDAL.ThemTacGia(tg);
        }
        public static TacGiaDTO TimTGTheoMa(string ma)
        {
            return TacGiaDAL.TimTGTheoMa(ma);
        }
        public static bool SuaTacGia(TacGiaDTO tg)
        {
            return TacGiaDAL.SuaTacGia(tg);
        }
        public static bool XoaTacGia(TacGiaDTO tg)
        {
            return TacGiaDAL.XoaTacGia(tg);
        }
        public static List<TacGiaDTO> TimSachTheoTen(string ten)
        {
            return TacGiaDAL.TimSachTheoTen(ten);
        }
    }
}
