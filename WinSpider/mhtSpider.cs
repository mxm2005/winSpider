using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;

namespace WinSpider
{
    public partial class mhtSpider : Form
    {
        public mhtSpider()
        {
            InitializeComponent();
        }

        private void btn_begin_Click(object sender, EventArgs e)
        {
            string exePath = Mxm.Common.Comm.GetExePath();
            ArrayList lst = Mxm.Common.TxtOpt.GetTxtList(exePath + "lst.txt");
            for (int i = 1; i <= lst.Count; i++)
            {
                try
                {
                    string url = lst[i - 1].ToString();
                    string fName = exePath + GetFileName(url) + ".mht";
                    bool isOk = Mxm.Common.MIMEConverter.SaveWebPageToMHTFile(url, fName);

                    gv1.Rows.Add(new string[] { i.ToString(), url, isOk.ToString() });
                    gv1.Update();
                }
                catch (Exception ex)
                {
                    Mxm.Common.TxtOpt.WriteTxt(DateTime.Now.ToString() + " " + ex.Message + ex.StackTrace);
                }
            }
            MessageBox.Show("完成");
        }

        private string GetFileName(string url)
        {
            string resVal = "";
            string strHead = Mxm.Common.SpiderComm.GetHeadStr(
                url,8000, 0, Encoding.GetEncoding("gb2312"));
            MatchCollection coll = Mxm.Common.Comm.getAllHyperLinks(strHead, "<title", "title>");
            if (coll.Count >= 1)
            {
                resVal = coll[0].ToString();
            }
            resVal = Mxm.Common.Comm.GetFilterStr(resVal);
            if (string.IsNullOrEmpty(resVal))
            {
                resVal = Mxm.Common.Comm.GetTimeStr();
            }
            return resVal;
        }

        private void mhtSpider_Load(object sender, EventArgs e)
        {
            skinEngine1.SkinFile = Application.StartupPath + @"\skin\MP10.ssk";
        }

        /// <summary>
        /// 分析和收集URL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            CrawlUrl f = new CrawlUrl(txt_Url.Text);
            f.Show();
        }

        /// <summary>
        /// 显示页面源码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            ShowHtml f = new ShowHtml(txt_Url.Text);
            f.Show();    
        }

        /// <summary>
        /// 单个页面下载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSingle_Click(object sender, EventArgs e)
        {
            try
            {
                string url = txt_Url.Text.Trim();
                string rName = GetFileName(url);
                string fiName = Mxm.Common.Comm.GetExePath() + rName;
                string fName = fiName + ".mht";
                int index = 1;
                while (File.Exists(fName))
                {
                    fName = fiName + index + ".mht";
                    index++;
                }
                bool isOk = Mxm.Common.MIMEConverter.SaveWebPageToMHTFile(url, fName);
                index = gv1.Rows.Count;

                gv1.Rows.Add(new string[] { index.ToString(), url, isOk.ToString(), rName });
                gv1.Update();
            }
            catch (Exception ex)
            {
                Mxm.Common.TxtOpt.WriteTxt(DateTime.Now.ToString() + " " + ex.Message + ex.StackTrace);
            }
            MessageBox.Show("完成");
        }
    }
}