using Application.Shared.Interfaces;
using Domain.Shared.Request;
using Domain.Shared.Response;

namespace Application.Shared
{
    public abstract class BaseQuery<TEntity, TRequest, TResponse> where TRequest : BaseRequest<TResponse> where TResponse : BaseResponse where TEntity : class
    {
        public int skip;
        protected readonly IRepository _repository;

        protected BaseQuery(IRepository repository)
        {
            _repository = repository;
        }

        protected abstract Task<TResponse> Query(TRequest request, CancellationToken cancellationToken);

        public async Task<TResponse> ExecuteAsync(TRequest request, CancellationToken cancellationToken = default)
        {
            skip = request.GetNumber() * (request.GetPage() - 1);

            try
            {
                return await Query(request, cancellationToken);
            }
            catch (Exception ex)
            {
                var response = Activator.CreateInstance<TResponse>();
                response.SetError(ex.Message, 500);
                return response;
            }
        }
    }
}
