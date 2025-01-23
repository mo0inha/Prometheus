using Domain.Response;
using Domain.Shared.Request;

namespace Domain.Request
{
    public class UpdateTenantRequest : BaseRequest<UpdateTenantResponse>
    {
        public string Name { get; set; }
    }
}
