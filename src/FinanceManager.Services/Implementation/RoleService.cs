using AutoMapper;
using FinanceManager.Application.Common.Models;
using FinanceManager.Application.Role.Command.CreateRole;
using FinanceManager.Application.Role.Query.GetRoleByName;
using FinanceManager.Services.Common.Interfaces;
using FinanceManager.Services.Common.Models.ViewModels;
using FinanceManager.Services.Common.Models.ViewModels.Role;
using MediatR;
using System.Threading.Tasks;

namespace FinanceManager.Services.Implementation
{
    public class RoleService : IRoleService
    {
        private readonly IMediator _mediator;


        private readonly IMapper _mapper;
        public RoleService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<Result> CreateRoleAsync(string roleName)
        {
            return await _mediator.Send(new CreateRoleCommand(roleName));
        }

        public async Task<Response<RoleViewModel>> GetRoleByNameAsync(string roleName)
        {
            var role = await _mediator.Send(new GetRoleByNameQuery(roleName));

            return new Response<RoleViewModel>(_mapper.Map<RoleViewModel>(role), Result.Success());
        }
    }
}
