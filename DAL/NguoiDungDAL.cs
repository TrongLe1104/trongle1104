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
    public class NguoiDungDAL
    {
        static SqlConnection con;

        // Lấy thông tin người dùng có tên đăng nhập và mật khẩu tương ứng, trả về null nếu không thấy
        public static NguoiDungDTO LayNguoiDung(string ten, string matKhau)
        {
            string sTruyVan = string.Format(@"select * from nguoidung where ten=N'{0}' and matkhau='{1}'", ten, matKhau);
            con = DataAccess.MoKetNoi();
            DataTable dt = DataAccess.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            NguoiDungDTO nd = new NguoiDungDTO();
            nd.Ten = dt.Rows[0]["ten"].ToString();
            nd.MatKhau = dt.Rows[0]["matkhau"].ToString();
            nd.Quyen = int.Parse(dt.Rows[0]["quyen"].ToString());

            DataAccess.DongKetNoi(con);
            return nd;
        }

        public static bool CapNhatNguoiDung(NguoiDungDTO nd)
        {
            string sql = string.Format(@"update nguoidung set matkhau='{0}' where ten=N'{1}'", nd.MatKhau, nd.Ten);
            con = DataAccess.MoKetNoi();
            bool kq = DataAccess.TruyVanKhongLayDuLieu(sql, con);
            return kq;
        }
    }
}
