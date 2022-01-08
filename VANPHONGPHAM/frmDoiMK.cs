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
    public partial class frmDoiMK : DevExpress.XtraEditors.XtraForm
    {
        public frmDoiMK()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        NHANVIEN _nv;
        public string tendangnhap;

        frmMain frmMain = (frmMain)Application.OpenForms["frmMain"];
        private void frmDoiMK_Load(object sender, EventArgs e)
        {
            _nv = new NHANVIEN();
            tendangnhap = frmMain._tendn;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (txtPass.TextLength != 0 && txtMK.TextLength!=0 && txtXNMK.TextLength!=0)
            {
                if(txtMK.Text == txtXNMK.Text)
                {
                    var nv = _nv.getItemDN(tendangnhap, txtPass.Text);
                    if (nv != null)
                    {
                        _nv.updateMK(tendangnhap, txtMK.Text);
                        MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Sai mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                    MessageBox.Show("Mật khẩu mới không trùng khớp, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Vui lòng điền đầy đủ tên đăng nhập và mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnXacNhan_Paint(object sender, PaintEventArgs e)
        {
            SimpleButton p = sender as SimpleButton;
            ControlPaint.DrawBorder(e.Graphics, p.DisplayRectangle, Color.Blue, ButtonBorderStyle.Solid);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            ControlPaint.DrawBorder(e.Graphics, p.DisplayRectangle, Color.Blue, ButtonBorderStyle.Solid);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (txtPass.UseSystemPasswordChar == true)
                txtPass.UseSystemPasswordChar = false;
            else
                txtPass.UseSystemPasswordChar = true;
        }

        private void btneyeMKXN_Click(object sender, EventArgs e)
        {
            if (txtXNMK.UseSystemPasswordChar == true)
                txtXNMK.UseSystemPasswordChar = false;
            else
                txtXNMK.UseSystemPasswordChar = true;
        }

        private void btneyeMK_Click(object sender, EventArgs e)
        {
            if (txtMK.UseSystemPasswordChar == true)
                txtMK.UseSystemPasswordChar = false;
            else
                txtMK.UseSystemPasswordChar = true;
        }

        private void btnQuenMK_Click(object sender, EventArgs e)
        {
            frmQuenMK frm = new frmQuenMK();
            frm.ShowDialog();
        }
    }
}