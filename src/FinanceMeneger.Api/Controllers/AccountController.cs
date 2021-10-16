using FinanceManager.Api.Attributes;
using FinanceManager.Application.Common.DTO;
using FinanceManager.Application.Common.Models;
using FinanceManager.Services.Common.Interfaces;
using FinanceManager.Services.Common.Models.ViewModels;
using FinanceManager.Services.Common.Models.ViewModels.AppUser;
using FinanceManeger.Web.Models.CreateModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FinanceManager.Api.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : ApiController
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }       

        [HttpPost("reg")]
        public async Task<Result> Registration([FromBody]RegistrationModel model)
        {
            return await _userService.RegistrationAsync(model);
        }   
        
        [HttpPost("auth")]
        public async Task<Response<AppUserDTO>> Authentication([FromBody]AuthenticationModel model)
        {
            return await _userService.AuthenticationAsync(model);
        } 

        [HttpGet("logout")]
        [Authorize]
        public async Task Logout()
        {
            await _userService.Logout();
        }

        [HttpGet("get")]
        public async Task<Response<AppUserDTO>> GetCurrentUser()
        {
            return await _userService.GetUserById(_userService.GetCurrentUserId());
        }
    }
}
