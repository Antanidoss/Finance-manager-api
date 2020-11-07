using FinanceManager.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.Common.Interfaces
{
    public interface ITokenGenerator
    {
        Task<Token> GenerateToken(string name, string email, string password);
    }
}
