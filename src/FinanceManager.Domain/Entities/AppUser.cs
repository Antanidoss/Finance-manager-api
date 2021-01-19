using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace FinanceManager.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public virtual IEnumerable<DailyReport> DailyReports { get; set; }
        public AppUser() : base()
        {
            DailyReports = new List<DailyReport>();
        }
    }
}
