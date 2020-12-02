using AutoMapper;
using FinanceManager.Application.Common.DTO;
using FinanceManager.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceManager.Application.User.Queries.GetUserByEmail
{
    public class CheckIsEmailBusyHandler : IRequestHandler<CheckIsEmailBusyQuery, bool>
    {
        private readonly IUserManagerService _userManagerService;

        private readonly IMapper _mapper; 

        public CheckIsEmailBusyHandler(IUserManagerService userManagerService, IMapper mapper)
        {
            _userManagerService = userManagerService;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CheckIsEmailBusyQuery request, CancellationToken cancellationToken)
        {
            return await _userManagerService.CheckIsEmailBusy(request.Email);
        }
    }
}
