using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTest
{
    public class SearchSomethingWebClient : WebClient
    {
        public void Search(string txtSearch)
        {
            string loginAddress = "https://www.dating.com/en/people";

            Uri uri = new Uri(loginAddress);
            var request = (HttpWebRequest)WebRequest.Create(txtSearch);

            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";

            //var query = string.Join("&",
            //  loginData.Cast<string>().Select(key => $"{key}={loginData[key]}"));

            //var buffer = Encoding.ASCII.GetBytes(query);
            //request.ContentLength = buffer.Length;
            //var requestStream = request.GetRequestStream();
            //requestStream.Write(buffer, 0, buffer.Length);
            //requestStream.Close();


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                OtherActivity otherActivity = new OtherActivity(loginAddress);
                otherActivity.Show();
            }
            response.Close();
        }
    }
}
