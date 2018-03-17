using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlRepository.ShipmentFolder
{
    public class RateLine
    {
        public string ChargeableWeight { get; set; }

        public string CommodityItem { get; set; }

        public string GoodsDescription { get; set; }

        public string GrossWeight { get; set; }

        public string LineNumber { get; set; }

        public NatureAndQtyOfGoodsType NatureAndQtyOfGoodsType { get; set; }

        public string NoOfPiecesOrRCP { get; set; }

        public string RateChargeOrDiscount { get; set; }

        public RateClass RateClass { get; set; }

        public string TotalCharge { get; set; }

        public WeightUnit WeightUnit { get; set; }

    }
}
