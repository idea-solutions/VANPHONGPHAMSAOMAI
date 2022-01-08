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
    public partial class frmQuenMK : DevExpress.XtraEditors.XtraForm
    {
        public frmQuenMK()
        {
            InitializeComponent();
        }

        NHANVIEN _nv;

        private void frmQuenMK_Load(object sender, EventArgs e)
        {
            _nv = new NHANVIEN();
            hide(false);
            hide1(false);
        }
        void hide(bool t)
        {
            panel2.Visible = t;
            panel3.Visible = t;
            panel6.Visible = t;
            panel7.Visible = t;
            btnKiemTra.Visible = t;
            label2.Visible = t;
            label3.Visible = t;
            label5.Visible = t;
            label4.Visible = t;
        }

        void hide1(bool t)
        {
            panel8.Visible = t;
            panel5.Visible = t;
            btnXacNhan.Visible = t;
            label7.Visible = t;
            label8.Visible = t;
        }

        void loadTaiKhoan()
        {
            cmbTaiKhoan.DataSource = _nv.getItemQMK(txtSDT.Text);
            cmbTaiKhoan.DisplayMember = "TENDANGNHAP";
            cmbTaiKhoan.ValueMember = "MANHANVIEN";
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            loadTaiKhoan();
            if (cmbTaiKhoan.Text != "")
            {
                hide(true);
            }
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            var nv = _nv.getItemQMK(dateNgaySinh.DateTime.Date, txtCMND.Text, txtHoTen.Text, txtDiaChi.Text);
            if (nv != null)
            {
                MessageBox.Show("Thông tin đã được xác thực thành công, mời bạn tạo lại mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                hide(false);
                hide1(true);
            }
            else
            {
                MessageBox.Show("Không thể thực hiện do sai thông tin, mời bạn thao tác lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            ControlPaint.DrawBorder(e.Graphics, p.DisplayRectangle, Color.Blue, ButtonBorderStyle.Solid);
        }

        private void btnKiemTra_Paint(object sender, PaintEventArgs e)
        {
            SimpleButton p = sender as SimpleButton;
            ControlPaint.DrawBorder(e.Graphics, p.DisplayRectangle, Color.Blue, ButtonBorderStyle.Solid);
        }

        private void btnXacNhan_Paint(object sender, PaintEventArgs e)
        {
            SimpleButton p = sender as SimpleButton;
            ControlPaint.DrawBorder(e.Graphics, p.DisplayRectangle, Color.Blue, ButtonBorderStyle.Solid);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtXNMK.TextLength >0 && txtMK.TextLength>0)
            {
                if (txtMK.Text == txtXNMK.Text)
                {
                    try
                    {
                        _nv.updateMK(cmbTaiKhoan.Text, txtXNMK.Text);
                        DialogResult rs = MessageBox.Show("Đổi mật khẩu thành công, mời bạn quay lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if(rs == DialogResult.OK)
                        {
                            this.Close();
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi trong quá trình cập nhật, mời bạn thao tác lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    

                }

            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void svgImageBox9_Click(object sender, EventArgs e)
        {
            if (txtMK.UseSystemPasswordChar == true)
                txtMK.UseSystemPasswordChar = false;
            else
                txtMK.UseSystemPasswordChar = true;
        }

        private void svgImageBox10_Click(object sender, EventArgs e)
        {
            if (txtXNMK.UseSystemPasswordChar == true)
                txtXNMK.UseSystemPasswordChar = false;
            else
                txtXNMK.UseSystemPasswordChar = true;
        }

        private void txtMK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtXNMK.Focus();
            }
        }

        private void txtXNMK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1_Click(sender, e);
            }
        }

        private void txtHoTen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDiaChi.Focus();
            }
        }

        private void txtDiaChi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateNgaySinh.Focus();
            }
        }

        private void dateNgaySinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCMND.Focus();
            }
        }

        private void txtCMND_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnKiemTra_Click(sender, e);
            }
        }
    }
}