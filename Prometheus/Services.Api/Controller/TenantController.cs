using Domain.Request.TenantRequest;
using Domain.Response.TenantResponse;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Api.DependencyInjection;
using Services.Api.Shared;

[Route("api/[controller]")]
[ApiController]
public class TenantController : PrometheusController
{
    public TenantController(IMediator mediator, IValidationProvider validationProvider) : base(mediator, validationProvider) { }

    [HttpPost]
    public async Task<IActionResult> CreateTenant([FromBody] CreateTenantRequest request, CancellationToken cancellationToken)
    {
        return await ExecuteRequest<CreateTenantRequest, CreateTenantResponse>(request, cancellationToken);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTenant([FromRoute] Guid id, [FromBody] UpdateTenantRequest request, CancellationToken cancellationToken)
    {
        request.SetId(id);
        return await ExecuteRequest<UpdateTenantRequest, UpdateTenantResponse>(request, cancellationToken);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchTenant([FromRoute] Guid id, [FromBody] PatchTenantRequest request, CancellationToken cancellationToken)
    {
        request.SetId(id);
        return await ExecuteRequest<PatchTenantRequest, PatchTenantResponse>(request, cancellationToken);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTenant([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new DeleteTenantRequest();
        request.SetId(id);
        return await ExecuteRequest<DeleteTenantRequest, DeleteTenantResponse>(request, cancellationToken);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTenant([FromQuery] GetTenantRequest request, [FromQuery] int pageIndex, [FromQuery] int pageSize, CancellationToken cancellationToken)
    {
        request.SetNumberRegistryPage(pageSize, pageIndex);
        return await ExecuteRequest<GetTenantRequest, GetTenantResponse>(request, cancellationToken);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdTenant([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetByIdTenantRequest();
        request.SetId(id);
        return await ExecuteRequest<GetByIdTenantRequest, GetByIdTenantResponse>(request, cancellationToken);
    }
}