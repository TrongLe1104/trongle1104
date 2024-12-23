using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }
        public void HT()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            txtTim.Text = "";
        }
        private void HienThiDSKH()
        {
            List<KhachHangDTO> lstKH = KhachHangBLL.LayKhachHang();
            dgKH.DataSource = lstKH;
            dgKH.Columns["makh"].HeaderText = "Mã KH";
            dgKH.Columns["tenkh"].HeaderText = "Tên khách hàng";
            dgKH.Columns["diachi"].HeaderText = "Địa chỉ";
            dgKH.Columns["dienthoai"].HeaderText = "Điện thoại";

            dgKH.Columns["makh"].Width = 100;
            dgKH.Columns["tenkh"].Width = 260;
            dgKH.Columns["diachi"].Width = 150;
            dgKH.Columns["dienthoai"].Width = 100;
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            HienThiDSKH();
        }

        private void dgKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgKH.SelectedRows[0];
            txtMaKH.Text = row.Cells["makh"].Value.ToString();
            txtTenKH.Text = row.Cells["tenkh"].Value.ToString();
            txtDiaChi.Text = row.Cells["diachi"].Value.ToString();
            txtDienThoai.Text = row.Cells["dienthoai"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text == "" || txtTenKH.Text == "" || txtDiaChi.Text == "" || txtDienThoai.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            //Kiểm tra mã có độ dài chuỗi hợp lệ hay không
            if (txtMaKH.Text.Length > 6)
            {
                MessageBox.Show("Mã khách hàng tối đa 6 ký tự!");
                return;
            }

            if (KhachHangBLL.TimKHTheoMa(txtMaKH.Text) != null)
            {
                MessageBox.Show("Mã khách hàng đã tồn tại!");
                return;
            }
            KhachHangDTO kh = new KhachHangDTO();
            kh.MaKH = txtMaKH.Text;
            kh.TenKH = txtTenKH.Text;
            kh.DiaChi = txtDiaChi.Text;
            kh.DienThoai = int.Parse(txtDienThoai.Text);
            HT();
            if (KhachHangBLL.ThemKH(kh) == false)
            {
                MessageBox.Show("Không thêm được!");
                return;
            }
            HienThiDSKH();
            MessageBox.Show("Đã thêm thành công!");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text == "" || KhachHangBLL.TimKHTheoMa(txtMaKH.Text) == null)
            {
                MessageBox.Show("Vui lòng chọn mã khách hàng!");
                return;
            }
            KhachHangDTO kh = new KhachHangDTO();
            kh.MaKH = txtMaKH.Text;
            kh.TenKH = txtTenKH.Text;
            kh.DiaChi = txtDiaChi.Text;
            kh.DienThoai = int.Parse(txtDienThoai.Text);
            HT();
            if (KhachHangBLL.SuaKH(kh) == true)
            {
                HienThiDSKH();
                MessageBox.Show("Đã cập nhật thành công!");
            }
            else
            {
                MessageBox.Show("Không cập nhật được!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            KhachHangDTO kh = new KhachHangDTO();
            kh.MaKH = txtMaKH.Text;
            kh.TenKH = txtTenKH.Text;
            kh.DiaChi = txtDiaChi.Text;
            kh.DienThoai = int.Parse(txtDienThoai.Text);
            HT();
            if (KhachHangBLL.XoaKH(kh) == true)
            {
                HienThiDSKH();
                MessageBox.Show("Đã xóa thông tin thành công!");
            }
            else
            {
                MessageBox.Show("Không xóa được!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string ten = txtTim.Text;
            List<KhachHangDTO> lstTen = KhachHangBLL.TimKHTheoTen(ten);
            HT();
            if (lstTen == null)
            {
                MessageBox.Show("Không tìm thấy!");
                return;
            }
            dgKH.DataSource = lstTen;
        }
    }
}
