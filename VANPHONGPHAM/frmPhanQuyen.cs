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
    public partial class frmPhanQuyen : DevExpress.XtraEditors.XtraForm
    {
        public frmPhanQuyen()
        {
            InitializeComponent();
        }

        NHANVIEN _nv;


        private void frmPhanQuyen_Load(object sender, EventArgs e)
        {
            _nv = new NHANVIEN();

            gridControl1.DataSource = _nv.getItemByQuyen(false);
            btnClick.Click += BtnClick_Click;
        }

        private void BtnClick_Click(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }

        private void BtnChuyenquyen1_Click(object sender, EventArgs e)
        {
            
        }

        private void gcNV_Click(object sender, EventArgs e)
        {
           
        }

        private void BtnChuyen_Click(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }
    }
}