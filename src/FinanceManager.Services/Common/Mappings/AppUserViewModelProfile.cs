using AutoMapper;
using FinanceManager.Application.Common.DTO;
using FinanceManager.Services.Common.Models.ViewModels.AppUser;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Services.Common.Mappings
{
    public class AppUserViewModelProfile : Profile
    {
        public AppUserViewModelProfile()
        {
            CreateMap<AppUserDTO, AppUserViewModel>();
        }
    }
}
