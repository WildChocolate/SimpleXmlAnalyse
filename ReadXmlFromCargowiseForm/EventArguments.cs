using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using XmlRepository;

namespace ReadXmlFromCargowiseForm
{
    /// <summary>
    /// 文件提取完成和保存文件完成的事件，如果需要更改处理程序传递的信息，则修改相应的事件参数定义
    /// </summary>
    public class ExtractCompletedEventArgs :EventArgs
    {
        public ExtractCompletedEventArgs(BLBasicInfo basicInfo)
        {
            BasicInfo = basicInfo;
        }
        public BLBasicInfo BasicInfo
        {
            get;
            private set;
        }
    }
    public class SaveFileCompletedEventArgs:EventArgs
    {
        public SaveFileCompletedEventArgs(string filePath)
        {
            FilePath = filePath;
        }
        public string FilePath
        {
            get;
            private set;
        }
    }
}
