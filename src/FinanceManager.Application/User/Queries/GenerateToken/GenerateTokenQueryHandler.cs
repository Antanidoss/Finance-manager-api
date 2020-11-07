using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Application.Common.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceManager.Application.User.Command.GenerateToken
{
    public class GenerateTokenQueryHandler : IRequestHandler<GenerateTokenQuery, Token>
    {
        private readonly ITokenGenerator _tokenGenerator;

        public GenerateTokenQueryHandler(ITokenGenerator tokenGenerator)
        {
            _tokenGenerator = tokenGenerator;
        }

        public async Task<Token> Handle(GenerateTokenQuery request, CancellationToken cancellationToken)
        {
            return await _tokenGenerator.GenerateToken(request.Name, request.Email, request.Password);
        }
    }
}
