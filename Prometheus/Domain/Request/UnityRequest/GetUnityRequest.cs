using Domain.Response.UnityResponse;
using Domain.Shared.Request;

namespace Domain.Request.UnityRequest
{
    public class GetUnityRequest : BaseTenantRequest<GetUnityResponse>
    {
        public string? Name { get; set; }
    }
}
