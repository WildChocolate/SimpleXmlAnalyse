using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XmlRepository
{
    public static class ExtractXMLDynamic
    {
        //字符串 的Type
        private static Type StringType = typeof(string);
        
        //可以枚举类型Type
        private static Type EnumerableType = typeof(IEnumerable);

        /// <summary>
        /// 检查是否为 集合类型的属性
        /// </summary>
        /// <param name="Prop"></param>
        /// <returns></returns>
        public static bool CheckIsCollection(Type PropType)
        {
            return (PropType.IsGenericType && Array.IndexOf(PropType.GetInterfaces(), EnumerableType) > -1);
        }

        /// <summary>
        ///     通过传入的元素和节点名称返回对应的值，若不存在此值，返回Null
        ///     如果没有传入节点名或传入空值，则认为是 要取得当前 Element.Value
        /// </summary>
        /// <param name="Element">值元素</param>
        /// <param name="ValueNodename">要获取的值的节点名称</param>
        /// <returns></returns>
        public static string GetValueFromElement(XElement Element, string ValueNodename=null) {
            if (string.IsNullOrEmpty(ValueNodename))
            {
                return Element.Value;
            }
            else
            {
                var valueElement = Element.Element(ValueNodename);
                if (valueElement != null)
                    return valueElement.Value;
                else
                    return string.Empty;
            }
        } 

        /// <summary>
        /// 检查是否为类属性 并且不为 String 类型, 比如Country 类
        /// </summary>
        /// <returns></returns>
        public static bool CheckIsClassType(Type PropType)
        {
            return (PropType.IsClass && PropType != StringType);
        }
        public static void SetInstanceByXElement<T>(T Instance, string XelementText) where T : class , new() 
        {
            if (string.IsNullOrEmpty(XelementText)) {
                throw new ArgumentNullException("XML字符串不能为空");
            }
            try
            {
                XElement xelement = XElement.Parse(XelementText);
                SetInstanceByXElement<T>(Instance, xelement);
            }
            catch (Exception err)
            {
                var msg = err.Message;
                throw err;
            }
        }
        /// <summary>
        /// 通过对应的XML元素设置对应的类型实例
        /// </summary>
        /// <typeparam name="T">泛型参数</typeparam>
        /// <param name="Instance">泛型实例</param>
        /// <param name="Xelement">对应泛型参数类型的XML元素</param>
        public static void SetInstanceByXElement<T>(T Instance, XElement Xelement) where T : class , new()
        {
            if (Instance == null || Xelement == null)
                throw new NullReferenceException("参数 Instance， Xelement都不能为  Null");
            var Propertys = Instance.GetType().GetProperties();
            //这里把Shipment 下的属性分为两种，Collection属性和普通属性，普通属性里的Collection 如  DataContext->DataSourceCollection,不算Collection属性
            foreach (var Prop in Propertys)
            {
                //if (Prop.PropertyType == typeof(string) || !Prop.Name.Contains("Collection"))
                if (CheckIsCollection(Prop.PropertyType))
                {
                    var collectionType = Prop.PropertyType;
                    var collectionInstance = CreateInstance(collectionType);
                    var CollectionElement = Xelement.Element(Prop.Name);
                    if (CollectionElement != null)
                        SetCollectionAttr(collectionInstance, CollectionElement, Prop);
                    Prop.SetValue(Instance, collectionInstance, null);
                }
                else
                {
                    //因为下一步会 Xelement.Element(Prop.Name)元素，如果存在这个元素，就不进入了
                    if (Xelement.Element(Prop.Name) != null)
                        SetShipmentSimpleAttr(Instance, Xelement, Prop);
                }
            }
        }

        public static void SetShipmentSimpleAttr<T>(T Target, XElement TargetElement, PropertyInfo Prop) where T : class,new()
        {
            if (CheckIsClassType(Prop.PropertyType))
            {
                var classType = Prop.PropertyType;//当前属性的 类类型
                var classProps = classType.GetProperties();
                var instance = CreateInstance(classType);
                var PropElement = TargetElement.Element(classType.Name);
                if (PropElement != null)
                    SetNotCollectionElement(instance, PropElement, classProps);
                Prop.SetValue(Target, instance, null);
            }
            else
            {
                //var value = TargetElement.Element(Prop.Name).Value;
                var value = GetValueFromElement(TargetElement, Prop.Name);
                //if(!string.IsNullOrEmpty(value))属性的值为Null 之后，序列化的时候就不会生成该节点
                Prop.SetValue(Target, value);
            }
            //return Target;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listObj">
        ///     Collectin属性的对象,数据类型为一个List<T> 
        /// </param>
        /// <param name="cElement">
        ///      Collectin属性的对应的节点
        /// </param>
        /// <param name="classProps"></param>
        public static void SetCollectionAttr(dynamic listObj, XElement CollectionElement, PropertyInfo Prop)
        {
            //此时的Prop为 XXXCollection下的list<T>属性， obj 为XXXCollection属性的 对象
            
                //if (Prop.PropertyType.IsGenericType && Array.IndexOf(Prop.PropertyType.GetInterfaces(), typeof(IEnumerable)) > -1)
            var collectionType = Prop.PropertyType;
            if (CheckIsCollection(collectionType))
                {
                    //先生成一个List<T>的实例
                    var listType = collectionType;//eg：List<OrganizationAddress>
                    //var listInstance = CreateInstance(listType);//eg：list = new List<OrganizationAddress()
                    //获取List<T>中的泛型类型T
                    var innerType = listType.GetGenericArguments()[0];//eg:OrganizationAddress
                    var innerProps = innerType.GetProperties();
                    if (innerType.Equals(typeof(string)))
                    {
                        var listInCollection = CollectionElement.Elements();
                        foreach (var cElement in listInCollection)
                        {
                            object obj = cElement.Value;
                            listObj.Add(obj.ToString());
                        }
                    }
                    else
                    {
                        var listInCollection = CollectionElement.Elements(innerType.Name);
                        foreach (var cElement in listInCollection)
                        {

                            var innerInstance = CreateInstance(innerType);//eg : organObj = new OrganizationAddress()
                            foreach (var innerProp in innerProps)
                            {
                                //如果当前属性不为Collection,则提取子节点值，否则，再次递归循环

                                if (CheckIsCollection(innerProp.PropertyType))
                                {
                                    //当前属性为Collection属性
                                    var innerCollectionType = innerProp.PropertyType; //获取Collection属性的Type, 
                                    var innerCollectionProps = innerCollectionType.GetProperties();//获取XXXCollection属性列表
                                    var innerColletionInstance = CreateInstance(innerCollectionType);//生成当前Collection对象,eg:RegistrationNumberCollection
                                    var subCollectionElement = cElement.Element(innerProp.Name);
                                    if (subCollectionElement != null)
                                        SetCollectionAttr(innerColletionInstance, subCollectionElement, innerProp);
                                    innerProp.SetValue(innerInstance, innerColletionInstance, null);// 设置当前属性下的 Colletion属性
                                }
                                else
                                {
                                    SetNotCollectionElement(innerInstance, cElement, innerProps);
                                }
                            }
                            listObj.Add(innerInstance);//把当前对象 添加到列表对象
                        }
                    }
                }
            
        }
        public static string GetVarName(System.Linq.Expressions.Expression<Func<string, string>> exp)
        {
            return ((System.Linq.Expressions.MemberExpression)exp.Body).Member.Name;
        }  
        /// <summary>
        /// 设置非Collection的属性
        /// </summary>
        /// <param name="obj">
        ///     非Collection属性的实例,eg:Name
        /// </param>
        /// <param name="cElement">
        ///     与当前属性对应的节点，eg:<Name></Name>
        /// </param>
        /// <param name="classProps">
        ///     当前属性的列表
        /// </param>
        /// <returns></returns>
        public static void SetNotCollectionElement(dynamic obj, XElement cElement, PropertyInfo[] classProps)
        {
            //cElement = child.Element(prop.Name);//此类对应的元素

            foreach (var cprop in classProps)
            {
                var currentType = cprop.PropertyType;
                if (CheckIsCollection(currentType))
                {
                    //若当前属性名称带有Collection ,则为一个列表属性，类型为 List<T>
                    var classType = currentType;
                    var instance = CreateInstance(classType);//生成List<T> 对象
                    var collectionElement = cElement.Element(cprop.Name);
                    if (collectionElement != null)
                        SetCollectionAttr(instance, collectionElement, cprop);
                    cprop.SetValue(obj, instance, null);
                }
                else
                {
                    //if (cprop.PropertyType.IsClass && cprop.PropertyType != typeof(string))
                    if (CheckIsClassType(currentType))
                    {
                        ///若不存在此子元素，跳过当前循环
                        var cElementChild = cElement.Element(cprop.Name);
                        if (cElementChild == null)
                            continue;
                        var cPropType = currentType;
                        var cPropObj = CreateInstance(cPropType);
                        var cPropInfos = cPropType.GetProperties();
                        foreach (var info in cPropInfos)
                        {
                            var infoElement = cElementChild.Element(info.Name);
                            if (infoElement != null)
                            {
                                //if (info.PropertyType.IsClass && info.PropertyType.Name != "String")
                                var infoClass = info.PropertyType;
                                if (CheckIsClassType(infoClass))
                                {
                                    var infoProps = infoClass.GetProperties();
                                    var infoInstance = CreateInstance(infoClass);
                                    //if (infoClass.Name.Contains("Collection"))

                                    if (CheckIsCollection(infoClass))
                                    {
                                        SetCollectionAttr(infoInstance, infoElement, info);
                                    }
                                    else
                                    {
                                        SetNotCollectionElement(infoInstance, infoElement, infoProps);
                                    }

                                    info.SetValue(cPropObj, infoInstance, null);
                                }
                                else
                                {
                                    //var value = infoElement.Value;
                                    var value = GetValueFromElement(infoElement);
                                    //if (!string.IsNullOrEmpty(value))
                                    info.SetValue(cPropObj, value, null);
                                }
                            }
                        }
                        cprop.SetValue(obj, cPropObj, null);
                    }
                    else
                    {
                        //cElement.Element(cprop.Name).Value;
                        var value = GetValueFromElement(cElement, cprop.Name);
                        //if (!string.IsNullOrEmpty(value))
                        cprop.SetValue(obj, value, null);
                    }
                }
            }

        }
        
        /// <summary>
        /// 根据传入的Type类型创建相应的实例对象
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static dynamic CreateInstance(Type type, string assembleName = "", string typeName = "", object[] args= null)
        {
            //string path = fullName + "," + assemblyName;//命名空间.类型名,程序集
            
            dynamic obj;
            if (type.IsPrimitive || type.Equals(typeof(string))) 
            {
                return new object();
            }
            if (assembleName.Length > 0 && typeName.Length > 0)
            {
                obj = Activator.CreateInstance(assembleName, "" + typeName);
                return obj;
            }
            if (args != null)
                obj = Activator.CreateInstance(type, true, args);//根据类型创建实例
            else
                obj = Activator.CreateInstance(type, true);
            return obj;//类型转换并返回
        }
    }
}
