using AutoMapper;
using FinanceManager.Application.Common.DTO;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Common.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceManager.Application.User.Commands.Authentication
{
    public class AuthenticationCommandHandler : IRequestHandler<AuthenticationCommand, (AppUserDTO User, Result Result)>
    {
        private readonly IUserManagerService _userManagerService;

        private readonly IMapper _mapper;

        public AuthenticationCommandHandler(IUserManagerService userManagerService, IMapper mapper)
        {
            _userManagerService = userManagerService;
            _mapper = mapper;
        }
        public async Task<(AppUserDTO User, Result Result)> Handle(AuthenticationCommand request, CancellationToken cancellationToken)
        {
            var passwordSignResult = await _userManagerService.PasswordSignInAsync(request.Email, request.Password, request.IsPersisitent);

            if (!passwordSignResult.Result.Succeeded)
                return (User: null, Result: passwordSignResult.Result);

            var appUserDTO = _mapper.Map<AppUserDTO>(passwordSignResult.User);
            appUserDTO.Token = passwordSignResult.Token;

            return (User: appUserDTO, Result: passwordSignResult.Result);
        }
    }
}
