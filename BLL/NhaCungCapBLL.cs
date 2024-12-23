using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NhaCungCapBLL
    {
        public static List<NhaCungCapDTO> LayNCC()
        {
            return NCCDAL.LayNCC();
        }
        public static bool ThemNCC(NhaCungCapDTO ncc)
        {
            return NCCDAL.ThemNCC(ncc);
        }
        public static NhaCungCapDTO TimTheLoaiTheoMa(string ma)
        {
            return NCCDAL.TimTheLoaiTheoMa(ma);
        }
        public static bool SuaNCC(NhaCungCapDTO ncc)
        {
            return NCCDAL.SuaNCC(ncc);
        }
        public static bool XoaNCC(NhaCungCapDTO ncc)
        {
            return NCCDAL.XoaNCC(ncc);
        }
        public static List<NhaCungCapDTO> TimSachTheoTen(string ten)
        {
            return NCCDAL.TimSachTheoTen(ten);
        }
    }
}
