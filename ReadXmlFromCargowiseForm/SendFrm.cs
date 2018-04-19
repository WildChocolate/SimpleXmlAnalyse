using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Management;
using System.Net;
using System.Printing;
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
        
        // Declare the PrintDocument object.  
        private string streamType;
        private Stream streamToPrint;
        private PrintDocument docToPrint = new PrintDocument();//创建一个PrintDocument的实例  
        string Patt
        {
            get { return @"<(UniversalShipment)[^>]*>[\s\S]+</\1>"; }
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
            this.docToPrint.PrintPage += new PrintPageEventHandler(docToPrint_PrintPage);  
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
                    else
                    {
                        MessageBox.Show("文件内容需要包含 :<UniversalShipment>...</UniversalShipment>");
                    }
                }
            }
            else
            {
                MessageBox.Show("文件路径不存在！！！");
            }
        }

        private void SendToCWBtn_ClickHandler(object sender, EventArgs e)
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
                SendToCWBtn.Text = "Sending......";
            }
            else
            {
                SendToCWBtn.Text = "发送到Cargowise";
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

        private void ResetBtn_ClickHandler(object sender, EventArgs e)
        {
            editContentBox.ResetText();
            responseTxt.Clear();
            LoadFromFilePath();
        }

        private void 打开OToolStripButton_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog()==DialogResult.OK)
            {
                FilePath = fileDialog.FileName;
                LoadFromFilePath();
            }
            fileDialog.Dispose();
        }

        private void 保存SToolStripButton_Click(object sender, EventArgs e)
        {
            var content = editContentBox.Text;
            if (File.Exists(FilePath))
            {
                using (var sw = new StreamWriter(FilePath, false, Encoding.UTF8))
                {
                    sw.WriteAsync(content).ContinueWith(t => {
                        if (t.IsCompleted)
                        {
                            MessageBox.Show("已保存至文件:"+FilePath);
                        }
                    });
                }
            }
        }

        private void 剪切UToolStripButton_Click(object sender, EventArgs e)
        {
            var text = editContentBox.SelectedText;
            editContentBox.Cut();
        }

        private void 复制CToolStripButton_Click(object sender, EventArgs e)
        {
            editContentBox.Copy();
        }

        private void 粘贴PToolStripButton_Click(object sender, EventArgs e)
        {
            if (editContentBox.SelectionLength > 0)
            {
                editContentBox.SelectionStart = editContentBox.SelectionStart + editContentBox.SelectionLength;
            }
            editContentBox.SelectedText = Clipboard.GetText();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (File.Exists(FilePath))
            {
                using (var stream = File.OpenRead(FilePath))
                {
                    var type = stream.Name.Split('.');
                    streamType = type.LastOrDefault();
                    StartPrint(stream, "xml");
                }
            }
        }

        // This method will set properties on the PrintDialog object and  
        // then display the dialog.  
        public void StartPrint(Stream streamToPrint, string streamType)
        {
            this.streamToPrint = streamToPrint;
            this.streamType = streamType;
            PrintDialog printDialog = new PrintDialog();//创建一个PrintDialog的实例  
            printDialog.AllowSomePages = true;
            printDialog.ShowHelp = true;
            // Set the Document property to the PrintDocument for  
            // which the PrintPage Event has been handled. To display the  
            // dialog, either this property or the PrinterSettings property  
            // must be set  
            printDialog.Document = docToPrint;//把PrintDialog的Document属性设为上面配置好的PrintDocument的实例  
            DialogResult result = printDialog.ShowDialog();//调用PrintDialog的ShowDialog函数显示打印对话框  
            // If the result is OK then print the document.  
            
            if (result == DialogResult.OK)
            {
                docToPrint.Print();//开始打印  
            }
        }
        // The PrintDialog will print the document  
        // by handling the document’s PrintPage event.  
        private void docToPrint_PrintPage(object sender,
        System.Drawing.Printing.PrintPageEventArgs e)//设置打印机开始打印的事件处理函数  
        {
            // Insert code to render the page here.  
            // This code will be called when the control is drawn.  
            // The following code will render a simple  
            // message on the printed document  
            switch (this.streamType)
            {
                case "txt":
                case "xml":
                    string text = null;
                    System.Drawing.Font printFont = new System.Drawing.Font
                    ("Arial", 35, System.Drawing.FontStyle.Regular);
                    // Draw the content.  
                    System.IO.StreamReader streamReader = new StreamReader(this.streamToPrint);
                    text = streamReader.ReadToEnd();
                    e.Graphics.DrawString(text, printFont, System.Drawing.Brushes.Black, e.MarginBounds.X, e.MarginBounds.Y);
                    break;
                case "image":
                    System.Drawing.Image image = System.Drawing.Image.FromStream(this.streamToPrint);
                    int x = e.MarginBounds.X;
                    int y = e.MarginBounds.Y;
                    int width = image.Width;
                    int height = image.Height;
                    if ((width / e.MarginBounds.Width) > (height / e.MarginBounds.Height))
                    {
                        width = e.MarginBounds.Width;
                        height = image.Height * e.MarginBounds.Width / image.Width;
                    }
                    else
                    {
                        height = e.MarginBounds.Height;
                        width = image.Width * e.MarginBounds.Height / image.Height;
                    }
                    System.Drawing.Rectangle destRect = new System.Drawing.Rectangle(x, y, width, height);
                    e.Graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, System.Drawing.GraphicsUnit.Pixel);
                    break;
                default:
                    break;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            editContentBox.Undo();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            editContentBox.Redo();
        }   
    }
}
