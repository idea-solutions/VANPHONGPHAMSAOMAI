using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataLayer;
using BusinessLayer;
using DevExpress.XtraCharts;

namespace VANPHONGPHAM
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnLoaiHang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmLOAIMATHANG frm = new frmLOAIMATHANG();
            frm.Show();
        }

        private void btnMatHang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmMATHANG frm = new frmMATHANG();
            frm.Show();
        }

        private void btnKhachHang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmKHACHHANG frm = new frmKHACHHANG();
            frm.Show();
        }

        private void btnNhanVien_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmNHANVIEN frm = new frmNHANVIEN();
            frm.Show();
        }

        private void btnNCC_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmNHACUNGCAP frm = new frmNHACUNGCAP();
            frm.Show();
        }

        THONGKE _thongke;
        Series series = new Series("", ViewType.Pie); // tròn
        Series series1 = new Series("", ViewType.Bar); // cột
        Series series2 = new Series("", ViewType.Bar); // cột


        public void frmMain_Load(object sender, EventArgs e)
        {
            _thongke = new THONGKE();
            loadChart();
            chartControl1.Series.Add(series);
            chartControl3.Series.Add(series1);
            chartControl2.Series.Add(series2);
            series.Label.TextPattern = "{A}: {VP: p0}";
            //series1.Label.TextPattern = "{A}: {VP: p0}";
            //
            timer1.Enabled = true;
            timer1.Start();
            label5.Text = DateTime.Now.ToLongTimeString();
        }

        public void loadChart()
        {
            List<OBJTHONGKELOAIMH> lstMH;
            lstMH= new List<OBJTHONGKELOAIMH>();
            lstMH = _thongke.thongKeMatHang();

            List<OBJTHONGKEKHACHHANG> lstKH;
            lstKH = new List<OBJTHONGKEKHACHHANG>();
            lstKH = _thongke.thongKeKhachHang();


            List<OBJTHONGKEBANHANG> lstBH;
            lstBH= new List<OBJTHONGKEBANHANG>();
            lstBH = _thongke.thongKeBanHang();
            series.Points.Clear();
            foreach (var item in lstMH)
            {
                series.Points.Add(new SeriesPoint(item.TENLOAI, item.SOLUONG));
            }
            foreach (var item in lstBH)
            {
                series1.Points.Add(new SeriesPoint(item.TENMH, item.SOLUONG));
            }

            foreach (var item in lstKH)
            {
                series2.Points.Add(new SeriesPoint(item.TENKH, item.THANHTIEN));
            }
        }

        private void btnBanHang_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmBanHang frm = new frmBanHang();
            frm.Show();
        }

        private void btnDelete_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmDelete frm = new frmDelete();
            frm.Show();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnDatHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDATHANG frm = new frmDATHANG();
            frm.Show();
        }
        public int i = 10;
        private void timer1_Tick(object sender, EventArgs e)
        {
            string a = "";
            label5.Text = DateTime.Now.ToLongTimeString();
            if (DateTime.Now.Hour > 5 && DateTime.Now.Hour <= 10)
                a = "Good morning";
            else if (DateTime.Now.Hour > 10 && DateTime.Now.Hour <= 17)
                a = "Good afternoon";
            else
                a = "Good evening";
            label6.Text = a + "! Văn phòng phẩm Sao Mai kính chúc quý khách một ngày tốt lành!";
            label6.Left += i;
            if (label6.Left >= this.Width - 500 || label6.Left <= -750)
                i = -i;
            label6.Left += i;
        }
    }
}
