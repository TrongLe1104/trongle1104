using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        public void HT()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            //gioitinh cboMaTG.Text = "";
            dtpNgay.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
        }
        private void HienThiDSNV()
        {
            List<NhanVienDTO> lstNV = NhanVienBLL.LayNhanVien();
            dgNV.DataSource = lstNV;
            dgNV.Columns["manv"].HeaderText = "Mã NV";
            dgNV.Columns["tennv"].HeaderText = "Tên nhân viên";
            dgNV.Columns["gioitinh"].HeaderText = "Giới tính";
            dgNV.Columns["ngaysinh"].HeaderText = "Ngày sinh";
            dgNV.Columns["diachi"].HeaderText = "Địa chỉ";
            dgNV.Columns["dienthoai"].HeaderText = "Điện thoại";

            dgNV.Columns["manv"].Width = 70;
            dgNV.Columns["tennv"].Width = 170;
            dgNV.Columns["gioitinh"].Width = 70;
            dgNV.Columns["ngaysinh"].Width = 80;
            dgNV.Columns["diachi"].Width = 130;
            dgNV.Columns["dienthoai"].Width = 80;
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            HienThiDSNV();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Kiểm tra dữ liệu có bị bỏ trống 
            if (txtMaNV.Text == "" || txtTenNV.Text == "" || dtpNgay.Text == "" || txtDiaChi.Text == "" || txtDienThoai.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            //Kiểm tra mã có độ dài chuỗi hợp lệ hay không
            if (txtMaNV.Text.Length > 6)
            {
                MessageBox.Show("Mã sách tối đa 6 ký tự!");
                return;
            }

            if (NhanVienBLL.TimNVTheoMa(txtMaNV.Text) != null)
            {
                MessageBox.Show("Mã sách đã tồn tại!");
                return;
            }
            NhanVienDTO nv = new NhanVienDTO();
            nv.MaNV = txtMaNV.Text;
            nv.TenNV = txtTenNV.Text;
            if (rad1.Checked == true)
            {
                nv.GioiTinh = "Nam";
            }
            else
            {
                nv.GioiTinh = "Nữ";
            }
            nv.NgaySinh = DateTime.Parse(dtpNgay.Text);
            nv.DiaChi = txtDiaChi.Text;
            nv.DienThoai = int.Parse(txtDienThoai.Text);
            HT();
            if (NhanVienBLL.ThemNV(nv) == false)
            {
                MessageBox.Show("Không thêm được!");
                return;
            }
            HienThiDSNV();
            MessageBox.Show("Đã thêm thành công!");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "" || NhanVienBLL.TimNVTheoMa(txtMaNV.Text) == null)
            {
                MessageBox.Show("Vui lòng chọn mã sách!");
                return;
            }
            NhanVienDTO nv = new NhanVienDTO();
            nv.MaNV = txtMaNV.Text;
            nv.TenNV = txtTenNV.Text;
            if (rad1.Checked == true)
            {
                nv.GioiTinh = "Nam";
            }
            else
            {
                nv.GioiTinh = "Nữ";
            }
            nv.NgaySinh = DateTime.Parse(dtpNgay.Text);
            nv.DiaChi = txtDiaChi.Text;
            nv.DienThoai = int.Parse(txtDienThoai.Text);
            HT();
            if (NhanVienBLL.SuaNV(nv) == true)
            {
                HienThiDSNV();
                MessageBox.Show("Đã cập nhật thành công!");
            }
            else
            {
                MessageBox.Show("Không cập nhật được!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            NhanVienDTO nv = new NhanVienDTO();
            nv.MaNV = txtMaNV.Text;
            nv.TenNV = txtTenNV.Text;
            if (rad1.Checked == true)
            {
                nv.GioiTinh = "Nam";
            }
            else
            {
                nv.GioiTinh = "Nữ";
            }
            nv.NgaySinh = DateTime.Parse(dtpNgay.Text);
            nv.DiaChi = txtDiaChi.Text;
            nv.DienThoai = int.Parse(txtDienThoai.Text);
            HT();
            if (NhanVienBLL.XoaNV(nv) == true)
            {
                HienThiDSNV();
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
            List<NhanVienDTO> lstNV = NhanVienBLL.TimNVTheoTen(ten);
            HT();
            if (lstNV == null)
            {
                MessageBox.Show("Không tìm thấy!");
                return;
            }
            dgNV.DataSource = lstNV;
        }

        private void dgNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgNV.SelectedRows[0];
            txtMaNV.Text = row.Cells["manv"].Value.ToString();
            txtTenNV.Text = row.Cells["tennv"].Value.ToString();
            if (row.Cells["gioitinh"].Value.ToString() == "Nam")
            {
                rad1.Checked = true;
            }
            else
            {
                rad2.Checked = true;
            }
            dtpNgay.Text = row.Cells["ngaysinh"].Value.ToString();
            txtDiaChi.Text = row.Cells["diachi"].Value.ToString();
            txtDienThoai.Text = row.Cells["dienthoai"].Value.ToString();
        }
    }
}
