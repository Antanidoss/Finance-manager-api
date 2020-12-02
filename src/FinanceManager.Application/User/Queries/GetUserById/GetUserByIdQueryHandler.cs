using AutoMapper;
using FinanceManager.Application.Common.DTO;
using FinanceManager.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceManager.Application.User.Command.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, AppUserDTO>
    {
        private readonly IUserManagerService _userManagerService;

        private readonly IMapper _mapper;
        public GetUserByIdQueryHandler(IUserManagerService userManagerService, IMapper mapper)
        {
            _userManagerService = userManagerService;
            _mapper = mapper;
        }

        public async Task<AppUserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<AppUserDTO>(await _userManagerService.GetUserByIdAsync(request.AppUserId));
        }
    }
}

