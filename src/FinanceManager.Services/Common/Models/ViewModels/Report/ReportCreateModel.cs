using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceManager.Services.Common.Models.ViewModels.Report
{
    public class ReportCreateModel
    {
        [JsonProperty("amountSpent")]
        [Required(ErrorMessage = "Введите сумму траты")]
        [Range(1, int.MaxValue)]
        public string AmountSpent { get; set; }

        [JsonProperty("descriptionsOfExpenses")]
        [Required(ErrorMessage = "Введите описания траты")]
        [StringLength(300, MinimumLength = 3, ErrorMessage = "Описания траты может быть от 3 до 300 символов")]
        public string DescriptionsOfExpenses { get; set; }
    }
}
