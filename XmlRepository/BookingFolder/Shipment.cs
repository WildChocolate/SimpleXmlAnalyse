using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlRepository.BookingFolder
{
    public class Shipment
    {
        public DataContext DataContext { get; set; }

        public string ActualChargeable { get; set; }

        public string AdditionalTerms { get; set; }

        public AWBServiceLevel AWBServiceLevel { get; set; }

        public string BookingConfirmationReference { get; set; }

        public string CFSReference { get; set; }

        public string ContainerCount { get; set; }

        public ContainerMode ContainerMode { get; set; }

        public string FreightRate { get; set; }

        public FreightRateCurrency FreightRateCurrency { get; set; }

        public string GoodsDescription { get; set; }

        public string GoodsValue { get; set; }

        public GoodsValueCurrency GoodsValueCurrency { get; set; }

        public HBLAWBChargesDisplay HBLAWBChargesDisplay { get; set; }

        public string InsuranceValue { get; set; }

        public InsuranceValueCurrency InsuranceValueCurrency { get; set; }

        public string InterimReceiptNumber { get; set; }

        public string IsCancelled { get; set; }

        public string IsDirectBooking { get; set; }

        public string IsForwardRegistered { get; set; }

        public string OuterPacks { get; set; }

        public OuterPacksPackageType OuterPacksPackageType { get; set; }

        public string PackingOrder { get; set; }

        public PortOfDestination PortOfDestination { get; set; }

        public PortOfDischarge PortOfDischarge { get; set; }

        public PortOfLoading PortOfLoading { get; set; }

        public PortOfOrigin PortOfOrigin { get; set; }

        public ReleaseType ReleaseType { get; set; }

        public ServiceLevel ServiceLevel { get; set; }

        public ShipmentIncoTerm ShipmentIncoTerm { get; set; }

        public ShippedOnBoard ShippedOnBoard { get; set; }

        public string TotalVolume { get; set; }

        public TotalVolumeUnit TotalVolumeUnit { get; set; }

        public string TotalWeight { get; set; }

        public TotalWeightUnit TotalWeightUnit { get; set; }

        public TransportMode TransportMode { get; set; }

        public string WayBillNumber { get; set; }

        public WayBillType WayBillType { get; set; }

        public LocalProcessing LocalProcessing { get; set; }

        public List<CustomizedField> CustomizedFieldCollection { get; set; }

        public List<Date> DateCollection { get; set; }

        public List<OrganizationAddress> OrganizationAddressCollection { get; set; }

        public List<PackingLine> PackingLineCollection { get; set; }

        public List<RelatedShipment> RelatedShipmentCollection { get; set; }

    }
}
