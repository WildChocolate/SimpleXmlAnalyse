using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlRepository.BookingFolder
{
    public class RelatedShipment
    {
        public DataContext DataContext { get; set; }

        public string AdditionalTerms { get; set; }

        public string BookingConfirmationReference { get; set; }

        public CommercialInfo CommercialInfo { get; set; }

        public ContainerMode ContainerMode { get; set; }

        public string FirstBuyerContact { get; set; }

        public string FreightRate { get; set; }

        public FreightRateCurrency FreightRateCurrency { get; set; }

        public string GoodsDescription { get; set; }

        public string OuterPacks { get; set; }

        public OuterPacksPackageType OuterPacksPackageType { get; set; }

        public string SecondBuyerContact { get; set; }

        public ServiceLevel ServiceLevel { get; set; }

        public ShipmentIncoTerm ShipmentIncoTerm { get; set; }

        public string TotalVolume { get; set; }

        public TotalVolumeUnit TotalVolumeUnit { get; set; }

        public string TotalWeight { get; set; }

        public TotalWeightUnit TotalWeightUnit { get; set; }

        public TransportMode TransportMode { get; set; }

        public string WayBillNumber { get; set; }

        public WayBillType WayBillType { get; set; }

        public LocalProcessing LocalProcessing { get; set; }

        public Order Order { get; set; }

        public List<AdditionalBill> AdditionalBillCollection { get; set; }

        public List<Date> DateCollection { get; set; }

        public List<Milestone> MilestoneCollection { get; set; }

        public List<OrganizationAddress> OrganizationAddressCollection { get; set; }

    }
}
