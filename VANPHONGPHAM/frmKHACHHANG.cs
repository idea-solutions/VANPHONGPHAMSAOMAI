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
    public partial class frmKhachHang : DevExpress.XtraEditors.XtraForm
    {
        public frmKhachHang(){
            InitializeComponent();
        }
        frmBanHang objBANHANG = (frmBanHang)Application.OpenForms["frmBanHang"];
        KHACHHANG _kh;
        bool _them;
        public int _makh = 0;
        bool cal(Int32 _Width, GridView _view){
            _view.IndicatorWidth = _view.IndicatorWidth < _Width ? _Width : _view.IndicatorWidth;
            return true;
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
        
        private void frmKHACHHANG_Load(object sender, EventArgs e){
            _kh = new KHACHHANG(); // tạo ra 1 đối tượng khách hàng mới
            loadData();
            showHideControl(true);
            cmbGioiTinh.Items.Add("Nam");
            cmbGioiTinh.Items.Add("Nữ");
            cmbGioiTinh.Items.Add("Khác");
            cmbGioiTinh.Text = "Nam";
            txtSDT.MaxLength = 10;
            txtTen.MaxLength = 30;
        }

        private void loadData(){
            gcDanhSach.DataSource = _kh.getAll();
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
            txtSDT.Enabled = t;
            cmbGioiTinh.Enabled = t;
            ckbDisable.Enabled = t;
        }

        void reset(bool t){
            txtTen.Text = "";
            txtSDT.Text = "";
            cmbGioiTinh.Text = "";
            ckbDisable.Checked = false;
            cmbGioiTinh.Text = "Nam";
        }

        private void btnThem_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e){
            showHideControl(false);
            _them = true;
            enable(true);
            reset(true);
            ckbDisable.Enabled = false;
        }

        private void btnSua_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e){
            showHideControl(false);
            _them = false;
            enable(true);
        }

        private void btnXoa_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e){
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes){
                _kh.disable(_makh);
                MessageBox.Show("Xóa khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            reset(true);
            loadData();
        }

        private void btnLuu_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e){
            if (txtTen.TextLength != 0 && cmbGioiTinh.Text != ""){
                if(txtSDT.TextLength == 0 || txtSDT.TextLength == 10){
                    if (_them == true){
                        var khachhang = _kh.getItem(txtTen.Text, txtSDT.Text, cmbGioiTinh.Text);
                        if (khachhang == null){
                            KHACH_HANG kh = new KHACH_HANG();
                            kh.SDT = txtSDT.Text;
                            kh.TENKH = txtTen.Text;
                            kh.VOHIEUHOA = ckbDisable.Checked;
                            kh.GIOITINH = cmbGioiTinh.Text;
                            _kh.add(kh);
                            _them = false;
                            loadData();
                            enable(false);
                            showHideControl(true);
                            MessageBox.Show("Thêm khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Khách hàng đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else{
                        KHACH_HANG kh = _kh.getItem(_makh);
                        kh.SDT = txtSDT.Text;
                        kh.GIOITINH = cmbGioiTinh.Text;
                        kh.TENKH = txtTen.Text;
                        kh.VOHIEUHOA = ckbDisable.Checked;
                        _kh.update(kh);
                        _them = false;
                        loadData();
                        enable(false);
                        showHideControl(true);
                        MessageBox.Show("Cập nhật khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("Vui lòng nhập lại số điện thoại(10 số)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Vui lòng điền đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnBoQua_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e){
            _them = false;
            showHideControl(true);
            enable(false);
        }

        private void gvDanhSach_Click(object sender, EventArgs e){
            if (gvDanhSach.RowCount > 0){
                if (gvDanhSach.GetFocusedRowCellValue("MAKH") != null && gvDanhSach.GetFocusedRowCellValue("MAKH").ToString()!="1007"){
                    _makh = int.Parse(gvDanhSach.GetFocusedRowCellValue("MAKH").ToString());
                    txtSDT.Text = gvDanhSach.GetFocusedRowCellValue("SDT").ToString();
                    txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TENKH").ToString();
                    ckbDisable.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("VOHIEUHOA").ToString());
                    cmbGioiTinh.Text = gvDanhSach.GetFocusedRowCellValue("GIOITINH").ToString();
                }
                else{
                    _makh = int.Parse(gvDanhSach.GetFocusedRowCellValue("MAKH").ToString());
                    txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TENKH").ToString();
                }    
            }
        }

        private void gvDanhSach_DoubleClick(object sender, EventArgs e){
            if (objBANHANG == null || objBANHANG.IsDisposed){
                frmBanHang frm = new frmBanHang();
                frm.Show();
            }
            else{
                if (gvDanhSach.GetFocusedRowCellValue("MAKH") != null){
                    objBANHANG.loadKH();
                    objBANHANG.setKhachHang(int.Parse(gvDanhSach.GetFocusedRowCellValue("MAKH").ToString()));
                    this.Close();
                }
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e){
            XuatReport("ReportKH", "DANH MỤC KHÁCH HÀNG");
        }

        private void XuatReport(string _reportName, string _tieude){
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
            try{
                Crv.Dock = DockStyle.Fill;
                Crv.ReportSource = doc;
                frm.Controls.Add(Crv);
                Crv.Refresh();
                frm.Text = _tieude;
                frm.WindowState = FormWindowState.Maximized;
                frm.ShowDialog();
            }
            catch (Exception ex){
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}