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
    public partial class frmTheLoai : Form
    {
        public frmTheLoai()
        {
            InitializeComponent();
        }
        public void HT()
        {
            txtMaTL.Text = "";
            txtTenTL.Text = "";
            txtTim.Text = "";
        }
        private void HienThiDSTheLoaiLenDatagrid()
        {
            List<TheLoaiDTO> lstTheLoai = TheLoaiBLL.LayTheLoai();
            dgTheLoai.DataSource = lstTheLoai;
            dgTheLoai.Columns["matl"].HeaderText = "Mã thể loại";
            dgTheLoai.Columns["tentl"].HeaderText = "Tên thể loại";

            dgTheLoai.Columns["matl"].Width = 130;
            dgTheLoai.Columns["tentl"].Width = 300;
        }

        private void frmTheLoai_Load(object sender, EventArgs e)
        {
            HienThiDSTheLoaiLenDatagrid();
        }

        private void dgTheLoai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow r = new DataGridViewRow();
            r = dgTheLoai.SelectedRows[0];
            txtMaTL.Text = r.Cells["matl"].Value.ToString();
            txtTenTL.Text = r.Cells["tentl"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Kiểm tra dữ liệu có bị bỏ trống 
            if (txtMaTL.Text == "" || txtTenTL.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            //Kiểm tra mã nhân viên có độ dài chuỗi hợp lệ hay không
            if (txtMaTL.Text.Length > 6)
            {
                MessageBox.Show("Mã thể loại tối đa 6 ký tự!");
                return;
            }

            if (TheLoaiBLL.TimTheLoaiTheoMa(txtMaTL.Text) != null)
            {
                MessageBox.Show("Mã thể loại đã tồn tại!");
                return;
            }
            TheLoaiDTO tl = new TheLoaiDTO();
            tl.MaTL = txtMaTL.Text;
            tl.TenTL = txtTenTL.Text;
            HT();
            if (TheLoaiBLL.ThemTheLoai(tl) == false)
            {
                MessageBox.Show("Không thêm được!");
                return;
            }
            HienThiDSTheLoaiLenDatagrid();
            MessageBox.Show("Đã thêm thành công!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            TheLoaiDTO tl = new TheLoaiDTO();
            tl.MaTL = txtMaTL.Text;
            tl.TenTL = txtTenTL.Text;
            HT();
            if (TheLoaiBLL.XoaTheLoai(tl) == true)
            {
                HienThiDSTheLoaiLenDatagrid();
                MessageBox.Show("Đã xóa thông tin thể loại!");
            }
            else
            {
                MessageBox.Show("Không xóa được!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaTL.Text == "" || TheLoaiBLL.TimTheLoaiTheoMa(txtMaTL.Text) == null)
            {
                MessageBox.Show("Vui lòng chọn mã thể loại!");
                return;
            }
            TheLoaiDTO tl = new TheLoaiDTO();
            tl.MaTL = txtMaTL.Text;
            tl.TenTL = txtTenTL.Text;
            HT();
            if (TheLoaiBLL.SuaTheLoai(tl) == true)
            {
                HienThiDSTheLoaiLenDatagrid();
                MessageBox.Show("Đã cập nhật thông tin thể loại!");
            }
            else
            {
                MessageBox.Show("Không cập nhật được!");
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string theloai = txtTim.Text;
            List<TheLoaiDTO> lstTL = TheLoaiBLL.TimSachTheoTen(theloai);
            HT();
            if (lstTL == null)
            {
                MessageBox.Show("Không tìm thấy!");
                return;
            }
            dgTheLoai.DataSource = lstTL;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
