namespace HeadHorseOfTuanzhang
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lbl_name = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.tb_num = new System.Windows.Forms.TextBox();
            this.lbl_num = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_select = new System.Windows.Forms.Button();
            this.ofd_excel = new System.Windows.Forms.OpenFileDialog();
            this.tb_file = new System.Windows.Forms.TextBox();
            this.cb_pic = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(-3, 0);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(29, 12);
            this.lbl_name.TabIndex = 0;
            this.lbl_name.Text = "名字";
            this.lbl_name.Visible = false;
            // 
            // tb_name
            // 
            this.tb_name.ImeMode = System.Windows.Forms.ImeMode.On;
            this.tb_name.Location = new System.Drawing.Point(58, -3);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(100, 21);
            this.tb_name.TabIndex = 1;
            this.tb_name.Visible = false;
            // 
            // tb_num
            // 
            this.tb_num.Location = new System.Drawing.Point(58, 41);
            this.tb_num.Name = "tb_num";
            this.tb_num.Size = new System.Drawing.Size(100, 21);
            this.tb_num.TabIndex = 3;
            this.tb_num.Visible = false;
            // 
            // lbl_num
            // 
            this.lbl_num.AutoSize = true;
            this.lbl_num.Location = new System.Drawing.Point(-3, 44);
            this.lbl_num.Name = "lbl_num";
            this.lbl_num.Size = new System.Drawing.Size(29, 12);
            this.lbl_num.TabIndex = 2;
            this.lbl_num.Text = "编号";
            this.lbl_num.Visible = false;
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(152, 143);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 4;
            this.btn_ok.Text = "生成";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "表格";
            // 
            // btn_select
            // 
            this.btn_select.Location = new System.Drawing.Point(305, 68);
            this.btn_select.Name = "btn_select";
            this.btn_select.Size = new System.Drawing.Size(75, 23);
            this.btn_select.TabIndex = 6;
            this.btn_select.Text = "选择表格";
            this.btn_select.UseVisualStyleBackColor = true;
            this.btn_select.Click += new System.EventHandler(this.btn_select_Click);
            // 
            // ofd_excel
            // 
            this.ofd_excel.Filter = "Excel文件|*.xls;*.xlsx||*.*";
            this.ofd_excel.Title = "请选择Excel";
            // 
            // tb_file
            // 
            this.tb_file.ImeMode = System.Windows.Forms.ImeMode.On;
            this.tb_file.Location = new System.Drawing.Point(99, 68);
            this.tb_file.Name = "tb_file";
            this.tb_file.Size = new System.Drawing.Size(179, 21);
            this.tb_file.TabIndex = 7;
            // 
            // cb_pic
            // 
            this.cb_pic.FormattingEnabled = true;
            this.cb_pic.Items.AddRange(new object[] {
            "机智云",
            "五号空间"});
            this.cb_pic.Location = new System.Drawing.Point(99, 105);
            this.cb_pic.Name = "cb_pic";
            this.cb_pic.Size = new System.Drawing.Size(121, 20);
            this.cb_pic.TabIndex = 8;
            this.cb_pic.Text = "机智云";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "底图";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 223);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_pic);
            this.Controls.Add(this.tb_file);
            this.Controls.Add(this.btn_select);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.tb_num);
            this.Controls.Add(this.lbl_num);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.lbl_name);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "919";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.TextBox tb_num;
        private System.Windows.Forms.Label lbl_num;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_select;
        private System.Windows.Forms.OpenFileDialog ofd_excel;
        private System.Windows.Forms.TextBox tb_file;
        private System.Windows.Forms.ComboBox cb_pic;
        private System.Windows.Forms.Label label2;
    }
}

