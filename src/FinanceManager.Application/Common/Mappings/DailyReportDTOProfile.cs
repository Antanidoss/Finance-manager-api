using AutoMapper;
using FinanceManager.Application.Common.DTO;
using FinanceManager.Domain.Entities;
using System.Linq;

namespace FinanceManager.Application.Common.Mappings
{
    public class DailyReportDTOProfile : Profile
    {
        public DailyReportDTOProfile()
        {
            CreateMap<DailyReport, DailyReportDTO>()
                .ForMember(dto => dto.TimeOfCreate, conf => conf.MapFrom(o => o.TimeOfCreate.ToShortDateString()))
                .ForMember(dto => dto.Reports, conf => conf.MapFrom(o => o.Reports.ToList()));
        }
    }
}
