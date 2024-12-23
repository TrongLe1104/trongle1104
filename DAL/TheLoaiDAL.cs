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
    public class TheLoaiDAL
    {
        static SqlConnection con;
        public static List<TheLoaiDTO> LayTheLoai()
        {
            string sTruyVan = "select * from theloai";
            con = DataAccess.MoKetNoi();
            DataTable dt = DataAccess.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<TheLoaiDTO> lstTheLoai = new List<TheLoaiDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TheLoaiDTO tl = new TheLoaiDTO();
                tl.MaTL = dt.Rows[i]["matl"].ToString();
                tl.TenTL = dt.Rows[i]["tentl"].ToString();
                lstTheLoai.Add(tl);
            }
            DataAccess.DongKetNoi(con);
            return lstTheLoai;
        }
        public static TheLoaiDTO TimTheLoaiTheoMa(string ma)
        {
            //quét mã
            string sTruyVan = string.Format(@"select * from theloai where matl='{0}'", ma);
            con = DataAccess.MoKetNoi();
            DataTable dt = DataAccess.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            TheLoaiDTO tl = new TheLoaiDTO();
            tl.MaTL = dt.Rows[0]["matl"].ToString();
            tl.TenTL = dt.Rows[0]["tentl"].ToString();


            DataAccess.DongKetNoi(con);
            return tl;
        }
        public static bool ThemTheLoai(TheLoaiDTO tl)
        {
            string sTruyVan = string.Format(@"insert into theloai values(N'{0}', N'{1}')", tl.MaTL, tl.TenTL);
            bool kq = DataAccess.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return kq;
        }
        public static bool SuaTheLoai(TheLoaiDTO tl)
        {
            string sTruyVan = string.Format(@"update theloai set tentl=N'{0}'where matl=N'{1}'", tl.TenTL, tl.MaTL);
            con = DataAccess.MoKetNoi();
            bool kq = DataAccess.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return kq;
        }
        public static bool XoaTheLoai(TheLoaiDTO tl)
        {
            string sTruyVan = string.Format(@"delete from theloai where matl=N'{0}'", tl.MaTL);
            con = DataAccess.MoKetNoi();
            bool kq = DataAccess.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return kq;
        }
        public static List<TheLoaiDTO> TimSachTheoTen(string ten)
        {
            string sTruyVan = string.Format(@"select * from theloai where tentl like N'%{0}%'", ten);
            con = DataAccess.MoKetNoi();
            DataTable dt = DataAccess.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }

            List<TheLoaiDTO> lstTL = new List<DTO.TheLoaiDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TheLoaiDTO tl = new TheLoaiDTO();
                tl.MaTL = dt.Rows[0]["matl"].ToString();
                tl.TenTL = dt.Rows[0]["tentl"].ToString();
                lstTL.Add(tl);
            }
            DataAccess.DongKetNoi(con);
            return lstTL;
        }
    }
}
