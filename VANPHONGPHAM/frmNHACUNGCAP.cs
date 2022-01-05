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
    public partial class frmNHACUNGCAP : DevExpress.XtraEditors.XtraForm
    {
        public frmNHACUNGCAP()
        {
            InitializeComponent();
        }

        NHACUNGCAP _ncc;
        bool _them;
        string _mancc;
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
        private void frmNHACUNGCAP_Load(object sender, EventArgs e)
        {
            _ncc = new NHACUNGCAP();
            loadData();
            showHideControl(true);
        }

        private void loadData()
        {
            gcDanhSach.DataSource = _ncc.getAll();
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
            txtMa.Enabled = t;
            txtTen.Enabled = t;
            txtSDT.Enabled = t;
            txtDiaChi.Enabled = t;
            txtEmail.Enabled = t;
            ckbDisable.Enabled = t;
        }

        void reset(bool t)
        {
            txtMa.Text = "";
            txtTen.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
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
        }

        private void btnXoa_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _ncc.disable(_mancc);
            }
            reset(true);
            loadData();
        }

        private void btnLuu_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (txtMa.TextLength <= 5)
            {
                if (txtSDT.TextLength == 10)
                {
                    if (_them)
                    {
                        NHA_CUNG_CAP ncc = new NHA_CUNG_CAP();
                        ncc.MANCC = txtMa.Text;
                        ncc.TENNCC = txtTen.Text;
                        ncc.SDT = txtSDT.Text;
                        ncc.DIACHI = txtDiaChi.Text;
                        ncc.EMAIL = txtEmail.Text;
                        ncc.VOHIEUHOA = ckbDisable.Checked;
                        _ncc.add(ncc);
                    }
                    else
                    {
                        NHA_CUNG_CAP ncc = _ncc.getItem(_mancc);
                        ncc.MANCC = txtMa.Text;
                        ncc.DIACHI = txtDiaChi.Text;
                        ncc.SDT = txtSDT.Text;
                        ncc.EMAIL = txtEmail.Text;
                        ncc.TENNCC = txtTen.Text;
                        ncc.VOHIEUHOA = ckbDisable.Checked;
                        _ncc.update(ncc);
                    }
                    _them = false;
                    loadData();
                    enable(false);
                    showHideControl(true);
                }
                else
                    MessageBox.Show("Vui lòng nhập đúng số điện thoai (10 ký tự)");
            }
        }


        private void btnBoQua_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            showHideControl(true);
            enable(false);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                if (gvDanhSach.GetFocusedRowCellValue("MANCC") != null)
                {
                    _mancc = gvDanhSach.GetFocusedRowCellValue("MANCC").ToString();
                    txtMa.Text = gvDanhSach.GetFocusedRowCellValue("MANCC").ToString();
                    txtSDT.Text = gvDanhSach.GetFocusedRowCellValue("SDT").ToString();
                    txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TENNCC").ToString();
                    txtDiaChi.Text = gvDanhSach.GetFocusedRowCellValue("DIACHI").ToString();
                    txtEmail.Text = gvDanhSach.GetFocusedRowCellValue("EMAIL").ToString();
                    ckbDisable.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("VOHIEUHOA").ToString());
                }
            }
        }

        frmDATHANG objDATHANG = (frmDATHANG)Application.OpenForms["frmDATHANG"];

        private void gvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            if (objDATHANG == null || objDATHANG.IsDisposed) //null là chưa được khởi tạo. IsDisposed là khởi tạo rồi nhưng đang bị ẩn
            {
                frmDATHANG frm = new frmDATHANG();
                frm.Show();
            }
            else
            {
                if (gvDanhSach.GetFocusedRowCellValue("MANCC") != null)
                {
                    objDATHANG.loadNCC();
                    objDATHANG.setNhaCungCap(gvDanhSach.GetFocusedRowCellValue("MANCC").ToString());
                    this.Close();
                }
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XuatReport("ReportNCC", "DANH MỤC NHÀ CUNG CẤP");
        }

        private void XuatReport(string _reportName, string _tieude)
        {
            if (_mancc != null || _mancc == null)
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