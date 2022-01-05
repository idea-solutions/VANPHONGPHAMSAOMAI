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
    public partial class frmLOAIMATHANG : DevExpress.XtraEditors.XtraForm
    {
        public frmLOAIMATHANG()
        {
            InitializeComponent();
        }

        LOAIMATHANG _loaimh;
        bool _them;
        string _maloaimh;
        bool cal(Int32 _Width, GridView _view)
        {
            _view.IndicatorWidth = _view.IndicatorWidth < _Width ? _Width : _view.IndicatorWidth;
            return true;
        }

        private void frmLOAIMATHANG_Load(object sender, EventArgs e)
        {
            _loaimh = new LOAIMATHANG();
            loadData();
            showHideControl(true);
        }

        private void loadData()
        {
            gcDanhSach.DataSource = _loaimh.getAll1();
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
            txtMa.Enabled = t;
            ckbDisable.Enabled = t;
        }

        void reset(bool t)
        {
            txtTen.Text = "";
            txtMa.Text = "";
            ckbDisable.Checked = false;
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                if(gvDanhSach.GetFocusedRowCellValue("MALOAI") != null)
                {
                    _maloaimh = gvDanhSach.GetFocusedRowCellValue("MALOAI").ToString();
                    txtMa.Text = gvDanhSach.GetFocusedRowCellValue("MALOAI").ToString();
                    txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TENLOAI").ToString();
                    ckbDisable.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("VOHIEUHOA").ToString());
                }
            }
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

        frmMATHANG objMATHANG = (frmMATHANG)Application.OpenForms["frmMATHANG"];

        private void gvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            if(objMATHANG == null || objMATHANG.IsDisposed) //null là chưa được khởi tạo. IsDisposed là khởi tạo rồi nhưng đang bị ẩn
            {
                frmMATHANG frm = new frmMATHANG();
                frm.ShowDialog();
            }
            else
            {
                if (gvDanhSach.GetFocusedRowCellValue("MALOAI") != null)
                {
                    objMATHANG.loadLoaiMH();
                    objMATHANG.setLoaiMH(gvDanhSach.GetFocusedRowCellValue("MALOAI").ToString());
                    this.Close();
                }
            }
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            showHideControl(false);
            _them = true;
            enable(true);
            reset(true);
            ckbDisable.Enabled = false;
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            showHideControl(false);
            _them = false;
            enable(true);
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _loaimh.disable(_maloaimh);
            }
            reset(true);
            loadData();
        }
        frmMain objMain = (frmMain)Application.OpenForms["frmMain"];

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMa.TextLength <= 5)
            {
                showHideControl(true);
                if (_them)
                {
                    LOAI_MAT_HANG loaimh = new LOAI_MAT_HANG();
                    loaimh.MALOAI = txtMa.Text;
                    loaimh.TENLOAI = txtTen.Text;
                    loaimh.VOHIEUHOA = ckbDisable.Checked;
                    _loaimh.add(loaimh);
                }
                else
                {
                    LOAI_MAT_HANG loaimh = _loaimh.getItem(_maloaimh);
                    loaimh.TENLOAI = txtTen.Text;
                    loaimh.VOHIEUHOA = ckbDisable.Checked;
                    _loaimh.update(loaimh);
                }
                _them = false;
                loadData();
                enable(false);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đúng (tối đa 5 ký tự)");
            }
            objMain.loadChart();
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            showHideControl(true);
            enable(false);
        }
    }
}