using AutoMapper;
using FinanceManager.Application.Common.DTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Application.Common.Mappings
{
    public class RoleDTOProfile : Profile
    {
        public RoleDTOProfile()
        {
            CreateMap<IdentityRole, RoleDTO>();
        }
    }
}
