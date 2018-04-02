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
            shipmentHandler.ConvertInstanceToFile(shipment);
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
            consolHandler.ConvertInstanceToFile(Consol);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bookingHandler.ConvertInstanceToFile(Booking);
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}