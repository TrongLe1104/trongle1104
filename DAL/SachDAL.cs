using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SachDAL
    {
        static SqlConnection con;
        public static List<SachDTO> LaySach()
        {
            string sTruyVan = "select * from sach";
            con = DataAccess.MoKetNoi();
            DataTable dt = DataAccess.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<SachDTO> lstSach = new List<SachDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SachDTO s = new SachDTO();
                s.MaSach = dt.Rows[i]["masach"].ToString();
                s.TenSach = dt.Rows[i]["tensach"].ToString();
                s.MaTG = dt.Rows[i]["matg"].ToString();
                s.MaTL = dt.Rows[i]["matl"].ToString();
                s.MaNXB = dt.Rows[i]["manxb"].ToString();
                s.GiaNhap = int.Parse(dt.Rows[i]["gianhap"].ToString());
                s.GiaBan = int.Parse(dt.Rows[i]["giaban"].ToString());
                s.SoLuong = int.Parse(dt.Rows[i]["soluong"].ToString());
                lstSach.Add(s);
            }
            DataAccess.DongKetNoi(con);
            return lstSach;
        }
        public static SachDTO TimSachTheoMa(string ma)
        {
            //quét mã
            string sTruyVan = string.Format(@"select * from sach where masach='{0}'", ma);
            con = DataAccess.MoKetNoi();
            DataTable dt = DataAccess.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            SachDTO s = new SachDTO();
            s.MaSach = dt.Rows[0]["masach"].ToString();
            s.TenSach = dt.Rows[0]["tensach"].ToString();
            s.MaTG = dt.Rows[0]["matg"].ToString();
            s.MaTL = dt.Rows[0]["matl"].ToString();
            s.MaNXB = dt.Rows[0]["manxb"].ToString();
            s.GiaNhap = int.Parse(dt.Rows[0]["gianhap"].ToString());
            s.GiaBan = int.Parse(dt.Rows[0]["giaban"].ToString());
            s.SoLuong = int.Parse(dt.Rows[0]["soluong"].ToString());

            DataAccess.DongKetNoi(con);
            return s;
        }
        public static bool ThemSach(SachDTO s)
        {
            string sTruyVan = string.Format(@"insert into sach values(N'{0}',N'{1}',N'{2}',N'{3}',N'{4}','{5}','{6}','{7}')", s.MaSach, s.TenSach, s.MaTG, s.MaTL, s.MaNXB, s.GiaNhap, s.GiaBan, s.SoLuong);
            bool kq = DataAccess.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return kq;
        }
        public static bool SuaSach(SachDTO s)
        {
            string sTruyVan = string.Format(@"update sach set tensach=N'{0}',matg=N'{1}',matl=N'{2}',manxb=N'{3}',gianhap='{4}',giaban='{5}',soluong='{6}' where masach=N'{7}'", s.TenSach, s.MaTG, s.MaTL, s.MaNXB, s.GiaNhap, s.GiaBan, s.SoLuong, s.MaSach);
            con = DataAccess.MoKetNoi();
            bool kq = DataAccess.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return kq;
        }
        public static bool XoaSach(SachDTO s)
        {
            string sTruyVan = string.Format(@"delete from sach where masach=N'{0}'", s.MaSach);
            con = DataAccess.MoKetNoi();
            bool kq = DataAccess.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return kq;
        }
        public static List<SachDTO> TimSachTheoTen(string ten)
        {
            string sTruyVan = string.Format(@"select * from sach where tensach like N'%{0}%'", ten);
            con = DataAccess.MoKetNoi();
            DataTable dt = DataAccess.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }

            List<SachDTO> lstTen = new List<DTO.SachDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SachDTO s = new SachDTO();
                s.MaSach = dt.Rows[0]["masach"].ToString();
                s.TenSach = dt.Rows[0]["tensach"].ToString();
                s.MaTG = dt.Rows[0]["matg"].ToString();
                s.MaTL = dt.Rows[0]["matl"].ToString();
                s.MaNXB = dt.Rows[0]["manxb"].ToString();
                s.GiaNhap = int.Parse(dt.Rows[0]["gianhap"].ToString());
                s.GiaBan = int.Parse(dt.Rows[0]["giaban"].ToString());
                s.SoLuong = int.Parse(dt.Rows[0]["soluong"].ToString());
                lstTen.Add(s);
            }
            DataAccess.DongKetNoi(con);
            return lstTen;
        }
    }
}
