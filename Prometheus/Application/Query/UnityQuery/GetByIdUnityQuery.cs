using Application.Shared;
using Application.Shared.Interfaces;
using Domain.Entities;
using Domain.Request.UnityRequest;
using Domain.Response.UnityResponse;

namespace Application.Query.UnityQuery
{
    public class GetByIdUnityQuery : BaseQuery<Unity, GetByIdUnityRequest, GetByIdUnityResponse>
    {
        public GetByIdUnityQuery(IRepository repository) : base(repository)
        {
        }

        protected override async Task<GetByIdUnityResponse> Query(GetByIdUnityRequest request, CancellationToken cancellationToken)
        {
            var result = _repository.AsQueryable<Unity>()
                .Where(x => x.Id == request.GetId())
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.IsActive,
                    x.CreatedAt,
                    x.UpdatedAt,
                });

            var response = new GetByIdUnityResponse() { Data = result, TotalCount = 1, TotalPages = 1 };

            return await Task.FromResult(response);
        }
    }
}
