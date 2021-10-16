using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceManeger.Web.Models.CreateModel
{
    public class RegistrationModel
    {
        [JsonProperty("name")]
        [Required(ErrorMessage = "Введите имя")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина имени должна быть от 2 до 50 символов")]
        public string Name { get; set; }

        [JsonProperty("email")]
        [Required(ErrorMessage = "Введите эл.почту")]
        [StringLength(254, MinimumLength = 3, ErrorMessage = "Длина эл.почты должна быть от 3 до 254 символов")]
        public string Email { get; set; }

        [JsonProperty("password")]
        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Длина пароля должна быть от 10 до 100 символов")]
        public string Password { get; set; }
    }
}
