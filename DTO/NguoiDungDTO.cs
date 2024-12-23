using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NguoiDungDTO
    {
        private string ten;
        private string matKhau;
        private int quyen;

        public NguoiDungDTO()
        {

        }
        public NguoiDungDTO(string ten, string matKhau, int quyen)
        {
            Ten = ten;
            MatKhau = matKhau;
            Quyen = quyen;
        }
        public string Ten { get => ten; set => ten = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public int Quyen { get => quyen; set => quyen = value; }
    }
}
