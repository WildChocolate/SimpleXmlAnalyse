using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlRepository.BookingFolder
{
    public class RegistrationNumber
    {
        public SType Type { get; set; }
        public CountryOfIssue CountryOfIssue { get; set; }
        public string Value { get; set; }
    }
}
