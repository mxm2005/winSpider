using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace WinSpider
{
    public partial class CrawlPic : Form
    {
        /// <summary>
        /// 下载图片路径
        /// </summary>
        string _path = "";
        /// <summary>
        /// 窗体尺寸
        /// </summary>
        private Size beforeResizeSize = Size.Empty;

        public CrawlPic()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = txtURL.Text.Trim();
            //url = "http://www.yirenw.com/pic/photo/132771.html"; //test
            _path = Mxm.Common.Comm.GetExePath() + Mxm.Common.Comm.GetDateStr();
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }
            GetSinglePage(url);
            MessageBox.Show("完成");
        }

        /// <summary>
        /// 返回www.domain.com
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private string GetDomain(string url)
        {
            string resVal = url;
            if (!string.IsNullOrEmpty(url))
            {
                resVal = url.Replace("http://", "");
                resVal = resVal.Substring(0, resVal.IndexOf("/"));
                //resVal += "http://" + resVal;
            }
            return resVal;
        }

        private void GetSinglePage(string url)
        {            
            //string strHtml = Mxm.Common.SpiderComm.GetHtml(url);
            string strHtml = Mxm.Common.SpiderComm.GetReqHtml(url,"GB2312");
            //string str_img = @"(src|SRC)[ ]*=[ ]*[""'][^""'#>]+[""']";         //取图片地址的正则
            //Regex imgRegex = new Regex(str_img, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            Regex imgRegex = new Regex(@"<img\s+[^>]*\s*src\s*=\s*([']?)(?<url>\S+)'?[^>]*>", RegexOptions.IgnoreCase);
            Regex imgRegex1 = new Regex("^\"{1}\\w.jpg$", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            MatchCollection mc3 = null;
            if (checkBox1.Checked)
            {
                mc3 = imgRegex1.Matches(strHtml);
            }
            else
            {
                mc3 = imgRegex.Matches(strHtml);
            }
            string[] imageid = new string[mc3.Count];
            //下载图片到本地
            for (int j = 0; j < mc3.Count; j++)
            {
                //string imguir = mc3[j].Value;
                string imguir = mc3[j].Groups["url"].Value.Replace("\"","");

                if (imguir.IndexOf(GetDomain(url))<0)
                {
                    imageid[j] = "http://" + GetDomain(url) + imguir;
                }
                else
                {
                    imageid[j] = imguir;
                }
                
                foreach(Match m in mc3){
                    gv.Rows.Add(new string[] { gv.Rows.Count.ToString(), m.Value,"" });
                    gv.Update();
                }
                //string time = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                //time = time + j.ToString() + ".jpg";
                //WebClient client = new WebClient();
                try
                {
                //    Image img = Image.FromStream(client.OpenRead(imageid[j]));
                //    if (img.Width > int.Parse(txtWidth.Text) || img.Height > int.Parse(txtHeight.Text))
                //    {
                //        //client.DownloadFile(imageid[j], _path + "\\" + time);
                //        img.Save(_path + "\\" + time);
                //        gv.Rows.Add(new string[] { gv.Rows.Count.ToString(), url });
                //        gv.Update();
                //    }
                }
                catch(Exception ex)
                {
                    Mxm.Common.TxtOpt.WriteTxt(DateTime.Now.ToString() + ex.Message + ex.StackTrace+"\r\n");
                }
            }
        }
                
        protected override void OnResizeBegin(EventArgs e)
        {
            base.OnResizeBegin(e);
            beforeResizeSize = this.Size;
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
            //窗口resize之后的大小
            Size endResizeSize = this.Size;
            //获得变化比例
            float percentWidth = (float)endResizeSize.Width / beforeResizeSize.Width;
            float percentHeight = (float)endResizeSize.Height / beforeResizeSize.Height;

            foreach (Control control in this.Controls)
            {
                if (control is DataGridView)
                    continue;
                //按比例改变控件大小
                control.Width = (int)(control.Width * percentWidth);
                control.Height = (int)(control.Height * percentHeight);
                //为了不使控件之间覆盖 位置也要按比例变化
                control.Left = (int)(control.Left * percentWidth);
                control.Top = (int)(control.Top * percentHeight);
            }
        }
    }
}