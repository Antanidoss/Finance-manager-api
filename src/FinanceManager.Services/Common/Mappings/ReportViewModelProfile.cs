using AutoMapper;
using FinanceManager.Application.Common.DTO;
using FinanceManager.Services.Common.Models.ViewModels.Report;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Services.Common.Mappings
{
    public class ReportViewModelProfile : Profile
    {
        public ReportViewModelProfile()
        {
            CreateMap<ReportCreateModel, ReportDTO>()
                .ForMember(dto => dto.AmountSpent, conf => conf.MapFrom(cm => decimal.Parse(cm.AmountSpent)));
            CreateMap<ReportCreateModel, ReportDTO>();

            CreateMap<ReportUpdateModel, ReportDTO>()
                .ForMember(dto => dto.AmountSpent, conf => conf.MapFrom(um => decimal.Parse(um.AmountSpent)))
                .ForMember(dto => dto.Id, conf => conf.MapFrom(um => um.ReportId));
            CreateMap<ReportDTO, ReportUpdateModel>()
                .ForMember(um => um.ReportId, conf => conf.MapFrom(dto => dto.Id));
        }
    }
}
