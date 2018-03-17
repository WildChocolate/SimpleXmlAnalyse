using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlRepository.BookingFolder
{
    public class PackedItem
    {
        public string OrderLineLink { get; set; }

        public string PackedQuantity { get; set; }

        public Product Product { get; set; }

        public UnitOfQuantity UnitOfQuantity { get; set; }

    }
}
