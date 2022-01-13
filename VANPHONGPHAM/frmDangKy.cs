using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using BusinessLayer;
using System.Windows.Forms;

namespace VANPHONGPHAM
{
    public partial class frmDangKy : DevExpress.XtraEditors.XtraForm
    {
        public frmDangKy(){
            InitializeComponent();
        }

        frmNHANVIEN frm = (frmNHANVIEN)Application.OpenForms["frmNHANVIEN"];
        NHANVIEN _nv;

        private void btnKtra_Click(object sender, EventArgs e) {
            if (txtMa.TextLength != 0 && txtCMND.TextLength != 0 && txtDiaChi.TextLength != 0 && txtSDT.TextLength != 0 && dtNgaySinh.Text != ""){
                if (txtMa.TextLength == 4){
                    if (txtSDT.TextLength == 10){
                        if (txtCMND.TextLength == 12 || txtCMND.TextLength == 9){
                            if (cmbGioiTinh.Text == "Nam" || cmbGioiTinh.Text == "Nữ" || cmbGioiTinh.Text == "Khác"){
                                var nvmanv = _nv.getItem(txtMa.Text);
                                if (nvmanv == null){
                                    var sdt = _nv.getItemBySDT(txtSDT.Text);
                                    if (sdt == null){
                                        var cmnd = _nv.getItemByCMND(txtCMND.Text);
                                        if (cmnd == null){
                                            if(DateTime.Now.Year - dtNgaySinh.DateTime.Year >= 18){
                                                MessageBox.Show("Kiểm tra thành công, mời bạn tạo tài khoản đăng nhập cho nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                            else
                                                MessageBox.Show("Nhân viên chưa đủ 18 tuổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                        else
                                            MessageBox.Show("Số CMND đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                    else
                                        MessageBox.Show("Số điện thoại đang được sử dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                    MessageBox.Show("Nhân viên đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("Vui lòng nhập lại mã nhân viên (4 ký tự)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Vui lòng điền đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void frmDangKy_Load(object sender, EventArgs e){
            _nv = new NHANVIEN();
            cmbGioiTinh.Items.Add("Nam");
            cmbGioiTinh.Items.Add("Nữ");
            cmbGioiTinh.Items.Add("Khác");
            cmbGioiTinh.Text = "Nam";
            txtMa.MaxLength = 4;
            txtDiaChi.MaxLength = 50;
            txtCMND.MaxLength = 12;
            txtMatKhau.MaxLength = 20;
            txtNLMatKhau.MaxLength = 20;
            txtTen.MaxLength = 30;
            txtSDT.MaxLength = 10;
        }

        private void btnXacNhan_Click(object sender, EventArgs e){
            if (txtMatKhau.TextLength >= 8){
                if (txtNLMatKhau.Text == txtMatKhau.Text){
                    var tendn = _nv.getItemByTDN(txtTenDangNhap.Text);
                    if (tendn == null){
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
                        nv.VOHIEUHOA = false;
                        nv.LAQUANLY = false;
                        _nv.add(nv);
                        DialogResult dialogResult = MessageBox.Show("Đăng ký tài khoản nhân viên thành công, mời bạn trở lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if(dialogResult == DialogResult.OK){
                            frm.loadData();
                            this.Close();
                        }
                    }
                    else
                        MessageBox.Show("Tên đăng nhập đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Mật khẩu nhập lại phải trùng nhau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Mật khẩu quá ngắn, vui lòng tạo lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            ControlPaint.DrawBorder(e.Graphics, p.DisplayRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.UseSystemPasswordChar == true)
                txtMatKhau.UseSystemPasswordChar = false;
            else
                txtMatKhau.UseSystemPasswordChar = true;
        }

        private void btnShow1_Click(object sender, EventArgs e)
        {
            if (txtNLMatKhau.UseSystemPasswordChar == true)
                txtNLMatKhau.UseSystemPasswordChar = false;
            else
                txtNLMatKhau.UseSystemPasswordChar = true;
        }

        private void btnKtra_Paint(object sender, PaintEventArgs e)
        {
            SimpleButton p = sender as SimpleButton;
            ControlPaint.DrawBorder(e.Graphics, p.DisplayRectangle, Color.Blue, ButtonBorderStyle.Solid);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}