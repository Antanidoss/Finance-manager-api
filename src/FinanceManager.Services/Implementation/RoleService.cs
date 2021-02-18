using AutoMapper;
using FinanceManager.Application.Common.DTO;
using FinanceManager.Application.Common.Models;
using FinanceManager.Application.Role.Command.CreateRole;
using FinanceManager.Application.Role.Query.GetRoleByName;
using FinanceManager.Services.Common.Interfaces;
using FinanceManager.Services.Common.Models.ViewModels;
using MediatR;
using System.Threading.Tasks;

namespace FinanceManager.Services.Implementation
{
    public class RoleService : IRoleService
    {
        private readonly IMediator _mediator;

        public RoleService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Result> CreateRoleAsync(string roleName)
        {
            return await _mediator.Send(new CreateRoleCommand(roleName));
        }

        public async Task<Response<RoleDTO>> GetRoleByNameAsync(string roleName)
        {
            var role = await _mediator.Send(new GetRoleByNameQuery(roleName));

            return new Response<RoleDTO>(role, Result.Success());
        }
    }
}
