namespace WinSpider
{
    partial class CrawlUrl
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnUrl = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnShowCode = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUrlReplace1 = new System.Windows.Forms.TextBox();
            this.txtUrlReplace2 = new System.Windows.Forms.TextBox();
            this.txtUrlReg = new System.Windows.Forms.TextBox();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtReplace1To = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(11, 245);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(485, 226);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // btnUrl
            // 
            this.btnUrl.Location = new System.Drawing.Point(348, 116);
            this.btnUrl.Name = "btnUrl";
            this.btnUrl.Size = new System.Drawing.Size(120, 35);
            this.btnUrl.TabIndex = 3;
            this.btnUrl.Text = "分析并取URL列表";
            this.btnUrl.UseVisualStyleBackColor = true;
            this.btnUrl.Click += new System.EventHandler(this.btnUrl_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtReplace1To);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnShowCode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtUrlReplace1);
            this.groupBox1.Controls.Add(this.txtUrlReplace2);
            this.groupBox1.Controls.Add(this.txtUrlReg);
            this.groupBox1.Controls.Add(this.btnUrl);
            this.groupBox1.Location = new System.Drawing.Point(11, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 159);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "分析处理URL数据";
            // 
            // btnShowCode
            // 
            this.btnShowCode.Location = new System.Drawing.Point(250, 116);
            this.btnShowCode.Name = "btnShowCode";
            this.btnShowCode.Size = new System.Drawing.Size(92, 35);
            this.btnShowCode.TabIndex = 6;
            this.btnShowCode.Text = "显示源码";
            this.btnShowCode.UseVisualStyleBackColor = true;
            this.btnShowCode.Click += new System.EventHandler(this.btnShowCode_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Replace2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Repalce1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "URL正则";
            // 
            // txtUrlReplace1
            // 
            this.txtUrlReplace1.Location = new System.Drawing.Point(87, 52);
            this.txtUrlReplace1.Name = "txtUrlReplace1";
            this.txtUrlReplace1.Size = new System.Drawing.Size(163, 21);
            this.txtUrlReplace1.TabIndex = 4;
            this.txtUrlReplace1.Text = "<li><a href=\"";
            // 
            // txtUrlReplace2
            // 
            this.txtUrlReplace2.Location = new System.Drawing.Point(87, 89);
            this.txtUrlReplace2.Name = "txtUrlReplace2";
            this.txtUrlReplace2.Size = new System.Drawing.Size(381, 21);
            this.txtUrlReplace2.TabIndex = 4;
            this.txtUrlReplace2.Text = "\">";
            // 
            // txtUrlReg
            // 
            this.txtUrlReg.Location = new System.Drawing.Point(87, 18);
            this.txtUrlReg.Name = "txtUrlReg";
            this.txtUrlReg.Size = new System.Drawing.Size(381, 21);
            this.txtUrlReg.TabIndex = 4;
            this.txtUrlReg.Text = "<li><a href=\"(.*).html\">";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(11, 37);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(485, 21);
            this.txtURL.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "种子URL：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(264, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = ">>";
            // 
            // txtReplace1To
            // 
            this.txtReplace1To.Location = new System.Drawing.Point(295, 52);
            this.txtReplace1To.Name = "txtReplace1To";
            this.txtReplace1To.Size = new System.Drawing.Size(173, 21);
            this.txtReplace1To.TabIndex = 8;
            // 
            // CrawlUrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 485);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.richTextBox1);
            this.MaximizeBox = false;
            this.Name = "CrawlUrl";
            this.Text = "爬取URL列表";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnUrl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUrlReplace1;
        private System.Windows.Forms.TextBox txtUrlReplace2;
        private System.Windows.Forms.TextBox txtUrlReg;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnShowCode;
        private System.Windows.Forms.TextBox txtReplace1To;
        private System.Windows.Forms.Label label5;
    }
}