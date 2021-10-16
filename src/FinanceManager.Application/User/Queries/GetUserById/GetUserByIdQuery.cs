using FinanceManager.Application.Common.DTO;
using MediatR;

namespace FinanceManager.Application.User.Command.GetUserById
{
    public class GetUserByIdQuery : IRequest<AppUserDTO>
    {
        public string AppUserId { get; }
        public GetUserByIdQuery(string appUserId)
        {
            AppUserId = appUserId;
        }
    }
}
