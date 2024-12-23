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
    public class NCCDAL
    {
        static SqlConnection con;
        public static List<NhaCungCapDTO> LayNCC()
        {
            string sTruyVan = "select * from nhacungcap";
            con = DataAccess.MoKetNoi();
            DataTable dt = DataAccess.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<NhaCungCapDTO> lstNCC = new List<NhaCungCapDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NhaCungCapDTO ncc = new NhaCungCapDTO();
                ncc.MaNCC = dt.Rows[i]["mancc"].ToString();
                ncc.TenNCC = dt.Rows[i]["tenncc"].ToString();
                lstNCC.Add(ncc);
            }
            DataAccess.DongKetNoi(con);
            return lstNCC;
        }
        public static NhaCungCapDTO TimTheLoaiTheoMa(string ma)
        {
            //quét mã
            string sTruyVan = string.Format(@"select * from nhacungcap where mancc='{0}'", ma);
            con = DataAccess.MoKetNoi();
            DataTable dt = DataAccess.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            NhaCungCapDTO ncc = new NhaCungCapDTO();
            ncc.MaNCC = dt.Rows[0]["mancc"].ToString();
            ncc.TenNCC = dt.Rows[0]["tenncc"].ToString(); 

            DataAccess.DongKetNoi(con);
            return ncc;
        }
        public static bool ThemNCC(NhaCungCapDTO ncc)
        {
            string sTruyVan = string.Format(@"insert into nhacungcap values(N'{0}', N'{1}')", ncc.MaNCC, ncc.TenNCC);
            bool kq = DataAccess.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return kq;
        }
        public static bool SuaNCC(NhaCungCapDTO ncc)
        {
            string sTruyVan = string.Format(@"update nhacungcap set tenncc=N'{0}'where mancc=N'{1}'", ncc.TenNCC, ncc.MaNCC);
            con = DataAccess.MoKetNoi();
            bool kq = DataAccess.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return kq;
        }
        public static bool XoaNCC(NhaCungCapDTO ncc)
        {
            string sTruyVan = string.Format(@"delete from nhacungcap where mancc=N'{0}'", ncc.MaNCC);
            con = DataAccess.MoKetNoi();
            bool kq = DataAccess.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return kq;
        }
        public static List<NhaCungCapDTO> TimSachTheoTen(string ten)
        {
            string sTruyVan = string.Format(@"select * from nhacungcap where tenncc like N'%{0}%'", ten);
            con = DataAccess.MoKetNoi();
            DataTable dt = DataAccess.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }

            List<NhaCungCapDTO> lstNCC = new List<DTO.NhaCungCapDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NhaCungCapDTO ncc = new NhaCungCapDTO();
                ncc.MaNCC = dt.Rows[0]["mancc"].ToString();
                ncc.TenNCC = dt.Rows[0]["tenncc"].ToString();
                lstNCC.Add(ncc);
            }
            DataAccess.DongKetNoi(con);
            return lstNCC;
        }
    }
}
