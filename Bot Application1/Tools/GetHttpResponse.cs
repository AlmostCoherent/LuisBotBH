using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace Bot_Application1.Tools
{
    public static class GetHttpResponse
    {
        public static string GetJsonResponse(string url, NameValueCollection query = null)
        {
            url = url += query;
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(string.Format(url));

            webRequest.Method = "GET";
            try
            {
                HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();

                string jsonResponse;
                using (Stream stream = webResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                    jsonResponse = reader.ReadToEnd();
                }
                return jsonResponse;
            }
            catch (Exception e)
            {

            }
            return string.Empty;
        }
    }
}