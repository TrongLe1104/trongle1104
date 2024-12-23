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
    public partial class frmSach : Form
    {
        public frmSach()
        {
            InitializeComponent();

        }
        public void HT()
        {
            txtMaSach.Text = "";
            txtTen.Text = "";
            cboMaTG.Text = "";
            cboMaTL.Text = "";
            cboMaNXB.Text = "";
            txtGiaNhap.Text = "";
            txtGiaBan.Text = "";
            txtSLTon.Text = "";
            txtTim.Text = "";
        }
        private void HienThiMaTheLoai()
        {
            List<TheLoaiDTO> listMTL = TheLoaiBLL.LayTheLoai(); 
            cboMaTL.DataSource = listMTL;
            cboMaTL.DisplayMember = "MaTL";
            cboMaTL.ValueMember = "TenTL"; 
        }
        private void HienThiMaTacGia()
        {
            List<TacGiaDTO> listMTG = TacGiaBLL.LayTacGia();
            cboMaTG.DataSource = listMTG;
            cboMaTG.DisplayMember = "MaTG";
            cboMaTG.ValueMember = "TenTG";
        }
        private void HienThiMaNXB()
        {
            List<NXBDTO> listNXB = NXBBLL.LayNXB();
            cboMaNXB.DataSource = listNXB;
            cboMaNXB.DisplayMember = "MaNXB";
            cboMaNXB.ValueMember = "TenNXB";
        }
        private void HienThiDSSach()
        {
            List<SachDTO> lstSach = SachBLL.LaySach();
            dgSach.DataSource = lstSach;
            dgSach.Columns["masach"].HeaderText = "Mã sách";
            dgSach.Columns["tensach"].HeaderText = "Tên sách";
            dgSach.Columns["matg"].HeaderText = "Mã tác giả";
            dgSach.Columns["matl"].HeaderText = "Mã thể loại";
            dgSach.Columns["manxb"].HeaderText = "Mã NXB";
            dgSach.Columns["gianhap"].HeaderText = "Giá nhập";
            dgSach.Columns["giaban"].HeaderText = "Giá bán";
            dgSach.Columns["soluong"].HeaderText = "Số lượng";

            dgSach.Columns["masach"].Width = 65;
            dgSach.Columns["tensach"].Width = 170;
            dgSach.Columns["matg"].Width = 65;
            dgSach.Columns["matl"].Width = 65;
            dgSach.Columns["manxb"].Width = 65;
            dgSach.Columns["gianhap"].Width = 65;
            dgSach.Columns["giaban"].Width = 65;
            dgSach.Columns["soluong"].Width = 65;
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Kiểm tra dữ liệu có bị bỏ trống 
            if (txtMaSach.Text == "" || txtTen.Text == "" || cboMaTG.Text == "" || cboMaTL.Text == "" || cboMaNXB.Text == "" || txtGiaNhap.Text == "" || txtGiaBan.Text == "" || txtSLTon.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            //Kiểm tra mã có độ dài chuỗi hợp lệ hay không
            if (txtMaSach.Text.Length > 6)
            {
                MessageBox.Show("Mã sách tối đa 6 ký tự!");
                return;
            }

            if (SachBLL.TimSachTheoMa(cboMaNXB.Text) != null)
            {
                MessageBox.Show("Mã sách đã tồn tại!");
                return;
            }
            SachDTO s = new SachDTO();
            s.MaSach = txtMaSach.Text;
            s.TenSach = txtTen.Text;
            s.MaTG = cboMaTG.Text;
            s.MaTL = cboMaTL.Text;
            s.MaNXB = cboMaNXB.Text;
            s.GiaNhap = int.Parse(txtGiaNhap.Text);
            s.GiaBan = int.Parse(txtGiaBan.Text);
            s.SoLuong = int.Parse(txtSLTon.Text);
            HT();
            if (SachBLL.ThemSach(s) == false)
            {
                MessageBox.Show("Không thêm được!");
                return;
            }
            HienThiDSSach();
            MessageBox.Show("Đã thêm thành công!");
        }

        private void frmSach_Load(object sender, EventArgs e)
        {
            HienThiDSSach();
            HienThiMaTheLoai();
            HienThiMaTacGia();
            HienThiMaNXB();
        }

        private void dgSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgSach.SelectedRows[0];
            txtMaSach.Text = row.Cells["masach"].Value.ToString();
            txtTen.Text = row.Cells["tensach"].Value.ToString();
            cboMaTG.Text = row.Cells["matg"].Value.ToString();
            cboMaTL.Text = row.Cells["matl"].Value.ToString();
            cboMaNXB.Text = row.Cells["manxb"].Value.ToString();
            txtGiaNhap.Text = row.Cells["gianhap"].Value.ToString();
            txtGiaBan.Text = row.Cells["giaban"].Value.ToString();
            txtSLTon.Text = row.Cells["soluong"].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SachDTO s = new SachDTO();
            s.MaSach = txtMaSach.Text;
            s.TenSach = txtTen.Text;
            s.MaTG = cboMaTG.Text;
            s.MaTL = cboMaTL.Text;
            s.MaNXB = cboMaNXB.Text;
            s.GiaNhap = int.Parse(txtGiaNhap.Text);
            s.GiaBan = int.Parse(txtGiaBan.Text);
            s.SoLuong = int.Parse(txtSLTon.Text);
            HT();
            if (SachBLL.XoaSach(s) == true)
            {
                HienThiDSSach();
                MessageBox.Show("Đã xóa thông tin thành công!");
            }
            else
            {
                MessageBox.Show("Không xóa được!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaSach.Text == "" || SachBLL.TimSachTheoMa(txtMaSach.Text) == null)
            {
                MessageBox.Show("Vui lòng chọn mã sách!");
                return;
            }
            SachDTO s = new SachDTO();
            s.MaSach = txtMaSach.Text;
            s.TenSach = txtTen.Text;
            s.MaTG = cboMaTG.Text;
            s.MaTL = cboMaTL.Text;
            s.MaNXB = cboMaNXB.Text;
            s.GiaNhap = int.Parse(txtGiaNhap.Text);
            s.GiaBan = int.Parse(txtGiaBan.Text);
            s.SoLuong = int.Parse(txtSLTon.Text);
            HT();
            if (SachBLL.SuaSach(s) == true)
            {
                HienThiDSSach();
                MessageBox.Show("Đã cập nhật thành công!");
            }
            else
            {
                MessageBox.Show("Không cập nhật được!");
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string ten = txtTim.Text;
            List<SachDTO> lstTen = SachBLL.TimSachTheoTen(ten);
            HT();
            if (lstTen == null)
            {
                MessageBox.Show("Không tìm thấy!");
                return;
            }
            dgSach.DataSource = lstTen;
        }
    }
}
