using FinanceManager.Application.Common.Models;
using FinanceManager.Services.Common.Interfaces;
using FinanceManager.Services.Common.Models.ViewModels.AppUser;
using FinanceManager.Services.Common.Models.ViewModels.Token;
using FinanceManeger.Web.Models.CreateModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FinanceManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
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
        public async Task<Result> Authentication([FromBody]AuthenticationModel model)
        {
            return await _userService.AuthenticationAsync(model);
        }

        [HttpGet("auth/me")]
        public async Task<AuthenticationResponceModel> Authentication()
        {
            return await _userService.GetCurrentUser();
        }

        [HttpGet("token")]
        [System.Web.Http.Authorize]
        public async Task<Token> GenerateToken([FromBody]TokenCreateModel model)
        {
            return await _userService.GenerateToken(model);
        }

        [HttpGet("logout")]
        [System.Web.Http.Authorize]
        public async Task Logout()
        {
            await _userService.Logout();
        }
    }
}
