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

        enum ConvertType
        {
            Shipment,
            Booking,
            Consol
        }
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
            foreach (ConvertType item in Enum.GetValues(typeof(ConvertType)))
            {
                typeComBo.Items.Add(item.ToString());
            }
            typeComBo.SelectedIndex = 0;
            typeComBo.Location = new Point(10, 50);
            typeComBo.DropDownStyle = ComboBoxStyle.DropDownList;
            mutiConvertBtn.Location = new Point(typeComBo.Location.X, typeComBo.Location.Y + 30);
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
            this.Invoke(new Action(()=>{
                SaveFileCompletedHandler(e.FilePath);
            }));
            
        }


        void bookingHandler_SaveFileCompleled(object sender, SaveFileCompletedEventArgs e)
        {
            
                SaveFileCompletedHandler(e.FilePath);
            
        }

        void shipmentHandler_SaveFileCompleled(object sender, SaveFileCompletedEventArgs e)
        {
            
                SaveFileCompletedHandler(e.FilePath);
            
        }
        void SaveFileCompletedHandler(string FilePath)
        {
            this.Invoke(new Action(()=>{
                if (mutipleChkBox.Checked)
                {
                    using (var fs = File.OpenRead(FilePath))
                    {
                        var doc = XDocument.Load(fs);
                        LoadDocIntoTreeview(ResultTv, doc);
                    }
                }
                else
                {
                    showPathMsg(FilePath);
                    ShowInResult(FilePath);
                }
            }));
        }
        void ShowInResult(string FilePath)
        {
            using (var fs = File.OpenRead(FilePath))
            {
                ResultTv.Nodes.Clear();
                var doc = XDocument.Load(fs);
                LoadDocIntoTreeview(ResultTv, doc);
            }
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
            if (!mutipleChkBox.Checked)
            {
                typeComBo.Hide();
                mutiConvertBtn.Hide();
            }
        }

        private void UploadBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (mutipleChkBox.Checked)
                    {
                        FileTxt.Text = string.Join("|", openFileDialog1.FileNames);
                        LoadMutiFileToTv(openFileDialog1.FileNames);
                    }
                    else
                    {
                        FileTxt.Text = openFileDialog1.FileName;
                        LoadMutiFileToTv(FileTxt.Text);
                    }
                }
            }
            catch(Exception err)
            {
                WriteLog.Logging(err.Message);
            }
        }
        void LoadMutiFileToTv(params string[] fileNames)
        {
            FileContentTv.Nodes.Clear();
            foreach (var filename in fileNames)
            {
                if (File.Exists(filename) && filename.EndsWith(".xml"))
                {
                    var xdoc = XDocument.Load(filename);
                    LoadDocIntoTreeview(FileContentTv, xdoc);
                }
                else
                {
                    MessageBox.Show(filename+"不是XML文件");
                }
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
            this.Invoke(new Action(() => { 
                treeview.Nodes.Add(rootnode);
            }));
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
            sendFrm.FilePath = openFileDialog1.FileName;
            sendFrm.ShowDialog();
        }

        private void ConvertFrm_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void mutipleChkBox_CheckedChanged(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = mutipleChkBox.Checked;
            var ctrls = splitContainer2.Panel1.Controls;
            foreach (Control control in ctrls)
            {
                control.Visible = !control.Visible;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var dlgReslt= openFileDialog1.ShowDialog();
            if (dlgReslt == DialogResult.OK)
            {
                var files = openFileDialog1.FileNames;
                var actions = new Action[files.Length];
                for (var i = 0; i < files.Length; i++)
                {
                    var fn = files[i];
                    actions[i] = new Action(async() =>
                    {
                        Consol = await consolHandler.GetShipmentAsync(fn);
                        var newf = consolHandler.ConvertInstanceToFile(Consol, @"XML\Consol" + DateTime.Now.Ticks + ".xml");
                        Console.WriteLine("任务完成："+newf);
                    });
                }
                Parallel.Invoke(actions);
            }
        }

        private void mutiConvertBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.FileNames.Length > 0)
            {
                var conversion = (ConvertType)Enum.Parse(typeof(ConvertType),typeComBo.Text+string.Empty) ;
                var files = openFileDialog1.FileNames;
                var actions = new Action[files.Length];
                this.mutiConvertBtn.Enabled = !this.mutiConvertBtn.Enabled;
                
                switch (conversion)
                {
                    case ConvertType.Shipment:
                        for (var i = 0; i < files.Length; i++)
                        {
                            var fn = files[i];
                            var idx = i + 1;
                            actions[i] = new Action(async () =>
                            {
                                NsShipment.Shipment newshipment= await shipmentHandler.GetShipmentAsync(fn);
                                //var tick = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss_")+idx;
                                var tick = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss_") + idx;
                                var newf = shipmentHandler.ConvertInstanceToFile(newshipment, @"XML\Shipment" + tick + ".xml");
                                Console.WriteLine(string.Format("任务{0}完成：{1}", idx, newf));
                                this.Invoke(new Action(() => { 
                                    ResultTv.Nodes.Add(new TreeNode(string.Format("任务{0}完成：{1}", idx, newf)));
                                }));
                                shipmentHandler.RaiseSaveFileCompleled(newf);
                            });
                        }
                        break;
                    case ConvertType.Booking:
                        for (var i = 0; i < files.Length; i++)
                        {
                            var fn = files[i];
                            var idx = i + 1;
                            actions[i] = new Action( () =>
                            {
                                NsBooking.Shipment newshipment =  bookingHandler.GetShipment(fn);
                                var tick = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss_") + idx;
                                var newf = bookingHandler.ConvertInstanceToFile(newshipment, @"XML\Booking" + tick + ".xml");
                                Console.WriteLine(string.Format("任务{0}完成：{1}", idx, newf));
                                this.Invoke(new Action(() =>
                                {
                                    ResultTv.Nodes.Add(new TreeNode(string.Format("任务{0}完成：{1}", idx, newf)));
                                }));
                                bookingHandler.RaiseSaveFileCompleled(newf);
                            });
                        }
                        break;
                    case ConvertType.Consol:
                        for (var i = 0; i < files.Length; i++)
                        {
                            var fn = files[i];
                            var idx = i+1;
                            actions[i] = new Action( () =>
                            {
                                NsConsol.Shipment newshipment =  consolHandler.GetShipment(fn);
                                var tick = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss_") + idx;
                                var newf = consolHandler.ConvertInstanceToFile(newshipment, @"XML\Consol" + tick + ".xml");
                                Console.WriteLine(string.Format("任务{0}完成：{1}", idx, newf));
                                this.Invoke(new Action(() =>
                                {
                                    ResultTv.Nodes.Add(new TreeNode(string.Format("任务{0}完成：{1}", idx, newf)));
                                }));
                                consolHandler.RaiseSaveFileCompleled(newf);
                            });
                        }
                        break;
                    default:
                        MessageBox.Show("请选择正确的转换类型");
                        break;
                }
                ResultTv.Nodes.Clear();
                mutiConvertBtn.Text = "请等待...";
                Stopwatch sw = new Stopwatch();
                sw.Start();
                Parallel.Invoke(async() => {
                    var tlist = new List<Task>();
                    foreach (var a in actions)
                    {
                         tlist.Add(Task.Run(a));
                    }
                    await Task.WhenAll(tlist.ToArray());
                    this.Invoke(new Action(() =>
                    {
                        sw.Stop();
                        MessageBox.Show("全部任务完成，总耗时："+sw.Elapsed.TotalSeconds+"秒");
                        mutiConvertBtn.Text = "开始转换";
                        this.mutiConvertBtn.Enabled = !this.mutiConvertBtn.Enabled;
                    }));
                });
            }
            else
            {
                MessageBox.Show("请选择文件");
            }
        }
        //string GenFileName(string prefix, int idx)
        //{
        //    var tick = DateTime.Now.ToString("yyyy-MM-dd-hh:mm:ss_") + idx;
        //    return @"XML\" + prefix + tick + ".xml";
        //}
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