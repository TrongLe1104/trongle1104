using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ChiTietPNDAL
    {
        static SqlConnection con;
        public static List<ChiTietHDNDTO> LayCTHDNhap(string masach)
        {
            string sTruyVan = "select *, sach.soluong from chitiethdn, sach where sach.masach = chitiethdn.masach";
            con = DataAccess.MoKetNoi();
            DataTable dt = DataAccess.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<ChiTietHDNDTO> lstcthd = new List<ChiTietHDNDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChiTietHDNDTO nv = new ChiTietHDNDTO();
                nv.SoHD = dt.Rows[i]["sohd"].ToString();
                nv.MaSach = dt.Rows[i]["masach"].ToString();
                nv.TenSach = dt.Rows[i]["tensach"].ToString();
                nv.SlNhap = int.Parse(dt.Rows[i]["slnhap"].ToString());
                lstcthd.Add(nv);
            }
            DataAccess.DongKetNoi(con);
            return lstcthd;
        }
        public static ChiTietHDNDTO TimCTHDTheoMa(string ma)
        {
            //quét mã
            string sTruyVan = string.Format(@"select * from chitiethdn where sohd=N'{0}'", ma);
            con = DataAccess.MoKetNoi();
            DataTable dt = DataAccess.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            ChiTietHDNDTO nv = new ChiTietHDNDTO();
            nv.SoHD = dt.Rows[0]["sohd"].ToString();
            nv.MaSach = dt.Rows[0]["masach"].ToString();
            nv.TenSach = dt.Rows[0]["tensach"].ToString();
            nv.SlNhap = int.Parse(dt.Rows[0]["slnhap"].ToString());

            DataAccess.DongKetNoi(con);
            return nv;
        }
        public static bool CapNhatKhoKhiXoa_HDNhap(ChiTietHDNDTO ctx)
        {
            string sTruyVan = string.Format(@"update sach set SoLuong = SoLuong - '{0}' where masach='{1}'", ctx.SlNhap, ctx.MaSach);
            con = DataAccess.MoKetNoi();
            bool kq = DataAccess.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return kq;
        }
        public static bool CapNhatKhoKhiNhap(ChiTietHDNDTO ctn)
        {
            string sTruyVan = string.Format(@"update sach set soluong = soluong + '{0}' where masach='{1}'", ctn.SlNhap, ctn.MaSach);
            con = DataAccess.MoKetNoi();
            bool kq = DataAccess.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return kq;
        }
        public static bool ThemCT(ChiTietHDNDTO nv)
        {
            string sTruyVan = string.Format(@"INSERT INTO CHITIETHDN VALUES(N'{0}', N'{1}', N'{2}', '{3}');", nv.SoHD, nv.MaSach, nv.TenSach, nv.SlNhap);
            bool kq = DataAccess.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return kq;
        }
        public static bool SuaCT(ChiTietHDNDTO nv)
        {
            string sTruyVan = string.Format(@"update chitiethdn set masach=N'{0}',tensach=N'{1}',slnhap={2} where sohd=N'{3}'", nv.MaSach, nv.TenSach, nv.SlNhap, nv.SoHD);
            con = DataAccess.MoKetNoi();
            bool kq = DataAccess.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return kq;
        }
        public static bool XoaCT(ChiTietHDNDTO nv)
        {
            string sTruyVan = string.Format(@"delete from chitiethdn where sohd=N'{0}'", nv.SoHD);
            con = DataAccess.MoKetNoi();
            bool kq = DataAccess.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return kq;
        }
    }
}
