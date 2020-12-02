using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceManager.Services.Common.Models.ViewModels.Report
{
    public class ReportUpdateModel
    {
        [JsonProperty("amountSpent")]
        public decimal AmountSpent { get; set; }

        [JsonProperty("descriptionsOfExpenses")]
        public string DescriptionsOfExpenses { get; set; }

        [JsonProperty("reportId")]
        public int ReportId { get; set; }
    }
}
