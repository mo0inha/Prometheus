using Application.Shared;
using Domain.Shared.Request;
using Domain.Shared.Response;
using Microsoft.AspNetCore.Mvc;

namespace Services.Api.Shared
{
    public abstract class PrometheusController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;

        protected PrometheusController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        // Método genérico para executar comandos
        protected async Task<IActionResult> ExecuteCommand<TCommand, TRequest, TResponse, TEntity>(TRequest request)
            where TCommand : BaseCommand<TEntity, TRequest, TResponse>
            where TRequest : BaseRequest<TResponse>
            where TResponse : BaseResponse, new()
            where TEntity : class
        {
            try
            {
                var command = _serviceProvider.GetService<TCommand>();

                if (command == null) throw new InvalidOperationException($"Comando {typeof(TCommand).Name} não registrado.");

                var response = await command.ExecuteAsync(request);

                if (!response.Success) return BadRequest(response);

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new TResponse
                {
                    Success = false,
                    Message = ex.Message,
                    StatusCode = 500
                };
                return StatusCode(500, errorResponse);
            }
        }

        protected async Task<IActionResult> ExecuteQuery<TQuery, TRequest, TResponse, TEntity>(TRequest request)
            where TQuery : BaseQuery<TEntity, TRequest, TResponse>
            where TRequest : BaseRequest<TResponse>
            where TResponse : BaseResponse, new()
            where TEntity : class
        {
            try
            {
                var query = _serviceProvider.GetService<TQuery>();

                if (query == null) new InvalidOperationException($"Consulta não registrada.");

                var response = await query.ExecuteAsync(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new TResponse
                {
                    Success = false,
                    Message = ex.Message,
                    StatusCode = 500
                };
                return StatusCode(500, errorResponse);
            }
        }
    }
}
