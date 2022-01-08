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
using DevExpress.XtraEditors.Controls;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace VANPHONGPHAM
{
    public partial class frmMATHANG : DevExpress.XtraEditors.XtraForm
    {
        public frmMATHANG()
        {
            InitializeComponent();
        }

        NHANVIEN _nv;
        frmLOAIMATHANG objLOAIMATHANG = (frmLOAIMATHANG)Application.OpenForms["frmLOAIMATHANG"];
        frmMain objMain = (frmMain)Application.OpenForms["frmMain"];
        LOAIMATHANG _loaimh;
        MATHANG _mh;
        bool _them;
        string _mamh;
        bool cal(Int32 _Width, GridView _view)
        {
            _view.IndicatorWidth = _view.IndicatorWidth < _Width ? _Width : _view.IndicatorWidth;
            return true;
        }

        void quyenChucNang(bool t)
        {
            btnDelete.Enabled = t;
            btnEdit.Enabled = t;
            btnAdd.Enabled = t;
        }

        private void frmMATHANG_Load(object sender, EventArgs e)
        {
            txtMa.MaxLength = 5;
            txtTen.MaxLength = 50;
            cmbDVT.MaxLength = 10;
            _nv = new NHANVIEN();
            _loaimh = new LOAIMATHANG();
            _mh = new MATHANG();
            loadData();
            gvDanhSach.ExpandAllGroups();
            showHideControl(true);
            bool t = _nv.kiemtraQuyen(objMain._tendn);
            if (t)
            {

            }
            else
            {
                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
            cmbDVT.Items.Add("Hộp");
            cmbDVT.Items.Add("Chiếc");
            cmbDVT.Items.Add("Đôi");
            cmbDVT.Items.Add("Lọ");
            cmbDVT.Items.Add("Gói");
            cmbDVT.Items.Add("Tờ");
            cmbDVT.Items.Add("Bộ");
        }
        
        private void loadData()
        {
            
            enable(false);
            loadLoaiMH();
            gcDanhSach.DataSource = _mh.getAll();
        }
        
        public void loadLoaiMH()
        {
            cmbLoaiMH.DataSource = _loaimh.getAll();
            cmbLoaiMH.DisplayMember = "TENLOAI";
            cmbLoaiMH.ValueMember = "MALOAI";
        }

        public void setLoaiMH(string maMH)
        {
            var mh = _loaimh.getItem(maMH);
            cmbLoaiMH.SelectedValue = mh.MALOAI;
            cmbLoaiMH.Text = mh.TENLOAI;
        }

        void showHideControl(bool t)
        {
            btnAdd.Enabled = t;
            btnEdit.Enabled = t;
            btnDelete.Enabled = t;
            btnSave.Enabled = !t;
            btnCancel.Enabled = !t;
        }

        public void enable(bool t)
        {
            txtTen.Enabled = t;
            txtMa.Enabled = t;
            txtGiaBan.Enabled = t;
            cmbDVT.Enabled = t;
            txtMoTa.Enabled = t;
            ckbDisable.Enabled = t;
        }

        void reset(bool t)
        {
            txtTen.Text = "";
            txtMa.Text = "";
            txtGiaBan.Text = "";
            cmbDVT.Text = "";
            txtMoTa.Text = "";
            ckbDisable.Checked = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                if(gvDanhSach.GetFocusedRowCellValue("MAMH") != null)
                {
                    _mamh = gvDanhSach.GetFocusedRowCellValue("MAMH").ToString();
                    txtMa.Text = gvDanhSach.GetFocusedRowCellValue("MAMH").ToString();
                    txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TENMH").ToString();
                    txtGiaBan.Text = gvDanhSach.GetFocusedRowCellValue("GIABAN").ToString();
                    cmbDVT.Text = gvDanhSach.GetFocusedRowCellValue("DVT").ToString();
                    txtMoTa.Text = gvDanhSach.GetFocusedRowCellValue("MOTA").ToString();
                    cmbLoaiMH.Text = gvDanhSach.GetFocusedRowCellValue("TENLOAIMH").ToString();
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

        private void btnAddnew_Click(object sender, EventArgs e)
        {
            frmLOAIMATHANG frm = new frmLOAIMATHANG();
            frm.ShowDialog();
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
            txtMa.Enabled = false;
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _mh.disable(_mamh);
                MessageBox.Show("Xóa mặt hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            reset(true);
            loadData();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMa.TextLength > 0 && txtGiaBan.Value > 0 && cmbDVT.Text !=""&& txtTen.Text != "")
            {
                if (txtMa.TextLength == 5)
                {
                    MAT_HANG kiemtramh;
                    kiemtramh = _mh.getItem(txtMa.Text);
                    if (_them)
                    {
                        if (kiemtramh == null)
                        {
                            showHideControl(true);
                            MAT_HANG mh = new MAT_HANG();
                            mh.MAMH = txtMa.Text;
                            mh.TENMH = txtTen.Text;
                            mh.GIABAN = int.Parse(txtGiaBan.Text);
                            mh.DVT = cmbDVT.Text;
                            mh.MALOAI = cmbLoaiMH.SelectedValue.ToString();
                            mh.MOTA = txtMoTa.Text;
                            mh.VOHIEUHOA = ckbDisable.Checked;
                            _mh.add(mh);
                            MessageBox.Show("Thêm mới mặt hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _them = false;
                            loadData();
                            enable(false);
                        }
                        else
                            MessageBox.Show("Mã mặt hàng đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MAT_HANG mh = _mh.getItem(_mamh);
                        mh.MAMH = txtMa.Text;
                        mh.TENMH = txtTen.Text;
                        mh.GIABAN = int.Parse(txtGiaBan.Text);
                        mh.DVT = cmbDVT.Text;
                        mh.MALOAI = cmbLoaiMH.SelectedValue.ToString();
                        mh.MOTA = txtMoTa.Text;
                        mh.VOHIEUHOA = ckbDisable.Checked;
                        _mh.update(mh);
                        MessageBox.Show("Cập nhật mặt hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _them = false;
                        loadData();
                        enable(false);
                    }
                    
                }
                else
                    MessageBox.Show("Vui lòng nhập lại mã mặt hàng (5 ký tự)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            objMain.loadChart();
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            showHideControl(true);
            enable(false);
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XuatReport("ReportMH", "DANH MỤC LOẠI MẶT HÀNG");
        }

        private void XuatReport(string _reportName, string _tieude)
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
    }
}