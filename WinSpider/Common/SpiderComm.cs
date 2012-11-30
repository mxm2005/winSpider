using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;

namespace Mxm.Common
{
    public static class SpiderComm
    {
        /// <summary>        
        /// 获取所需要的字段内容        
        /// </summary>        
        /// <param name="strUrl">所要查找的远程网页地址</param>        
        /// <param name="timeout">超时时长设置，一般设置为8000</param>        
        /// <param name="enterType">是否输出换行符，0不输出，1输出文本框换行</param>        
        /// <param name="EnCodeType">编码方式</param>        
        /// <returns></returns>    
        public static string GetHeadStr(string strUrl, int timeout, int enterType, Encoding EnCodeType)
        {
            string strResult = string.Empty;
            StreamReader sr = null; 
            string temp = string.Empty;
            try
            {
                HttpWebRequest myReq = (HttpWebRequest)HttpWebRequest.Create(strUrl);
                myReq.Timeout = timeout;
                HttpWebResponse HttpWResp = (HttpWebResponse)myReq.GetResponse();
                if (HttpWResp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    StringBuilder strBuilder = new StringBuilder();
                    Stream myStream = HttpWResp.GetResponseStream();
                    sr = new StreamReader(myStream, EnCodeType);
                    string tmp = string.Empty;
                    while ((temp = sr.ReadLine()) != null)
                    {
                        strBuilder.Append(temp);
                        //if has </title> then end     
                        tmp = strBuilder.ToString();
                        if (tmp.IndexOf("</head>") > 0)
                        {
                            break;
                        }
                        if (enterType == 1)
                        {
                            strBuilder.Append("\r\n");
                        }
                    }
                    strResult = strBuilder.ToString();

                    //处理编码问题
                    Match charSetMatch = Regex.Match(
                        strResult,
                        "<meta([^<]*)charset=([^<]*)\"",
                        RegexOptions.IgnoreCase | RegexOptions.Multiline);
                    string webCharSet = charSetMatch.Groups[2].Value;
                    if ((Encoding.GetEncoding(webCharSet) != EnCodeType))
                    {
                        Encoding utf16 = Encoding.Unicode;
                        byte[] u16bytes = utf16.GetBytes(strResult);
                        byte[] gbytes = Encoding.Convert(utf16, EnCodeType, u16bytes);
                        strResult = Encoding.GetEncoding(webCharSet).GetString(gbytes);
                    }
                    return strResult;
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                Mxm.Common.TxtOpt.WriteTxt(DateTime.Now.ToString() + " " + ex.Message);                
                return strResult;
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }
        }

        /// <summary>
        /// 通过列表网址取整个分类url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static ArrayList getUrlList(string url)
        {
            string listHtml = GetHtml(url);
            ArrayList listUrl = new ArrayList();
            Regex regURL = new Regex("<a href=\\\"(.*)>");
            
            MatchCollection resultURL = regURL.Matches(listHtml);            
            foreach (Match m in resultURL)//整页条目地址
            {
                string infoURL = m.Value;
                listUrl.Add("" + infoURL);
            }
            return listUrl;
        }

        /// <summary>
        /// 获取网页源码
        /// </summary>
        /// <param name="url">网址</param>
        /// <param name="charSet">字符集名称</param>
        /// <returns>网页源码</returns>
        public static string GetReqHtml(string url, string charSet)
        {
            string strResult = string.Empty;
            StreamReader sr = null;
            string temp = string.Empty;
            Encoding EnCodeType = Encoding.GetEncoding(charSet);
            try
            {
                HttpWebRequest myReq = (HttpWebRequest)HttpWebRequest.Create(url);
                myReq.Timeout = 10 * 1000;
                HttpWebResponse HttpWResp = (HttpWebResponse)myReq.GetResponse();
                if (HttpWResp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    StringBuilder strBuilder = new StringBuilder();
                    Stream myStream = HttpWResp.GetResponseStream();
                    sr = new StreamReader(myStream, EnCodeType);
                    strResult = sr.ReadToEnd();

                    //处理编码问题
                    Match charSetMatch = Regex.Match(
                        strResult,
                        "<meta([^<]*)charset=([^<]*)\"",
                        RegexOptions.IgnoreCase | RegexOptions.Multiline);
                    string webCharSet = charSetMatch.Groups[2].Value;
                    if ((Encoding.GetEncoding(webCharSet) != EnCodeType))
                    {
                        Encoding utf16 = Encoding.Unicode;
                        byte[] u16bytes = utf16.GetBytes(strResult);
                        byte[] gbytes = Encoding.Convert(utf16, EnCodeType, u16bytes);
                        strResult = Encoding.GetEncoding(webCharSet).GetString(gbytes);
                    }
                    return strResult;
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                Mxm.Common.TxtOpt.WriteTxt(DateTime.Now.ToString() + " " + ex.Message);
                return strResult;
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }
        }

        /// <summary>
        /// 获取网页源码，自动判断编码或用系统默认的
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetHtml(string url)
        {
            WebClient myWebClient = new WebClient();
            myWebClient.Credentials = CredentialCache.DefaultCredentials;
            //从资源下载数据并返回字节数组。（加@是因为网址中间有"/"符号）
            byte[] myDataBuffer = myWebClient.DownloadData(url);
            string strWebData = Encoding.Default.GetString(myDataBuffer);

            //获取网页字符编码描述信息
            Match charSetMatch = Regex.Match(strWebData, 
                "<meta([^<]*)charset=([^<]*)\"", 
                RegexOptions.IgnoreCase | RegexOptions.Multiline);
            string charSet = charSetMatch.Groups[2].Value;
            charSet = charSet.Replace("\"", "");
            if (charSet != null && charSet != "" && Encoding.GetEncoding(charSet) != Encoding.Default)
            {
                strWebData = Encoding.GetEncoding(charSet).GetString(myDataBuffer);
            }
            return strWebData;
        }

        /// <summary>
        /// 获取网页源码，按输入编码获取
        /// </summary>
        /// <param name="url"></param>
        /// <param name="charset">编码字符集</param>
        /// <returns></returns>
        public static string GetHtml(string url,string charSet)
        {
            WebClient myWebClient = new WebClient(); //创建WebClient实例myWebClient
            // 需要注意的：
            //有的网页可能下不下来，有种种原因比如需要cookie,编码问题等等
            //这是就要具体问题具体分析比如在头部加入cookie
            // webclient.Headers.Add("Cookie", cookie);
            //这样可能需要一些重载方法。根据需要写就可以了

            //获取或设置用于对向 Internet 资源的请求进行身份验证的网络凭据。
            myWebClient.Credentials = CredentialCache.DefaultCredentials;
            //如果服务器要验证用户名,密码
            //NetworkCredential mycred = new NetworkCredential(struser, strpassword);
            //myWebClient.Credentials = mycred;
            //从资源下载数据并返回字节数组。（加@是因为网址中间有"/"符号）
            byte[] myDataBuffer = myWebClient.DownloadData(url);
            string strWebData = Encoding.Default.GetString(myDataBuffer);

            //获取网页字符编码描述信息
            //Match charSetMatch = Regex.Match(strWebData,
            //    "<meta([^<]*)charset=([^<]*)\"",
            //    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            //string webCharSet = charSetMatch.Groups[2].Value;
            //if (charSet == null || charSet == "")
            //{
            //    charSet = webCharSet;
            //}

            if (charSet != null && charSet != "" && Encoding.GetEncoding(charSet) != Encoding.Default)
            {
                strWebData = Encoding.GetEncoding(charSet).GetString(myDataBuffer);
            }
            return strWebData;
        }
    }
}
