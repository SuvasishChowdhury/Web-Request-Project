using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterviewTest
{
    public partial class OtherActivity : Form
    {
        SearchSomethingWebClient client = null;
        string _url = null;
        public OtherActivity(string URL)
        {
            InitializeComponent();
            client = new SearchSomethingWebClient();
            _url = URL;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //string URL = "http://gitlab.company.com/api/v3/users?per_page=100&page=1";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_url);
            request.ContentType = "application/json; charset=utf-8";
            request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes("username:password"));
            request.PreAuthenticate = true;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            bool found = false;
            int count = 0;
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);

                Console.WriteLine(reader.ReadLine());
                Console.WriteLine(reader.ReadToEnd());
                string line;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((line = reader.ReadToEnd()) != null)
                {
                    // bypass the search once we've found a match
                    if (found || line.Contains(textBox1.Text))
                    {            
                        found = true;
                        Console.WriteLine(line);
                        count++;
                        if (count == 3)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}
