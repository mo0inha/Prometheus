using Domain.Shared.Response;

namespace Domain.Response
{
    public class GetByIdTenantResponse : BaseResponse
    {
        public IEnumerable<object> Data { get; set; }
    }
}
