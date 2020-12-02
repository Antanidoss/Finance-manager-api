using AutoMapper;
using FinanceManager.Application.Common.DTO;
using FinanceManager.Services.Common.Models.ViewModels.DailyReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinanceManager.Services.Common.Mappings
{
    public class DailyReportViewModelProfile : Profile
    {
        public DailyReportViewModelProfile()
        {
            CreateMap<DailyReportDTO, DailyReportViewModel>()
                .ForMember(vm => vm.Reports, conf => conf.MapFrom(dto => dto.Reports.ToArray()));
        }
    }
}
