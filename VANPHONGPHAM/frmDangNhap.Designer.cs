
namespace VANPHONGPHAM
{
    partial class frmDangNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDangNhap));
            this.panel1 = new System.Windows.Forms.Panel();
            this.svgImageBox1 = new DevExpress.XtraEditors.SvgImageBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnShow = new DevExpress.XtraEditors.SvgImageBox();
            this.svgImageBox2 = new DevExpress.XtraEditors.SvgImageBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.btnQuenMK = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbTaikhoan = new DevExpress.XtraEditors.LabelControl();
            this.lbMatkhau = new DevExpress.XtraEditors.LabelControl();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.peImage = new DevExpress.XtraEditors.PictureEdit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageBox2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.peImage.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.svgImageBox1);
            this.panel1.Controls.Add(this.txtUser);
            this.panel1.Location = new System.Drawing.Point(136, 95);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 39);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // svgImageBox1
            // 
            this.svgImageBox1.Location = new System.Drawing.Point(3, 4);
            this.svgImageBox1.Name = "svgImageBox1";
            this.svgImageBox1.Size = new System.Drawing.Size(32, 30);
            this.svgImageBox1.SizeMode = DevExpress.XtraEditors.SvgImageSizeMode.Squeeze;
            this.svgImageBox1.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageBox1.SvgImage")));
            this.svgImageBox1.TabIndex = 1;
            this.svgImageBox1.Text = "svgImageBox1";
            // 
            // txtUser
            // 
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUser.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.Location = new System.Drawing.Point(40, 9);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(266, 21);
            this.txtUser.TabIndex = 0;
            this.txtUser.TextChanged += new System.EventHandler(this.txtUser_TextChanged);
            this.txtUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUser_KeyDown);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnShow);
            this.panel2.Controls.Add(this.svgImageBox2);
            this.panel2.Controls.Add(this.txtPass);
            this.panel2.Location = new System.Drawing.Point(136, 154);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(310, 39);
            this.panel2.TabIndex = 0;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(272, 4);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(32, 30);
            this.btnShow.SizeMode = DevExpress.XtraEditors.SvgImageSizeMode.Squeeze;
            this.btnShow.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnShow.SvgImage")));
            this.btnShow.TabIndex = 1;
            this.btnShow.Text = "svgImageBox1";
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // svgImageBox2
            // 
            this.svgImageBox2.Location = new System.Drawing.Point(3, 4);
            this.svgImageBox2.Name = "svgImageBox2";
            this.svgImageBox2.Size = new System.Drawing.Size(32, 30);
            this.svgImageBox2.SizeMode = DevExpress.XtraEditors.SvgImageSizeMode.Squeeze;
            this.svgImageBox2.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageBox2.SvgImage")));
            this.svgImageBox2.TabIndex = 1;
            this.svgImageBox2.Text = "svgImageBox1";
            // 
            // txtPass
            // 
            this.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPass.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.Location = new System.Drawing.Point(39, 7);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(230, 21);
            this.txtPass.TabIndex = 0;
            this.txtPass.UseSystemPasswordChar = true;
            this.txtPass.TextChanged += new System.EventHandler(this.txtPass_TextChanged);
            this.txtPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPass_KeyDown);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDangNhap.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangNhap.Location = new System.Drawing.Point(-5, -5);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(320, 54);
            this.btnDangNhap.TabIndex = 1;
            this.btnDangNhap.Text = "ĐĂNG NHẬP";
            this.btnDangNhap.UseVisualStyleBackColor = true;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // btnQuenMK
            // 
            this.btnQuenMK.AutoSize = true;
            this.btnQuenMK.BackColor = System.Drawing.Color.Transparent;
            this.btnQuenMK.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuenMK.Location = new System.Drawing.Point(329, 281);
            this.btnQuenMK.Name = "btnQuenMK";
            this.btnQuenMK.Size = new System.Drawing.Size(117, 18);
            this.btnQuenMK.TabIndex = 3;
            this.btnQuenMK.Text = "Quên mật khẩu?";
            this.btnQuenMK.Click += new System.EventHandler(this.btnQuenMK_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnDangNhap);
            this.panel3.Location = new System.Drawing.Point(136, 232);
            this.panel3.Margin = new System.Windows.Forms.Padding(5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(310, 44);
            this.panel3.TabIndex = 13;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lbTaikhoan
            // 
            this.lbTaikhoan.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lbTaikhoan.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lbTaikhoan.Appearance.Options.UseBackColor = true;
            this.lbTaikhoan.Appearance.Options.UseForeColor = true;
            this.lbTaikhoan.Location = new System.Drawing.Point(344, 135);
            this.lbTaikhoan.Name = "lbTaikhoan";
            this.lbTaikhoan.Size = new System.Drawing.Size(100, 17);
            this.lbTaikhoan.TabIndex = 14;
            this.lbTaikhoan.Text = "*Nhập tài khoản";
            // 
            // lbMatkhau
            // 
            this.lbMatkhau.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lbMatkhau.Appearance.Options.UseForeColor = true;
            this.lbMatkhau.Location = new System.Drawing.Point(344, 194);
            this.lbMatkhau.Name = "lbMatkhau";
            this.lbMatkhau.Size = new System.Drawing.Size(102, 17);
            this.lbMatkhau.TabIndex = 15;
            this.lbMatkhau.Text = "*Nhập mật khẩu";
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.ImageOptions.Image")));
            this.btnExit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExit.Location = new System.Drawing.Point(535, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(38, 38);
            this.btnExit.TabIndex = 1;
            this.btnExit.Click += new System.EventHandler(this.btnAddnew_Click);
            // 
            // peImage
            // 
            this.peImage.EditValue = ((object)(resources.GetObject("peImage.EditValue")));
            this.peImage.Location = new System.Drawing.Point(-98, -58);
            this.peImage.Margin = new System.Windows.Forms.Padding(4);
            this.peImage.Name = "peImage";
            this.peImage.Properties.AllowFocused = false;
            this.peImage.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.peImage.Properties.Appearance.Options.UseBackColor = true;
            this.peImage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.peImage.Properties.ShowMenu = false;
            this.peImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.peImage.Size = new System.Drawing.Size(798, 563);
            this.peImage.TabIndex = 10;
            // 
            // frmDangNhap
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 443);
            this.Controls.Add(this.lbMatkhau);
            this.Controls.Add(this.lbTaikhoan);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnQuenMK);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.peImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ĐĂNG NHẬP";
            this.Load += new System.EventHandler(this.frmDangNhap_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.peImage.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SvgImageBox svgImageBox1;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SvgImageBox svgImageBox2;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Label btnQuenMK;
        private DevExpress.XtraEditors.PictureEdit peImage;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraEditors.SvgImageBox btnShow;
        private DevExpress.XtraEditors.LabelControl lbTaikhoan;
        private DevExpress.XtraEditors.LabelControl lbMatkhau;
    }
}