using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlRepository.ConsolFolder
{
    public class SubShipment
    {
        public DataContext DataContext { get; set; }

        public string ActualChargeable { get; set; }

        public string AdditionalTerms { get; set; }

        public string BookingConfirmationReference { get; set; }

        public string CartageWaybillNumber { get; set; }

        public string CFSReference { get; set; }

        public string ContainerCount { get; set; }

        public ContainerMode ContainerMode { get; set; }

        public string DocumentedChargeable { get; set; }

        public string DocumentedVolume { get; set; }

        public string DocumentedWeight { get; set; }

        public string FreightRate { get; set; }

        public FreightRateCurrency FreightRateCurrency { get; set; }

        public string GoodsDescription { get; set; }

        public string GoodsValue { get; set; }

        public GoodsValueCurrency GoodsValueCurrency { get; set; }

        public HBLAWBChargesDisplay HBLAWBChargesDisplay { get; set; }

        public string HBLContainerPackModeOverride { get; set; }

        public string InsuranceValue { get; set; }

        public InsuranceValueCurrency InsuranceValueCurrency { get; set; }

        public string InterimReceiptNumber { get; set; }

        public string IsBooking { get; set; }

        public string IsCancelled { get; set; }

        public string IsCFSRegistered { get; set; }

        public string IsDirectBooking { get; set; }

        public string IsForwardRegistered { get; set; }

        public string IsNeutralMaster { get; set; }

        public string IsShipping { get; set; }

        public string IsSplitShipment { get; set; }
        public JobCosting JobCosting { get; set; }

        public string LloydsIMO { get; set; }

        public string ManifestedChargeable { get; set; }

        public string ManifestedVolume { get; set; }

        public string ManifestedWeight { get; set; }

        public string NoCopyBills { get; set; }

        public string NoOriginalBills { get; set; }

        public string OuterPacks { get; set; }

        public OuterPacksPackageType OuterPacksPackageType { get; set; }

        public string PackingOrder { get; set; }

        public PortOfDestination PortOfDestination { get; set; }

        public PortOfDischarge PortOfDischarge { get; set; }

        public PortOfFirstArrival PortOfFirstArrival { get; set; }

        public PortOfLoading PortOfLoading { get; set; }

        public PortOfOrigin PortOfOrigin { get; set; }

        public ReleaseType ReleaseType { get; set; }

        public ScreeningStatus ScreeningStatus { get; set; }

        public ServiceLevel ServiceLevel { get; set; }

        public ShipmentIncoTerm ShipmentIncoTerm { get; set; }

        public ShipmentType ShipmentType { get; set; }

        public ShippedOnBoard ShippedOnBoard { get; set; }

        public string ShipperCODAmount { get; set; }

        public ShipperCODPayMethod ShipperCODPayMethod { get; set; }

        public string TotalNoOfPacks { get; set; }

        public TotalNoOfPacksPackageType TotalNoOfPacksPackageType { get; set; }

        public string TotalVolume { get; set; }

        public TotalVolumeUnit TotalVolumeUnit { get; set; }

        public string TotalWeight { get; set; }

        public TotalWeightUnit TotalWeightUnit { get; set; }

        public string TranshipToOtherCFS { get; set; }

        public TransportMode TransportMode { get; set; }

        public string VesselName { get; set; }

        public string VoyageFlightNo { get; set; }

        public string WarehouseLocation { get; set; }

        public string WayBillNumber { get; set; }

        public WayBillType WayBillType { get; set; }

        public LocalProcessing LocalProcessing { get; set; }

        public List<CustomizedField> CustomizedFieldCollection { get; set; }

        public List<Date> DateCollection { get; set; }

        public List<Milestone> MilestoneCollection { get; set; }

        public List<Note> NoteCollection { get; set; }

        public List<OrganizationAddress> OrganizationAddressCollection { get; set; }

        public List<PackingLine> PackingLineCollection { get; set; }

        public List<RelatedShipment> RelatedShipmentCollection { get; set; } 
    }

}
