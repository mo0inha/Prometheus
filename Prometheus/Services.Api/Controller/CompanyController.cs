using Domain.Request.CompanyRequest;
using Domain.Response.CompanyResponse;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Api.DependencyInjection;
using Services.Api.Shared;

namespace Services.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : PrometheusController
    {
        public CompanyController(IMediator mediator, IValidationProvider validationProvider) : base(mediator, validationProvider)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyRequest request, CancellationToken cancellationToken)
        {
            return await ExecuteRequest<CreateCompanyRequest, CreateCompanyResponse>(request, cancellationToken);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany([FromRoute] Guid id, [FromBody] UpdateCompanyRequest request, CancellationToken cancellationToken)
        {
            request.SetId(id);
            return await ExecuteRequest<UpdateCompanyRequest, UpdateCompanyResponse>(request, cancellationToken);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchCompany([FromRoute] Guid id, [FromBody] PatchCompanyRequest request, CancellationToken cancellationToken)
        {
            request.SetId(id);
            return await ExecuteRequest<PatchCompanyRequest, PatchCompanyResponse>(request, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var request = new DeleteCompanyRequest();
            request.SetId(id);
            return await ExecuteRequest<DeleteCompanyRequest, DeleteCompanyResponse>(request, cancellationToken);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCompany([FromQuery] GetCompanyRequest request, [FromQuery] int pageIndex, [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            request.SetNumberRegistryPage(pageSize, pageIndex);
            return await ExecuteRequest<GetCompanyRequest, GetCompanyResponse>(request, cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCompany([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var request = new GetByIdCompanyRequest();
            request.SetId(id);
            return await ExecuteRequest<GetByIdCompanyRequest, GetByIdCompanyResponse>(request, cancellationToken);
        }
    }
}
