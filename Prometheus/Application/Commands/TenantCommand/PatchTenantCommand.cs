using Application.Shared;
using Application.Shared.Interfaces;
using Domain.Entities;
using Domain.Request.TenantRequest;
using Domain.Response.TenantResponse;

namespace Application.Commands.TenantCommand
{
    public class PatchTenantCommand : BaseCommand<Tenant, PatchTenantRequest, PatchTenantResponse>
    {
        private Tenant _tenant;

        public PatchTenantCommand(IRepository repository) : base(repository)
        {
        }

        protected override async Task BeforeChanges(PatchTenantRequest request)
        {
            _tenant = await _repository.GetByIdAsync<Tenant>(request.GetId());

            if (_tenant == null || _tenant.IsDeleted || !_tenant.IsActive)
            {
                _response.AddError("Tenant não encontrado ou inativo.");
            }
        }

        protected override async Task<Tenant> Changes(PatchTenantRequest request)
        {
            if (request.Name != null) _tenant.Name = request.Name;

            await _repository.UpdateAsync(_tenant);

            return _tenant;
        }
    }
}
