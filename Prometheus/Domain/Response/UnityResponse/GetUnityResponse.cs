using Domain.Shared.Response;

namespace Domain.Response.UnityResponse
{
    public class GetUnityResponse : BaseResponse
    {
        public IEnumerable<object> Data { get; set; }
    }
}
