using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlRepository.ShipmentFolder
{
    public class AdditionalService
    {
        public ServiceCode ServiceCode { get; set; }

        public string Booked { get; set; }

        public string Completed { get; set; }

        public Contractor Contractor { get; set; }

        public string Duration { get; set; }

        public string References { get; set; }

        public string ServiceCount { get; set; }

        public string ServiceNote { get; set; }

    }
}
