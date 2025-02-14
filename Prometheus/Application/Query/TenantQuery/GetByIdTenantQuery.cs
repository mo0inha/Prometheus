using Application.Shared;
using Application.Shared.Interfaces;
using Domain.Entities;
using Domain.Request.TenantRequest;
using Domain.Response.TenantResponse;

namespace Application.Query.TenantQuery
{
    public class GetByIdTenantQuery : BaseQuery<Tenant, GetByIdTenantRequest, GetByIdTenantResponse>
    {
        public GetByIdTenantQuery(IRepository repository) : base(repository)
        {
        }

        protected override async Task<GetByIdTenantResponse> Query(GetByIdTenantRequest request, CancellationToken cancellationToken)
        {
            var result = _repository.AsQueryable<Tenant>()
                .Where(x => x.Id == request.GetId())
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.IsActive,
                    x.CreatedAt,
                    x.UpdatedAt,
                });

            var response = new GetByIdTenantResponse() { Data = result, TotalCount = 1, TotalPages = 1 };

            return await Task.FromResult(response);
        }
    }
}
