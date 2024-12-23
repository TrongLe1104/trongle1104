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
    public partial class frmQuanLy : Form
    {
        public frmQuanLy()
        {
            InitializeComponent();
        }
        public bool bDangNhap;
        public static NguoiDungDTO NguoiDung;
        frmDangNhap fDN;
        private void HienThiMenu()
        {
            btnDangNhap.Enabled = !bDangNhap;
            btnDangXuat.Enabled = bDangNhap;

            if (bDangNhap == true)
            {
                // Hiển thị trạng thái đăng nhập
                sttNguoiDung.Text = "Người dùng: " + NguoiDung.Ten;

                // Hiển thị menu theo quyền, ví dụ: 
                //  1. quantri: sử dụng tất cả menu
                //  2. nhanvien: không sử dụng các menu: Danh mục, Nghiệp vụ       
                int iQuyen;
                if (NguoiDung == null)
                {
                    iQuyen = 0;
                }
                else
                {
                    iQuyen = int.Parse(NguoiDung.Quyen.ToString());
                }
                switch (iQuyen)
                {
                    case 1:
                        menuHeThong.Enabled = true;
                        menuQuanly.Enabled = true;
                        menuDanhmuc.Enabled = true;
                        menuNghiepVu.Enabled = true;
                        menuTroGiup.Enabled = true;    
                        break;
                    case 2:
                        menuQuanly.Enabled = false;
                        menuDanhmuc.Enabled = true;
                        menuNghiepVu.Enabled = true;
                        menuTroGiup.Enabled = true;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                sttNguoiDung.Text = "Chưa đăng nhập";
                menuQuanly.Enabled = false;
                menuDanhmuc.Enabled = false;
                menuNghiepVu.Enabled = false;
                menuTroGiup.Enabled = false;

            }
        }

        private void frmQuanLy_Load(object sender, EventArgs e)
        {
            HienThiMenu();
        }

        private void btnDangNhap_Click_1(object sender, EventArgs e)
        {
            fDN = new frmDangNhap();
            if (fDN.ShowDialog() == DialogResult.OK)
            {
                string sTen = fDN.txtTenDN.Text;
                string sMaKhau = fDN.txtMK.Text;

                NguoiDung = new NguoiDungDTO();
                NguoiDung = NguoiDungBLL.LayNguoiDung(sTen, sMaKhau);
                if (NguoiDung != null)
                {
                    bDangNhap = true;
                }
            }
            else
            {
                bDangNhap = false;
            }
            HienThiMenu();
        }

        private void btnDangXuat_Click_1(object sender, EventArgs e)
        {
            // Đóng tất cả form đang mở
            foreach (Form f in this.MdiChildren)
            {
                if (!f.IsDisposed)
                    f.Close();
            }
            // Đăng xuất & thiết lập lại menu
            bDangNhap = false;
            HienThiMenu();
        }

        private void thểLoạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTheLoai fc = new frmTheLoai();
            panel_show.Show();
            panel_show.Controls.Clear();
            fc.TopLevel = false;
            fc.Dock = DockStyle.Fill;
            panel_show.Controls.Add(fc);
            fc.Show();
        }

        private void tácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTacGia fc = new frmTacGia();
            panel_show.Show();
            panel_show.Controls.Clear();
            fc.TopLevel = false;
            fc.Dock = DockStyle.Fill;
            panel_show.Controls.Add(fc);
            fc.Show();
        }

        private void nhàXuấtBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNXB fc = new frmNXB();
            panel_show.Show();
            panel_show.Controls.Clear();
            fc.TopLevel = false;
            fc.Dock = DockStyle.Fill;
            panel_show.Controls.Add(fc);
            fc.Show();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhaCungCap fc = new frmNhaCungCap();
            panel_show.Show();
            panel_show.Controls.Clear();
            fc.TopLevel = false;
            fc.Dock = DockStyle.Fill;
            panel_show.Controls.Add(fc);
            fc.Show();
        }

        private void sáchToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmSach fc = new frmSach();
            panel_show.Show();
            panel_show.Controls.Clear();
            fc.TopLevel = false;
            fc.Dock = DockStyle.Fill;
            panel_show.Controls.Add(fc);
            fc.Show();
        }

        private void nhânViênToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
           frmNhanVien fc = new frmNhanVien();
           panel_show.Show();
           panel_show.Controls.Clear();
           fc.TopLevel = false;
           fc.Dock = DockStyle.Fill;
           panel_show.Controls.Add(fc);
           fc.Show();
        }

        private void kháchHàngToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmKhachHang fc = new frmKhachHang();
            panel_show.Show();
            panel_show.Controls.Clear();
            fc.TopLevel = false;
            fc.Dock = DockStyle.Fill;
            panel_show.Controls.Add(fc);
            fc.Show();
        }

        private void hóaĐơnBánSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmHoaDon fc = new frmHoaDon();
           panel_show.Show();
           panel_show.Controls.Clear();
           fc.TopLevel = false;
           fc.Dock = DockStyle.Fill;
           panel_show.Controls.Add(fc);
            fc.Show();
        }

        private void phiếuNhậpSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhieuNhap fc = new frmPhieuNhap();
            panel_show.Show();
            panel_show.Controls.Clear();
            fc.TopLevel = false;
            fc.Dock = DockStyle.Fill;
            panel_show.Controls.Add(fc);
            fc.Show();
        }

        private void doanhThuToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmDoanhThu fc = new frmDoanhThu();
            panel_show.Show();
            panel_show.Controls.Clear();
            fc.TopLevel = false;
            fc.Dock = DockStyle.Fill;
            panel_show.Controls.Add(fc);
            fc.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhachHang fc = new frmKhachHang();
            panel_show.Show();
            panel_show.Controls.Clear();
            fc.TopLevel = false;
            fc.Dock = DockStyle.Fill;
            panel_show.Controls.Add(fc);
            fc.Show();
        }

        private void menuHeThong_Click(object sender, EventArgs e)
        {

        }
    }
}
