using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class NXBDAL
    {
        static SqlConnection con;
        public static List<NXBDTO> LayNXB()
        {
            string sTruyVan = "select * from nxb";
            con = DataAccess.MoKetNoi();
            DataTable dt = DataAccess.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<NXBDTO> lstNXB = new List<NXBDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NXBDTO nxb = new NXBDTO();
                nxb.MaNXB = dt.Rows[i]["manxb"].ToString();
                nxb.TenNXB = dt.Rows[i]["tennxb"].ToString();
                lstNXB.Add(nxb);
            }
            DataAccess.DongKetNoi(con);
            return lstNXB;
        }
        public static NXBDTO TimNXBTheoMa(string ma)
        {
            //quét mã
            string sTruyVan = string.Format(@"select * from nxb where manxb='{0}'", ma);
            con = DataAccess.MoKetNoi();
            DataTable dt = DataAccess.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            NXBDTO nxb = new NXBDTO();
            nxb.MaNXB = dt.Rows[0]["manxb"].ToString();
            nxb.TenNXB = dt.Rows[0]["tennxb"].ToString();

            DataAccess.DongKetNoi(con);
            return nxb;
        }
        public static bool ThemNXB(NXBDTO nxb)
        {
            string sTruyVan = string.Format(@"insert into nxb values(N'{0}', N'{1}')", nxb.MaNXB, nxb.TenNXB);
            con = DataAccess.MoKetNoi();
            bool kq = DataAccess.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return kq ;
        }
        public static bool SuaNXB(NXBDTO nxb)
        {
            string sTruyVan = string.Format(@"update nxb set tennxb=N'{0}' where manxb=N'{1}'", nxb.TenNXB, nxb.MaNXB);
            con = DataAccess.MoKetNoi();
            bool kq = DataAccess.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return kq;
        }
        public static bool XoaNXB(NXBDTO nxb)
        {
            string sTruyVan = string.Format(@"delete from nxb where manxb=N'{0}'", nxb.MaNXB);
            con = DataAccess.MoKetNoi();
            bool kq = DataAccess.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return kq;
        }
        public static List<NXBDTO> TimSachTheoTen(string ten)
        {
            string sTruyVan = string.Format(@"select * from nxb where tennxb like N'%{0}%'", ten);
            con = DataAccess.MoKetNoi();
            DataTable dt = DataAccess.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }

            List<NXBDTO> lstNXB = new List<DTO.NXBDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NXBDTO nxb = new NXBDTO();
                nxb.MaNXB = dt.Rows[0]["manxb"].ToString();
                nxb.TenNXB = dt.Rows[0]["tennxb"].ToString();
                lstNXB.Add(nxb);
            }
            DataAccess.DongKetNoi(con);
            return lstNXB;
        }
    }
}
