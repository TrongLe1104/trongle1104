using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ChiTietPNBLL
    {
        public static bool CapNhatSLKhoKhiXoaCTHDN(ChiTietHDNDTO ctn)
        {
            return ChiTietPNDAL.CapNhatKhoKhiXoa_HDNhap(ctn);
        }
        public static bool CapNhatSLTrongKho(ChiTietHDNDTO ctn)
        {
            return ChiTietPNDAL.CapNhatKhoKhiNhap(ctn);
        }
        public static List<ChiTietHDNDTO> LayCTHDNhap(string masach)
        {
            return ChiTietPNDAL.LayCTHDNhap(masach);
        }
        public static bool ThemCT(ChiTietHDNDTO nv)
        {
            return ChiTietPNDAL.ThemCT(nv);
        }
        public static ChiTietHDNDTO TimCTHDTheoMa(string ma)
        {
            return ChiTietPNDAL.TimCTHDTheoMa(ma);
        }
        public static bool SuaCT(ChiTietHDNDTO nv)
        {
            return ChiTietPNDAL.SuaCT(nv);
        }
        public static bool XoaCT(ChiTietHDNDTO nv)
        {
            return ChiTietPNDAL.XoaCT(nv);
        }
    }
}
