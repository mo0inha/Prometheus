using Application.Shared;
using Application.Shared.Interfaces;
using Domain.Entities;
using Domain.Request;
using Domain.Response;

namespace Application.Commands
{
    public class UpdateTenantCommand : BaseCommand<Tenant, UpdateTenantRequest, UpdateTenantResponse>
    {
        private Tenant _tenant;

        public UpdateTenantCommand(IRepository repository) : base(repository)
        {
        }

        protected override async Task BeforeChanges(UpdateTenantRequest request)
        {
            _tenant = await _repository.GetByIdAsync<Tenant>(request.GetId());

            if (_tenant == null || _tenant.IsDeleted || !_tenant.IsActive)
            {
                _response.AddError("Tenant não encontrado ou inativo.");
                return;
            }

            var tenantExists = await _repository.ExistsAsync<Tenant>(x => x.IsActive && !x.IsDeleted && x.Name == request.Name && x.Id != request.GetId());

            if (tenantExists)
            {
                _response.AddError("Já existe um Tenant com esse nome.");
            }
        }

        protected override async Task<Tenant> Changes(UpdateTenantRequest request)
        {
            _tenant.Name = request.Name;

            await _repository.UpdateAsync(_tenant);

            return _tenant;
        }
    }
}
