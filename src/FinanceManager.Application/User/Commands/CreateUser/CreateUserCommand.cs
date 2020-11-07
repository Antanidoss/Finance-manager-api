using FinanceManager.Application.Common.Models;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Application.User.Command.CreateUser
{
    public class CreateUserCommand : IRequest<Result>
    {
        public string Name { get; }
        public string Password { get; }
        public string Email { get; }
        public CreateUserCommand(string name, string email, string password)
        {
            Name = name;
            Password = password;
            Email = email;
        }
    }
}
