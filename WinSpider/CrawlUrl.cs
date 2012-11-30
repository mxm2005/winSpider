using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections;

namespace WinSpider
{
    public partial class CrawlUrl : Form
    {        
        string listHtml;
        public CrawlUrl(string url)
        {
            InitializeComponent();
            txtURL.Text = url;
        }

        /// <summary>
        /// 分析爬取URL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUrl_Click(object sender, EventArgs e)
        {
            getUrlList();
        }


        #region 成员方法

        /// <summary>
        /// 向文件添加URL列表
        /// </summary>
        private void getUrlList()
        {
            ArrayList urlList = getListAllUrl(txtURL.Text.Trim());
            string fPath = Mxm.Common.TxtOpt.GetExeOrWebRootPath() + "lst.txt";

            try
            {
                Mxm.Common.TxtOpt.ClearTxt(fPath);
                foreach (string url in urlList)
                {
                    Mxm.Common.TxtOpt.WriteLine(fPath, url);
                    richTextBox1.Text += url + "\r\n";
                }
            }
            catch (Exception ex)
            {
                richTextBox1.Text += DateTime.Now.ToString() + " " + ex.Message
                    + "\r\n" + ex.StackTrace + "\r\n";
            }

            this.richTextBox1.AppendText("完成URL爬取");
        }

        /// <summary>
        /// 通过列表网址取整个分类url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private ArrayList getListAllUrl(string url)
        {
            listHtml = Mxm.Common.SpiderComm.GetHtml(url);
            ArrayList listUrl = new ArrayList();
            //Regex regURL = new Regex("<li><a href=\\\"(.*).html\\\">");            
            Regex regURL = new Regex(txtUrlReg.Text);
            MatchCollection resultURL = regURL.Matches(listHtml);
            foreach (Match m in resultURL)//整页条目地址
            {
                //string infoURL = m.Value.Replace("<li><a href=\"", "").Replace("\">", "");
                string infoURL = m.Value.Replace(txtUrlReplace1.Text, txtReplace1To.Text)
                    .Replace(txtUrlReplace2.Text, "");
                listUrl.Add("" + infoURL);
            }
            return listUrl;
        }
        
        #endregion

        private void btnShowCode_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = Mxm.Common.SpiderComm.GetHtml(txtURL.Text.Trim());
        }
    }
}