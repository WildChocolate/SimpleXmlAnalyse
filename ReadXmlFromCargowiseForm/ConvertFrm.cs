using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using XmlRepository;
using NsBooking = XmlRepository.BookingFolder;
using NsShipment = XmlRepository.ShipmentFolder;
using NsConsol = XmlRepository.ConsolFolder;
using System.Threading;

namespace ReadXmlFromCargowiseForm
{
    public partial class ConvertFrm : Form
    {
        NsShipment.Shipment shipment = null;
        NsBooking.Shipment Booking = null;
        NsConsol.Shipment Consol = null;
        ShipmentHandler shipmentHandler = null;
        BookingHandler bookingHandler = null;
        ConsolHandler consolHandler = null;
        static string Bracket = " => ";
        SendFrm sendFrm;
        public ConvertFrm()
        {
            InitializeComponent();
            ///处理对象初始化
            ///
            sendFrm = new SendFrm();
            shipmentHandler = new ShipmentHandler();
            bookingHandler = new BookingHandler();
            consolHandler = new ConsolHandler();
            shipmentHandler.ExtractCompleted += shipmentHandler_ExtractCompleted;
            bookingHandler.ExtractCompleted += bookingHandler_ExtractCompleted;
            consolHandler.ExtractCompleted += consolHandler_ExtractCompleted;
            shipmentHandler.SaveFileCompleled += shipmentHandler_SaveFileCompleled;
            bookingHandler.SaveFileCompleled += bookingHandler_SaveFileCompleled;
            consolHandler.SaveFileCompleled += consolHandler_SaveFileCompleled;
        }
        string FilePath
        {
            get
            {
                if (FileTxt.Text.EndsWith(".xml"))
                {
                    return FileTxt.Text;
                }
                else
                {
                    MessageBox.Show("请上传XML文件");
                    return "";
                }
            }
        }
        private void showPathMsg(string path)
        {
            MessageBox.Show("保存成功，文件路径为--> "+path);
        }
        void consolHandler_SaveFileCompleled(object sender, SaveFileCompletedEventArgs e)
        {
            showPathMsg(e.FilePath);
            using (var fs = File.OpenRead(e.FilePath))
            {
                var doc = XDocument.Load(fs);
                LoadDocIntoTreeview(ResultTv, doc);

            }
            ExpandShipmentNode(ResultTv.TopNode, "Shipment");
        }


        void bookingHandler_SaveFileCompleled(object sender, SaveFileCompletedEventArgs e)
        {
            showPathMsg(e.FilePath);
            using (var fs = File.OpenRead(e.FilePath))
            {
                var doc = XDocument.Load(fs);
                LoadDocIntoTreeview(ResultTv, doc);
            }
            ExpandShipmentNode(ResultTv.TopNode, "Shipment");
        }

        void shipmentHandler_SaveFileCompleled(object sender, SaveFileCompletedEventArgs e)
        {
            showPathMsg(e.FilePath);
            using (var fs = File.OpenRead(e.FilePath))
            {
                var doc = XDocument.Load(fs);
                LoadDocIntoTreeview(ResultTv, doc);
            };
            ExpandShipmentNode(ResultTv.TopNode, "Shipment");
        }

        void consolHandler_ExtractCompleted(object sender, ExtractCompletedEventArgs e)
        {
            //consol转换完成后的后续操作
        }

        void bookingHandler_ExtractCompleted(object sender, ExtractCompletedEventArgs e)
        {
            //booking转换完成后的后续操作
        }

        void shipmentHandler_ExtractCompleted(object sender, ExtractCompletedEventArgs e)
        {
            //shipment转换完成后的后续操作
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FilePath))
                return;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                var task = shipmentHandler.GetShipmentAsync(FilePath);//获取Shipment
                task.ContinueWith(t =>
                {
                    shipment = t.Result;
                    stopwatch.Stop();
                    var ts = stopwatch.Elapsed;
                    string elapsedTime = String.Format("Shipment 提取完成，用时 {0}.{1:000}秒",
                    ts.Seconds, ts.Milliseconds);
                    MessageBox.Show(elapsedTime);
                    shipmentHandler.RaiseExtractCompleted(shipment.BookingConfirmationReference, shipment.WayBillNumber);
                });
            }
            catch (NullReferenceException err) {
                MessageBox.Show("Null引用错误："+err.Message);
            }
            catch (FileNotFoundException ferr)
            {
                MessageBox.Show(ferr.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FilePath))
                return;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                var task = bookingHandler.GetShipmentAsync(FilePath);//获取Shipment
                task.ContinueWith(t => {
                    Booking = t.Result;
                    stopwatch.Stop();
                    var ts = stopwatch.Elapsed;
                    string elapsedTime = String.Format("Shipment 提取完成，用时 {0}.{1}秒",
                    ts.Seconds, ts.Milliseconds);
                    MessageBox.Show(elapsedTime);
                    bookingHandler.RaiseExtractCompleted(Booking.BookingConfirmationReference, Booking.WayBillNumber);
                });
            }
            catch (NullReferenceException err)
            {
                MessageBox.Show("Null引用错误：" + err.Message);
            }
            catch (FileNotFoundException ferr)
            {
                MessageBox.Show(ferr.Message);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var fPath = shipmentHandler.ConvertInstanceToFile(shipment);
            if (!string.IsNullOrEmpty(fPath))
                shipmentHandler.RaiseSaveFileCompleled(fPath);
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FilePath))
                return;
            try
            {
                //由于Consol的处理时间比较长，所以用异步方法
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                var task = consolHandler.GetShipmentAsync(FilePath);//获取Shipment
                ConsolBtn.Text = "Process waiting....";
                task.ContinueWith((t) =>
                {
                    stopwatch.Stop();
                    var ts = stopwatch.Elapsed;
                    string elapsedTime = String.Format("Shipment 提取完成，用时 {0}.{1:000}秒",
                    ts.Seconds, ts.Milliseconds);
                    Consol = t.Result;
                    MessageBox.Show(elapsedTime);
                    var str = "Consol";
                    var fun = new Action<string>((text) =>
                    {
                        this.ConsolBtn.Text = text;
                    });
                    if (this.InvokeRequired)
                    {
                        this.Invoke(fun, str);
                    }
                    consolHandler.RaiseExtractCompleted(Consol.BookingConfirmationReference, Consol.WayBillNumber);
                });
                float second = 0f;
                var fun2 = new Action(() =>
                {
                    ConsolBtn.Text = "Processing " + String.Format("{0:N2} ", second) +" Seconds";
                });
                var clockTask = Task.Run(async() => {
                    while(!task.IsCompleted)
                    {
                        await Task.Delay(100);
                        if (this.ConsolBtn.InvokeRequired)
                        {
                            second += 0.1f;
                            this.ConsolBtn.Invoke(fun2);
                        }
                    }
                });
            }
            catch (NullReferenceException err)
            {
                MessageBox.Show("Null引用错误：" + err.Message);
            }
            catch (FileNotFoundException ferr)
            {
                MessageBox.Show(ferr.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var fPath = consolHandler.ConvertInstanceToFile(Consol);
            if (!string.IsNullOrEmpty(fPath))
            {
                consolHandler.RaiseSaveFileCompleled(fPath);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var fPath = bookingHandler.ConvertInstanceToFile(Booking);
            if (!string.IsNullOrEmpty(fPath))
                shipmentHandler.RaiseSaveFileCompleled(fPath);
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void UploadBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileTxt.Text = openFileDialog1.FileName;
                    if (File.Exists(openFileDialog1.FileName) && openFileDialog1.FileName.EndsWith(".xml"))
                    {
                        var xdoc = XDocument.Load(openFileDialog1.FileName);
                        FileContentTv.Nodes.Clear();
                        LoadDocIntoTreeview(FileContentTv, xdoc);
                    }
                    else
                    {
                        MessageBox.Show("请选择XML文件");
                    }
                }
            }
            catch(Exception err)
            {
                WriteLog.Logging(err.Message);
            }
        }

        private void LoadDocIntoTreeview(TreeView treeview, XDocument xdoc)
        {
            var root = xdoc.Root;
            if (root.HasElements)
            {
                FillByXElement(treeview, root);
            }
            var top = treeview.TopNode;
            var level = "Shipment";
            if (top != null)
            {
                top.Expand();
                foreach (TreeNode node in top.Nodes)
                {
                    ExpandShipmentNode(node, level);
                }
            }
        }
        void ExpandShipmentNode(TreeNode tnode, string level) {
            tnode.Expand();
            if (tnode.FullPath.Contains(level))
            {
                foreach (TreeNode target in tnode.Nodes)
                {
                    target.Expand();
                }
                return;
            }
            if (tnode.Nodes != null && tnode.Nodes.Count > 0)
            {
                foreach (TreeNode node in tnode.Nodes)
                {
                    ExpandShipmentNode(node, level);
                }
            }
            else
                return;
        }

        private void FillByXElement(TreeView treeview, XElement root)
        {
            TreeNode rootnode = new TreeNode();
            var localname = root.Name.LocalName;
            rootnode.Name = localname + string.Empty;
            if (root.HasElements)
            {
                rootnode.Text = localname + string.Empty;
                FillTnode(rootnode, root.Elements());
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(root.Name + string.Empty))
                    rootnode.Text = root.Value;
            }
            treeview.Nodes.Add(rootnode);
        }

        private void FillTnode(TreeNode Treenode, IEnumerable<XElement> elements)
        {
            foreach (var element in elements)
            {
                var localname = element.Name.LocalName;
                var node = new TreeNode();
                node.Name = localname + string.Empty;
                Treenode.Nodes.Add(node);
                if (element.HasElements)
                {
                    node.Text = localname + string.Empty;
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(element.Value + string.Empty))
                        node.Text = localname + ConvertFrm.Bracket + element.Value;
                    else
                        node.Text = localname + ConvertFrm.Bracket;
                }
                if (element.HasElements)
                    FillTnode(node, element.Elements());
            }
        }

        private void FileContentTV_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(e.Label))
            {
                e.CancelEdit = true;
            }
            else
            {
                if (e.Node.Nodes.Count == 0)
                {
                    var idx = e.Node.Index;
                    var name = e.Node.Name;
                    var text = e.Node.Name + ConvertFrm.Bracket + e.Label;
                    var newnode = new TreeNode();
                    newnode.Name = name;
                    newnode.Text = text;
                    e.Node.Parent.Nodes.Insert(idx, newnode);
                    e.Node.EndEdit(false);
                    e.Node.Remove();
                }
            }
        }

        private void FileContentTV_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sendFrm.FilePath = FileTxt.Text;
            sendFrm.ShowDialog();
        }

        private void ConvertFrm_Paint(object sender, PaintEventArgs e)
        {
            
        }

        //private void FileContentTV_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        //{
        //    var newnode = new TreeNode();
        //    var name = e.Node.Name;
        //    var text = e.Node.Text;
        //    var idx = e.Node.Index;
        //    newnode.Name = name;
        //    newnode.Text = text;
        //    e.Node.Parent.Nodes.Insert(idx, newnode);
        //    e.Node.Remove();
        //}

        
    }
}