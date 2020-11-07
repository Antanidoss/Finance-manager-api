using AutoMapper;
using FinanceManager.Application.Common.DTO;
using FinanceManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Application.Common.Mappings
{
    class DailyReportDTOProfile : Profile
    {
        public DailyReportDTOProfile()
        {
            CreateMap<DailyReport, DailyReportDTO>()
                .ForMember(dto => dto.TimeOfCreate, conf => conf.MapFrom(o => o.TimeOfCreate.ToString()));
        }
    }
}
