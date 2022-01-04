using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
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

namespace VANPHONGPHAM
{
    public partial class frmFormReport : DevExpress.XtraEditors.XtraForm
    {
        public frmFormReport()
        {
            InitializeComponent();
        }

        private void frmFormReport_Load(object sender, EventArgs e)
        {
            //if (_mamh != null)
            //{
            //    Form frm = new Form();
            //    CrystalReportViewer Crv = new CrystalReportViewer();
            //    Crv.ShowGroupTreeButton = false;
            //    Crv.ShowParameterPanelButton = false;
            //    Crv.ToolPanelView = ToolPanelViewType.None;
            //    TableLogOnInfo Thongtin;
            //    ReportDocuments doc = new ReportDocuments();
            //    doc.Load(System.Windows.Forms.Application.StartupPath + "\\Report\\" + _reportName + @".rpt");
            //    Thongtin = doc.Dabase.Tables[0].LogOnInfo;
            //    Thongtin.ConnectionInfo.ServerName = myFun._srv;
            //    Thongtin.ConnectionInfo.UserID = myFun._us;
            //    Thongtin.ConnectionInfo.Password = myFun._pw;
            //    Thongtin.ConnectionInfo.DatabaseName = myFun._db;
            //    doc.Database.Tables[0].ApplyLogOnInfo
            //    doc.SetParameterValue;
            //}
        }
    }
}