using ReadXmlFromCargowiseForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadXmlFromCargowiseConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, string>();
            dict.Add("a", "34324");
            dict.Add("b", "34324");
            dict.Add("c", "34324");

            Console.WriteLine(string.Join(",",new string[]{"2","23432","234"}));
            
            Console.Read();
        }
    }
}
