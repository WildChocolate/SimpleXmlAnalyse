using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlRepository.ShipmentFolder
{
    public class Test
    {
        protected string val;
        public static implicit operator Test(string value){
            return value;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
