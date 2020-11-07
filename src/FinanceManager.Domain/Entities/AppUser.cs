using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

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
