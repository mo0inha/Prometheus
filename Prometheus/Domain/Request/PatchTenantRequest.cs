using Domain.Response;
using Domain.Shared.Request;

namespace Domain.Request
{
    public class PatchTenantRequest : BaseRequest<PatchTenantResponse>
    {
        public string? Name { get; set; } // Campo opcional
    }
}
