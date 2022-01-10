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

namespace VANPHONGPHAM
{
    public partial class frmThongTinNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public frmThongTinNhanVien(){
            InitializeComponent();
        }

        NHANVIEN _nv;
        frmMain frmMain = (frmMain)Application.OpenForms["frmMain"];
        string _manv;
        bool _thaydoi;
        private void frmThongTinNhanVien_Load(object sender, EventArgs e){
            _nv = new NHANVIEN();
            _manv = _nv.getItemByTDN(frmMain._tendn).MANHANVIEN.ToString();
            btnBoQua.Visible = false;
            btnDongY.Visible = false;
            cmGT.Items.Add("Nam");
            cmGT.Items.Add("Nữ");
            cmGT.Items.Add("Khác");
            showThongTin();
        }

        void enable(bool t){
            txtMa.Enabled = t;
            txtHoTen.Enabled = t;
            txtCMND.Enabled = t;
            txtDiaChi.Enabled = t;
            txtSDT.Enabled = t;
            cmGT.Enabled = t;
            dateNgaySinh.Enabled = t;
        }

        void showThongTin(){
            txtTenDN.Text = _nv.getItem(_manv).TENDANGNHAP.ToString();
            txtMa.Text = _manv;
            txtHoTen.Text = _nv.getItem(_manv).TENNHANVIEN.ToString();
            txtDiaChi.Text = _nv.getItem(_manv).DIACHI.ToString();
            txtSDT.Text = _nv.getItem(_manv).SDT.ToString();
            txtCMND.Text = _nv.getItem(_manv).CMND_CCCD.ToString();
            cmGT.Text = _nv.getItem(_manv).GIOITINH.ToString();
            dateNgaySinh.Text = _nv.getItem(_manv).NGAYSINH.ToString("dd/MM/yyyy");
        }

        private void btnExit_Click(object sender, EventArgs e){
            this.Close();
        }

        private void panel6_Paint(object sender, PaintEventArgs e){
            Panel p = sender as Panel;
            ControlPaint.DrawBorder(e.Graphics, p.DisplayRectangle, Color.Blue, ButtonBorderStyle.Solid);
        }

        private void btnDongY_Paint(object sender, PaintEventArgs e){
            SimpleButton p = sender as SimpleButton;
            ControlPaint.DrawBorder(e.Graphics, p.DisplayRectangle, Color.Blue, ButtonBorderStyle.Solid);
        }

        private void btnDongY_Click(object sender, EventArgs e){
            if (_thaydoi){
                NHAN_VIEN nv = _nv.getItem(_manv);
                nv.TENNHANVIEN = txtHoTen.Text;
                nv.DIACHI = txtDiaChi.Text;
                nv.SDT = txtSDT.Text;
                nv.GIOITINH = cmGT.Text;
                nv.NGAYSINH = dateNgaySinh.DateTime;
                nv.CMND_CCCD = txtCMND.Text;
                _nv.update(nv);
                showThongTin();
                btnKiemTra.Visible = true;
                btnBoQua.Visible = false;
                btnDongY.Visible = false;
            }
        }

        private void btnKiemTra_Click(object sender, EventArgs e){
            btnBoQua.Visible = true;
            btnDongY.Visible = true;
            _thaydoi = true;
            btnKiemTra.Visible = false;
        }

        private void btnBoQua_Click(object sender, EventArgs e){
            btnKiemTra.Visible = true;
            btnBoQua.Visible = false;
            btnDongY.Visible = false;
        }

        private void txtThayDoiMK_Click(object sender, EventArgs e){
            frmDoiMK frm = new frmDoiMK();
            frm.ShowDialog();
        }
    }
}