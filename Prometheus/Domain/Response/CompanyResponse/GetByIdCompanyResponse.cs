using Domain.Shared.Response;

namespace Domain.Response.CompanyResponse
{
    public class GetByIdCompanyResponse : BaseResponse
    {
        public IEnumerable<object> Data { get; set; }
    }
}
