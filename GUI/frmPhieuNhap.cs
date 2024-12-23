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
    public partial class frmPhieuNhap : Form
    {
        public frmPhieuNhap()
        {
            InitializeComponent();
        }
        public void HT()
        {
            txtSoHD.Text = "";
            cboMaNV.Text = "";
            cboMaNCC.Text = "";
            dtpNgay.Text = "";
            txtGia.Text = "";
        }
        private void HienThiMaNV()
        {
            List<NhanVienDTO> listMNV = NhanVienBLL.LayNhanVien();
            cboMaNV.DataSource = listMNV;
            cboMaNV.DisplayMember = "MaNV";
            cboMaNV.ValueMember = "TenNV";
        }
        private void HienThiMaNCC()
        {
            List<NhaCungCapDTO> listNCC = NhaCungCapBLL.LayNCC();
            cboMaNCC.DataSource = listNCC;
            cboMaNCC.DisplayMember = "MaNCC";
            cboMaNCC.ValueMember = "TenNCC";
        }
        private void HienThiDSHDNhap()
        {
            List<HoaDonNhap> lstHDN = HoaDonNhapBLL.LayHDNhap();
            dgHoaDon.DataSource = lstHDN;
            dgHoaDon.Columns["sohd"].HeaderText = "Số HDN";
            dgHoaDon.Columns["manv"].HeaderText = "Mã nhân viên";
            dgHoaDon.Columns["ngaynhap"].HeaderText = "Ngày nhập";
            dgHoaDon.Columns["mancc"].HeaderText = "Mã nhà cung cấp";
            dgHoaDon.Columns["gianhap"].HeaderText = "Giá nhập";

            dgHoaDon.Columns["sohd"].Width = 80;
            dgHoaDon.Columns["manv"].Width = 80;
            dgHoaDon.Columns["ngaynhap"].Width = 100;
            dgHoaDon.Columns["mancc"].Width = 80;
            dgHoaDon.Columns["gianhap"].Width = 100;
        }

        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {
            HienThiDSHDNhap();
            HienThiMaNCC();
            HienThiMaNV();
        }

        private void dgHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgHoaDon.SelectedRows[0];
            txtSoHD.Text = row.Cells["sohd"].Value.ToString();
            cboMaNV.Text = row.Cells["manv"].Value.ToString();
            dtpNgay.Text = row.Cells["ngaynhap"].Value.ToString();
            cboMaNCC.Text = row.Cells["mancc"].Value.ToString();           
            txtGia.Text = row.Cells["gianhap"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtSoHD.Text == "" || cboMaNV.Text == "" ||  dtpNgay.Text == "" ||  cboMaNCC.Text == ""  || txtGia.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            //Kiểm tra mã có độ dài chuỗi hợp lệ hay không
            if (txtSoHD.Text.Length > 6)
            {
                MessageBox.Show("Số hóa đơn tối đa 6 ký tự!");
                return;
            }

            if (HoaDonNhapBLL.TimHDNTheoMa(txtSoHD.Text) != null)
            {
                MessageBox.Show("Số hóa đơn đã tồn tại!");
                return;
            }
            HoaDonNhap hdn = new HoaDonNhap();
            hdn.SoHD = txtSoHD.Text;
            hdn.MaNV = cboMaNV.Text;
            hdn.NgayNhap = DateTime.Parse(dtpNgay.Text);
            hdn.MaNCC = cboMaNCC.Text;   
            hdn.GiaNhap = int.Parse(txtGia.Text);
            HT();
            if (HoaDonNhapBLL.ThemHDN(hdn) == false)
            {
                MessageBox.Show("Không thêm được!");
                return;
            }
            HienThiDSHDNhap();
            MessageBox.Show("Đã thêm thành công!");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtSoHD.Text == "" || HoaDonNhapBLL.TimHDNTheoMa(txtSoHD.Text) == null)
            {
                MessageBox.Show("Vui lòng chọn số hóa đơn!");
                return;
            }
            HoaDonNhap hdn = new HoaDonNhap();
            hdn.SoHD = txtSoHD.Text;
            hdn.MaNV = cboMaNV.Text;
            hdn.NgayNhap = DateTime.Parse(dtpNgay.Text);
            hdn.MaNCC = cboMaNCC.Text;
            hdn.GiaNhap = int.Parse(txtGia.Text);
            HT();
            if (HoaDonNhapBLL.SuaHDN(hdn) == true)
            {
                HienThiDSHDNhap();
                MessageBox.Show("Đã cập nhật thành công!");
            }
            else
            {
                MessageBox.Show("Không cập nhật được!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            HoaDonNhap hdn = new HoaDonNhap();
            hdn.SoHD = txtSoHD.Text;
            hdn.MaNV = cboMaNV.Text;
            hdn.NgayNhap = DateTime.Parse(dtpNgay.Text);
            hdn.MaNCC = cboMaNCC.Text;
            hdn.GiaNhap = int.Parse(txtGia.Text);
            HT();
            if (HoaDonNhapBLL.XoaHDN(hdn) == true)
            {
                HienThiDSHDNhap();
                MessageBox.Show("Đã xóa thành công!");
            }
            else
            {
                MessageBox.Show("Không xóa được!");
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            frmCTPN pn = new frmCTPN();
            pn.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
