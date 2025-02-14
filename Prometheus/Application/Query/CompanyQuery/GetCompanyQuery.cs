using Application.Shared;
using Application.Shared.Interfaces;
using Domain.Entities;
using Domain.Request.CompanyRequest;
using Domain.Response.CompanyResponse;

namespace Application.Query.CompanyQuery
{
    public class GetCompanyQuery : BaseQuery<Company, GetCompanyRequest, GetCompanyResponse>
    {
        public GetCompanyQuery(IRepository repository) : base(repository)
        {
        }

        protected override async Task<GetCompanyResponse> Query(GetCompanyRequest request, CancellationToken cancellationToken)
        {
            var filter = FilterBuilder.New<Company>();

            if (!string.IsNullOrEmpty(request.Name)) filter = filter.And(x => x.Name.Contains(request.Name));

            int sumRecords = _repository.AsQueryable<Company>()
                .Where(filter).Count();

            var result = _repository.AsQueryable<Company>()
                .Where(filter)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.CreatedAt,
                    x.UpdatedAt
                }).OrderByDescending(x => x.CreatedAt).Skip(skip).Take(request.GetNumber());

            var response = new GetCompanyResponse() { Data = result, TotalCount = sumRecords, TotalPages = Math.Ceiling((decimal)sumRecords / request.GetNumber()) };

            return await Task.FromResult(response);
        }
    }
}
