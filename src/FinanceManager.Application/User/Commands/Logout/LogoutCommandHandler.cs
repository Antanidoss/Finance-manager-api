using FinanceManager.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceManager.Application.User.Commands.Logout
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand>
    {
        private readonly IUserManagerService _userManagerService;

        public LogoutCommandHandler(IUserManagerService userManagerService)
        {
            _userManagerService = userManagerService;
        }

        public async Task<Unit> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            await _userManagerService.SignOutAsync();

            return Unit.Value;
        }
    }
}
