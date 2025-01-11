using Application.Commands;
using Application.Shared.Interfaces;

namespace Services.Api.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();

            services.AddScoped<CreateTenantCommand>();

            /*
            var assemblyApplication = Assembly.GetAssembly(typeof(CreateTenantCommand)); 

            var commandTypes = assemblyApplication.GetTypes()
                .Where(t => t.IsSubclassOf(typeof(BaseCommand<,,>)))
                .ToList();

            foreach (var commandType in commandTypes)
            {
                services.AddScoped(commandType);
            }
            */

            return services;
        }
    }
}
