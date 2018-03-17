# SimpleXmlAnalyse


###### 根据类定义自动解析XML文件，提取对应节点值到对象。（只适合解析普通的XML，既不带命名空间的那种节点）

---
  程序为C#窗体应用程序，使用C# 反射完对文件内容的提取，既然说到反射，那就肯定要说要类了。  
  假设有以下一段xml 文本 eg:


      <People>
        <Name>
          xu
        </name>
        <height>
          1.86
        </height>
        <Age>
          18
        </Age>
      </People>
      
  
  则相应的类定义应该为：
  
      
      public class People
      {
        public string Name {get; set;}
        public string height{get; set;}
        public string Age{ get; set;}
      }
  
  __至于为什么 都要设置要把与值相关的属性数据 类型的设置为string, 因为从XML中取到的所有值都为string类型， 这样方便设置，还有一些可以取出为空的，
  如果设置为值类型，必须要转换，可能还有错误！！！
  上面是普通节点的定义，如果遇到集合类型的节点呢？
  
  
eg:

    <Body>
      <RegistrationNumberCollection>
        <RegistrationNumber>
          <Code>
            007
          </Code>
          <Name>
            test
          </Name>
        </RegistrationNumber>
        <RegistrationNumber>
          ...
      </RegistrationNumberCollection>
    </Body>




  __那么你要这么定义类:
  
      public class Body
      {
        //也不一定要用List<T> 类型，只要是任何继承了  IList接口任何的类型都可以
        public List<RegistrationNumber> RegistrationNumberCollection{get; set;}
      }
      
      public class RegistrationNumber
      {
        public string Code {get; set;}
        public string Name {get; set;}
      }
      
 ### 也就是说，类的定义与节点相关，如果是复杂的节点，必须对应定义相应的类型， 而存值的节点，则定义为String 类型, 而集合类型节点，下面是多个相同的类集合，必须使用实现了IEnumerable和ICollection<>接口的类型，因为后面要用到 这两个IEnumerable接口作是否集合的判断，和动态添加时候要用到 ICollection<>的 Add方法
所以使用程序时只要，传入相应的类与对应的节点之间的内容，就可以实现取自动取值，
比如要设置 Body类的值， 相应的就要传入 <Body>......</Body>
 
