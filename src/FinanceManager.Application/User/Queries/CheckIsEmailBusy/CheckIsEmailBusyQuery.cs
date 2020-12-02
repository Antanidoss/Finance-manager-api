using FinanceManager.Application.Common.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

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
