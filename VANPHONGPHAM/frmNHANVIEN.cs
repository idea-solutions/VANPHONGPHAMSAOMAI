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
    public partial class frmNHANVIEN : DevExpress.XtraEditors.XtraForm
    {
        public frmNHANVIEN()
        {
            InitializeComponent();
        }

        NHANVIEN _nv;
        bool _them;
        string _manv;
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

        private void frmNHANVIEN_Load(object sender, EventArgs e)
        {
            _nv = new NHANVIEN();
            loadData();
        }

        private void loadData()
        {
            gcDanhSach.DataSource = _nv.getAll();
            enable(false);
            showHideControl(true);

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
            txtMa.Enabled = t;
            txtCMND.Enabled = t;
            txtDiaChi.Enabled = t;
            txtMatKhau.Enabled = t;
            txtNLMatKhau.Enabled = t;
            txtSDT.Enabled = t;
            dtNgaySinh.Enabled = t;
            txtTenDangNhap.Enabled = t;
            ckbGioiTinh.Enabled = t;
            ckbDisable.Enabled = t;
        }

        void reset(bool t)
        {
            txtTen.Text = "";
            txtMa.Text = "";
            txtCMND.Text = "";
            txtDiaChi.Text = "";
            txtTenDangNhap.Text = "";
            txtSDT.Text = "";
            txtMatKhau.Text = "";
            txtNLMatKhau.Text = "";
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
            txtMa.Enabled = false;
            txtTenDangNhap.Enabled = false;
        }

        private void btnXoa_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _nv.disable(_manv);
            }
            reset(true);
            loadData();
        }

        private void btnLuu_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMa.TextLength <= 5)
            {
                showHideControl(true);
                if (_them)
                {
                    NHAN_VIEN nv = new NHAN_VIEN();
                    nv.MANHANVIEN = txtMa.Text;
                    nv.TENNHANVIEN = txtTen.Text;
                    nv.DIACHI = txtDiaChi.Text;
                    nv.SDT = txtSDT.Text;
                    nv.GIOITINH = ckbGioiTinh.Checked;
                    nv.NGAYSINH = dtNgaySinh.DateTime;
                    nv.CMND_CCCD = txtCMND.Text;
                    nv.TENDANGNHAP = txtTenDangNhap.Text;
                    nv.MATKHAU = txtMatKhau.Text;
                    nv.VOHIEUHOA = ckbDisable.Checked;
                    _nv.add(nv);
                }
                else
                {
                    NHAN_VIEN nv = _nv.getItem(_manv);
                    //nv.MANHANVIEN = txtMa.Text;
                    nv.TENNHANVIEN = txtTen.Text;
                    nv.DIACHI = txtDiaChi.Text;
                    nv.SDT = txtSDT.Text;
                    nv.GIOITINH = ckbGioiTinh.Checked;
                    nv.NGAYSINH = dtNgaySinh.DateTime;
                    nv.CMND_CCCD = txtCMND.Text;
                    //nv.TENDANGNHAP = txtTenDangNhap.Text;
                    nv.MATKHAU = txtMatKhau.Text;
                    nv.VOHIEUHOA = ckbDisable.Checked;
                    _nv.update(nv);
                }
                _them = false;
                loadData();
                enable(false);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đúng (tối đa 5 ký tự)");
            }
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
                if (gvDanhSach.GetFocusedRowCellValue("MANHANVIEN") != null)
                {
                    _manv = gvDanhSach.GetFocusedRowCellValue("MANHANVIEN").ToString();
                    txtMa.Text = gvDanhSach.GetFocusedRowCellValue("MANHANVIEN").ToString();
                    txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TENNHANVIEN").ToString();
                    txtDiaChi.Text = gvDanhSach.GetFocusedRowCellValue("DIACHI").ToString();
                    txtSDT.Text = gvDanhSach.GetFocusedRowCellValue("SDT").ToString();
                    txtCMND.Text = gvDanhSach.GetFocusedRowCellValue("CMND_CCCD").ToString();
                    txtTenDangNhap.Text = gvDanhSach.GetFocusedRowCellValue("TENDANGNHAP").ToString();
                    txtMatKhau.Text = gvDanhSach.GetFocusedRowCellValue("MATKHAU").ToString();
                    dtNgaySinh.Text = gvDanhSach.GetFocusedRowCellValue("NGAYSINH").ToString();
                    ckbDisable.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("VOHIEUHOA").ToString());
                    ckbGioiTinh.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("GIOITINH").ToString());
                }
            }
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XuatReport("ReportNV", "DANH SÁCH NHÂN VIÊN");
        }

        private void XuatReport(string _reportName, string _tieude)
        {
            if (_manv != null || _manv == null)
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