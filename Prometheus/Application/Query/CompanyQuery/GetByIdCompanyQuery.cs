using Application.Shared;
using Application.Shared.Interfaces;
using Domain.Entities;
using Domain.Request.CompanyRequest;
using Domain.Response.CompanyResponse;

namespace Application.Query.CompanyQuery
{
    public class GetByIdCompanyQuery : BaseQuery<Company, GetByIdCompanyRequest, GetByIdCompanyResponse>
    {
        public GetByIdCompanyQuery(IRepository repository) : base(repository)
        {
        }

        protected override async Task<GetByIdCompanyResponse> Query(GetByIdCompanyRequest request, CancellationToken cancellationToken)
        {
            var result = _repository.AsQueryable<Company>()
                .Where(x => x.Id == request.GetId())
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.IsActive,
                    x.CreatedAt,
                    x.UpdatedAt,
                });

            var response = new GetByIdCompanyResponse() { Data = result, TotalCount = 1, TotalPages = 1 };

            return await Task.FromResult(response);
        }
    }
}
