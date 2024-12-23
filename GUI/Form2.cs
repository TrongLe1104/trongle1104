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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ModelPhieuNhap pn = new ModelPhieuNhap();
            List<CHITIETHDN> listCTHDN = pn.CHITIETHDNs.ToList();
            List<PhieuNhapReport> listReport = new List<PhieuNhapReport>();
            foreach (CHITIETHDN sv in listCTHDN)
            {
                PhieuNhapReport temp = new PhieuNhapReport();
                temp.soHD = sv.soHD;
                temp.maSach = sv.maSach;
                temp.tenSach = sv.tenSach;
                temp.slNhap = (int)sv.slNhap;
                temp.giaNhap = (int)sv.HDNHAP.giaNhap;
                temp.ngayNhap = (DateTime)sv.HDNHAP.ngayNhap;

                listReport.Add(temp);
            }
            reportViewer1.LocalReport.ReportPath = "ReportPhieuNhap.rdlc";
            var source = new ReportDataSource("DataSetPhieuNhap", listReport);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(source);
            this.reportViewer1.RefreshReport();
        }
    }
}
