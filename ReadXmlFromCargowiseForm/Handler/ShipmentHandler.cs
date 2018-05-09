using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using XmlRepository;
using XmlRepository.ShipmentFolder;

namespace ReadXmlFromCargowiseForm
{
    public class ShipmentHandler:Handler<Shipment>
    {
        /// <summary>
        /// 如果有特殊集合 像 xxCollection, 子节点直接为值的，放在这里，ConvertInstanceToFile 生成文件的时候再处理
        /// </summary>
        private Dictionary<string, string> specialCollection = null;
        public ShipmentHandler(){
            specialCollection =new Dictionary<string, string>();
            specialCollection.Add(typeof(TestCollection).Name, typeof(TestCollection).Name.Replace("Collection",""));
        }
        protected override Dictionary<string, string> SpecialCollection
        {
            get
            {
                return specialCollection;
            }
        }
        /* 关于动态提取XML内容的通用部分，移动到---> ExtractXMLDynamic 
         *      SearchCollectionNew<T>() 和 SearchCollection<T>()由于使用了特定的类，就留下来，不过好像没什么地方用到了
         */
        public override Shipment ReadFile(string content)
        {
            //带命名空间时可以用XName取元素，也可以在用 var r = root.Element(xmlns + "元素名"),xmlns为XNamespace
            //XDocument xdoc = XDocument.Load(fs);
            //var Xname = XName.Get("Header", "http://www.cargowise.com/Schemas/Universal/2011/11");
            //var root = xdoc.Root;
            //XNamespace xmlns = "http://www.cargowise.com/Schemas/Universal/2011/11";
            /*
                *可以在这里加一些特定的操作
                */
            return GetShipmentByText(content);
        }

        public override string ConvertInstanceToFile(Shipment Instance,string newFilePath=@"XML\ShipmentResult.xml")
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
                
                //以下为特殊节点进行特殊处理
                if (SpecialCollection.Count > 0)
                {
                    foreach (var coll in SpecialCollection)
                    {
                        var key = coll.Key;
                        var patt = @"<?>[\s\S]+</?>";
                        patt = patt.Replace("?", key);
                        var reg = new Regex(patt, RegexOptions.IgnoreCase);
                        var matches = reg.Matches(xShipmentString);
                        foreach (Match m in matches)
                        {
                            var xcoll = XElement.Parse(m.Value);
                            var replaceName = coll.Value;
                            foreach (var ele in xcoll.Elements())
                            {
                                ele.Name = replaceName;
                            }
                            xShipmentString = xShipmentString.Remove(m.Index, m.Value.Length);
                            xShipmentString = xShipmentString.Insert(m.Index, xcoll.ToString());
                        }
                    }
                }
                if (!File.Exists(newFilePath))
                {
                    var myFile = File.Create(newFilePath);
                    myFile.Dispose();
                    myFile.Close();
                }
                using (var sw = new StreamWriter(newFilePath))
                {
                    sw.Write(xShipmentString);
                }
                fPath = Path.GetFullPath(newFilePath);
            }
            return fPath;
        }
        
        #region 新的关于遍历节点的方法在 XmlRepository.ExtractXMLDynamic
        /// <summary>
        /// 旧方法，根据T， 在element中查找所有的 T 类型的元素（并不一定是element的直接子元素），最后返回 T的列表
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
                foreach (var ele in element.Elements())
                {
                    if (ele.HasElements)
                        tList.AddRange(SearchCollection<T>(ele));//递归遍历每个子节点
                }
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
        /// 根据T， 在element中查找，T类型的节点，最后返回 T的列表，比如要返回   List<MileStone> 就传入 <MeilStoneColletion>...</MeilStoneColletion>元素
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

        #endregion

    }
}
