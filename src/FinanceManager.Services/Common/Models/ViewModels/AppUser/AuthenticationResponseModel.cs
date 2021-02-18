using FinanceManager.Application.Common.DTO;

namespace FinanceManager.Services.Common.Models.ViewModels.AppUser
{
    public class AuthenticationResponseModel
    {
        public AppUserDTO User { get; set; }
        public bool IsAuthenticated { get; set; }

        public AuthenticationResponseModel(AppUserDTO user, bool isAuthenticated)
        {
            User = user;
            IsAuthenticated = isAuthenticated;
        }        
    }
}
