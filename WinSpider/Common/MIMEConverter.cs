using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using CDO;
using ADODB;

namespace Mxm.Common
{
    public class MIMEConverter
    {
        //private ctor as our methods are all static here
        //private MIMEConverter()
        //{
        //}
        public static bool SaveWebPageToMHTFile(string url, string filePath)
        {
            bool result = false;
            CDO.Message msg = new CDO.MessageClass();
            ADODB.Stream stm = null;
            try
            {
                msg.MimeFormatted = true;
                msg.CreateMHTMLBody(url, CDO.CdoMHTMLFlags.cdoSuppressNone, "", "");
                stm = msg.GetStream();
                stm.SaveToFile(filePath, ADODB.SaveOptionsEnum.adSaveCreateOverWrite);
                msg = null;
                result = true;
            }
            catch
            {
                throw;
            }
            finally
            {
                stm.Close();
            }
            return result;
        }
        public static string ConvertWebPageToMHTString(string url)
        {
            string data = String.Empty;
            CDO.Message msg = new CDO.MessageClass();
            ADODB.Stream stm = null;
            try
            {
                msg.MimeFormatted = true;
                msg.CreateMHTMLBody(url, CDO.CdoMHTMLFlags.cdoSuppressNone, "", ""); 
                stm = msg.GetStream();
                data = stm.ReadText(stm.Size);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                stm.Close();
            }
            return data;
        }
    }

}
