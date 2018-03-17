using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using XmlRepository.ShipmentFolder;

namespace XmlRepository.ShipmentFolder
{
    public class RegistrationNumber
    {
        public RegistrationNumber() {
            //Type = new SType();
            //CountryOfIssue = new CountryOfIssue();
        }
        public SType Type { get; set; }
        public CountryOfIssue CountryOfIssue { get; set; }
        public string Value { get; set; }

    }
}
