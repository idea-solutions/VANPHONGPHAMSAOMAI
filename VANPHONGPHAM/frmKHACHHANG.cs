using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;
using BusinessLayer;
using DevExpress.XtraGrid.Views.Grid;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace VANPHONGPHAM
{
    public partial class frmKHACHHANG : DevExpress.XtraEditors.XtraForm
    {
        public frmKHACHHANG()
        {
            InitializeComponent();
        }

        KHACHHANG _kh;
        bool _them;
        public int _makh = 0;
        bool cal(Int32 _Width, GridView _view)
        {
            _view.IndicatorWidth = _view.IndicatorWidth < _Width ? _Width : _view.IndicatorWidth;
            return true;
        }
        private void gvDanhSach_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator) //Nếu là dòng Indicator
            {
                if (e.RowHandle < 0)
                {
                    e.Info.ImageIndex = 0;
                    e.Info.DisplayText = string.Empty;
                }
                else
                {
                    e.Info.ImageIndex = -1; //Nếu hiển thị
                    e.Info.DisplayText = (e.RowHandle + 1).ToString(); //Số thứ tự tăng dần
                }
                SizeF sizeF = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font); //Lây kích thước của vùng hiển thị Text
                Int32 _Width = Convert.ToInt32(sizeF.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { cal(_Width, gvDanhSach); })); // Tăng kích thước nếu text vượt quá
            }
        }

        private void frmKHACHHANG_Load(object sender, EventArgs e)
        {
            _kh = new KHACHHANG();
            loadData();
            showHideControl(true);
        }

        private void loadData()
        {
            gcDanhSach.DataSource = _kh.getAll();
            enable(false);            
        }

        void showHideControl(bool t)
        {
            btnAdd.Enabled = t;
            btnEdit.Enabled = t;
            btnDelete.Enabled = t;
            btnSave.Enabled = !t;
            btnCancel.Enabled = !t;
        }

        void enable(bool t)
        {
            txtTen.Enabled = t;
            txtSDT.Enabled = t;
            ckbGioiTinh.Enabled = t;
            ckbDisable.Enabled = t;
        }

        void reset(bool t)
        {
            txtTen.Text = "";
            txtSDT.Text = "";
            ckbGioiTinh.Checked = false;
            ckbDisable.Checked = false;
        }

        private void btnThem_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            showHideControl(false);
            _them = true;
            enable(true);
            reset(true);
            ckbDisable.Enabled = false;
        }

        private void btnSua_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            showHideControl(false);
            _them = false;
            enable(true);
        }

        private void btnXoa_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _kh.disable(_makh);
            }
            reset(true);
            loadData();
        }

        private void btnLuu_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if (txtSDT.TextLength <= 10)
            {
                if (_them)
                {
                    KHACH_HANG kh = new KHACH_HANG();
                    kh.SDT = txtSDT.Text;
                    kh.TENKH = txtTen.Text;
                    kh.VOHIEUHOA = ckbDisable.Checked;
                    kh.GIOITINH = ckbGioiTinh.Checked;
                    _kh.add(kh);
                }
                else
                {
                    KHACH_HANG kh = _kh.getItem(_makh);
                    kh.SDT = txtSDT.Text;
                    kh.GIOITINH = ckbGioiTinh.Checked;
                    kh.TENKH = txtTen.Text;
                    kh.VOHIEUHOA = ckbDisable.Checked;
                    _kh.update(kh);
                }
                _them = false;
                loadData();
                enable(false);
                showHideControl(true);
            }
            else
                MessageBox.Show("Vui lòng nhập đúng số điện thoại (10 ký tự)");
        }


        private void btnBoQua_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            showHideControl(true);
            enable(false);
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                if (gvDanhSach.GetFocusedRowCellValue("MAKH") != null)
                {
                    _makh = int.Parse(gvDanhSach.GetFocusedRowCellValue("MAKH").ToString());
                    txtSDT.Text = gvDanhSach.GetFocusedRowCellValue("SDT").ToString();
                    txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TENKH").ToString();
                    ckbDisable.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("VOHIEUHOA").ToString());
                    ckbGioiTinh.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("GIOITINH").ToString());
                }
            }
        }

        frmBanHang objBANHANG = (frmBanHang)Application.OpenForms["frmBanHang"];

        private void gvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            if (objBANHANG == null || objBANHANG.IsDisposed) //null là chưa được khởi tạo. IsDisposed là khởi tạo rồi nhưng đang bị ẩn
            {
                frmBanHang frm = new frmBanHang();
                frm.Show();
            }
            else
            {
                if (gvDanhSach.GetFocusedRowCellValue("MAKH") != null)
                {
                    objBANHANG.loadKH();
                    objBANHANG.setKhachHang(int.Parse(gvDanhSach.GetFocusedRowCellValue("MAKH").ToString()));
                    this.Close();
                }
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XuatReport("ReportKH", "DANH MỤC KHÁCH HÀNG");
        }

        private void XuatReport(string _reportName, string _tieude)
        {
            if (_makh != null || _makh == null)
            {
                Form frm = new Form();
                CrystalReportViewer Crv = new CrystalReportViewer();
                Crv.ShowGroupTreeButton = false;
                Crv.ShowParameterPanelButton = false;
                Crv.ToolPanelView = ToolPanelViewType.None;
                TableLogOnInfo Thongtin;
                ReportDocument doc = new ReportDocument();
                doc.Load(System.Windows.Forms.Application.StartupPath + "\\Reports\\" + _reportName + @".rpt");
                Thongtin = doc.Database.Tables[0].LogOnInfo;
                Thongtin.ConnectionInfo.ServerName = myFun._srv;
                Thongtin.ConnectionInfo.UserID = myFun._us;
                Thongtin.ConnectionInfo.Password = myFun._pw;
                Thongtin.ConnectionInfo.DatabaseName = myFun._db;
                doc.Database.Tables[0].ApplyLogOnInfo(Thongtin);
                try
                {
                    //doc.SetParameterValue("maloaimh", _maloaimh);
                    Crv.Dock = DockStyle.Fill;
                    Crv.ReportSource = doc;
                    frm.Controls.Add(Crv);
                    Crv.Refresh();
                    frm.Text = _tieude;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
            else
                MessageBox.Show("Không có dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}