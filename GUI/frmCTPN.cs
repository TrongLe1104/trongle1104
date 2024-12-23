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
    public partial class frmCTPN : Form
    {
        public frmCTPN()
        {
            InitializeComponent();
        }
        public void HT()
        {
            cboSoHD.Text = "";
            cboMaSach.Text = "";
            txtTen.Text = "";
            txtSL.Text = "";
        }
        private void HienThiSoHD()
        {
            List<HoaDonNhap> listSHD = HoaDonNhapBLL.LayHDNhap();
            cboSoHD.DataSource = listSHD;
            cboSoHD.DisplayMember = "SoHD";
            cboSoHD.ValueMember = "MaNV";
        }
        private void HienThiMaSach()
        {
            List<SachDTO> listSach = SachBLL.LaySach();
            cboMaSach.DataSource = listSach;
            cboMaSach.DisplayMember = "MaSach";
            cboMaSach.ValueMember = "MaSach";
            cboMaSach.SelectedIndexChanged += cboMaSP_SelectedIndexChanged;
            if(listSach.Count > 0)
            {
                HienThiTenSach(listSach[0].MaSach);
            }    
        }
        private void cboMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            string masach = cboMaSach.SelectedValue.ToString();
            HienThiTenSach(masach);
            //string sl = cbMaKH.SelectedValue.ToString();
            // HienThiSLHangH(sl);
        }
        private void HienThiDSCTHD()
        {
            List<ChiTietHDNDTO> lstHDB = ChiTietPNBLL.LayCTHDNhap(txtTen.Text);
            dgHoaDon.DataSource = lstHDB;
            dgHoaDon.Columns["sohd"].HeaderText = "Số HD";
            dgHoaDon.Columns["masach"].HeaderText = "Mã sách";
            dgHoaDon.Columns["tensach"].HeaderText = "Tên sách";
            dgHoaDon.Columns["slnhap"].HeaderText = "Số lượng nhập";

            dgHoaDon.Columns["sohd"].Width = 80;
            dgHoaDon.Columns["masach"].Width = 80;
            dgHoaDon.Columns["tensach"].Width = 200;
            dgHoaDon.Columns["slnhap"].Width = 80;
        }

        private void dgHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgHoaDon.SelectedRows[0];
            cboSoHD.Text = row.Cells["sohd"].Value.ToString();
            cboMaSach.Text = row.Cells["masach"].Value.ToString();
            txtTen.Text = row.Cells["tensach"].Value.ToString();
            txtSL.Text = row.Cells["slnhap"].Value.ToString();
        }

        private void frmCTPN_Load(object sender, EventArgs e)
        {
            HienThiDSCTHD();
            HienThiSoHD();
            HienThiMaSach();
        }
        private void HienThiTenSach(string masach)
        {
            SachDTO sach = SachBLL.TimSachTheoMa(masach);
            if (sach != null)
            {
                txtTen.Text = sach.TenSach;
            }
            else
            {
                txtTen.Text = string.Empty;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboSoHD.Text == "" || cboMaSach.Text == "" || txtTen.Text == "" || txtSL.Text == "")
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
            if (ChiTietPNBLL.TimCTHDTheoMa(cboSoHD.Text) != null)
            {
                MessageBox.Show("Mã hóa đơn đã tồn tại!");
                return;
            }
            ChiTietHDNDTO nv = new ChiTietHDNDTO();
            nv.SoHD = cboSoHD.Text;
            nv.MaSach = cboMaSach.Text;
            nv.TenSach = txtTen.Text;
            nv.SlNhap = int.Parse(txtSL.Text);
            HT();
            if (ChiTietPNBLL.ThemCT(nv) == false)
            {
                MessageBox.Show("Không thêm được!");
                return;
            }
            if (ChiTietPNBLL.CapNhatSLTrongKho(nv) == false)
            {
                MessageBox.Show("Không cập nhật được!");
                return;
            }
            HienThiDSCTHD();
            MessageBox.Show("Đã thêm thành công!");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (cboSoHD.Text == "" || ChiTietPNBLL.TimCTHDTheoMa(cboSoHD.Text) == null)
            {
                MessageBox.Show("Vui lòng chọn số hóa đơn!");
                return;
            }
            ChiTietHDNDTO nv = new ChiTietHDNDTO();
            nv.SoHD = cboSoHD.Text;
            nv.MaSach = cboMaSach.Text;
            nv.TenSach = txtTen.Text;
            nv.SlNhap = int.Parse(txtSL.Text);
            HT();
            if (ChiTietPNBLL.SuaCT(nv) == false)
            {
                MessageBox.Show("Không cập nhật được!");
                return;
            }
            HienThiDSCTHD();
            MessageBox.Show("Đã cập nhật thành công!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            ChiTietHDNDTO nv = new ChiTietHDNDTO();
            nv.SoHD = cboSoHD.Text;
            nv.MaSach = cboMaSach.Text;
            nv.TenSach = txtTen.Text;
            nv.SlNhap = int.Parse(txtSL.Text);
            HT();
            if (ChiTietPNBLL.XoaCT(nv) == false)
            {
                MessageBox.Show("Không xóa được!");
                return;
            }
            if (ChiTietPNBLL.CapNhatSLKhoKhiXoaCTHDN(nv) == false)
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

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.ShowDialog();
        }
    }
}
