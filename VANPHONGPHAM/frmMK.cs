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
    public partial class frmMK : DevExpress.XtraEditors.XtraForm
    {
        public frmMK()
        {
            InitializeComponent();
        }

        private void frmMK_Load(object sender, EventArgs e)
        {
            btnYes.Enabled = false;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        frmPhanQuyenND objPhanQuyen = (frmPhanQuyenND)Application.OpenForms["frmPhanQuyenND"];

        private void btnYes_Click(object sender, EventArgs e)
        {

            if (objPhanQuyen.KiemTraMK(txtPASS.Text))
            {
                objPhanQuyen.XN();
                MessageBox.Show("Cấp quyền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
                MessageBox.Show("Sai mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void txtPASS_TextChanged(object sender, EventArgs e)
        {
            if (txtPASS.TextLength > 0)
                btnYes.Enabled = true;
            else
                btnYes.Enabled = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            ControlPaint.DrawBorder(e.Graphics, p.DisplayRectangle, Color.Blue, ButtonBorderStyle.Solid);
        }
    }
}