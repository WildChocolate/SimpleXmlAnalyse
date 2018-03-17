using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using XmlRepository;
using XmlRepository.BookingFolder;

namespace ReadXmlFromCargowiseForm
{
    public class BookingHandler
    {
        static BookingHandler()
        {

        }
        /* 关于动态提取XML内容的通用部分，移动到---> ExtractXMLDynamic 
         *      SearchCollectionNew<T>() 和 SearchCollection<T>()由于使用了特定的类，就留下来，不过好像没什么地方用到了
         */
        public static Shipment GetBooking(string filePath="")
        {
            var path = "";
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

                    #region -----这是以前的做法，先给普通节点赋值，再分别取得每个集合，之后每个集合设置到Shipment，垃圾
                    //var shipment = XmlSerializeHelper.DeSerialize<Shipment>(text);
                    //var shipments = doc.Element("Body").Element("UniversalShipment").Elements("Shipment").ToList();
                    //var ObjCustomizedFieldCollection = ShipmentHandler.SearchCollectionNew<CustomizedField>(Xshipment.Element(typeof(CustomizedFieldCollection).Name));
                    //var ObjDataSourceCollection = ShipmentHandler.SearchCollectionNew<DataSource>(Xshipment.Element(typeof(DataSourceCollection).Name));
                    //var ObjDateCollection = ShipmentHandler.SearchCollectionNew<Date>(Xshipment.Element(typeof(DateCollection).Name));
                    //var ObjMilestoneCollection = ShipmentHandler.SearchCollectionNew<Milestone>(Xshipment.Element(typeof(MilestoneCollection).Name));
                    //var ObjOrganizationAddressCollection = ShipmentHandler.SearchCollectionNew<OrganizationAddress>(Xshipment.Element(typeof(OrganizationAddressCollection).Name));
                    //var ObjRecipientRoleCollection = ShipmentHandler.SearchCollectionNew<RecipientRole>(Xshipment);
                    //var ObjRegistrationNumberCollection = ShipmentHandler.SearchCollectionNew<RegistrationNumber>(shipments[0]);
                    //RegistrationNumberCollection是OrganizationAddressCollection子元素OrganizationAddress的子元素
                    //现在要把RegistrationNumberCollection填入OrganizationAddressCollection里相应的OrganizationAddress
                    //shipment.CustomizedFieldCollection.CustomizedFields.AddRange(ObjCustomizedFieldCollection);
                    ////shipment.DataContext.RecipientRoleCollection.RecipientRoles.AddRange(ObjRecipientRoleCollection);
                    //shipment.DataContext.DataSourceCollection.DataSources.AddRange(ObjDataSourceCollection);
                    //shipment.DateCollection.Dates.AddRange(ObjDateCollection);
                    //shipment.MilestoneCollection.Milestones.AddRange(ObjMilestoneCollection);
                    //shipment.OrganizationAddressCollection.OrganizationAddresses.AddRange(ObjOrganizationAddressCollection);
                    #endregion

                    return shipment;
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
