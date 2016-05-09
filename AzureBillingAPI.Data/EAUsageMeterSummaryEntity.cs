﻿using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureBillingAPI.Data
{
    public class EAUsageMeterSummaryEntity : TableEntity
    {
        public EAUsageMeterSummaryEntity() { }

        public string MeterId { get; set; }

        public string MeterName { get; set; }
        public string MeterCategory { get; set; }
        public string RunId { get; set; }
        public double Amount { get; set; }
    }
}
