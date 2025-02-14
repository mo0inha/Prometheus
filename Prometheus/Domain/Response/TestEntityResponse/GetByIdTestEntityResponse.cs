using Domain.Shared.Response;

namespace Domain.Response.TestEntityResponse
{
    public class GetByIdTestEntityResponse : BaseResponse
    {
        public IEnumerable<object> Data { get; set; }
    }
}
