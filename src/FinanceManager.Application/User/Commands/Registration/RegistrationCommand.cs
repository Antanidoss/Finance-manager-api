using FinanceManager.Application.Common.Models;
using MediatR;

namespace FinanceManager.Application.User.Commands.Registration
{
    public class RegistrationCommand : IRequest<Result>
    {
        public readonly string Name;

        public readonly string Email;

        public readonly string Password;

        public RegistrationCommand(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
