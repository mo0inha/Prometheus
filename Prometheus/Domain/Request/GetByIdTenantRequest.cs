using Domain.Response;
using Domain.Shared.Request;

namespace Domain.Request
{
    public class GetByIdTenantRequest : BaseRequest<GetByIdTenantResponse>
    {
        public Guid Id { get; set; }
    }
}
