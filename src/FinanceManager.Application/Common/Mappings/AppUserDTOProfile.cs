using AutoMapper;
using FinanceManager.Application.Common.DTO;
using FinanceManager.Domain.Entities;

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
