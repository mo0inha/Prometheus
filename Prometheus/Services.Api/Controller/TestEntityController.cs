using Domain.Request.TestEntityRequest;
using Domain.Response.TestEntityResponse;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Api.DependencyInjection;
using Services.Api.Shared;

namespace Services.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestEntityController : PrometheusController
    {
        public TestEntityController(IMediator mediator, IValidationProvider validationProvider) : base(mediator, validationProvider)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreateTenant([FromBody] CreateTestEntityRequest request, CancellationToken cancellationToken)
        {
            return await ExecuteRequest<CreateTestEntityRequest, CreateTestEntityResponse>(request, cancellationToken);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTestEntity([FromRoute] Guid id, [FromBody] UpdateTestEntityRequest request, CancellationToken cancellationToken)
        {
            request.SetId(id);
            return await ExecuteRequest<UpdateTestEntityRequest, UpdateTestEntityResponse>(request, cancellationToken);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchTestEntity([FromRoute] Guid id, [FromBody] PatchTestEntityRequest request, CancellationToken cancellationToken)
        {
            request.SetId(id);
            return await ExecuteRequest<PatchTestEntityRequest, PatchTestEntityResponse>(request, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestEntity([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var request = new DeleteTestEntityRequest();
            request.SetId(id);
            return await ExecuteRequest<DeleteTestEntityRequest, DeleteTestEntityResponse>(request, cancellationToken);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTestEntity([FromQuery] GetTestEntityRequest request, [FromQuery] int pageIndex, [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            request.SetNumberRegistryPage(pageSize, pageIndex);
            return await ExecuteRequest<GetTestEntityRequest, GetTestEntityResponse>(request, cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdTestEntity([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var request = new GetByIdTestEntityRequest();
            request.SetId(id);
            return await ExecuteRequest<GetByIdTestEntityRequest, GetByIdTestEntityResponse>(request, cancellationToken);
        }
    }
}
