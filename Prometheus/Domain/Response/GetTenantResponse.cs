using Domain.Shared.Response;

namespace Domain.Response
{
    public class GetTenantResponse : BaseResponse
    {
        public IEnumerable<object> Data { get; set; }
    }
}
