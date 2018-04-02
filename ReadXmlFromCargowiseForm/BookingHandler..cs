using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using XmlRepository;
using XmlRepository.BookingFolder;

namespace ReadXmlFromCargowiseForm
{
    public class BookingHandler:Handler<Shipment>
    {
        
        /* 关于动态提取XML内容的通用部分，移动到---> ExtractXMLDynamic 
         *      SearchCollectionNew<T>() 和 SearchCollection<T>()由于使用了特定的类，就留下来，不过好像没什么地方用到了
         */
        private Dictionary<string, string> specialCollection = null;
        public BookingHandler() {
            specialCollection = new Dictionary<string, string>();
        }
        protected override Dictionary<string, string> SpecialCollection
        {
            get { return specialCollection; }
        }
        public override Shipment ReadFile(string filePath)
        {
            using (FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    //带命名空间时可以用XName取元素，也可以在用 var r = root.Element(xmlns + "元素名"),xmlns为XNamespace
                    //XDocument xdoc = XDocument.Load(fs);
                    //var Xname = XName.Get("Header", "http://www.cargowise.com/Schemas/Universal/2011/11");
                    //var root = xdoc.Root;
                    //XNamespace xmlns = "http://www.cargowise.com/Schemas/Universal/2011/11";

                    string text = sr.ReadToEnd();
                    return GetShipmentByText(text);
                }
            }
        }
        public override void ConvertInstanceToFile(Shipment Instance)
        {
            if (Instance == null)
            {
                MessageBox.Show("请先生成Shipment实例");
            }
            else
            {
                var uShipment = new UniversalShipment();
                uShipment.Shipment = Instance;
                var xShipmentString = XmlSerializeHelper.Serialize(uShipment);//让它自己类型推断
                xShipmentString = Regex.Replace(xShipmentString, @"<UniversalShipment[\s]*>", "<UniversalShipment>");
                using (StreamWriter tw = new StreamWriter(@"XML\BookingResult.xml", false))
                {
                    tw.WriteLine(xShipmentString);
                    //Console.WriteLine(tw.BaseStream.GetType());     //输出FileStream
                    MessageBox.Show("转换成功，文件地址：" + Path.GetFullPath(@"XML\BookingResult.xml"));
                }
            }
        }
        /// <summary>
        /// 旧方法，根据T， 在element中查找，T类型的节点，最后返回 T的列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="element"></param>
        /// <returns></returns>
        [Obsolete]
        public static List<T> SearchCollection<T>(XElement element) where T : class,new()
        {
            var tList = new List<T>();
            if (element.HasElements)
            {
                //foreach (var ele in element.Elements())
                //{
                //    tList.AddRange(SearchCollection<T>(ele));//递归遍历每个子节点
                //}

                dynamic t = CreateInstance(typeof(T));
                var tName = t.GetType().Name;
                var nName = element.Name.ToString();

                if (tName == nName)
                {

                    var eName = nName.Replace("Collection", "");
                    var children = element.Parent.Elements(nName).ToList();//获取所有子节点
                    var props = t.GetType().GetProperties();//T的属性列表
                    
                    foreach (var child in children)
                    {
                        foreach (var prop in props)
                        {
                            if (prop.PropertyType.IsClass && prop.PropertyType.Name != "String")
                            {
                                Type classType = prop.PropertyType;//获得属性当前的类类型
                                dynamic obj = CreateInstance(classType);//用反射根据传入类型生成对象
                                var classProps = classType.GetProperties();//获取此类型对象的属性列表
                                XElement cElement = null;
                                if (!prop.PropertyType.Name.Contains("Collection"))//属性类型不是集合时进入
                                {
                                    cElement = child.Element(prop.Name);//此类对应的元素
                                    foreach (var cprop in classProps)
                                    {
                                        cprop.SetValue(obj, cElement.Element(cprop.Name).Value);
                                    }
                                    prop.SetValue(t, obj);
                                }

                            }
                            else prop.SetValue(t, child.Element(prop.Name).Value);

                        }
                    }
                    tList.Add(t);
                }

            }
            return tList;
        }
        /// <summary>
        /// 根据T， 在element中查找，T类型的节点，最后返回 T的列表，
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="element"></param>
        /// <returns></returns>
        public static List<T> SearchCollectionNew<T>(XElement element) where T : class,new()
        {
            var tList = new List<T>();
            if (element != null && element.HasElements)
            {
                dynamic t = null;
                var tName = typeof(T).Name;
                var nName = element.Name.ToString();

                if (nName.Contains(tName))
                {
                    //var eName = nName.Replace("Collection", "");
                    var children = element.Elements(tName);//获取所有子节点
                    var props = typeof(T).GetProperties();//T的属性列表
                    foreach (var child in children)
                    {
                        t = CreateInstance(typeof(T));
                        foreach (var prop in props)
                        {
                            if (prop.PropertyType.IsClass && prop.PropertyType.Name != "String")
                            {
                                Type classType = prop.PropertyType;//获得属性当前的类类型
                                dynamic obj = CreateInstance(classType);//用反射根据传入类型生成对象
                                //var classProps = classType.GetProperties();//获取此类型对象的属性列表
                                XElement cElement = null;
                                if (!prop.PropertyType.Name.Contains("Collection"))//属性类型不是集合时进入
                                {

                                    cElement = child.Element(prop.Name);//此类对应的元素
                                    var classProps = classType.GetProperties();//获取此类型对象的属性列表

                                    if (cElement != null && cElement.HasElements)
                                        ExtractXMLDynamic.SetNotCollectionElement(obj, cElement, classProps);//把obj 对象传入进行值设置
                                    prop.SetValue(t, obj);//把属性元素对象设置到目标对象t
                                }
                                else
                                {
                                    var subCollectionName = prop.PropertyType.Name;//子Collection名称
                                    var subColletctionChildName = subCollectionName.Replace("Collection", string.Empty);//去掉Collectin后的子元素名称
                                    var subCollection = child.Element(subCollectionName);//获取子Collection元素

                                    //此处可以扩展，如果有其它的情况可以加入其它的条件判断
                                    if (subColletctionChildName == typeof(RegistrationNumber).Name)
                                    {
                                        var subInstance = new RegistrationNumber();
                                        var tSubList = SearchSubCollection(subInstance, subCollection);
                                        SetInstanceSubCollection(t, tSubList);
                                    }
                                }
                            }

                            else
                                prop.SetValue(t, child.Element(prop.Name).Value);
                        }

                        tList.Add(t);
                        if (nName == "RegistrationNumberCollection")
                        {
                            var test = tList;
                        }
                        if (nName == "OrganizationAddressCollection")
                        {
                            var test = tList;
                        }
                    }
                }
            }

            return tList;
        }
        

       
        #region //与SearchCollectionNew<T>（）相关的方法
        public static void SetInstanceSubCollection(dynamic t, dynamic sourceList)
        {
            if (t.GetType() == typeof(OrganizationAddress))
                t.RegistrationNumberCollection.RegistrationNumbers = sourceList;
        }
        public static List<T> SearchSubCollection<T>(T t, XElement element) where T : class,new()
        {
            var tSubList = SearchCollectionNew<T>(element);
            return tSubList;
        }
        #endregion
        /// <summary>
        /// 根据传入的Type类型创建相应的实例对象
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static dynamic CreateInstance(Type type, string assembleName = "", string typeName = "")
        {
            //string path = fullName + "," + assemblyName;//命名空间.类型名,程序集
            Type o = type;//加载类型
            dynamic obj;
            if (assembleName.Length > 0 && typeName.Length > 0)
            {
                obj = Activator.CreateInstance(assembleName, "" + typeName);
                return obj;
            }
            obj = Activator.CreateInstance(o, true);//根据类型创建实例
            return obj;//类型转换并返回
        }



    }
}
