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
    public partial class frmPhanQuyenND : DevExpress.XtraEditors.XtraForm
    {
        public frmPhanQuyenND()
        {
            InitializeComponent();
        }
        NHANVIEN _nv;
        string _manv;
        string _tennv;

        private void frmPhanQuyenND_Load(object sender, EventArgs e)
        {
            _nv = new NHANVIEN();
            loadData();
            btnChuyenlen.Click += BtnChuyen_Click;
            btnChuyenxuong.Click += BtnChuyenxuong_Click;
            if (objMain._tendn == "ADMIN" || objMain._tendn=="admin")
            {
                //gcQL.Enabled = false;
            }
            else
                gcQL.Enabled = false;
        }

        public void loadData()
        {
            gcNV.DataSource = _nv.getItemByQuyen(false);
            gcQL.DataSource = _nv.getItemByQuyen(true);
        }
        bool t;
        public void XN()
        {
            _nv.chuyenQuyen(_manv, t);
            loadData();
        }

        frmMain objMain = (frmMain)Application.OpenForms["frmMain"];


        public bool KiemTraMK(string mk)
        {
            var nv = _nv.getItemDN(objMain._tendn, mk);

            if (nv != null) return true;
            else return false;
        }

        private void BtnChuyenxuong_Click(object sender, EventArgs e)
        {
            if (gvQL.RowCount > 1)
            {
                if (_manv != null)
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn có chắn chắn muốn hủy quyền Quản lý của nhân viên:\n" + _tennv + " không?", "Thông  báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        t = false;
                        frmMK frm = new frmMK();
                        frm.ShowDialog();
                    }
                }
                else
                    MessageBox.Show("Vui lòng chọn một nhân viên để thực hiện", "Thông  báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Không thể xóa hết nhân viên quản lý", "Thông  báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void BtnChuyen_Click(object sender, EventArgs e)
        {
            if (gvNV.RowCount > 1)
            {
                if (_manv != null)
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn có chắn chắn muốn cấp quyền Quản lý cho nhân viên:\n" + _tennv + " không?", "Thông  báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        t = true;
                        frmMK frm = new frmMK();
                        frm.ShowDialog();
                    }
                }
                else
                    MessageBox.Show("Vui lòng chọn một nhân viên để thực hiện", "Thông  báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Không thể xóa hết nhân viên bán hàng" +
                    "", "Thông  báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void gvQL_Click(object sender, EventArgs e)
        {
            if (gvQL.RowCount > 0)
            {
                if (gvQL.GetFocusedRowCellValue("MANHANVIEN") != null)
                {
                    _manv = gvQL.GetFocusedRowCellValue("MANHANVIEN").ToString();
                    _tennv = gvQL.GetFocusedRowCellValue("TENNHANVIEN").ToString();
                }
            }
        }

        private void gvNV_Click(object sender, EventArgs e)
        {
            if (gvNV.RowCount > 0)
            {
                if (gvNV.GetFocusedRowCellValue("MANHANVIEN") != null)
                {
                    _manv = gvNV.GetFocusedRowCellValue("MANHANVIEN").ToString();
                    _tennv = gvNV.GetFocusedRowCellValue("TENNHANVIEN").ToString();
                }
            }
        }

        private void gcQL_Click(object sender, EventArgs e)
        {
            gvNV.Columns[0].Visible = false;
            gvQL.Columns[0].Visible = true;
        }

        private void gcNV_Click(object sender, EventArgs e)
        {
            gvQL.Columns[0].Visible = false;
            gvNV.Columns[0].Visible = true;
        }
    }
}