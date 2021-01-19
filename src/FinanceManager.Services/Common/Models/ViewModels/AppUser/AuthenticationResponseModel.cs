namespace FinanceManager.Services.Common.Models.ViewModels.AppUser
{
    public class AuthenticationResponseModel
    {
        public AppUserViewModel User { get; set; }
        public bool IsAuthenticated { get; set; }

        public AuthenticationResponseModel(AppUserViewModel user, bool isAuthenticated)
        {
            User = user;
            IsAuthenticated = isAuthenticated;
        }        
    }
}
