using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Services.Common.Models.ViewModels.AppUser
{
    public class AuthenticationModel
    {
        [JsonProperty("email")]
        [Required(ErrorMessage = "Введите эл.почту")]
        [StringLength(254, MinimumLength = 3, ErrorMessage = "Длина эл.почты должна быть от 3 до 254 символов")]
        public string Email { get; set; }

        [JsonProperty("password")]
        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Длина пароля должна быть от 10 до 100 символов")]
        public string Password { get; set; }

        [JsonProperty("isParsistent")]
        public string IsParsistent { get; set; }
    }
}
