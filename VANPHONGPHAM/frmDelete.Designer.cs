
namespace VANPHONGPHAM
{
    partial class frmDelete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDelete));
            this.label1 = new System.Windows.Forms.Label();
            this.ckbDongY = new System.Windows.Forms.CheckBox();
            this.btnNo = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.svgImageBox1 = new DevExpress.XtraEditors.SvgImageBox();
            this.txtPASS = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(508, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hành động này kiến toàn bộ dữ liệu bán hàng bị xóa. Bạn có muốn tiếp tục?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ckbDongY
            // 
            this.ckbDongY.AutoSize = true;
            this.ckbDongY.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbDongY.Location = new System.Drawing.Point(70, 54);
            this.ckbDongY.Name = "ckbDongY";
            this.ckbDongY.Size = new System.Drawing.Size(130, 22);
            this.ckbDongY.TabIndex = 1;
            this.ckbDongY.Text = "Tôi đồng ý xóa";
            this.ckbDongY.UseVisualStyleBackColor = true;
            this.ckbDongY.CheckedChanged += new System.EventHandler(this.ckbDongY_CheckedChanged);
            // 
            // btnNo
            // 
            this.btnNo.Location = new System.Drawing.Point(480, 110);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(95, 36);
            this.btnNo.TabIndex = 2;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(364, 110);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(95, 36);
            this.btnYes.TabIndex = 2;
            this.btnYes.Text = "Yes";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // svgImageBox1
            // 
            this.svgImageBox1.Location = new System.Drawing.Point(13, 10);
            this.svgImageBox1.Name = "svgImageBox1";
            this.svgImageBox1.Size = new System.Drawing.Size(48, 41);
            this.svgImageBox1.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageBox1.SvgImage")));
            this.svgImageBox1.TabIndex = 3;
            this.svgImageBox1.Text = "svgImageBox1";
            // 
            // txtPASS
            // 
            this.txtPASS.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPASS.Location = new System.Drawing.Point(70, 111);
            this.txtPASS.Name = "txtPASS";
            this.txtPASS.Size = new System.Drawing.Size(288, 34);
            this.txtPASS.TabIndex = 4;
            this.txtPASS.UseSystemPasswordChar = true;
            this.txtPASS.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nhập mật khẩu để tiếp tục";
            // 
            // frmDelete
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 164);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPASS);
            this.Controls.Add(this.svgImageBox1);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.ckbDongY);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.Image = global::VANPHONGPHAM.Properties.Resources.Nhiều_màu_sắc_Hình_khối_Thiết_kế___Nghệ_thuật_Biểu_trưng__3_;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDelete";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XÓA DỮ LIỆU BÁN HÀNG";
            this.Load += new System.EventHandler(this.frmDelete_Load);
            ((System.ComponentModel.ISupportInitialize)(this.svgImageBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckbDongY;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Button btnYes;
        private DevExpress.XtraEditors.SvgImageBox svgImageBox1;
        private System.Windows.Forms.TextBox txtPASS;
        private System.Windows.Forms.Label label2;
    }
}