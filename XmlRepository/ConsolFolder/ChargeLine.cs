using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlRepository.ConsolFolder
{
    public class ChargeLine
    {
        public Branch Branch { get; set; }

        public ChargeCode ChargeCode { get; set; }

        public ChargeCodeGroup ChargeCodeGroup { get; set; }

        public string CostAPInvoiceNumber { get; set; }

        public CostApportionmentConsolNumber CostApportionmentConsolNumber { get; set; }

        public string CostDueDate { get; set; }

        public string CostInvoiceDate { get; set; }

        public string CostIsPosted { get; set; }

        public string CostLocalAmount { get; set; }

        public string CostOSAmount { get; set; }

        public CostOSCurrency CostOSCurrency { get; set; }

        public string CostOSGSTVATAmount { get; set; }

        public Creditor Creditor { get; set; }

        public Debtor Debtor { get; set; }

        public Department Department { get; set; }

        public string Description { get; set; }

        public string DisplaySequence { get; set; }

        public string SellInvoiceType { get; set; }

        public string SellIsPosted { get; set; }

        public string SellLocalAmount { get; set; }

        public string SellOSAmount { get; set; }

        public SellOSCurrency SellOSCurrency { get; set; }

        public string SellOSGSTVATAmount { get; set; }

        public string SellPostedTransactionNumber { get; set; }

        public string SellPostedTransactionType { get; set; }

    }
}
