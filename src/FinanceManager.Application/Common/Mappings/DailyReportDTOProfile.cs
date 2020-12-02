using AutoMapper;
using FinanceManager.Application.Common.DTO;
using FinanceManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinanceManager.Application.Common.Mappings
{
    public class DailyReportDTOProfile : Profile
    {
        public DailyReportDTOProfile()
        {
            CreateMap<DailyReport, DailyReportDTO>()
                .ForMember(dto => dto.TimeOfCreate, conf => conf.MapFrom(o => o.TimeOfCreate.ToString()))
                .ForMember(dto => dto.Reports, conf => conf.MapFrom(o => o.Reports.ToList()));
        }
    }
}
