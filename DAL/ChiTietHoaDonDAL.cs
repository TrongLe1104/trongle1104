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
    public class ChiTietHoaDonDAL
    {
        static SqlConnection con;
        public static List<ChiTietHDBDTO> LayCTHDBAN(string masach)
        {
            string sTruyVan = "select *, sach.soluong from cthdban, sach where sach.masach = cthdban.masach";
            con = DataAccess.MoKetNoi();
            DataTable dt = DataAccess.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<ChiTietHDBDTO> lstcthd = new List<ChiTietHDBDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChiTietHDBDTO nv = new ChiTietHDBDTO();
                nv.SoHDB = dt.Rows[i]["sohdb"].ToString();
                nv.MaSach = dt.Rows[i]["masach"].ToString();
                nv.TenSach = dt.Rows[i]["tensach"].ToString();
                nv.DonGia = int.Parse(dt.Rows[i]["dongia"].ToString());
                nv.SoLuong = int.Parse(dt.Rows[i]["soluong"].ToString());
                nv.ThanhTien = int.Parse(dt.Rows[i]["thanhtien"].ToString());
                lstcthd.Add(nv);
            }
            DataAccess.DongKetNoi(con);
            return lstcthd;
        }
        public static ChiTietHDBDTO TimCTHDBTheoMa(string ma)
        {
            //quét mã
            string sTruyVan = string.Format(@"select * from cthdban where sohdb=N'{0}'", ma);
            con = DataAccess.MoKetNoi();
            DataTable dt = DataAccess.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            ChiTietHDBDTO nv = new ChiTietHDBDTO();
            nv.SoHDB = dt.Rows[0]["sohdb"].ToString();
            nv.MaSach = dt.Rows[0]["masach"].ToString();
            nv.TenSach = dt.Rows[0]["tensach"].ToString();
            nv.DonGia = int.Parse(dt.Rows[0]["dongia"].ToString());
            nv.SoLuong = int.Parse(dt.Rows[0]["soluong"].ToString());
            nv.ThanhTien = int.Parse(dt.Rows[0]["thanhtien"].ToString());

            DataAccess.DongKetNoi(con);
            return nv;
        }
        public static bool CapNhatKhoKhiXoa_HDXuat(ChiTietHDBDTO ctx)
        {
            string sTruyVan = string.Format(@"update sach set SoLuong = SoLuong + '{0}' where masach='{1}'", ctx.SoLuong, ctx.MaSach);
            con = DataAccess.MoKetNoi();
            bool kq = DataAccess.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return kq;
        }
        public static bool CapNhatKhoKhiXuat(ChiTietHDBDTO ctx)
        {
            string sTruyVan = string.Format(@"update sach set soluong = soluong - '{0}' where masach='{1}'", ctx.SoLuong, ctx.MaSach);
            con = DataAccess.MoKetNoi();
            bool kq = DataAccess.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataAccess.DongKetNoi(con);
           return kq;
        }
        public static bool ThemCT(ChiTietHDBDTO nv)
        {
            string sTruyVan = string.Format(@"insert into cthdban values(N'{0}',N'{1}',N'{2}',{3},{4},{5})", nv.SoHDB, nv.MaSach, nv.TenSach, nv.DonGia, nv.SoLuong, nv.ThanhTien);
            bool kq = DataAccess.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return kq;
        }
        public static bool SuaCT(ChiTietHDBDTO nv)
        {
            string sTruyVan = string.Format(@"update cthdban set masach=N'{0}',tensach=N'{1}',dongia={2},soluong={3},thanhtien={4} where sohdb=N'{5}'", nv.MaSach, nv.TenSach, nv.DonGia, nv.SoLuong, nv.ThanhTien, nv.SoHDB);
            con = DataAccess.MoKetNoi();
            bool kq = DataAccess.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return kq;
        }
        public static bool XoaCT(ChiTietHDBDTO nv)
        {
            string sTruyVan = string.Format(@"delete from cthdban where sohdb=N'{0}'", nv.SoHDB);
            con = DataAccess.MoKetNoi();
            bool kq = DataAccess.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return kq;
        }
        public static List<ChiTietHDBDTO> TimCTHDBTheoTen(string ten)
        {
            string sTruyVan = string.Format(@"select * from cthdban where tensach like N'%{0}%'", ten);
            con = DataAccess.MoKetNoi();
            DataTable dt = DataAccess.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }

            List<ChiTietHDBDTO> lstNV = new List<DTO.ChiTietHDBDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChiTietHDBDTO nv = new ChiTietHDBDTO();
                nv.SoHDB = dt.Rows[i]["sohdb"].ToString();
                nv.MaSach = dt.Rows[i]["masach"].ToString();
                nv.TenSach = dt.Rows[i]["tensach"].ToString();
                nv.DonGia = int.Parse(dt.Rows[i]["dongia"].ToString());
                nv.SoLuong = int.Parse(dt.Rows[i]["soluong"].ToString());
                nv.ThanhTien = int.Parse(dt.Rows[i]["thanhtien"].ToString());
                lstNV.Add(nv);
            }
            DataAccess.DongKetNoi(con);
            return lstNV;
        }
    }
}
