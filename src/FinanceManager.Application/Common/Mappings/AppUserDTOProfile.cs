using AutoMapper;
using FinanceManager.Application.Common.DTO;
using FinanceManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Application.Common.Mappings
{
    public class AppUserDTOProfile : Profile
    {
        public AppUserDTOProfile()
        {
            CreateMap<AppUser, AppUserDTO>();
        }
    }
}
