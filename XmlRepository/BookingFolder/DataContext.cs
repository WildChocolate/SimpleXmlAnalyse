﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlRepository.BookingFolder
{
    public class DataContext
    {
        public List<DataSource> DataSourceCollection { get; set; }

        public Company Company { get; set; }

        public string DataProvider { get; set; }

        public string EnterpriseID { get; set; }

        public EventBranch EventBranch { get; set; }

        public EventDepartment EventDepartment { get; set; }

        public EventType EventType { get; set; }

        public EventUser EventUser { get; set; }

        public string ServerID { get; set; }

        public string TriggerCount { get; set; }

        public string TriggerDate { get; set; }

        public string TriggerDescription { get; set; }

        public string TriggerType { get; set; }

        public List<RecipientRole> RecipientRoleCollection { get; set; }

    }
}
