using AutoMapper;
using FinanceManager.Application.Common.Models;
using FinanceManager.Application.Role.Command.CreateRole;
using FinanceManager.Application.Role.Query.GetRoleByName;
using FinanceManager.Services.Common.Interfaces;
using FinanceManager.Services.Common.Models.ViewModels.Role;
using MediatR;
using System.Threading.Tasks;

namespace FinanceManager.Services.Implementation
{
    public class RoleService : IRoleService
    {
        private readonly IMediator _mediator;

        private readonly IUserService _userService;

        private readonly IMapper _mapper;
        public RoleService(IMediator mediator, IUserService userService, IMapper mapper)
        {
            _mediator = mediator;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<Result> CreateRoleAsync(string roleName)
        {
            return await _mediator.Send(new CreateRoleCommand(roleName));
        }

        public async Task<RoleViewModel> GetRoleByNameAsync(string roleName)
        {
            return _mapper.Map<RoleViewModel>(await _mediator.Send(new GetRoleByNameQuery(roleName)));
        }
    }
}
