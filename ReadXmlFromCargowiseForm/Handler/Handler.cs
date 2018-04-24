using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using XmlRepository;

namespace ReadXmlFromCargowiseForm
{
    public abstract class Handler<T>:IHandler<T> where T:class,new()
    {
        public event EventHandler<ExtractCompletedEventArgs> ExtractCompleted;
        public event EventHandler<SaveFileCompletedEventArgs> SaveFileCompleled;
        string Patt
        {
            get { return @"<(UniversalShipment)[^>]*>[\s\S]+</\1>"; }
        }
        /// <summary>
        /// 如果有特殊集合 像 xxCollection, 子节点直接为值的，放在这里，ConvertInstanceToFile 生成文件的时候再处理
        /// </summary>
        protected abstract Dictionary<string, string> SpecialCollection
        {
            get;
        }
        public void RaiseExtractCompleted(string bookingReference, string wayBillNum)
        {
            BLBasicInfo basicInfo = new BLBasicInfo() { BookingConfirmationReference = bookingReference, WayBillNumber = wayBillNum };
            OnExtractCompleted(new ExtractCompletedEventArgs(basicInfo));
        }
        protected virtual void OnExtractCompleted(ExtractCompletedEventArgs e)
        {
            var tmp = ExtractCompleted;
            if(ExtractCompleted != null){
                ExtractCompleted(this, e);
            }
        }
        public void RaiseSaveFileCompleled(string filePath)
        {
            OnSaveFileCompleled(filePath);
        }
        protected virtual void OnSaveFileCompleled(string filePath)
        {
            var tmp = SaveFileCompleled;
            if (tmp != null)
            {
                SaveFileCompleled(this, new SaveFileCompletedEventArgs(filePath));
            }
        }
        public abstract T ReadFile(string filePath);

        public abstract string ConvertInstanceToFile(T Instance);
        public virtual T GetShipment(string filePath) {
            var newpath = CheckFilePath(filePath);
            if (newpath.Length > 0)
            {
                using (var fs = File.OpenRead(filePath))
                {
                    var buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    var content = Encoding.UTF8.GetString(buffer);
                    if (Regex.IsMatch(content, Patt))
                    {
                        return ReadFile(content);
                    }
                    else
                    {
                        throw new FileFormatException("文件内容不符合：<UniversalShipment>...</UniversalShipment>");
                    }
                }
            }
            else {
                throw new FileNotFoundException("不存在文件或文件路径不合法！！！");
            }
        }
        
        protected string CheckFilePath(string filePath)
        {
            var newpath = "";
            if (File.Exists(filePath))
            {
                newpath = filePath;
            }
            else
            {
                var fullpath = Path.GetFullPath(filePath);
                if (File.Exists(fullpath))
                {
                    newpath = fullpath;
                }
                else
                    throw new FileNotFoundException("不存在此文件！！！,请检查路径");
            }
            return newpath;
        }


        public virtual async Task<T> GetShipmentAsync(string filePath) 
        {
            var shipment = await Task.Run<T>(() => GetShipment(filePath));
            return shipment;
        }

        public virtual T GetShipmentByText(string text) {
            var shipmentText = Regex.Match(text, @"<Shipment>[\s\S]*?</Shipment>").Value.ToString();
            var headerText = Regex.Match(text, @"<SenderID>(\w*?)</SenderID>[\s]+?<RecipientID>(\w*?)</RecipientID>").Groups;
            var SenderID = headerText[1].Value;
            var RecipientID = headerText[2].Value;
            var shipment = new T();
            var Xshipment = XElement.Parse(shipmentText);
            ExtractXMLDynamic.SetInstanceByXElement(shipment, Xshipment);
            return shipment;
        }
        public virtual async Task<T> GetShipmentByTextAsync(string text)
        {
            var shipment = await Task.Run<T>(()=> GetShipmentByText(text));
            return shipment;
        }
    }
}
