using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Mxm.Common
{
    public static class Comm
    {
        /// <summary>
        /// 返回可执行文件路径 带 "\"
        /// </summary>
        /// <returns></returns>
        public static string GetExePath()
        {
            return System.AppDomain.CurrentDomain.BaseDirectory;
        }

        /// <summary>
        /// 获取日期和时间数字字符串,eg: 20120512456
        /// </summary>
        /// <returns></returns>
        public static string GetTimeStr()
        {
            string time = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            //string time = DateTime.Now.Year.ToString();
            //time += DateTime.Now.Month.ToString();
            //time += DateTime.Now.Day.ToString();
            //time += DateTime.Now.Hour.ToString();
            //time += DateTime.Now.Minute.ToString();
            //time += DateTime.Now.Second.ToString();
            //time += DateTime.Now.Millisecond.ToString();
            return time;
        }

        /// <summary>
        /// 获取日期数字字符串,eg: 20120512
        /// </summary>
        /// <returns></returns>
        public static string GetDateStr()
        {
            string time = DateTime.Now.ToString("yyyyMMdd");
            return time;
        }

        /// <summary>
        /// 获取正则表达式匹配的内容
        /// </summary>
        /// <param name="text"></param>
        /// <param name="s">开始字符</param>
        /// <param name="e">结束字符</param>
        /// <returns></returns>
        public static MatchCollection getAllHyperLinks(String text, String s, string e)
        {
            try
            {
                Regex rg = new Regex("(?<=(" + s + "))[.\\s\\S]*?(?=(" + e + "))", RegexOptions.Multiline | RegexOptions.Singleline);
                MatchCollection matches = rg.Matches(text);
                return matches;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 过滤特殊字符(windows系统不允许的)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetFilterStr(string str)
        {
            string resVal = str;
            resVal = resVal.Replace("<", "");
            resVal = resVal.Replace(">", "");
            resVal = resVal.Replace("*", "");
            resVal = resVal.Replace("-", "");
            resVal = resVal.Replace("?", "");
            resVal = resVal.Replace("'", "''");
            resVal = resVal.Replace(",", "");
            resVal = resVal.Replace("/", "");
            resVal = resVal.Replace(";", "");
            resVal = resVal.Replace("*/", "");
            resVal = resVal.Replace("\r\n", "");
            resVal = resVal.Replace("\\", "");
            resVal = resVal.Replace(":", "");
            resVal = resVal.Replace("\"", "");
            resVal = resVal.Replace("|", "");
            return resVal;
        }

        /**  
         *  用getBytes(encoding)：返回字符串的一个byte数组  
         *  当b[0]为  63时，应该是转码错误  
         *  A、不乱码的汉字字符串：  
         *  1、encoding用GB2312时，每byte是负数；  
         *  2、encoding用ISO8859_1时，b[i]全是63。  
         *  B、乱码的汉字字符串：  
         *  1、encoding用ISO8859_1时，每byte也是负数；  
         *  2、encoding用GB2312时，b[i]大部分是63。  
         *  C、英文字符串  
         *  1、encoding用ISO8859_1和GB2312时，每byte都大于0；  
         *  <p/>  
         *  总结：给定一个字符串，用getBytes("iso8859_1")  
         *  1、如果b[i]有63，不用转码；  A-2  
         *  2、如果b[i]全大于0，那么为英文字符串，不用转码；  B-1  
         *  3、如果b[i]有小于0的，那么已经乱码，要转码。  C-1  
         */
        public static string toGb2312(string str)
        {
            if (str == null) return null;
            string resVal = str;
            byte[] b;
            try
            {
                b = Encoding.GetEncoding("ISO8859-1").GetBytes(str);
                for (int i = 0; i < b.Length; i++)
                {
                    byte b1 = b[i];
                    if (b1 == 63)
                        break;    //1  
                    else if (b1 > 0)
                        continue; //2  
                    else if (b1 < 0) //不可能为0，0为字符串结束符  
                    {
                        resVal = Encoding.GetEncoding("utf-8").GetString(b);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Mxm.Common.TxtOpt.WriteTxt(ex.Message);
            }
            return resVal;
        }
    }
}
