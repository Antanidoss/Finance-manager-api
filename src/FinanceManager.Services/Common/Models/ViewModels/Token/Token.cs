using System.IdentityModel.Tokens.Jwt;

namespace FinanceManager.Services.Common.Models.ViewModels.Token
{
    public class Token
    {
        public string AccessToken { get; }
        public string UserName { get; }

        public Token(string accessToken, string userName)
        {
            AccessToken = accessToken;
            UserName = userName;
        }
    }
}
