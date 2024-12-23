using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SachDTO
    {
        private string maSach;
        private string tenSach;
        private string maTG;
        private string maTL;
        private string maNXB;
        private int giaNhap;
        private int giaBan;
        private int soLuong;

        public string MaSach { get => maSach; set => maSach = value; }
        public string TenSach { get => tenSach; set => tenSach = value; }
        public string MaTG { get => maTG; set => maTG = value; }
        public string MaTL { get => maTL; set => maTL = value; }
        public string MaNXB { get => maNXB; set => maNXB = value; }
        public int GiaNhap { get => giaNhap; set => giaNhap = value; }
        public int GiaBan { get => giaBan; set => giaBan = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
    }
}
