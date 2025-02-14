using Domain.Response.TenantResponse;
using Domain.Shared.Request;

namespace Domain.Request.TenantRequest
{
    public class PatchTenantRequest : BaseRequest<PatchTenantResponse>
    {
        public string? Name { get; set; }
    }
}
