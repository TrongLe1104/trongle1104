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
    public class KhachHangDAL
    {
        static SqlConnection con;
        public static List<KhachHangDTO> LayKhachHang()
        {
            string sTruyVan = "select * from khachhang";
            con = DataAccess.MoKetNoi();
            DataTable dt = DataAccess.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<KhachHangDTO> lstKH = new List<KhachHangDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                KhachHangDTO kh = new KhachHangDTO();
                kh.MaKH = dt.Rows[i]["makh"].ToString();
                kh.TenKH = dt.Rows[i]["tenkh"].ToString();
                kh.DiaChi = dt.Rows[i]["diachi"].ToString();
                kh.DienThoai = int.Parse(dt.Rows[i]["dienthoai"].ToString());
                lstKH.Add(kh);
            }
            DataAccess.DongKetNoi(con);
            return lstKH;
        }
        public static KhachHangDTO TimKHTheoMa(string ma)
        {
            //quét mã
            string sTruyVan = string.Format(@"select * from khachhang where makh='{0}'", ma);
            con = DataAccess.MoKetNoi();
            DataTable dt = DataAccess.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            KhachHangDTO kh = new KhachHangDTO();
            kh.MaKH = dt.Rows[0]["makh"].ToString();
            kh.TenKH = dt.Rows[0]["tenkh"].ToString();
            kh.DiaChi = dt.Rows[0]["diachi"].ToString();
            kh.DienThoai = int.Parse(dt.Rows[0]["dienthoai"].ToString());

            DataAccess.DongKetNoi(con);
            return kh;
        }
        public static bool ThemKH(KhachHangDTO kh)
        {
            string sTruyVan = string.Format(@"insert into khachhang values(N'{0}',N'{1}',N'{2}','{3}')", kh.MaKH, kh.TenKH, kh.DiaChi, kh.DienThoai);
            bool kq = DataAccess.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return kq;
        }
        public static bool SuaKH(KhachHangDTO kh)
        {
            string sTruyVan = string.Format(@"update khachhang set tenkh=N'{0}',diachi=N'{1}',dienthoai='{2}' where makh=N'{3}'", kh.TenKH, kh.DiaChi, kh.DienThoai, kh.MaKH);
            con = DataAccess.MoKetNoi();
            bool kq = DataAccess.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return kq;
        }
        public static bool XoaKH(KhachHangDTO kh)
        {
            string sTruyVan = string.Format(@"delete from khachhang where makh=N'{0}'", kh.MaKH);
            con = DataAccess.MoKetNoi();
            bool kq = DataAccess.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return kq;
        }
        public static List<KhachHangDTO> TimKHTheoTen(string ten)
        {
            string sTruyVan = string.Format(@"select * from khachhang where tenkh like N'%{0}%'", ten);
            con = DataAccess.MoKetNoi();
            DataTable dt = DataAccess.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }

            List<KhachHangDTO> lstKH = new List<DTO.KhachHangDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                KhachHangDTO kh = new KhachHangDTO();
                kh.MaKH = dt.Rows[0]["makh"].ToString();
                kh.TenKH = dt.Rows[0]["tenkh"].ToString();
                kh.DiaChi = dt.Rows[0]["diachi"].ToString();
                kh.DienThoai = int.Parse(dt.Rows[0]["dienthoai"].ToString());
                lstKH.Add(kh);
            }
            DataAccess.DongKetNoi(con);
            return lstKH;
        }
    }
}
