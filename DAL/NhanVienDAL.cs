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
    public class NhanVienDAL
    {
        static SqlConnection con;
        public static List<NhanVienDTO> LayNhanVien()
        {
            string sTruyVan = "select * from nhanvien";
            con = DataAccess.MoKetNoi();
            DataTable dt = DataAccess.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<NhanVienDTO> lstNV = new List<NhanVienDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NhanVienDTO nv = new NhanVienDTO();
                nv.MaNV = dt.Rows[i]["manv"].ToString();
                nv.TenNV = dt.Rows[i]["tennv"].ToString();
                nv.GioiTinh = dt.Rows[i]["gioitinh"].ToString();
                nv.NgaySinh = DateTime.Parse(dt.Rows[i]["ngaysinh"].ToString());
                nv.DiaChi = dt.Rows[i]["diachi"].ToString();
                nv.DienThoai = int.Parse(dt.Rows[i]["dienthoai"].ToString());
                lstNV.Add(nv);
            }
            DataAccess.DongKetNoi(con);
            return lstNV;
        }
        public static NhanVienDTO TimNVTheoMa(string ma)
        {
            //quét mã
            string sTruyVan = string.Format(@"select * from nhanvien where manv='{0}'", ma);
            con = DataAccess.MoKetNoi();
            DataTable dt = DataAccess.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            NhanVienDTO nv = new NhanVienDTO();
            nv.MaNV = dt.Rows[0]["manv"].ToString();
            nv.TenNV = dt.Rows[0]["tennv"].ToString();
            nv.GioiTinh = dt.Rows[0]["gioitinh"].ToString();
            nv.NgaySinh = DateTime.Parse(dt.Rows[0]["ngaysinh"].ToString());
            nv.DiaChi = dt.Rows[0]["diachi"].ToString();
            nv.DienThoai = int.Parse(dt.Rows[0]["dienthoai"].ToString());

            DataAccess.DongKetNoi(con);
            return nv;
        }
        public static bool ThemNV(NhanVienDTO nv)
        {
            string sTruyVan = string.Format(@"insert into nhanvien values(N'{0}',N'{1}',N'{2}',N'{3}',N'{4}','{5}')", nv.MaNV, nv.TenNV, nv.GioiTinh, nv.NgaySinh, nv.DiaChi, nv.DienThoai);
            bool kq = DataAccess.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return kq;
        }
        public static bool SuaNV(NhanVienDTO nv)
        {
            string sTruyVan = string.Format(@"update nhanvien set tennv=N'{0}',gioitinh=N'{1}',ngaysinh=N'{2}',diachi=N'{3}',dienthoai='{4}' where manv=N'{5}'", nv.TenNV, nv.GioiTinh, nv.NgaySinh, nv.DiaChi, nv.DienThoai, nv.MaNV);
            con = DataAccess.MoKetNoi();
            bool kq = DataAccess.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return kq;
        }
        public static bool XoaNV(NhanVienDTO nv)
        {
            string sTruyVan = string.Format(@"delete from nhanvien where manv=N'{0}'", nv.MaNV);
            con = DataAccess.MoKetNoi();
            bool kq = DataAccess.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return kq;
        }
        public static List<NhanVienDTO> TimNVTheoTen(string ten)
        {
            string sTruyVan = string.Format(@"select * from nhanvien where tennv like N'%{0}%'", ten);
            con = DataAccess.MoKetNoi();
            DataTable dt = DataAccess.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }

            List<NhanVienDTO> lstNV = new List<DTO.NhanVienDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NhanVienDTO nv = new NhanVienDTO();
                nv.MaNV = dt.Rows[0]["manv"].ToString();
                nv.TenNV = dt.Rows[0]["tennv"].ToString();
                nv.GioiTinh = dt.Rows[0]["gioitinh"].ToString();
                nv.NgaySinh = DateTime.Parse(dt.Rows[0]["ngaysinh"].ToString());
                nv.DiaChi = dt.Rows[0]["diachi"].ToString();
                nv.DienThoai = int.Parse(dt.Rows[0]["dienthoai"].ToString());
                lstNV.Add(nv);
            }
            DataAccess.DongKetNoi(con);
            return lstNV;
        }
    }
}
