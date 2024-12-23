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
using static BLL.NXBBLL;

namespace GUI
{
    public partial class frmNXB : Form
    {
        public frmNXB()
        {
            InitializeComponent();
        }
        public void HT()
        {
            txtMaNXB.Text = "";
            txtTenNXB.Text = "";
            txtTim.Text = "";
        }
        private void HienThiDSNXB()
        {
            List<NXBDTO> lstNXB = NXBBLL.LayNXB();
            dgNhaXuatBan.DataSource = lstNXB;
            dgNhaXuatBan.Columns["manxb"].HeaderText = "Mã NXB";
            dgNhaXuatBan.Columns["tennxb"].HeaderText = "Tên NXB";

            dgNhaXuatBan.Columns["manxb"].Width = 150;
            dgNhaXuatBan.Columns["tennxb"].Width = 300;

        }

        private void frmNXB_Load(object sender, EventArgs e)
        {
            HienThiDSNXB();
        }

        private void dgNhaXuatBan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgNhaXuatBan.SelectedRows[0];
            txtMaNXB.Text = row.Cells["manxb"].Value.ToString();
            txtTenNXB.Text = row.Cells["tennxb"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Kiểm tra dữ liệu có bị bỏ trống 
            if (txtMaNXB.Text == "" || txtTenNXB.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            //Kiểm tra mã có độ dài chuỗi hợp lệ hay không
            if (txtMaNXB.Text.Length > 6)
            {
                MessageBox.Show("Mã NXB tối đa 6 ký tự!");
                return;
            }

            if (NXBBLL.TimNXBTheoMa(txtMaNXB.Text) != null)
            {
                MessageBox.Show("Mã NXB đã tồn tại!");
                return;
            }
            NXBDTO nxb = new NXBDTO();
            nxb.MaNXB = txtMaNXB.Text;
            nxb.TenNXB = txtTenNXB.Text;
            HT();
            if (NXBBLL.ThemNXB(nxb) == false)
            {
                MessageBox.Show("Không thêm được!");
                return;
            }
            HienThiDSNXB();
            MessageBox.Show("Đã thêm thành công!");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaNXB.Text == "" || NXBBLL.TimNXBTheoMa(txtMaNXB.Text) == null)
            {
                MessageBox.Show("Vui lòng chọn mã NXB!");
                return;
            }
            NXBDTO nxb = new NXBDTO();
            nxb.MaNXB = txtMaNXB.Text;
            nxb.TenNXB = txtTenNXB.Text;
            HT();
            if (NXBBLL.SuaNXB(nxb) == true)
            {
                HienThiDSNXB();
                MessageBox.Show("Đã cập nhật thành công!");
            }
            else
            {
                MessageBox.Show("Không cập nhật được!");
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string nxb = txtTim.Text;
            List<NXBDTO> lstNXB = NXBBLL.TimSachTheoTen(nxb);
            HT();
            if (lstNXB == null)
            {
                MessageBox.Show("Không tìm thấy!");
                return;
            }
            dgNhaXuatBan.DataSource = lstNXB;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            NXBDTO nxb = new NXBDTO();
            nxb.MaNXB = txtMaNXB.Text;
            nxb.TenNXB = txtTenNXB.Text;
            HT();
            if (NXBBLL.XoaNXB(nxb) == true)
            {
                HienThiDSNXB();
                MessageBox.Show("Đã xóa thành công!");
            }
            else
            {
                MessageBox.Show("Không xóa được!");
            }
        }
    }
}
