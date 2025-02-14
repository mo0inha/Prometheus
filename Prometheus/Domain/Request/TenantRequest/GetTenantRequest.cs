using Domain.Response.TenantResponse;
using Domain.Shared.Request;

namespace Domain.Request.TenantRequest
{
    public class GetTenantRequest : BaseRequest<GetTenantResponse>
    {
        public string? Name { get; set; }
    }
}
