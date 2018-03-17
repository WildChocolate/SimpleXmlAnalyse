using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlRepository.BookingFolder
{
    public class OrderLine
    {
        public string AdditionalInformation { get; set; }

        public string AdditionalTerms { get; set; }

        public string CommercialInvoiceNumber { get; set; }

        public string ConfirmationNumber { get; set; }

        public string ContainerNumber { get; set; }

        public string ContainerPackingOrder { get; set; }

        public string CustomsData { get; set; }

        public string ExpectedQuantity { get; set; }

        public string ExtendedLinePrice { get; set; }

        public IncoTerm IncoTerm { get; set; }

        public string InnerPacksQty { get; set; }

        public InnerPacksQtyUnit InnerPacksQtyUnit { get; set; }

        public string LineNumber { get; set; }

        public string LineSplitNumber { get; set; }

        public string Link { get; set; }

        public string OrderedQty { get; set; }

        public OrderedQtyUnit OrderedQtyUnit { get; set; }

        public string PackageHeight { get; set; }

        public string PackageLength { get; set; }

        public PackageLengthUnit PackageLengthUnit { get; set; }

        public string PackageQty { get; set; }

        public PackageQtyUnit PackageQtyUnit { get; set; }

        public string PackageWidth { get; set; }

        public string PartAttribute1 { get; set; }

        public string PartAttribute2 { get; set; }

        public string PartAttribute3 { get; set; }

        public Product Product { get; set; }

        public string QuantityMet { get; set; }

        public string RequiredExWorks { get; set; }

        public string RequiredInStore { get; set; }

        public string SpecialInstructions { get; set; }

        public Status Status { get; set; }

        public string SubLineNumber { get; set; }

        public string SupplierConfirmedAcceptance { get; set; }

        public string UnitPriceRecommended { get; set; }

        public string Volume { get; set; }

        public VolumeUnit VolumeUnit { get; set; }

        public string Weight { get; set; }

        public WeightUnit WeightUnit { get; set; }

    }
}
