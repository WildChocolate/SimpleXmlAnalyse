using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlRepository.ShipmentFolder
{
    public class AdditionalBill
    {
        public string BillNumber { get; set; }

        public BillType BillType { get; set; }

        public string IssueDate { get; set; }

        public MessageStatus MessageStatus { get; set; }

        public string NoOfPacks { get; set; }

        public PackType PackType { get; set; }

    }

}
