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
    public partial class frmNhaCungCap : Form
    {
        public frmNhaCungCap()
        {
            InitializeComponent();
        }
        public void HT()
        {
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtTim.Text = "";
        }
        private void HienThiDSNCCLenDatagrid()
        {
            List<NhaCungCapDTO> lstNCC = NhaCungCapBLL.LayNCC();
            dgNCC.DataSource = lstNCC;
            dgNCC.Columns["mancc"].HeaderText = "Mã nhà cung cấp";
            dgNCC.Columns["tenncc"].HeaderText = "Tên nhà cung cấp";

            dgNCC.Columns["mancc"].Width = 150;
            dgNCC.Columns["tenncc"].Width = 300;
        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            HienThiDSNCCLenDatagrid();
        }

        private void dgNCC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow r = new DataGridViewRow();
            r = dgNCC.SelectedRows[0];
            txtMaNCC.Text = r.Cells["mancc"].Value.ToString();
            txtTenNCC.Text = r.Cells["tenncc"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Kiểm tra dữ liệu có bị bỏ trống 
            if (txtMaNCC.Text == "" || txtTenNCC.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            //Kiểm tra mã nhân viên có độ dài chuỗi hợp lệ hay không
            if (txtMaNCC.Text.Length > 6)
            {
                MessageBox.Show("Mã nhà cung cấp tối đa 6 ký tự!");
                return;
            }

            if (NhaCungCapBLL.TimTheLoaiTheoMa(txtMaNCC.Text) != null)
            {
                MessageBox.Show("Mã nhà cung cấp đã tồn tại!");
                return;
            }
            NhaCungCapDTO ncc = new NhaCungCapDTO();
            ncc.MaNCC = txtMaNCC.Text;
            ncc.TenNCC = txtTenNCC.Text;
            HT();
            if (NhaCungCapBLL.ThemNCC(ncc) == false)
            {
                MessageBox.Show("Không thêm được!");
                return;
            }
            HienThiDSNCCLenDatagrid();
            MessageBox.Show("Đã thêm thành công!");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaNCC.Text == "" || NhaCungCapBLL.TimTheLoaiTheoMa(txtMaNCC.Text) == null)
            {
                MessageBox.Show("Vui lòng chọn mã nhà cung cấp!");
                return;
            }
            NhaCungCapDTO ncc = new NhaCungCapDTO();
            ncc.MaNCC = txtMaNCC.Text;
            ncc.TenNCC = txtTenNCC.Text;
            HT();
            if (NhaCungCapBLL.SuaNCC(ncc) == true)
            {
                HienThiDSNCCLenDatagrid();
                MessageBox.Show("Đã cập nhật thông tin nhà cung cấp!");
            }
            else
            {
                MessageBox.Show("Không cập nhật được!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            NhaCungCapDTO ncc = new NhaCungCapDTO();
            ncc.MaNCC = txtMaNCC.Text;
            ncc.TenNCC = txtTenNCC.Text;
            HT();
            if (NhaCungCapBLL.XoaNCC(ncc) == true)
            {
                HienThiDSNCCLenDatagrid();
                MessageBox.Show("Đã xóa thông tin nhà cung cấp!");
            }
            else
            {
                MessageBox.Show("Không xóa được!");
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string ncc = txtTim.Text;
            List<NhaCungCapDTO> lstNCC = NhaCungCapBLL.TimSachTheoTen(ncc);
            HT();
            if (lstNCC == null)
            {
                MessageBox.Show("Không tìm thấy!");
                return;
            }
            dgNCC.DataSource = lstNCC;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
