using AutoMapper;
using FinanceManager.Application.Common.DTO;
using FinanceManager.Services.Common.Models.ViewModels.Role;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Services.Common.Mappings
{
    public class RoleViewModelProfile : Profile
    {
        public RoleViewModelProfile()
        {
            CreateMap<RoleDTO, RoleViewModel>();
        }
    }
}
