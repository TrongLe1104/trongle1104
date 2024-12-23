using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietHDBDTO
    {
        private string soHDB;
        private string maSach;
        private string tenSach;
        private int donGia;
        private int soLuong;
        private int thanhTien;

        public string SoHDB { get => soHDB; set => soHDB = value; }
        public string MaSach { get => maSach; set => maSach = value; }
        public string TenSach { get => tenSach; set => tenSach = value; }
        public int DonGia { get => donGia; set => donGia = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public int ThanhTien { get => thanhTien; set => thanhTien = value; }
    }
}
