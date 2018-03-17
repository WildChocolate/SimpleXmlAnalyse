using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlRepository.ShipmentFolder
{
    public class Shipper
    {
        public string AccountCode { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string ContactDetail { get; set; }

        public ContactType ContactType { get; set; }

        public Country Country { get; set; }

        public string IsAddressOverriddenForPaperWaybill { get; set; }

        public string Name { get; set; }

        public string PaperOverrideLine1 { get; set; }

        public string PaperOverrideLine2 { get; set; }

        public string PaperOverrideLine3 { get; set; }

        public string PaperOverrideLine4 { get; set; }

        public string PaperOverrideLine5 { get; set; }

        public string PostCode { get; set; }

        public string State { get; set; }

        

    }
}
