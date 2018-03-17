using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlRepository.ShipmentFolder
{
    public class CargoSecurityDeclaration
    {
        public string AdditionalScreeningMethods { get; set; }

        public AgentApprovalCategory AgentApprovalCategory { get; set; }

        public Country AgentApprovalCountry { get; set; }

        public string AgentApprovalExpiryDate { get; set; }

        public string AgentApprovalNumber { get; set; }

        public string SecurityStatusIssueDate { get; set; }

        public string SecurityStatusIssuedBy { get; set; }

        public string TSASecurityStatement { get; set; }

    }

}
