using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using XmlRepository;
using XmlRepository.ConsolFolder;

namespace ReadXmlFromCargowiseForm
{
    public static class ConsolHandler
    {
        public static Shipment GetShipment(string filePath = "")
        {
            var arr = new string[] { "01", "02", "03", "04" };
            var a = arr[new Random().Next(4)];
            var path = @"XML\Consol01.xml";
            if (File.Exists(filePath))
            {
                path = filePath;
            }
            else
            {
                var fullpath = Path.GetFullPath(filePath);
                if (File.Exists(fullpath))
                {
                    path = fullpath;
                }
                else
                    throw new FileNotFoundException("不存在此文件！！！,请检查路径");
            }
            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    //带命名空间时可以用XName取元素，也可以在用 var r = root.Element(xmlns + "元素名"),xmlns为XNamespace
                    //XDocument xdoc = XDocument.Load(fs);
                    //var Xname = XName.Get("Header", "http://www.cargowise.com/Schemas/Universal/2011/11");
                    //var root = xdoc.Root;
                    //XNamespace xmlns = "http://www.cargowise.com/Schemas/Universal/2011/11";

                    string text = sr.ReadToEnd();
                    var shipmentText = Regex.Match(text, @"<Shipment>[\s\S]*?</Shipment>").Value.ToString();
                    var headerText = Regex.Match(text, @"<SenderID>(\w*?)</SenderID>[\s]+?<RecipientID>(\w*?)</RecipientID>").Groups;
                    var SenderID = headerText[1].Value;
                    var RecipientID = headerText[2].Value;

                    var shipment = new Shipment();
                    var Xshipment = XElement.Parse(shipmentText);
                    ExtractXMLDynamic.SetInstanceByXElement(shipment, Xshipment);
                    return shipment;
                }
            }
        }
        public static async Task<Shipment> GetShipmentAsync(string filePath = "")
        {
            var shipment = await Task.Factory.StartNew( ()=> GetShipment(filePath));
            return shipment;
        }
    }
}
