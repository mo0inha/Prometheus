using Application.Commands;
using Application.Queries;
using Domain.Entities;
using Domain.Request;
using Domain.Response;
using Microsoft.AspNetCore.Mvc;
using Services.Api.Shared;

namespace Services.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : PrometheusController
    {
        public TenantController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreateTenant([FromBody] CreateTenantRequest request)
        {
            return await ExecuteCommand<CreateTenantCommand, CreateTenantRequest, CreateTenantResponse, Tenant>(request);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTenant([FromRoute] Guid id, UpdateTenantRequest request)
        {
            request.SetId(id);

            return await ExecuteCommand<UpdateTenantCommand, UpdateTenantRequest, UpdateTenantResponse, Tenant>(request);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchTenant(Guid id, UpdateTenantRequest request)
        {
            request.SetId(id);

            return await ExecuteCommand<UpdateTenantCommand, UpdateTenantRequest, UpdateTenantResponse, Tenant>(request);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTenant([FromRoute] Guid id)
        {
            var request = new DeleteTenantRequest();

            request.SetId(id);

            return await ExecuteCommand<DeleteTenantCommand, DeleteTenantRequest, DeleteTenantResponse, Tenant>(request);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTenant([FromQuery] GetTenantRequest request, [FromQuery] int page, [FromQuery] int index)
        {
            request.SetNumberRegistryPage(index, page);

            return await ExecuteQuery<GetTenantQuery, GetTenantRequest, GetTenantResponse, Tenant>(request);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdTenant([FromRoute] Guid id)
        {
            var request = new GetByIdTenantRequest();

            request.SetId(id);

            return await ExecuteQuery<GetByIdTenantQuery, GetByIdTenantRequest, GetByIdTenantResponse, Tenant>(request);
        }

        // GET: Buscar um Tenant por ID
        //[HttpGet("{id:guid}")]
        //public async Task<IActionResult> GetTenant([FromRoute] Guid id, [FromQuery] GetByIdTenantRequest request)
        //{
        //    var request = new GetTenantRequest { Id = id };
        //    return await ExecuteCommand<GetTenantCommand, GetTenantRequest, GetTenantResponse, Tenant>(request);
        //}
    }
}
