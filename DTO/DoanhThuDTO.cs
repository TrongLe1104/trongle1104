using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DoanhThuDTO
    {
        private string maSach;
        private string tenSach;
        private int gianNhap;
        private int giaBan;
        private int soLuongBan;
        private DateTime ngayBan;
        private int doanhThu;

        public string MaSach { get => maSach; set => maSach = value; }
        public string TenSach { get => tenSach; set => tenSach = value; }
        public int GianNhap { get => gianNhap; set => gianNhap = value; }
        public int GiaBan { get => giaBan; set => giaBan = value; }
        public int SoLuongBan { get => soLuongBan; set => soLuongBan = value; }
        public DateTime NgayBan { get => ngayBan; set => ngayBan = value; }
        public int DoanhThu { get => doanhThu; set => doanhThu = value; }
    }
}
