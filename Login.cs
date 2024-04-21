using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterviewTest
{
    public partial class Login : Form
    {
        CookieAwareWebClient client = null;
        public Login()
        {
            InitializeComponent();
            client = new CookieAwareWebClient();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string loginAddress = "https://www.dating.com/en/people";
            NameValueCollection loginData = new NameValueCollection
            {
                  { "username", textBox1.Text },
                  { "password", textBox2.Text }
            };
            if (client.Container == null)
            {
                client.Loginwithpassword(loginAddress, loginData);
            }
            else
            {

            }
        }

        //private async void button1_Click(object sender, EventArgs e)
        //{
        //    string url = "wss://srt.tubit.com";
        //    NameValueCollection loginData = new NameValueCollection
        //    {
        //          { "username", textBox1.Text },
        //          { "password", textBox2.Text }
        //    };
        //    if (client.Container == null)
        //    {
        //        var uri = new Uri(url);
        //        var websocket = new ClientWebSocket();
        //        websocket.Options.Credentials = new NetworkCredential(textBox1.Text, textBox2.Text);
        //        //string auth = Convert.ToBase64String(Encoding.Default.GetBytes(textBox1.Text + ":" + textBox2.Text));
        //        string auth = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(textBox1.Text + ":" + textBox2.Text));
        //        websocket.Options.SetRequestHeader("Authorization", "Basic " + auth);
        //        await websocket.ConnectAsync(uri, CancellationToken.None);
        //        var msg = "{ \"action\": \"nodes\" }";
        //        var bytesToSend = new ArraySegment<byte>(Encoding.UTF8.GetBytes(msg));

        //        await websocket.SendAsync(bytesToSend, WebSocketMessageType.Text, true, CancellationToken.None);
        //        ArraySegment<byte> bytesReceived = new ArraySegment<byte>(new byte[1024]);
        //        WebSocketReceiveResult result = await websocket.ReceiveAsync(bytesReceived, CancellationToken.None);
        //        Console.WriteLine(Encoding.UTF8.GetString(bytesReceived.Array, 0, result.Count));
        //    }
        //    else
        //    {

        //    }
        //}
    }


}
