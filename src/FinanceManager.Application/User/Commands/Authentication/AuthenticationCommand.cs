using FinanceManager.Application.Common.DTO;
using FinanceManager.Application.Common.Models;
using MediatR;

namespace FinanceManager.Application.User.Commands.Authentication
{
    public class AuthenticationCommand : IRequest<(AppUserDTO User, Result Result)>
    {
        public readonly string Email;

        public readonly string Password;

        public readonly bool IsPersisitent;

        public AuthenticationCommand(string email, string password, bool isPersistent)
        {
            Email = email;
            Password = password;
            IsPersisitent = isPersistent;
        }
    }
}
