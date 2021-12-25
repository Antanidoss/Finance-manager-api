using System.Text.Json.Serialization;

namespace FinanceManager.Application.Common.DTO
{
    public class AppUserDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }     
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
