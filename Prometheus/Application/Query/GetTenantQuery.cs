using Application.Shared;
using Application.Shared.Interfaces;
using Domain.Entities;
using Domain.Request;
using Domain.Response;

namespace Application.Queries
{
    public class GetTenantQuery : BaseQuery<Tenant, GetTenantRequest, GetTenantResponse>
    {
        public GetTenantQuery(IRepository repository) : base(repository)
        {
        }

        protected override async Task<GetTenantResponse> Query(GetTenantRequest request, CancellationToken cancellationToken)
        {
            var filter = FilterBuilder.New<Tenant>();

            if (!string.IsNullOrEmpty(request.Name)) filter = filter.And(x => x.Name.Contains(request.Name));

            int sumRecords = _repository.AsQueryable<Tenant>()
                .Where(filter).Count();

            var result = _repository.AsQueryable<Tenant>()
                .Where(filter)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.CreatedAt,
                    x.UpdatedAt
                }).OrderBy(x => x.Name).Skip(skip).Take(request.GetNumber());

            var response = new GetTenantResponse() { Data = result, SumRecords = sumRecords, TotalPagins = Math.Ceiling((decimal)sumRecords / request.GetNumber()) };

            return await Task.FromResult(response);
        }
    }
}
