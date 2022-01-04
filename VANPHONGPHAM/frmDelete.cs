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
    public partial class frmDelete : DevExpress.XtraEditors.XtraForm
    {
        public frmDelete()
        {
            InitializeComponent();
        }

        HOADONMATHANG _cthd;

        private void frmDelete_Load(object sender, EventArgs e)
        {
            _cthd = new HOADONMATHANG();
            btnYes.Enabled = false;
            btnNo.Enabled = false;
            ckbDongY.Checked = false;
            txtPASS.Visible = false;
            label2.Visible = false;
        }

        private void ckbDongY_CheckedChanged(object sender, EventArgs e)
        {
            if(ckbDongY.Checked == true)
            {
                txtPASS.Visible = true;
                label2.Visible = true;
            }
            else
            {
                label2.Visible = false;
                txtPASS.Visible = false;
                btnYes.Enabled = false;
                btnNo.Enabled = false;
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            _cthd.deleteAll();
            DialogResult dialogResult = MessageBox.Show("Đã xóa thành công!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if(dialogResult == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtPASS.TextLength >= 8)
            {
                btnYes.Enabled = true;
                btnNo.Enabled = true;
            }
            else
            {
                btnYes.Enabled = false;
                btnNo.Enabled = false;
            }
        }
    }
}