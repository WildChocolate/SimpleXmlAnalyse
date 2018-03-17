using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlRepository.ShipmentFolder
{
    public class PackedItem
    {
        public string CommercialInvoiceLineLink { get; set; }

        public string Description { get; set; }
        public string GoodsValue { get; set; }
        public string GrossWeight { get; set; }
        public UnitOfWeight GrossWeightUnit { get; set; }
        public string NetWeight { get; set; }
        public UnitOfWeight NetWeightUnit { get; set; }
        public string OrderLineLink { get; set; }
        public string PackedQuantity { get; set; }
        public Product Product { get; set; }
        public PackageType  UnitOfQuantity { get; set; }
    }
}
