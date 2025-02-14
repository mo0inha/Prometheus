using Domain.Shared.Response;

namespace Domain.Response.TestEntityResponse
{
    public class GetTestEntityResponse : BaseResponse
    {
        public IEnumerable<object> Data { get; set; }
    }
}
