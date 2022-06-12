using AutoMapper;
using FinanceManager.Application.Common.DTO;
using FinanceManager.Domain.Entities;

namespace FinanceManager.Application.Common.Mappings
{
    public class ReportDTOProfile : Profile
    {
        public ReportDTOProfile()
        {
            CreateMap<Report, ReportDTO>()
                .ForMember(dto => dto.TimeOfCreate, conf => conf.MapFrom(o => o.TimeOfCreate.ToShortTimeString()));
        }
    }
}
