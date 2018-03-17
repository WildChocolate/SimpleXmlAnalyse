using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlRepository.ConsolFolder
{
    public class PackingLine
    {
        public Commodity Commodity { get; set; }

        public string ContainerLink { get; set; }

        public string ContainerNumber { get; set; }

        public string ContainerPackingOrder { get; set; }

        public CountryOfOrigin CountryOfOrigin { get; set; }

        public string DetailedDescription { get; set; }

        public string EndItemNo { get; set; }

        public string ExportReferenceNumber { get; set; }

        public string GoodsDescription { get; set; }

        public string HarmonisedCode { get; set; }

        public string Height { get; set; }

        public string ImportReferenceNumber { get; set; }

        public string ItemNo { get; set; }

        public string Length { get; set; }

        public LengthUnit LengthUnit { get; set; }

        public string LinePrice { get; set; }

        public string Link { get; set; }

        public string LoadingMeters { get; set; }

        public string MarksAndNos { get; set; }

        public string OutturnComment { get; set; }

        public string OutturnDamagedQty { get; set; }

        public string OutturnedHeight { get; set; }

        public string OutturnedLength { get; set; }

        public string OutturnedVolume { get; set; }

        public string OutturnedWeight { get; set; }

        public string OutturnedWidth { get; set; }

        public string OutturnPillagedQty { get; set; }

        public string OutturnQty { get; set; }

        public string PackQty { get; set; }

        public PackType PackType { get; set; }

        public string ReferenceNumber { get; set; }

        public string Volume { get; set; }

        public VolumeUnit VolumeUnit { get; set; }

        public string Weight { get; set; }

        public WeightUnit WeightUnit { get; set; }

        public string Width { get; set; }

        public List<CustomizedField> CustomizedFieldCollection { get; set; }

        public List<PackedItem> PackedItemCollection { get; set; }

    }

}
