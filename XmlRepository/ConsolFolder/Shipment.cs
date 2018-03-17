using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlRepository.ConsolFolder
{
    public class Shipment
    {
        public DataContext DataContext { get; set; }

        public string AgentsReference { get; set; }

        public AWBServiceLevel AWBServiceLevel { get; set; }

        public string BookingConfirmationReference { get; set; }

        public string ChargeableRate { get; set; }

        public string ContainerCount { get; set; }

        public ContainerMode ContainerMode { get; set; }

        public string DocumentedChargeable { get; set; }

        public string DocumentedVolume { get; set; }

        public string DocumentedWeight { get; set; }

        public string FreightRate { get; set; }

        public FreightRateCurrency FreightRateCurrency { get; set; }

        public string IsCFSRegistered { get; set; }

        public string IsDirectBooking { get; set; }

        public string IsForwardRegistered { get; set; }

        public string IsNeutralMaster { get; set; }

        public string LloydsIMO { get; set; }

        public string ManifestedChargeable { get; set; }

        public string ManifestedVolume { get; set; }

        public string ManifestedWeight { get; set; }

        public string NoCopyBills { get; set; }

        public string NoOriginalBills { get; set; }

        public string OuterPacks { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public PlaceOfDelivery PlaceOfDelivery { get; set; }

        public PlaceOfIssue PlaceOfIssue { get; set; }

        public PlaceOfReceipt PlaceOfReceipt { get; set; }

        public PortFirstForeign PortFirstForeign { get; set; }

        public PortLastForeign PortLastForeign { get; set; }

        public PortOfDischarge PortOfDischarge { get; set; }

        public PortOfFirstArrival PortOfFirstArrival { get; set; }

        public PortOfLoading PortOfLoading { get; set; }

        public ReleaseType ReleaseType { get; set; }

        public ScreeningStatus ScreeningStatus { get; set; }

        public ShipmentType ShipmentType { get; set; }

        public string TotalNoOfPacks { get; set; }

        public TotalNoOfPacksPackageType TotalNoOfPacksPackageType { get; set; }

        public string TotalPreallocatedChargeable { get; set; }

        public string TotalPreallocatedVolume { get; set; }

        public TotalPreallocatedVolumeUnit TotalPreallocatedVolumeUnit { get; set; }

        public string TotalPreallocatedWeight { get; set; }

        public TotalPreallocatedWeightUnit TotalPreallocatedWeightUnit { get; set; }

        public string TotalVolume { get; set; }

        public TotalVolumeUnit TotalVolumeUnit { get; set; }

        public string TotalWeight { get; set; }

        public TotalWeightUnit TotalWeightUnit { get; set; }

        public TransportMode TransportMode { get; set; }

        public string VesselName { get; set; }

        public string VoyageFlightNo { get; set; }

        public string WayBillNumber { get; set; }

        public WayBillType WayBillType { get; set; }

        public List<Container> ContainerCollection { get; set; }

        public List<CustomizedField> CustomizedFieldCollection { get; set; }

        public List<Date> DateCollection { get; set; }

        public List<Milestone> MilestoneCollection { get; set; }

        public List<OrganizationAddress> OrganizationAddressCollection { get; set; }

        public List<SubShipment> SubShipmentCollection { get; set; }

        public List<TransportLeg> TransportLegCollection { get; set; }

    }
}
