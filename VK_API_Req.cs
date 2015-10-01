using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VK_API
{
    class VK_API_Req
    {
        public static string WebReq(string str)
        {
            WebRequest request = WebRequest.Create(str);
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            string returnstring = responseFromServer;
            reader.Close();
            dataStream.Close();
            response.Close();
            return returnstring;
        }
    }
}
