using Domain.Response.CompanyResponse;
using Domain.Shared.Request;

namespace Domain.Request.CompanyRequest
{
    public class GetCompanyRequest : BaseTenantRequest<GetCompanyResponse>
    {
        public string? Name { get; set; }
    }
}
