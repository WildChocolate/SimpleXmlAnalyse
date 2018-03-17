using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlRepository.ConsolFolder
{
    public class Order
    {
        public string OrderNumber { get; set; }

        public string ClientReference { get; set; }

        public string OrderNumberSplit { get; set; }

        public Status Status { get; set; }

    }
}
