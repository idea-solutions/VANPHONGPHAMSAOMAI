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
using BusinessLayer;
using DataLayer;

namespace VANPHONGPHAM
{
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        NHANVIEN _nv;
        public string tendangnhap;
        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            _nv = new NHANVIEN();
            this.ActiveControl = btnDangNhap;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            ControlPaint.DrawBorder(e.Graphics, p.DisplayRectangle, Color.Blue, ButtonBorderStyle.Solid);
        }

        private void btnAddnew_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtUser.TextLength <= 0)
            {
                lbTaikhoan.Visible = true;
            }

            if (txtPass.TextLength <= 0)
            {
                lbMatkhau.Visible = true;
            }
            if(txtPass.TextLength!=0 && txtUser.TextLength != 0)
            {
                var nv = _nv.getItemDN(txtUser.Text, txtPass.Text);
                if (nv != null)
                {
                    frmMain frm = new frmMain(txtUser.Text);
                    this.Visible = false;
                    frm.ShowDialog();
                    this.Visible = true;
                    tendangnhap = txtUser.Text;
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
                MessageBox.Show("Vui lòng điền đầy đủ đăng nhập và mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (txtPass.UseSystemPasswordChar == true)
                txtPass.UseSystemPasswordChar = false;
            else
                txtPass.UseSystemPasswordChar = true;
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            if (txtUser.TextLength > 0)
            {
                lbTaikhoan.Visible = false;
            }
            else
            {
                lbTaikhoan.Visible = true;
            }
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            if (txtPass.TextLength > 0)
            {
                lbMatkhau.Visible = false;
            }
            else
            {
                lbMatkhau.Visible = true;
            }
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPass.Focus();
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap_Click(sender, e);
            }
        }

        private void btnQuenMK_Click(object sender, EventArgs e)
        {
            frmQuenMK frm = new frmQuenMK();
            frm.ShowDialog();
        }
    }
}