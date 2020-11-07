using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceManeger.Api.Models.CreateModel
{
    public class ReportCreateModel
    {
        [JsonProperty("amountSpent")]
        public decimal AmountSpent { get; }

        [JsonProperty("descriptionsOfExpenses")]
        public string DescriptionsOfExpenses { get; }

        [JsonProperty("userId")]
        public string AppUserId { get; }
    }
}
