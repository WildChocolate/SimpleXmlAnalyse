using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using XmlRepository;
using XmlRepository.ConsolFolder;

namespace ReadXmlFromCargowiseForm
{
    public class ConsolHandler:Handler<Shipment>
    {
        private Dictionary<string, string> specialCollection = null;
        public ConsolHandler() {
            specialCollection = new Dictionary<string, string>();
        }
        protected override Dictionary<string, string> SpecialCollection
        {
            get {return specialCollection; }
        }
        public override Shipment ReadFile(string content)
        {
            //带命名空间时可以用XName取元素，也可以在用 var r = root.Element(xmlns + "元素名"),xmlns为XNamespace
            //XDocument xdoc = XDocument.Load(fs);
            //var Xname = XName.Get("Header", "http://www.cargowise.com/Schemas/Universal/2011/11");
            //var root = xdoc.Root;
            //XNamespace xmlns = "http://www.cargowise.com/Schemas/Universal/2011/11";
            return GetShipmentByText(content);
        }
        public override string ConvertInstanceToFile(Shipment Instance)
        {
            var fPath = string.Empty;
            if (Instance == null)
            {
                MessageBox.Show("请先生成Shipment实例");
            }
            else
            {
                var uShipment = new UniversalShipment();
                uShipment.Shipment = Instance;
                var xShipmentString = XmlSerializeHelper.Serialize(uShipment);//让它自己类型推断
                //xShipmentString = Regex.Replace(xShipmentString, @"<UniversalShipment[\s]*>", "<UniversalShipment>");
                using (StreamWriter tw = new StreamWriter(@"XML\ConsolResult.xml", false))
                {
                    tw.WriteLine(xShipmentString);
                    fPath = Path.GetFullPath(@"XML\ConsolResult.xml");
                }
            }
            return fPath;
        }
        //public Shipment GetShipmentByText(string text)
        //{
        //    var shipmentText = Regex.Match(text, @"<Shipment>[\s\S]*?</Shipment>").Value.ToString();
        //    var headerText = Regex.Match(text, @"<SenderID>(\w*?)</SenderID>[\s]+?<RecipientID>(\w*?)</RecipientID>").Groups;
        //    var SenderID = headerText[1].Value;
        //    var RecipientID = headerText[2].Value;
        //    var shipment = new Shipment();
        //    var Xshipment = XElement.Parse(shipmentText);
        //    ExtractXMLDynamic.SetInstanceByXElement(shipment, Xshipment);
        //    return shipment;
        //}
        
        //public async Task<Shipment> GetShipmentAsync(string filePath = "")
        //{
        //    var shipment = await Task.Factory.StartNew( ()=> GetShipment(filePath));
        //    return shipment;
        //}

        
    }
}
