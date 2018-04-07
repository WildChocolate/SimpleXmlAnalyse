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
    public partial class Form1 : Form
    {
        NsShipment.Shipment shipment = null;
        NsBooking.Shipment Booking = null;
        NsConsol.Shipment Consol = null;
        ShipmentHandler shipmentHandler = null;
        BookingHandler bookingHandler = null;
        ConsolHandler consolHandler = null;
        public Form1()
        {
            InitializeComponent();
            ///处理对象初始化
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
        private void showPathMsg(string path)
        {
            MessageBox.Show("保存成功，文件路径为--> "+path);
        }
        void consolHandler_SaveFileCompleled(object sender, SaveFileCompletedEventArgs e)
        {
            showPathMsg(e.FilePath);
        }


        void bookingHandler_SaveFileCompleled(object sender, SaveFileCompletedEventArgs e)
        {
            showPathMsg(e.FilePath);
        }

        void shipmentHandler_SaveFileCompleled(object sender, SaveFileCompletedEventArgs e)
        {
            showPathMsg(e.FilePath);
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
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {

                var task = shipmentHandler.GetShipmentAsync(@"XML\Message04" + ".xml");//获取Shipment
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
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                var task = bookingHandler.GetShipmentAsync(@"XML\Booking2" + ".xml");//获取Shipment
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
            try
            {
                //由于Consol的处理时间比较长，所以用异步方法
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                var task = consolHandler.GetShipmentAsync(@"XML\Consol01.xml");//获取Shipment
                button4.Text = "Process waiting....";
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
                        this.button4.Text = text;
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
                    button4.Text = "Processing " + String.Format("{0:N2} ", second) +" Seconds";
                });
                var clockTask = Task.Run(async() => {
                    while(!task.IsCompleted)
                    {
                        await Task.Delay(100);
                        if (this.button4.InvokeRequired)
                        {
                            second += 0.1f;
                            this.button4.Invoke(fun2);
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
    }
}