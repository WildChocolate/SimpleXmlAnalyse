using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlRepository.ConsolFolder
{
    public class TransportLeg
    {
        public PortOfDischarge PortOfDischarge { get; set; }

        public PortOfLoading PortOfLoading { get; set; }

        public string LegOrder { get; set; }

        public string ActualArrival { get; set; }

        public string ActualDeparture { get; set; }

        public Carrier Carrier { get; set; }

        public string CarrierBookingReference { get; set; }

        public CarrierServiceLevel CarrierServiceLevel { get; set; }

        public string EstimatedArrival { get; set; }

        public string EstimatedDeparture { get; set; }

        public string LegNotes { get; set; }

        public string LegType { get; set; }

        public string TransportMode { get; set; }

        public string VesselLloydsIMO { get; set; }

        public string VesselName { get; set; }

        public string VoyageFlightNo { get; set; }

    }

}
