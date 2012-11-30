using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinSpider
{
    public partial class ShowHtml : Form
    {
        //public ShowHtml()
        //{
        //    InitializeComponent();
        //}

        public ShowHtml(string url)
        {
            InitializeComponent();
            textBox1.Text = url;
            richTextBox1.Text = Mxm.Common.SpiderComm.GetHtml(url);
        }

        private void ShowHtml_Load(object sender, EventArgs e)
        {

        }

        private void OnResize(object sender, EventArgs e)
        {
            richTextBox1.Width = this.Width - 32;
            richTextBox1.Height = this.Height - 85;
        }
    }
}