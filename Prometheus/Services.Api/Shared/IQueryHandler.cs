using Domain.Shared.Request;
using Domain.Shared.Response;

namespace Application.Shared.Interfaces
{
    public interface IQueryHandler<TResponse>
        where TResponse : BaseResponse, new()
    {
        Task<TResponse> ExecuteAsync(BaseRequest<TResponse> request);
    }
}
