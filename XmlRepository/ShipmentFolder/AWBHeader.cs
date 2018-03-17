using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlRepository.ShipmentFolder
{
    public class AWBHeader
    {
        public string AgentAccountNo { get; set; }

        public string AgentIATACode { get; set; }

        public string AgentName { get; set; }

        public string AgentPlace { get; set; }

        public string AirportOfDepartureAndRequestRouteText { get; set; }

        public string AirportOfDestinationCode { get; set; }

        public string AirportOfDestinationText { get; set; }

        public AlsoNotify AlsoNotify { get; set; }

        public string AmountOfInsurance { get; set; }

        public string AsAgreedOn1stAWBSet { get; set; }

        public string AsAgreedOn2ndAWBSet { get; set; }

        public string AsAgreedTypeOn1stAWBSet { get; set; }

        public string AsAgreedTypeOn2ndAWBSet { get; set; }

        public string AWBIssueDate { get; set; }

        public string AWBIssuePlace { get; set; }

        public string AWBIssuerApprovedExporterNumber { get; set; }

        public string AWBIssuerExtraInfo { get; set; }

        public string AWBIssuerSignature { get; set; }

        public string AWBNumber { get; set; }

        public AWBType AWBType { get; set; }

        public CargoSecurityDeclaration CargoSecurityDeclaration { get; set; }

        public ChargesPayment ChargesPayment { get; set; }

        public Consignee Consignee { get; set; }

        public Currency Currency { get; set; }

        public string ForwardingAgentReference { get; set; }

        public string HandlingInformation { get; set; }

        public string IssuedByAddress1 { get; set; }

        public string IssuedByAddress2 { get; set; }

        public string IssuedByName { get; set; }

        public string NetRateCode { get; set; }

        public string OptionalShippingInformation1 { get; set; }

        public string OptionalShippingInformation2 { get; set; }

        public string OriginCode { get; set; }

        public OtherChargesPayment OtherChargesPayment { get; set; }

        public string Requested1stCarrier { get; set; }

        public string Requested1stFlight { get; set; }

        public string Requested1stFlightDate { get; set; }

        public string Requested2ndCarrier { get; set; }

        public string Requested2ndFlight { get; set; }

        public string Requested2ndFlightDate { get; set; }

        public string Routing1stBy { get; set; }

        public string Routing1stTo { get; set; }

        public string Routing2ndBy { get; set; }

        public string Routing2ndTo { get; set; }

        public string Routing3rdBy { get; set; }

        public string Routing3rdTo { get; set; }

        public Shipper Shipper { get; set; }

        public string ShipperExtraInfoLine1 { get; set; }

        public string ShipperExtraInfoLine2 { get; set; }

        public string ShippersLoadAndCount { get; set; }

        public string ShippersSignature { get; set; }

        public string SpecialHandlingCode { get; set; }

        public string TotalTaxesCollect { get; set; }

        public string TotalTaxesPrepaid { get; set; }

        public string TotalValuationCollect { get; set; }

        public string TotalValuationPrepaid { get; set; }

        public string ValueForCarriage { get; set; }

        public string ValueForCustoms { get; set; }

        public WeightChargesPayment WeightChargesPayment { get; set; }

        public List<RateLine> RateLineCollection { get; set; }

    }
}
