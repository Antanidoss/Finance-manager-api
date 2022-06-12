using AutoMapper;
using FinanceManager.Application.Common.DTO;
using Microsoft.AspNetCore.Identity;

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
