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
    public class HoaDonDAL
    {
        static SqlConnection con;
        public static List<HoaDonBanDTO> LayHoaDon()
        {
            string sTruyVan = "select * from hdban";
            con = DataAccess.MoKetNoi();
            DataTable dt = DataAccess.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<HoaDonBanDTO> lstHDB = new List<HoaDonBanDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                HoaDonBanDTO hdb = new HoaDonBanDTO();
                hdb.SoHDB = dt.Rows[i]["sohdb"].ToString();
                hdb.MaNV = dt.Rows[i]["manv"].ToString();
                hdb.MaKH = dt.Rows[i]["makh"].ToString();
                hdb.NgayBan = DateTime.Parse(dt.Rows[i]["ngayban"].ToString());
                lstHDB.Add(hdb);
            }
            DataAccess.DongKetNoi(con);
            return lstHDB;
        }
        public static HoaDonBanDTO TimHDBTheoMa(string ma)
        {
            //quét mã
            string sTruyVan = string.Format(@"select * from hdban where sohdb='{0}'", ma);
            con = DataAccess.MoKetNoi();
            DataTable dt = DataAccess.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            HoaDonBanDTO hdb = new HoaDonBanDTO();
            hdb.SoHDB = dt.Rows[0]["sohdb"].ToString();
            hdb.MaNV = dt.Rows[0]["manv"].ToString();
            hdb.MaKH = dt.Rows[0]["makh"].ToString();
            hdb.NgayBan = DateTime.Parse(dt.Rows[0]["ngayban"].ToString());

            DataAccess.DongKetNoi(con);
            return hdb;
        }
        public static bool ThemHDB(HoaDonBanDTO hdb)
        {
            string sTruyVan = string.Format(@"insert into hdban values(N'{0}',N'{1}',N'{2}','{3}')", hdb.SoHDB, hdb.MaNV, hdb.MaKH, hdb.NgayBan);
            bool kq = DataAccess.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return kq;
        }
        public static bool SuaHDB(HoaDonBanDTO hdb)
        {
            string sTruyVan = string.Format(@"update hdban set manv=N'{0}',makh=N'{1}',ngayban='{2}' where sohdb=N'{3}'", hdb.MaNV, hdb.MaKH, hdb.NgayBan, hdb.SoHDB);
            con = DataAccess.MoKetNoi();
            bool kq = DataAccess.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return kq;
        }
        public static bool XoaHDB(HoaDonBanDTO hdb)
        {
            string sTruyVan = string.Format(@"delete from hdban where sohdb=N'{0}'", hdb.SoHDB);
            con = DataAccess.MoKetNoi();
            bool kq = DataAccess.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return kq;
        }
    }
}
