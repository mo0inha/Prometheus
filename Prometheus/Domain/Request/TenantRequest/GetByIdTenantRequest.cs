using Domain.Response.TenantResponse;
using Domain.Shared.Request;

namespace Domain.Request.TenantRequest
{
    public class GetByIdTenantRequest : BaseRequest<GetByIdTenantResponse>
    {
        public Guid Id { get; set; }
    }
}
