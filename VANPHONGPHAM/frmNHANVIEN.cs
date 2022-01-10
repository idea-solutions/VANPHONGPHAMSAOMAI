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
        bool _them;
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
            txtMa.MaxLength = 4;
            txtDiaChi.MaxLength = 50;
            txtCMND.MaxLength = 12;
            txtMatKhau.MaxLength = 20;
            txtNLMatKhau.MaxLength = 20;
            txtTen.MaxLength = 30;
            txtSDT.MaxLength = 10;

            if (frm._tendn == "ADMIN" || frm._tendn == "admin"){}
            else{
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
            }

            showInfo(false);
        }

        private void loadData(){
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

        void showInfo(bool t){
            txtMatKhau.Visible = t;
            txtNLMatKhau.Visible = t;
            txtTenDangNhap.Visible = t;
            label7.Visible = t;
            label8.Visible = t;
            label9.Visible = t;
        }

        void enable(bool t){
            txtTen.Enabled = t;
            txtMa.Enabled = t;
            txtCMND.Enabled = t;
            txtDiaChi.Enabled = t;
            txtMatKhau.Enabled = t;
            txtNLMatKhau.Enabled = t;
            txtSDT.Enabled = t;
            dtNgaySinh.Enabled = t;
            txtTenDangNhap.Enabled = t;
            cmbGioiTinh.Enabled = t;
            ckbDisable.Enabled = t;
        }

        void reset(bool t){
            txtTen.Text = "";
            txtMa.Text = "";
            txtCMND.Text = "";
            txtDiaChi.Text = "";
            txtTenDangNhap.Text = "";
            txtSDT.Text = "";
            txtMatKhau.Text = "";
            txtNLMatKhau.Text = "";
            cmbGioiTinh.Text = "";
            ckbDisable.Checked = false;
        }

        private void btnThem_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e){
            showHideControl(false);
            _them = true;
            enable(true);
            reset(true);
            ckbDisable.Enabled = false;
            showInfo(true);

        }

        private void btnSua_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e){
            showHideControl(false);
            _them = false;
            enable(true);
            txtMa.Enabled = false;
            txtTenDangNhap.Enabled = false;
        }

        private void btnXoa_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e){
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes){
                _nv.disable(_manv);
            }
            reset(true);
            loadData();
        }

        private void btnLuu_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e){
            if (txtMa.TextLength != 0 && txtCMND.TextLength!=0 && txtDiaChi.TextLength!=0&& txtTenDangNhap.TextLength!=0 && txtSDT.TextLength!=0&& txtMatKhau.TextLength!=0&& txtNLMatKhau.TextLength != 0 && dtNgaySinh.Text != ""){
                if (txtMa.TextLength == 4){
                    if (txtSDT.TextLength == 10){
                        if(txtCMND.TextLength==12 || txtCMND.TextLength == 9){
                            if(cmbGioiTinh.Text == "Nam" || cmbGioiTinh.Text == "Nữ" && cmbGioiTinh.Text == "Khác"){
                                if (txtMatKhau.TextLength >= 8){
                                    if(txtNLMatKhau.Text == txtMatKhau.Text){
                                        var nvkt = _nv.getItem(txtMa.Text);
                                        if (nvkt == null){
                                            showHideControl(true);
                                            if (_them){
                                                NHAN_VIEN nv = new NHAN_VIEN();
                                                nv.MANHANVIEN = txtMa.Text;
                                                nv.TENNHANVIEN = txtTen.Text;
                                                nv.DIACHI = txtDiaChi.Text;
                                                nv.SDT = txtSDT.Text;
                                                nv.GIOITINH = cmbGioiTinh.Text;
                                                nv.NGAYSINH = dtNgaySinh.DateTime;
                                                nv.CMND_CCCD = txtCMND.Text;
                                                nv.TENDANGNHAP = txtTenDangNhap.Text;
                                                nv.MATKHAU = txtMatKhau.Text;
                                                nv.VOHIEUHOA = ckbDisable.Checked;
                                                nv.LAQUANLY = false;
                                                _nv.add(nv);
                                                MessageBox.Show("Thêm mới nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                _them = false;
                                                loadData();
                                                enable(false);
                                                showInfo(false);
                                            }
                                            else{
                                                NHAN_VIEN nv = _nv.getItem(_manv);
                                                nv.TENNHANVIEN = txtTen.Text;
                                                nv.DIACHI = txtDiaChi.Text;
                                                nv.SDT = txtSDT.Text;
                                                nv.GIOITINH = cmbGioiTinh.Text;
                                                nv.NGAYSINH = dtNgaySinh.DateTime;
                                                nv.CMND_CCCD = txtCMND.Text;
                                                nv.MATKHAU = txtMatKhau.Text;
                                                nv.VOHIEUHOA = ckbDisable.Checked;
                                                _nv.update(nv);
                                                MessageBox.Show("Cập nhật nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                _them = false;
                                                loadData();
                                                enable(false);
                                                showInfo(false);
                                            }
                                        }
                                        else
                                            MessageBox.Show("Nhân viên đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                    else
                                        MessageBox.Show("Mật khẩu nhập lại phải trùng nhau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                    MessageBox.Show("Mật khẩu quá ngắn, vui lòng tạo lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("Vui lòng nhập lại mã nhà nhân viên (4 ký tự)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
            else
                MessageBox.Show("Vui lòng điền đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btnBoQua_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e){
            _them = false;
            showHideControl(true);
            enable(false);
            showInfo(false);
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