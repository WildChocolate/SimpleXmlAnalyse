using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlRepository.BookingFolder
{
    public class Order
    {
        public string OrderNumber { get; set; }

        public string ClientReference { get; set; }

        public string OrderNumberSplit { get; set; }

        public Status Status { get; set; }

        public List<OrderLine> OrderLineCollection { get; set; }

    }
}
