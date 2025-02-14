using Domain.Response.TenantResponse;
using Domain.Shared.Request;

namespace Domain.Request.TenantRequest
{
    public class CreateTenantRequest : BaseRequest<CreateTenantResponse>
    {
        public string Name { get; set; }
    }
}
