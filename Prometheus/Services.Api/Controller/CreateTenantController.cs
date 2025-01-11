using Application.Commands;
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
        public async Task<IActionResult> CreateTenant(CreateTenantRequest request)
        {
            return await ExecuteCommand<CreateTenantCommand, CreateTenantRequest, CreateTenantResponse, Tenant>(request);
        }
    }
}
