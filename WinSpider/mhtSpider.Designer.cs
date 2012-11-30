namespace WinSpider
{
    partial class mhtSpider
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
            this.components = new System.ComponentModel.Container();
            this.btn_begin = new System.Windows.Forms.Button();
            this.txt_Url = new System.Windows.Forms.TextBox();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.gv1 = new System.Windows.Forms.DataGridView();
            this.btnSingle = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.URL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.结果 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.文件名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gv1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_begin
            // 
            this.btn_begin.Location = new System.Drawing.Point(665, 12);
            this.btn_begin.Name = "btn_begin";
            this.btn_begin.Size = new System.Drawing.Size(55, 37);
            this.btn_begin.TabIndex = 0;
            this.btn_begin.Text = "开 始";
            this.btn_begin.UseVisualStyleBackColor = true;
            this.btn_begin.Click += new System.EventHandler(this.btn_begin_Click);
            // 
            // txt_Url
            // 
            this.txt_Url.Location = new System.Drawing.Point(12, 21);
            this.txt_Url.Name = "txt_Url";
            this.txt_Url.Size = new System.Drawing.Size(413, 21);
            this.txt_Url.TabIndex = 1;
            this.txt_Url.Text = "http://www.yxdown.com/gonglue/longtengshijiqiyuan/";
            // 
            // skinEngine1
            // 
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(607, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "URL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(526, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 37);
            this.button2.TabIndex = 3;
            this.button2.Text = "显示源代码";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // gv1
            // 
            this.gv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.序号,
            this.URL,
            this.结果,
            this.文件名});
            this.gv1.Location = new System.Drawing.Point(12, 71);
            this.gv1.Name = "gv1";
            this.gv1.RowTemplate.Height = 23;
            this.gv1.Size = new System.Drawing.Size(708, 288);
            this.gv1.TabIndex = 4;
            // 
            // btnSingle
            // 
            this.btnSingle.Location = new System.Drawing.Point(452, 12);
            this.btnSingle.Name = "btnSingle";
            this.btnSingle.Size = new System.Drawing.Size(68, 37);
            this.btnSingle.TabIndex = 5;
            this.btnSingle.Text = "单个下载";
            this.btnSingle.UseVisualStyleBackColor = true;
            this.btnSingle.Click += new System.EventHandler(this.btnSingle_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "MHT爬虫";
            this.notifyIcon1.Visible = true;
            // 
            // 序号
            // 
            this.序号.HeaderText = "序号";
            this.序号.Name = "序号";
            this.序号.ReadOnly = true;
            this.序号.Width = 54;
            // 
            // URL
            // 
            this.URL.HeaderText = "URL";
            this.URL.Name = "URL";
            this.URL.ReadOnly = true;
            this.URL.Width = 48;
            // 
            // 结果
            // 
            this.结果.HeaderText = "结果";
            this.结果.Name = "结果";
            this.结果.ReadOnly = true;
            this.结果.Width = 54;
            // 
            // 文件名
            // 
            this.文件名.HeaderText = "文件名";
            this.文件名.Name = "文件名";
            this.文件名.Width = 66;
            // 
            // mhtSpider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 371);
            this.Controls.Add(this.btnSingle);
            this.Controls.Add(this.gv1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txt_Url);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_begin);
            this.MaximizeBox = false;
            this.Name = "mhtSpider";
            this.Text = "MHT文件爬虫";
            this.Load += new System.EventHandler(this.mhtSpider_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_begin;
        private System.Windows.Forms.TextBox txt_Url;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView gv1;
        private System.Windows.Forms.Button btnSingle;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 序号;
        private System.Windows.Forms.DataGridViewTextBoxColumn URL;
        private System.Windows.Forms.DataGridViewTextBoxColumn 结果;
        private System.Windows.Forms.DataGridViewTextBoxColumn 文件名;
    }
}