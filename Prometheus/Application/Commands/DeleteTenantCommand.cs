using Application.Shared;
using Application.Shared.Interfaces;
using Domain.Entities;
using Domain.Request;
using Domain.Response;

namespace Application.Commands
{
    public class DeleteTenantCommand : BaseCommand<Tenant, DeleteTenantRequest, DeleteTenantResponse>
    {
        private Tenant _tenant;

        public DeleteTenantCommand(IRepository repository) : base(repository)
        {
        }

        protected override async Task BeforeChanges(DeleteTenantRequest request)
        {
            _tenant = await _repository.GetByIdAsync<Tenant>(request.GetId());

            if (_tenant == null || _tenant.IsDeleted || !_tenant.IsActive)
            {
                _response.AddError("Tenant não encontrado ou já excluído.");
            }
        }

        protected override async Task<Tenant> Changes(DeleteTenantRequest request)
        {
            _tenant.SetIsDeleted();

            return _tenant;
        }
    }
}
