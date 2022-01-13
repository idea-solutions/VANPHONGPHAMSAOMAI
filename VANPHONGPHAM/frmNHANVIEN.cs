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
        public frmNHANVIEN(){
            InitializeComponent();
        }

        frmMain frm = (frmMain)Application.OpenForms["frmMain"];
        NHANVIEN _nv;
        string _manv;
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

        private void frmNHANVIEN_Load(object sender, EventArgs e){
            _nv = new NHANVIEN();
            loadData();
            showHideControl(true);

            cmbGioiTinh.Items.Add("Nam");
            cmbGioiTinh.Items.Add("Nữ");
            cmbGioiTinh.Items.Add("Khác");
            cmbGioiTinh.Text = "Nam";
            txtMa.MaxLength = 4;
            txtDiaChi.MaxLength = 50;
            txtCMND.MaxLength = 12;
            txtTen.MaxLength = 30;
            txtSDT.MaxLength = 10;

            if (frm._tendn == "ADMIN" || frm._tendn == "admin"){}
            else{
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
            }
        }

        public void loadData(){
            gcDanhSach.DataSource = _nv.getAll();
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
            txtCMND.Enabled = t;
            txtDiaChi.Enabled = t;
            txtSDT.Enabled = t;
            dtNgaySinh.Enabled = t;
            cmbGioiTinh.Enabled = t;
            ckbDisable.Enabled = t;
        }

        void reset(){
            txtTen.Text = "";
            txtMa.Text = "";
            txtCMND.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            cmbGioiTinh.Text = "Nam";
            ckbDisable.Checked = false;
        }

        private void btnThem_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e){
            frmDangKy frm = new frmDangKy();
            frm.ShowDialog();
        }

        private void btnSua_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e){
            showHideControl(false);
            enable(true);
            txtMa.Enabled = false;
        }

        private void btnXoa_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e){
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes){
                _nv.disable(_manv);
            }
            reset();
            loadData();
        }

        private void btnLuu_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e){
            if (txtMa.TextLength != 0 && txtCMND.TextLength!=0 && txtDiaChi.TextLength!=0 && txtSDT.TextLength!=0&& dtNgaySinh.Text != ""){
                    if (txtSDT.TextLength == 10){
                        if(txtCMND.TextLength == 12 || txtCMND.TextLength == 9){
                            if(cmbGioiTinh.Text == "Nam" || cmbGioiTinh.Text == "Nữ" || cmbGioiTinh.Text == "Khác"){
                                showHideControl(true);
                                NHAN_VIEN nv = _nv.getItem(_manv);
                                nv.TENNHANVIEN = txtTen.Text;
                                nv.DIACHI = txtDiaChi.Text;
                                nv.SDT = txtSDT.Text;
                                nv.GIOITINH = cmbGioiTinh.Text;
                                nv.NGAYSINH = dtNgaySinh.DateTime;
                                nv.CMND_CCCD = txtCMND.Text;
                                nv.VOHIEUHOA = ckbDisable.Checked;
                                _nv.update(nv);
                                MessageBox.Show("Cập nhật nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                loadData();
                                enable(false);
                            }
                            else
                                MessageBox.Show("Vui lòng chọn lại giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                            MessageBox.Show("Vui lòng nhập lại số CMND (9 hoặc 12 chữ số)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                        MessageBox.Show("Vui lòng nhập lại số điện thoại (10 số)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Vui lòng điền đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnBoQua_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e){
            showHideControl(true);
            enable(false);
        }

        private void gvDanhSach_Click(object sender, EventArgs e){
            if (gvDanhSach.RowCount > 0){
                if (gvDanhSach.GetFocusedRowCellValue("MANHANVIEN") != null){
                    _manv = gvDanhSach.GetFocusedRowCellValue("MANHANVIEN").ToString();
                    txtMa.Text = gvDanhSach.GetFocusedRowCellValue("MANHANVIEN").ToString();
                    txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TENNHANVIEN").ToString();
                    txtDiaChi.Text = gvDanhSach.GetFocusedRowCellValue("DIACHI").ToString();
                    txtSDT.Text = gvDanhSach.GetFocusedRowCellValue("SDT").ToString();
                    txtCMND.Text = gvDanhSach.GetFocusedRowCellValue("CMND_CCCD").ToString();
                    DateTime a = DateTime.Parse(gvDanhSach.GetFocusedRowCellValue("NGAYSINH").ToString());
                    dtNgaySinh.Text = a.ToString("dd/MM/yyyy");
                    ckbDisable.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("VOHIEUHOA").ToString());
                    cmbGioiTinh.Text = gvDanhSach.GetFocusedRowCellValue("GIOITINH").ToString();
                }
            }
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e){
            XuatReport("ReportNV", "DANH SÁCH NHÂN VIÊN");
        }

        private void XuatReport(string _reportName, string _tieude){
            if (_manv != null || _manv == null){
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
            else
                MessageBox.Show("Không có dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}