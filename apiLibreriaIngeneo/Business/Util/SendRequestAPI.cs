using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Business.Util
{
    public class SendRequestAPI
    {
        public static string Request(string url,string typeMethod, string jsonContent)
        {
            string answer;
            if (typeMethod!="GET")
            {
                answer = RequestPost(url, typeMethod, jsonContent);
            }
            else
            {
                answer = RequestGet(url, typeMethod);
            }
            return answer;
        }
        private static string RequestPost(string url, string typeMethod, string jsonContent)
        {
            long length = 0;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = typeMethod;

                System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                Byte[] byteArray = encoding.GetBytes(jsonContent);

                request.ContentLength = byteArray.Length;
                request.ContentType = @"application/json";
                request.Accept = @"text/plain";

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                Stream dataStream = request.GetRequestStream();

                dataStream.Write(byteArray, 0, byteArray.Length);

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    length = response.ContentLength;
                    dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();
                    return responseFromServer;
                }
            }
            catch (WebException ex)
            {
                return ex.Message;
            }
        }
        private static string RequestGet(string url, string typeMethod)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = typeMethod;
                request.ContentType = @"application/json";
                request.Accept = @"text/plain";

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Stream stream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(stream);
                    string responseFromServer = reader.ReadToEnd();
                    return responseFromServer;
                }
            }
            catch (WebException ex)
            {
                return ex.Message;
            }
        }
    }
}
