using FinanceManager.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Application.User.Commands.Authentication
{
    public class AuthenticationCommand : IRequest<Result>
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
