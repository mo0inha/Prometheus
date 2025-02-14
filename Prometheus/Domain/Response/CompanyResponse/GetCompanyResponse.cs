using Domain.Shared.Response;

namespace Domain.Response.CompanyResponse
{
    public class GetCompanyResponse : BaseResponse
    {
        public IEnumerable<object> Data { get; set; }
    }
}
