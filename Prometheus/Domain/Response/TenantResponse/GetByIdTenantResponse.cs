using Domain.Shared.Response;

namespace Domain.Response.TenantResponse
{
    public class GetByIdTenantResponse : BaseResponse
    {
        public IEnumerable<object> Data { get; set; }
    }
}
