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
    public class TacGiaDAL
    {
        static SqlConnection con;
        public static List<TacGiaDTO> LayTacGia()
        {
            string sTruyVan = "select * from tacgia";
            con = DataAccess.MoKetNoi();
            DataTable dt = DataAccess.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<TacGiaDTO> lstTG = new List<TacGiaDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TacGiaDTO tg = new TacGiaDTO();
                tg.MaTG = dt.Rows[i]["matg"].ToString();
                tg.TenTG = dt.Rows[i]["tentg"].ToString();
                lstTG.Add(tg);
            }
            DataAccess.DongKetNoi(con);
            return lstTG;
        }
        public static TacGiaDTO TimTGTheoMa(string ma)
        {
            //quét mã
            string sTruyVan = string.Format(@"select * from tacgia where matg='{0}'", ma);
            con = DataAccess.MoKetNoi();
            DataTable dt = DataAccess.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            TacGiaDTO tg = new TacGiaDTO();
            tg.MaTG = dt.Rows[0]["matg"].ToString();
            tg.TenTG = dt.Rows[0]["tentg"].ToString();

            DataAccess.DongKetNoi(con);
            return tg;
        }
        public static bool ThemTacGia(TacGiaDTO tg)
        {
            string sTruyVan = string.Format(@"insert into tacgia values(N'{0}', N'{1}')", tg.MaTG, tg.TenTG);
            bool kq = DataAccess.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return kq;
        }
        public static bool SuaTacGia(TacGiaDTO tg)
        {
            string sTruyVan = string.Format(@"update tacgia set tentg=N'{0}' where matg=N'{1}'", tg.TenTG, tg.MaTG);
            con = DataAccess.MoKetNoi();
            bool kq = DataAccess.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return kq;
        }
        public static bool XoaTacGia(TacGiaDTO tg)
        {
            string sTruyVan = string.Format(@"delete from tacgia where matg=N'{0}'", tg.MaTG);
            con = DataAccess.MoKetNoi();
            bool kq = DataAccess.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return kq;
        }
        public static List<TacGiaDTO> TimSachTheoTen(string ten)
        {
            string sTruyVan = string.Format(@"select * from tacgia where tentg like N'%{0}%'", ten);
            con = DataAccess.MoKetNoi();
            DataTable dt = DataAccess.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }

            List<TacGiaDTO> lstTG = new List<DTO.TacGiaDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TacGiaDTO tg = new TacGiaDTO();
                tg.MaTG = dt.Rows[0]["matg"].ToString();
                tg.TenTG = dt.Rows[0]["tentg"].ToString();
                lstTG.Add(tg);
            }
            DataAccess.DongKetNoi(con);
            return lstTG;
        }
    }
}
