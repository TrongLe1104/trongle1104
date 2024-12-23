using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietHDNDTO
    {
        private string soHD;
        private string maSach;
        private string tenSach;
        private int slNhap;

        public string SoHD { get => soHD; set => soHD = value; }
        public string MaSach { get => maSach; set => maSach = value; }
        public string TenSach { get => tenSach; set => tenSach = value; }
        public int SlNhap { get => slNhap; set => slNhap = value; }
    }
}
