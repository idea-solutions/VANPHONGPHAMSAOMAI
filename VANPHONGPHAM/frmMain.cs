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
        public frmMain(string Messen)
        {
            _tendn = Messen;
            InitializeComponent();
        }
        public string _tendn;
        bool kiemtra = false;

        private void btnLoaiHang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e){
            frmLOAIMATHANG frm = new frmLOAIMATHANG();
            frm.Show();
        }

        private void btnMatHang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e){
            frmMATHANG frm = new frmMATHANG();
            frm.Show();
        }

        private void btnKhachHang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e){
            frmKhachHang frm = new frmKhachHang();
            frm.Show();
        }

        private void btnNhanVien_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e){
            frmNHANVIEN frm = new frmNHANVIEN();
            frm.Show();
        }

        private void btnNCC_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e){
            frmNHACUNGCAP frm = new frmNHACUNGCAP();
            frm.Show();
        }

        THONGKE _thongke;
        Series series = new Series("", ViewType.Spline); // cột
        Series series1 = new Series("", ViewType.Bar); // sóng
        Series series2 = new Series("", ViewType.Bar); // cột
        Series series12 = new Series("", ViewType.Bar); // cột

        NHANVIEN _nv;
        public void frmMain_Load(object sender, EventArgs e){
            _nv = new NHANVIEN();
            _thongke = new THONGKE();
            loadChart();
            chartControl2.Series.Add(series2);

            chartControl1.Series.Add(series12);
            chartControl1.Series.Add(series);
            
            chartControl3.Series.Add(series1);

            timer1.Enabled = true;
            timer1.Start();
            label5.Text = DateTime.Now.ToLongTimeString();

            bool t = _nv.kiemtraQuyen(_tendn);
            if (!t)
                quyenChucNang(false);
        }

        void quyenChucNang(bool t){
            btnDatHang.Enabled = t;
            navBarGroup4.Visible = t;
        }

        public void loadChart(){

            List<OBJTHONGKEKHACHHANG> lstKH;
            lstKH = new List<OBJTHONGKEKHACHHANG>();
            lstKH = _thongke.thongKeKhachHang();

            List<OBJTHONGKEDOANHTHU> lstDThu;
            lstDThu = new List<OBJTHONGKEDOANHTHU>();
            lstDThu = _thongke.thongKeDoanhThu();

            List<OBJTHONGKEBANHANG> lstBH;
            lstBH= new List<OBJTHONGKEBANHANG>();
            lstBH = _thongke.thongKeBanHang();
            series.Points.Clear();
            foreach (var item in lstDThu){
                series12.Points.Add(new SeriesPoint(item.Ngay, item.ThanhTien));
                series.Points.Add(new SeriesPoint(item.Ngay, item.ThanhTien));
            }
            foreach (var item in lstBH){
                series1.Points.Add(new SeriesPoint(item.TENMH, item.SOLUONG));
            }

            foreach (var item in lstKH){
                series2.Points.Add(new SeriesPoint(item.TENKH, item.THANHTIEN));
            }
        }

        private void btnBanHang_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e){
            frmBanHang frm = new frmBanHang();
            frm.Show();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e){
            Application.Exit();
        }

        private void btnDatHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e){
            frmDatHang frm = new frmDatHang();
            frm.Show();
        }
        public int i = 10;
        private void timer1_Tick(object sender, EventArgs e){
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
            if (label6.Left >= this.Width || label6.Left <= -750)
                i = -i;
            label6.Left += i;
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e){
            frmPhanQuyenND frm = new frmPhanQuyenND();
            frm.ShowDialog();
        }

        private void btnDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e){
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(dialogResult == DialogResult.Yes){
                kiemtra = true;
                this.Close();
            }
        }

        private void frmMain_FormClosing_1(object sender, FormClosingEventArgs e){
            if(!kiemtra)
                Application.Exit();
        }

        private void btnDoiMk_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e){
            frmDoiMK frm = new frmDoiMK();
            frm.ShowDialog();
        }

        private void btnThongTin_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e){
            frmThongTinNhanVien frm = new frmThongTinNhanVien();
            frm.ShowDialog();
        }
    }
}
