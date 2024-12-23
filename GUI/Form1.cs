using Microsoft.Reporting.WinForms;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ModelHoaDon hoadon = new ModelHoaDon();
            List<CTHDBAN> listCTHDB = hoadon.CTHDBANs.ToList();
            List<HoaDonReport> listReport = new List<HoaDonReport>();
            foreach(CTHDBAN sv in listCTHDB)
            {
                HoaDonReport temp = new HoaDonReport();
                temp.soHDB = sv.soHDB;
                temp.maSach = sv.maSach;
                temp.tenSach = sv.tenSach;
                temp.donGia = (int)sv.donGia;
                temp.soLuong = (int)sv.soLuong;
                temp.thanhTien = (int)sv.thanhTien;

                listReport.Add(temp);
            }
            reportViewer1.LocalReport.ReportPath = "ReportHoaDon.rdlc";
            var source = new ReportDataSource("DataSetHoaDon", listReport);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(source);
            this.reportViewer1.RefreshReport();
        }
    }
}
