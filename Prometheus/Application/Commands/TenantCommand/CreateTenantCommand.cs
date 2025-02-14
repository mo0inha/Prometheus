using Application.Shared;
using Application.Shared.Interfaces;
using Domain.Entities;
using Domain.Request.TenantRequest;
using Domain.Response.TenantResponse;

namespace Application.Commands.TenantCommand
{
    public class CreateTenantCommand : BaseCommand<Tenant, CreateTenantRequest, CreateTenantResponse>
    {
        private Tenant _tenant;
        public CreateTenantCommand(IRepository repository) : base(repository)
        {
        }

        protected override async Task BeforeChanges(CreateTenantRequest request)
        {
            var tenantExists = await _repository.ExistsAsync<Tenant>(x => x.IsActive && !x.IsDeleted && x.Name == request.Name);

            if (tenantExists)
            {
                _response.AddError("Já existe um Tenant ativo.");
            }
        }

        protected override async Task<Tenant> Changes(CreateTenantRequest request)
        {
            _tenant = new Tenant(request.Name);

            await _repository.AddAsync(_tenant);

            return _tenant;
        }
    }
}
