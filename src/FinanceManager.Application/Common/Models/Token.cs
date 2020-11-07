using System.IdentityModel.Tokens.Jwt;

namespace FinanceManager.Application.Common.Models
{
    public class Token
    {
        public string AccessToken { get; }
        public string UserEmail { get; }

        public Token(string accessToken, string userEmail)
        {
            AccessToken = accessToken;
            UserEmail = userEmail;
        }
    }
}
