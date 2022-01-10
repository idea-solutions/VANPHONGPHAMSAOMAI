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
        public frmLOAIMATHANG(){
            InitializeComponent();
        }

        LOAIMATHANG _loaimh;
        bool _them;
        string _maloaimh;
        NHANVIEN _nv;
        frmMATHANG objMATHANG = (frmMATHANG)Application.OpenForms["frmMATHANG"];
        frmMain objMain = (frmMain)Application.OpenForms["frmMain"];

        bool cal(Int32 _Width, GridView _view){
            _view.IndicatorWidth = _view.IndicatorWidth < _Width ? _Width : _view.IndicatorWidth;
            return true;
        }

        private void frmLOAIMATHANG_Load(object sender, EventArgs e){

            txtMa.MaxLength = 5;
            txtTen.MaxLength = 50;
            _loaimh = new LOAIMATHANG();
            loadData();
            showHideControl(true);
            _nv = new NHANVIEN();
            bool t = _nv.kiemtraQuyen(objMain._tendn);
            if (t){}
            else{
                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void loadData(){
            gcDanhSach.DataSource = _loaimh.getAllFullShow();
            enable(false);
        }

        void showHideControl(bool t){
            btnAdd.Enabled = t;
            btnEdit.Enabled = t;
            btnDelete.Enabled = t;
            btnSave.Enabled = !t;
            btnCancel.Enabled = !t;
        }

        void enable(bool t){
            txtTen.Enabled = t;
            txtMa.Enabled = t;
            ckbDisable.Enabled = t;
        }

        void reset(){
            txtTen.Text = "";
            txtMa.Text = "";
            ckbDisable.Checked = false;
        }

        private void gvDanhSach_Click(object sender, EventArgs e){
            if (gvDanhSach.RowCount > 0){
                if(gvDanhSach.GetFocusedRowCellValue("MALOAI") != null){
                    _maloaimh = gvDanhSach.GetFocusedRowCellValue("MALOAI").ToString();
                    txtMa.Text = gvDanhSach.GetFocusedRowCellValue("MALOAI").ToString();
                    txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TENLOAI").ToString();
                    ckbDisable.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("VOHIEUHOA").ToString());
                }
            }
        }

        private void gvDanhSach_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e){
            if (e.Info.IsRowIndicator){
                if (e.RowHandle < 0){
                    e.Info.ImageIndex = 0;
                    e.Info.DisplayText = string.Empty;
                }
                else{
                    e.Info.ImageIndex = -1; //Nếu hiển thị
                    e.Info.DisplayText = (e.RowHandle + 1).ToString(); //Số thứ tự tăng dần
                }
                SizeF sizeF = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font); //Lây kích thước của vùng hiển thị Text
                Int32 _Width = Convert.ToInt32(sizeF.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { cal(_Width, gvDanhSach); })); // Tăng kích thước nếu text vượt quá
            }
        }

        private void gvDanhSach_DoubleClick(object sender, EventArgs e){
            if(objMATHANG == null || objMATHANG.IsDisposed){
                frmMATHANG frm = new frmMATHANG();
                frm.ShowDialog();
            }
            else{
                if (gvDanhSach.GetFocusedRowCellValue("MALOAI") != null){
                    objMATHANG.loadLoaiMH();
                    objMATHANG.setLoaiMH(gvDanhSach.GetFocusedRowCellValue("MALOAI").ToString());
                    this.Close();
                }
            }
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            showHideControl(false);
            // them = true thì xóa // them = false thì sửa
            _them = true;
            enable(true);
            reset();
            ckbDisable.Enabled = false;
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e){
            showHideControl(false);
            _them = false;
            enable(true);
            txtMa.Enabled = false;
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e){
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes){
                _loaimh.disable(_maloaimh);
                MessageBox.Show("Xóa mặt hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            reset();
            loadData();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e){
            if (txtMa.TextLength > 0 && txtTen.Text != ""){
                if (_them){
                    var nhommh = _loaimh.getItem(txtMa.Text);
                    if (nhommh == null){
                        showHideControl(true);
                        LOAI_MAT_HANG loaimh = new LOAI_MAT_HANG();
                        loaimh.MALOAI = txtMa.Text;
                        loaimh.TENLOAI = txtTen.Text;
                        loaimh.VOHIEUHOA = ckbDisable.Checked;
                        _loaimh.add(loaimh);
                        MessageBox.Show("Thêm mới mặt hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _them = false;
                        loadData();
                        enable(false);
                    }
                    else
                        MessageBox.Show("Mã nhóm mặt hàng đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else{
                    LOAI_MAT_HANG loaimh = _loaimh.getItem(_maloaimh);
                    loaimh.TENLOAI = txtTen.Text;
                    loaimh.VOHIEUHOA = ckbDisable.Checked;
                    _loaimh.update(loaimh);
                    MessageBox.Show("Cập nhật mặt hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _them = false;
                    loadData();
                    enable(false);
                }
            }
            else
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            objMain.loadChart();
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e){
            _them = false;
            showHideControl(true);
            enable(false);
        }
    }
}