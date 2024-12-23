using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ChiTietHoaDonBLL
    {
        public static bool CapNhatSLKhoKhiXoaCTHDB(ChiTietHDBDTO ctb)
        {
            return ChiTietHoaDonDAL.CapNhatKhoKhiXoa_HDXuat(ctb);
        }
        public static bool CapNhatSLTrongKho(ChiTietHDBDTO ctx)
        {
            return ChiTietHoaDonDAL.CapNhatKhoKhiXuat(ctx);
        }
        public static List<ChiTietHDBDTO> LayCTHDBAN(string masach)
        {
            return ChiTietHoaDonDAL.LayCTHDBAN(masach);
        }
        public static bool ThemCT(ChiTietHDBDTO nv)
        {
            return ChiTietHoaDonDAL.ThemCT(nv);
        }
        public static ChiTietHDBDTO TimCTHDBTheoMa(string ma)
        {
            return ChiTietHoaDonDAL.TimCTHDBTheoMa(ma);
        }
        public static bool SuaCT(ChiTietHDBDTO nv)
        {
            return ChiTietHoaDonDAL.SuaCT(nv);
        }
        public static bool XoaCT(ChiTietHDBDTO nv)
        {
            return ChiTietHoaDonDAL.XoaCT(nv);
        }
        public static List<ChiTietHDBDTO> TimCTHDBTheoTen(string ten)
        {
            return ChiTietHoaDonDAL.TimCTHDBTheoTen(ten);
        }
    }
}
