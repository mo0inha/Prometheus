using Domain.Shared.Response;

namespace Domain.Response.UnityResponse
{
    public class GetByIdUnityResponse : BaseResponse
    {
        public IEnumerable<object> Data { get; set; }
    }
}
