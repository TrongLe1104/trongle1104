using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmCTHD : Form
    {
        public frmCTHD()
        {
            InitializeComponent();
        }
        public void HT()
        {
            cboSoHD.Text = "";
            cboMaSach.Text = "";
            txtTenSach.Text = "";
            txtDG.Text = "";
            txtSL.Text = "";
            txtTien.Text = "";
            txtTim.Text = "";
        }
        private void HienThiSoHD()
        {
            List<HoaDonBanDTO> listSHD = HoaDonBanBLL.LayHoaDon();
            cboSoHD.DataSource = listSHD;
            cboSoHD.DisplayMember = "SoHDB";
            cboSoHD.ValueMember = "MaNV";
        }
        private void HienThiMaSach()
        {
            List<SachDTO> listSach = SachBLL.LaySach();
            cboMaSach.DataSource = listSach;
            cboMaSach.DisplayMember = "MaSach";
            cboMaSach.ValueMember = "MaSach";
            cboMaSach.SelectedIndexChanged += cboMaSP_SelectedIndexChanged;
            if (listSach.Count > 0)
            {
                HienThiTenSach(listSach[0].MaSach);
            }
        }
    
        private void HienThiTenSach(string masach)
        {
            SachDTO sach = SachBLL.TimSachTheoMa(masach);
            if (sach != null)
            {
                txtTenSach.Text = sach.TenSach;
            }
            else
            {
                txtTenSach.Text = string.Empty;
            }
        }
        private void cboMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            string masach = cboMaSach.SelectedValue.ToString();
            HienThiTenSach(masach);
            
        }
        private void HienThiDSCTHD()
        {
            List<ChiTietHDBDTO> lstHDB = ChiTietHoaDonBLL.LayCTHDBAN(txtTenSach.Text);
            dgHoaDon.DataSource = lstHDB;
            dgHoaDon.Columns["sohdb"].HeaderText = "Số HDB";
            dgHoaDon.Columns["masach"].HeaderText = "Mã sách";
            dgHoaDon.Columns["tensach"].HeaderText = "Tên sách";
            dgHoaDon.Columns["dongia"].HeaderText = "Đơn giá";
            dgHoaDon.Columns["soluong"].HeaderText = "Số lượng";
            dgHoaDon.Columns["thanhtien"].HeaderText = "Thành tiền";

            dgHoaDon.Columns["sohdb"].Width = 80;
            dgHoaDon.Columns["masach"].Width = 80;
            dgHoaDon.Columns["tensach"].Width = 200;
            dgHoaDon.Columns["dongia"].Width = 80;
            dgHoaDon.Columns["soluong"].Width = 80;
            dgHoaDon.Columns["thanhtien"].Width = 100;
        }

        private void frmCTHD_Load(object sender, EventArgs e)
        {
            HienThiDSCTHD();
            HienThiSoHD();
            HienThiMaSach();
        }

        private void dgHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgHoaDon.SelectedRows[0];
            cboSoHD.Text = row.Cells["sohdb"].Value.ToString();
            cboMaSach.Text = row.Cells["masach"].Value.ToString();
            txtTenSach.Text = row.Cells["tensach"].Value.ToString();
            txtDG.Text = row.Cells["dongia"].Value.ToString();
            txtSL.Text = row.Cells["soluong"].Value.ToString();
            txtTien.Text = row.Cells["thanhtien"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboSoHD.Text == "" || cboMaSach.Text == "" || txtTenSach.Text == "" || txtDG.Text == "" || txtSL.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            //Kiểm tra mã có độ dài chuỗi hợp lệ hay không
            if (cboSoHD.Text.Length > 6)
            {
                MessageBox.Show("Số hóa đơn tối đa 6 ký tự!");
                return;
            }

            if (ChiTietHoaDonBLL.TimCTHDBTheoMa(cboSoHD.Text) != null)
            {
                MessageBox.Show("Mã hóa đơn đã tồn tại!");
                return;
            }


            ChiTietHDBDTO nv = new ChiTietHDBDTO();
            nv.SoHDB = cboSoHD.Text;
            nv.MaSach = cboMaSach.Text;
            nv.TenSach = txtTenSach.Text;
            nv.DonGia = int.Parse(txtDG.Text);
            nv.SoLuong = int.Parse(txtSL.Text);
            //nv.ThanhTien = int.Parse(txtTien.Text);
            nv.ThanhTien = nv.DonGia * nv.SoLuong;
            nv.ThanhTien.ToString(txtTien.Text);

            HT();
            if (ChiTietHoaDonBLL.ThemCT(nv) == false)
            {
                MessageBox.Show("Không thêm được!");
                return;
            }
            if (ChiTietHoaDonBLL.CapNhatSLTrongKho(nv) == false)
            {
                MessageBox.Show("Không cập nhật được!");
                return;
            }
            

            HienThiDSCTHD();
            MessageBox.Show("Đã thêm thành công!");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (cboSoHD.Text == "" || ChiTietHoaDonBLL.TimCTHDBTheoMa(cboSoHD.Text) == null)
            {
                MessageBox.Show("Vui lòng chọn số hóa đơn!");
                return;
            }
            ChiTietHDBDTO nv = new ChiTietHDBDTO();
            nv.SoHDB = cboSoHD.Text;
            nv.MaSach = cboMaSach.Text;
            nv.TenSach = txtTenSach.Text;
            nv.DonGia = int.Parse(txtDG.Text);
            nv.SoLuong = int.Parse(txtSL.Text);
            nv.ThanhTien = int.Parse(txtTien.Text);
            HT();
            if (ChiTietHoaDonBLL.SuaCT(nv) == false)
            {
                MessageBox.Show("Không cập nhật được!");
                return;
            }
            HienThiDSCTHD();
            MessageBox.Show("Đã cập nhật thành công!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            ChiTietHDBDTO nv = new ChiTietHDBDTO();
            nv.SoHDB = cboSoHD.Text;
            nv.MaSach = cboMaSach.Text;
            nv.TenSach = txtTenSach.Text;
            nv.DonGia = int.Parse(txtDG.Text);
            nv.SoLuong = int.Parse(txtSL.Text);
            nv.ThanhTien = int.Parse(txtTien.Text);
            HT();
            if (ChiTietHoaDonBLL.XoaCT(nv) == false)
            {
                MessageBox.Show("Không xóa được!");
                return;
            }
            if (ChiTietHoaDonBLL.CapNhatSLKhoKhiXoaCTHDB(nv) == false)
            {
                MessageBox.Show("Không cập nhật được!");
                return;
            }
            HienThiDSCTHD();
            MessageBox.Show("Đã xóa thông tin thành công!");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string ten = txtTim.Text;
            List<ChiTietHDBDTO> lstNV = ChiTietHoaDonBLL.TimCTHDBTheoTen(ten);
            HT();
            if (lstNV == null)
            {
                MessageBox.Show("Không tìm thấy!");
                return;
            }
            dgHoaDon.DataSource = lstNV;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.ShowDialog();
        }
    }
}
