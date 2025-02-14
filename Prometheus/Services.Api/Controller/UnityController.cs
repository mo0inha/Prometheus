using Domain.Request.UnityRequest;
using Domain.Response.UnityResponse;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Api.DependencyInjection;
using Services.Api.Shared;

namespace Services.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnityController : PrometheusController
    {
        public UnityController(IMediator mediator, IValidationProvider validationProvider) : base(mediator, validationProvider)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreateUnity([FromBody] CreateUnityRequest request, CancellationToken cancellationToken)
        {
            return await ExecuteRequest<CreateUnityRequest, CreateUnityResponse>(request, cancellationToken);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUnity([FromRoute] Guid id, [FromBody] UpdateUnityRequest request, CancellationToken cancellationToken)
        {
            request.SetId(id);
            return await ExecuteRequest<UpdateUnityRequest, UpdateUnityResponse>(request, cancellationToken);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchUnity([FromRoute] Guid id, [FromBody] PatchUnityRequest request, CancellationToken cancellationToken)
        {
            request.SetId(id);
            return await ExecuteRequest<PatchUnityRequest, PatchUnityResponse>(request, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnity([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var request = new DeleteUnityRequest();
            request.SetId(id);
            return await ExecuteRequest<DeleteUnityRequest, DeleteUnityResponse>(request, cancellationToken);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUnity([FromQuery] GetUnityRequest request, [FromQuery] int pageIndex, [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            request.SetNumberRegistryPage(pageSize, pageIndex);
            return await ExecuteRequest<GetUnityRequest, GetUnityResponse>(request, cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdUnity([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var request = new GetByIdUnityRequest();
            request.SetId(id);
            return await ExecuteRequest<GetByIdUnityRequest, GetByIdUnityResponse>(request, cancellationToken);
        }
    }
}
