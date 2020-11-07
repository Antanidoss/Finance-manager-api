using FinanceManager.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Application.User.Command.GenerateToken
{
    public class GenerateTokenQuery : IRequest<Token>
    {
        public string Name { get; }
        public string Email { get; }
        public string Password { get; }

        public GenerateTokenQuery(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
