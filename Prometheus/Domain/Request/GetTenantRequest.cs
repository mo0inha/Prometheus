using Domain.Response;
using Domain.Shared.Request;

namespace Domain.Request
{
    public class GetTenantRequest : BaseRequest<GetTenantResponse>
    {
        public string? Name { get; set; }
    }
}
