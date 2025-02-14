using Application.Shared;
using Application.Shared.Interfaces;
using Domain.Entities;
using Domain.Request.UnityRequest;
using Domain.Response.UnityResponse;

namespace Application.Query.UnityQuery
{
    public class GetUnityQuery : BaseQuery<Unity, GetUnityRequest, GetUnityResponse>
    {
        public GetUnityQuery(IRepository repository) : base(repository)
        {
        }

        protected override async Task<GetUnityResponse> Query(GetUnityRequest request, CancellationToken cancellationToken)
        {
            var filter = FilterBuilder.New<Unity>();

            if (!string.IsNullOrEmpty(request.Name)) filter = filter.And(x => x.Name.Contains(request.Name));

            int sumRecords = _repository.AsQueryable<Unity>()
                .Where(filter).Count();

            var result = _repository.AsQueryable<Unity>()
                .Where(filter)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.CreatedAt,
                    x.UpdatedAt
                }).OrderByDescending(x => x.CreatedAt).Skip(skip).Take(request.GetNumber());

            var response = new GetUnityResponse() { Data = result, TotalCount = sumRecords, TotalPages = Math.Ceiling((decimal)sumRecords / request.GetNumber()) };

            return await Task.FromResult(response);
        }
    }
}
