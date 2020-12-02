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
            CreateMap<ReportDTO, ReportViewModel>();
        }
    }
}
