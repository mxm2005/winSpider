﻿using System;
using System.Collections;
using System.IO;

namespace Mxm.Common
{
    /// <summary>
    /// TXT文件操作类，WEB和EXE通用
    /// mxm 2012-4-6
    /// </summary>
    public static class TxtOpt
    {
        /// <summary>
        /// 如果路径为空，默认日志写到C:\\Error.txt，每写一条都换一行
        /// </summary>
        /// <param name="path">文件物理全路径</param>
        /// <param name="str">写入的内容</param>
        /// <returns></returns>
        public static bool WriteTxt(string path, string str)
        {
            if (string.IsNullOrEmpty(path))
            {
                path = "C:\\Error.txt";
            }

            str += "\r\n";

            try
            {
                string fileName = path;
                if (!File.Exists(fileName))
                {
                    //新建文件并写入
                    StreamWriter sw = File.CreateText(fileName);
                    sw.Write(str);
                    sw.Flush();
                    sw.Close();
                }
                else
                {
                    //C#追加文件 
                    StreamWriter sw = File.AppendText(fileName);
                    sw.Write(str);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 写到本地根目录的log.txt文件，每写一条都换一行
        /// </summary>
        /// <param name="str">写入的内容</param>
        /// <returns></returns>
        public static bool WriteTxt(string str)
        {
            string path = GetExeOrWebRootPath() + "log.txt";

            str += "\r\n";

            try
            {
                string fileName = path;
                if (!File.Exists(fileName))
                {
                    //新建文件并写入
                    StreamWriter sw = File.CreateText(fileName);
                    sw.Write(str);
                    sw.Flush();
                    sw.Close();
                }
                else
                {
                    //C#追加文件 
                    StreamWriter sw = File.AppendText(fileName);
                    sw.Write(str);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 写入一行文本，如果文件不存在自动创建
        /// </summary>
        /// <param name="path"></param>
        /// <param name="str"></param>
        public static void WriteLine(string path, string str)
        {
            StreamWriter sw = null;
            try
            {
                if (!File.Exists(path))
                {
                    //新建文件
                    sw = File.CreateText(path);
                    sw.Close();
                }
                sw = new StreamWriter(path, true);
                sw.WriteLine(str);
                sw.Flush();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sw.Close();
            }
        }

        /// <summary>
        /// 如果文件存在清空文件内容
        /// </summary>
        /// <param name="path"></param>
        public static void ClearTxt(string path)
        {
            FileStream stream2 = null;
            try
            {
                if (File.Exists(path))
                {
                    stream2 = File.Open(path, FileMode.OpenOrCreate, FileAccess.Write);
                    stream2.Seek(0, SeekOrigin.Begin);
                    stream2.SetLength(0); //清空txt文件                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                stream2.Close(); 
            }
        }

        /// <summary>
        /// 获取网站根目录或EXE目录+\
        /// </summary>
        /// <returns></returns>
        public static string GetExeOrWebRootPath()
        {
            return System.AppDomain.CurrentDomain.BaseDirectory;
        }

        ///// <summary>
        ///// 获取系统服务运行路径
        ///// </summary>
        ///// <returns></returns>
        //public static string GetServicePath()
        //{
        //    return System.Web.HttpRuntime.AppDomainAppPath;
        //}

        /// <summary>
        /// 替换文件内容
        /// </summary>
        /// <param name="path"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool ReplaceTxt(string path, string str)
        {
            if (string.IsNullOrEmpty(path))
            {
                return false;
            }
            else if (!System.IO.File.Exists(path))
            {
                System.IO.FileStream f = System.IO.File.Create(path);
                f.Close();
            }

            try
            {
                //替换文件内容 
                //FileStream stream2 = File.Open(path, FileMode.OpenOrCreate, FileAccess.Write);
                //stream2.Seek(0, SeekOrigin.Begin);
                //stream2.SetLength(0); //清空txt文件
                //stream2.Close();
                File.WriteAllLines(path, new string[] { str });
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 读取文件全部内容
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ReadTxt(string path)
        {
            string resVal = "";
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                StreamReader f2 = new StreamReader(path, System.Text.Encoding.GetEncoding("gb2312"));
                resVal = f2.ReadToEnd();
                f2.Close();
                f2.Dispose();
            }
            return resVal;
        }

        /// <summary>
        /// 获取文件全部行，返回ArrayList
        /// </summary>
        /// <param name="path">文件物理路径</param>
        /// <returns></returns>
        public static ArrayList GetTxtList(string path)
        {
            ArrayList lst = new ArrayList();
            StreamReader sr = null;
            try
            {
                if (File.Exists(path))
                {
                    sr = new StreamReader(path);
                    while (sr.Peek() >= 0)
                    {
                        lst.Add(sr.ReadLine());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sr.Close();
            }
            return lst;
        }

        /// <summary>
        /// 获取文件大小(字节)，文件不存在返回-1
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public static long GetFileLength(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return -1;
            }
            FileInfo fileInfo = new FileInfo(filePath);
            return fileInfo.Length;            
        }
    }
}
