using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonBanDTO
    {
        private string soHDB;
        private string maNV;
        private string maKH;
        private DateTime ngayBan;

        public string SoHDB { get => soHDB; set => soHDB = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public string MaKH { get => maKH; set => maKH = value; }
        public DateTime NgayBan { get => ngayBan; set => ngayBan = value; }
    }
}
