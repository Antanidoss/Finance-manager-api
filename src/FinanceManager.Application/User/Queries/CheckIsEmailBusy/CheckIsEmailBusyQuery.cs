using MediatR;

namespace FinanceManager.Application.User.Queries.GetUserByEmail
{
    public class CheckIsEmailBusyQuery : IRequest<bool>
    {
        public readonly string Email;

        public CheckIsEmailBusyQuery(string email)
        {
            Email = email;
        }
    }
}
