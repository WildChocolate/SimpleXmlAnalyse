using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlRepository.BookingFolder
{
    public class OrganizationAddress
    {
        public string AddressType { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string AddressOverride { get; set; }

        public string AddressShortCode { get; set; }

        public string City { get; set; }

        public string CompanyName { get; set; }

        public Country Country { get; set; }

        public string Email { get; set; }

        public string Fax { get; set; }

        public string OrganizationCode { get; set; }

        public string Phone { get; set; }

        public Port Port { get; set; }

        public string Postcode { get; set; }

        public ScreeningStatus ScreeningStatus { get; set; }

        public string State { get; set; }


        public List<RegistrationNumber> RegistrationNumberCollection { get; set; }
    }
}
