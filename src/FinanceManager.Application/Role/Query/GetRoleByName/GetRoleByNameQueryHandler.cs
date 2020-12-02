using AutoMapper;
using FinanceManager.Application.Common.DTO;
using FinanceManager.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceManager.Application.Role.Query.GetRoleByName
{
    public class GetRoleByNameQueryHandler : IRequestHandler<GetRoleByNameQuery, RoleDTO>
    {
        private readonly IRoleManagerService _roleManagerService;

        private readonly IMapper _mapper;

        public GetRoleByNameQueryHandler(IRoleManagerService roleManagerService, IMapper mapper)
        {
            _roleManagerService = roleManagerService;
            _mapper = mapper;
        }

        public async Task<RoleDTO> Handle(GetRoleByNameQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<RoleDTO>(await _roleManagerService.GetByNameAsync(request.RoleName));
        }
    }
}
