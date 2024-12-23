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
    public partial class frmTacGia : Form
    {
        public frmTacGia()
        {
            InitializeComponent();
        }
        public void HT()
        {
            txtMaTG.Text = "";
            txttenTG.Text = "";
            txtTim.Text = "";
        }
        private void HienThiDSTacGia()
        {
            List<TacGiaDTO> lstTacGia = TacGiaBLL.LayTacGia();
            dgTacGia.DataSource = lstTacGia;
            dgTacGia.Columns["matg"].HeaderText = "Mã TG";
            dgTacGia.Columns["tentg"].HeaderText = "Tên tác giả";

            dgTacGia.Columns["matg"].Width = 150;
            dgTacGia.Columns["tentg"].Width = 300;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            //Kiểm tra dữ liệu có bị bỏ trống 
            if (txtMaTG.Text == "" || txttenTG.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            //Kiểm tra mã có độ dài chuỗi hợp lệ hay không
            if (txtMaTG.Text.Length > 6)
            {
                MessageBox.Show("Mã tác giả tối đa 6 ký tự!");
                return;
            }

            if (TacGiaBLL.TimTGTheoMa(txtMaTG.Text) != null)
            {
                MessageBox.Show("Mã tác giả đã tồn tại!");
                return;
            }
            TacGiaDTO tg = new TacGiaDTO();
            tg.MaTG = txtMaTG.Text;
            tg.TenTG = txttenTG.Text;
            HT();
            if (TacGiaBLL.ThemTacGia(tg) == false)
            {
                MessageBox.Show("Không thêm được!");
                return;
            }
            HienThiDSTacGia();
            MessageBox.Show("Đã thêm thành công!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            TacGiaDTO tg = new TacGiaDTO();
            tg.MaTG = txtMaTG.Text;
            tg.TenTG = txttenTG.Text;
            HT();
            if (TacGiaBLL.XoaTacGia(tg) == true)
            {
                HienThiDSTacGia();
                MessageBox.Show("Đã xóa thông tin thành công!");
            }
            else
            {
                MessageBox.Show("Không xóa được!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaTG.Text == "" || TacGiaBLL.TimTGTheoMa(txtMaTG.Text) == null)
            {
                MessageBox.Show("Vui lòng chọn mã tác giả!");
                return;
            }
            TacGiaDTO tg = new TacGiaDTO();
            tg.MaTG = txtMaTG.Text;
            tg.TenTG= txttenTG.Text;
            HT();
            if (TacGiaBLL.SuaTacGia(tg) == true)
            {
                HienThiDSTacGia();
                MessageBox.Show("Đã cập nhật thành công!");
            }
            else
            {
                MessageBox.Show("Không cập nhật được!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgTacGia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgTacGia.SelectedRows[0];
            txtMaTG.Text = row.Cells["matg"].Value.ToString();
            txttenTG.Text = row.Cells["tentg"].Value.ToString();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string tg = txtTim.Text;
            List<TacGiaDTO> lstTG = TacGiaBLL.TimSachTheoTen(tg);
            HT();
            if (lstTG == null)
            {
                MessageBox.Show("Không tìm thấy!");
                return;
            }
            dgTacGia.DataSource = lstTG;
        }

        private void frmTacGia_Load(object sender, EventArgs e)
        {
            HienThiDSTacGia();
        }
    }
}
