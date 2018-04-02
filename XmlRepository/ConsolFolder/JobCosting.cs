using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlRepository.ConsolFolder
{
    public class JobCosting
    {
        public string AccrualNotRecognized { get; set; }

        public string AccrualRecognized { get; set; }

        public string AgentRevenue { get; set; }

        public Branch Branch { get; set; }

        public Currency Currency { get; set; }

        public Department Department { get; set; }

        public HomeBranch HomeBranch { get; set; }

        public string LocalClientRevenue { get; set; }

        public OperationsStaff OperationsStaff { get; set; }

        public string OtherDebtorRevenue { get; set; }

        public SalesStaff SalesStaff { get; set; }

        public string TotalAccrual { get; set; }

        public string TotalCost { get; set; }

        public string TotalJobProfit { get; set; }

        public string TotalRevenue { get; set; }

        public string TotalWIP { get; set; }

        public string WIPNotRecognized { get; set; }

        public string WIPRecognized { get; set; }

        public List<ChargeLine> ChargeLineCollection { get; set; }

    }
}
