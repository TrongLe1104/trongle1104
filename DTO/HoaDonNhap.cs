using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonNhap
    {
        private string soHD;
        private string maNV;
        private DateTime ngayNhap;
        private string maNCC;
        private int giaNhap;

        public string SoHD { get => soHD; set => soHD = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public DateTime NgayNhap { get => ngayNhap; set => ngayNhap = value; }
        public string MaNCC { get => maNCC; set => maNCC = value; }
        public int GiaNhap { get => giaNhap; set => giaNhap = value; }
    }
}
