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
    public partial class frmHoaDon : Form
    {
        public frmHoaDon()
        {
            InitializeComponent();
        }
        public void HT()
        {
            txtSoHD.Text = "";
            cboMaNV.Text = "";
            cboMaKH.Text = "";
            dtpNgay.Text = "";
        }
        private void HienThiMaNV()
        {
            List<NhanVienDTO> listMNV = NhanVienBLL.LayNhanVien();
            cboMaNV.DataSource = listMNV;
            cboMaNV.DisplayMember = "MaNV";
            cboMaNV.ValueMember = "TenNV";
        }
        private void HienThiMaKH()
        {
            List<KhachHangDTO> listMKH = KhachHangBLL.LayKhachHang();
            cboMaKH.DataSource = listMKH;
            cboMaKH.DisplayMember = "MaKH";
            cboMaKH.ValueMember = "TenKH";
        }
        private void HienThiDSHDB()
        {
            List<HoaDonBanDTO> lstHDB = HoaDonBanBLL.LayHoaDon();
            dgHoaDon.DataSource = lstHDB;
            dgHoaDon.Columns["sohdb"].HeaderText = "Số HDB";
            dgHoaDon.Columns["manv"].HeaderText = "Mã nhân viên";
            dgHoaDon.Columns["makh"].HeaderText = "Mã khách hàng";
            dgHoaDon.Columns["ngayban"].HeaderText = "Ngày bán";

            dgHoaDon.Columns["sohdb"].Width = 100;
            dgHoaDon.Columns["manv"].Width = 100;
            dgHoaDon.Columns["makh"].Width = 100;
            dgHoaDon.Columns["ngayban"].Width = 150;
        }

        private void dgHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgHoaDon.SelectedRows[0];
            txtSoHD.Text = row.Cells["sohdb"].Value.ToString();
            cboMaNV.Text = row.Cells["manv"].Value.ToString();
            cboMaKH.Text = row.Cells["makh"].Value.ToString();
            dtpNgay.Text = row.Cells["ngayban"].Value.ToString();
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            HienThiDSHDB();
            HienThiMaNV();
            HienThiMaKH();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtSoHD.Text == "" || cboMaNV.Text == "" || cboMaKH.Text == "" || dtpNgay.Text == "")
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

            if (HoaDonBanBLL.TimHDBTheoMa(txtSoHD.Text) != null)
            {
                MessageBox.Show("Số hóa đơn đã tồn tại!");
                return;
            }
            HoaDonBanDTO hdb = new HoaDonBanDTO();
            hdb.SoHDB = txtSoHD.Text;
            hdb.MaNV = cboMaNV.Text;
            hdb.MaKH = cboMaKH.Text;
            hdb.NgayBan = DateTime.Parse(dtpNgay.Text);
            HT();
            if (HoaDonBanBLL.ThemHDB(hdb) == false)
            {
                MessageBox.Show("Không thêm được!");
                return;
            }
            HienThiDSHDB();
            MessageBox.Show("Đã thêm thành công!");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtSoHD.Text == "" || HoaDonBanBLL.TimHDBTheoMa(txtSoHD.Text) == null)
            {
                MessageBox.Show("Vui lòng chọn số hóa đơn!");
                return;
            }
            HoaDonBanDTO hdb = new HoaDonBanDTO();
            hdb.SoHDB = txtSoHD.Text;
            hdb.MaNV = cboMaNV.Text;
            hdb.MaKH = cboMaKH.Text;
            hdb.NgayBan = DateTime.Parse(dtpNgay.Text);
            HT();
            if (HoaDonBanBLL.SuaHDB(hdb) == true)
            {
                HienThiDSHDB();
                MessageBox.Show("Đã cập nhật thành công!");
            }
            else
            {
                MessageBox.Show("Không cập nhật được!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            HoaDonBanDTO hdb = new HoaDonBanDTO();
            hdb.SoHDB = txtSoHD.Text;
            hdb.MaNV = cboMaNV.Text;
            hdb.MaKH = cboMaKH.Text;
            hdb.NgayBan = DateTime.Parse(dtpNgay.Text);
            HT();
            if (HoaDonBanBLL.XoaHDB(hdb) == true)
            {
                HienThiDSHDB();
                MessageBox.Show("Đã xóa thành công!");
            }
            else
            {
                MessageBox.Show("Không xóa được!");
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            frmCTHD cthd = new frmCTHD();
            cthd.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
