using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlRepository.ConsolFolder
{
    
        public class ConsolCostLine
        {
            public string ApportionmentMethod { get; set; }

            public string ApportionToSubShipments { get; set; }

            public ChargeCode ChargeCode { get; set; }

            public ChargeCodeGroup ChargeCodeGroup { get; set; }

            public string CostAPInvoiceNumber { get; set; }

            public string CostDueDate { get; set; }

            public string CostExchangeRate { get; set; }

            public string CostInvoiceDate { get; set; }

            public string CostIsPosted { get; set; }

            public string CostLocalAmount { get; set; }

            public string CostOSAmount { get; set; }

            public CostOSCurrency CostOSCurrency { get; set; }

            public string CostOSGSTVATAmount { get; set; }

            public Creditor Creditor { get; set; }

            public string IncludeOnCollectInvoice { get; set; }

            public string PrepaidCollectFilter { get; set; }

        }

    
}
