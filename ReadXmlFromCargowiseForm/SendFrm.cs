using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ReadXmlFromCargowiseForm
{
    public partial class SendFrm : Form
    {
        public string Url { get; set; }
        public string UserName { get; set; }
        public string Passwd { get; set; }
        public string FilePath { get; set; }
        string Patt
        {
            get { return @"<(UniversalShipment)[^>]+>[\s\S]+</\1>"; }
        }
        public SendFrm()
        {
            InitializeComponent();
            Url = "https://COHTRNservices.wisegrid.net/eAdaptor";
            UserName = "cohesiontest";
            Passwd = "12345";
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            LoadFromFilePath();
        }
        async void LoadFromFilePath()
        {
            if (File.Exists(FilePath))
            {
                using (var stream = File.OpenRead(FilePath))
                {
                    byte[] buffer = new byte[stream.Length];
                    await stream.ReadAsync(buffer, 0, buffer.Length);
                    var content = Encoding.UTF8.GetString(buffer);
                    if (Regex.IsMatch(content, Patt))
                    {
                        editContentBox.Text = Regex.Match(content, Patt).Value;
                    }
                }
            }
            else
            {
                MessageBox.Show("文件路径不存在！！！");
            }
        }

        private void barLargeButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var content = editContentBox.Text;
            if (content.Length > 0)
            {
                ChangeSendBtnStatus();
                HTTPPostXMLMessageAsync();
            }
        }
        void Log(string text)
        {
            editContentBox.Invoke(
                new Action(() =>
                {
                    responseTxt.AppendText(text + "\r\n");
                })
            );
        }
        void ChangeSendBtnStatus()
        {
            if (SendToCWBtn.Enabled)
            {
                SendToCWBtn.Caption = "Sending......";
            }
            else
            {
                SendToCWBtn.Caption = "发送到Cargowise";
            }
            SendToCWBtn.Enabled = !SendToCWBtn.Enabled;
        }
        async void HTTPPostXMLMessageAsync()
        {
            await Task.Run(() =>
            {
                HTTPPostXMLMessage();
            });
            Log("HTTP POST Complete.");
            ChangeSendBtnStatus();
        }
        void HTTPPostXMLMessage()
        {
            // It may be instructive to view the output of this sample in Microsoft Fiddler (http://www.fiddlertool.com).
            // This will allow you to see the raw POST and Reponse with all HTTP Headers and your XML body content.

            var uri = new Uri(Url);
            var client = new HttpXmlClient(uri, CompressCheckBox.Checked, UserName, Passwd);

            using (var sourceStream = new MemoryStream(Encoding.UTF8.GetBytes(editContentBox.Text)))
            {
                Log("Begin POST to " + uri);
                Log("        <<<------------------------------------------------- Begin Message Body ------------------------------------------------->>>");
                Log(editContentBox.Text);
                Log("        <<<-------------------------------------------------- End Message Body -------------------------------------------------->>>");
                Log("");
                Log("Waiting Response...");
                Log("");

                try
                {
                    var response = client.Post(sourceStream);
                    var responseStatus = response.StatusCode;

                    

                    if (response.Content != null)
                    {
                        var stream = response.Content.ReadAsStreamAsync().Result;

                        if (response.Content.Headers.ContentEncoding.Contains("gzip", StringComparer.InvariantCultureIgnoreCase))
                        {
                            stream = new GZipStream(stream, CompressionMode.Decompress);
                        }

                        using (var reader = new StreamReader(stream))
                        {
                            Log("        <<<------------------------------------------------- Begin Response Body ------------------------------------------------->>>");
                            Log(reader.ReadToEnd());
                            Log("        <<<-------------------------------------------------- End Response Body -------------------------------------------------->>>");
                        }
                    }
                    Log((responseStatus == HttpStatusCode.OK ? "Response Received" : "ERROR RESPONSE RECEIVED") + ", Status:- " + (int)responseStatus + " - " + response.ReasonPhrase);
                    Log("");
                }
                catch (Exception exception)
                {
                    Log("EXCEPTION THROWN DURING POST!!!!");
                    Log(exception.ToString());
                    Log("");
                }
            }

        }

        private void barLargeButtonItem2_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            editContentBox.ResetText();
            responseTxt.Clear();
            LoadFromFilePath();
        }
    }
}
