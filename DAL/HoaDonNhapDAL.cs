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
    public class HoaDonNhapDAL
    {
        static SqlConnection con;
        public static List<HoaDonNhap> LayHDNhap()
        {
            string sTruyVan = "select * from hdnhap";
            con = DataAccess.MoKetNoi();
            DataTable dt = DataAccess.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<HoaDonNhap> lstHDN = new List<HoaDonNhap>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                HoaDonNhap hdn = new HoaDonNhap();
                hdn.SoHD = dt.Rows[i]["sohd"].ToString();
                hdn.MaNV = dt.Rows[i]["manv"].ToString();
                hdn.NgayNhap = DateTime.Parse(dt.Rows[i]["ngaynhap"].ToString());
                hdn.MaNCC = dt.Rows[i]["mancc"].ToString();
                hdn.GiaNhap = int.Parse(dt.Rows[i]["gianhap"].ToString());
                lstHDN.Add(hdn);
            }
            DataAccess.DongKetNoi(con);
            return lstHDN;
        }
        public static HoaDonNhap TimHDNTheoMa(string ma)
        {
            //quét mã
            string sTruyVan = string.Format(@"select * from hdnhap where sohd='{0}'", ma);
            con = DataAccess.MoKetNoi();
            DataTable dt = DataAccess.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            HoaDonNhap hdn = new HoaDonNhap();
            hdn.SoHD = dt.Rows[0]["sohd"].ToString();
            hdn.MaNV = dt.Rows[0]["manv"].ToString();
            hdn.NgayNhap = DateTime.Parse(dt.Rows[0]["ngaynhap"].ToString());
            hdn.MaNCC = dt.Rows[0]["mancc"].ToString();
            hdn.GiaNhap = int.Parse(dt.Rows[0]["gianhap"].ToString());

            DataAccess.DongKetNoi(con);
            return hdn;
        }
        public static bool ThemHDN(HoaDonNhap hdb)
        {
            string sTruyVan = string.Format(@"insert into hdnhap values(N'{0}',N'{1}',{2},N'{3}','{4}')", hdb.SoHD, hdb.MaNV, hdb.NgayNhap.ToString("yyyy/MM/dd"), hdb.MaNCC, hdb.GiaNhap);
            bool kq = DataAccess.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return kq;
        }
        public static bool SuaHDN(HoaDonNhap hdb)
        {
            string sTruyVan = string.Format(@"update hdnhap set manv=N'{0}',ngaynhap='{1}',mancc=N'{2}',gianhap='{3}' where sohd=N'{4}'", hdb.MaNV, hdb.NgayNhap.ToString("yyyy/MM/dd"), hdb.MaNCC, hdb.GiaNhap, hdb.SoHD);
            con = DataAccess.MoKetNoi();
            bool kq = DataAccess.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return kq;
        }
        public static bool XoaHDN(HoaDonNhap hdb)
        {
            string sTruyVan = string.Format(@"delete from hdnhap where sohd=N'{0}'", hdb.SoHD);
            con = DataAccess.MoKetNoi();
            bool kq = DataAccess.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return kq;
        }
    }
}
