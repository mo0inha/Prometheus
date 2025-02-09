using Application.Shared;
using Application.Shared.Interfaces;
using FluentValidation;
using MediatR;

namespace Services.Api.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services.AddValidators().AddMediatRConfiguration().AddInfrastructure().AddHandlers();
        }

        private static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Application.AssemblyReference.Assembly, includeInternalTypes: true);

            services.AddSingleton<IValidationProvider>(sp => new OptionalValidationProvider(sp));

            return services;
        }

        private static IServiceCollection AddMediatRConfiguration(
            this IServiceCollection services
        )
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Application.AssemblyReference.Assembly);
            });

            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var assembly in assemblies)
            {
                var handlerTypes = assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract && t.BaseType != null && t.BaseType.IsGenericType && (t.BaseType.GetGenericTypeDefinition() == typeof(BaseCommand<,,>) || t.BaseType.GetGenericTypeDefinition() == typeof(BaseQuery<,,>))).ToList();

                foreach (var handlerType in handlerTypes)
                {
                    var interfaces = handlerType.GetInterfaces();
                    foreach (var @interface in interfaces)
                    {
                        if (@interface.IsGenericType && @interface.GetGenericTypeDefinition() == typeof(IRequestHandler<,>))
                        {
                            Console.WriteLine($"Registering {@interface.FullName} as {handlerType.FullName}");
                            services.AddScoped(@interface, handlerType);
                        }
                    }
                }
            }

            return services;
        }

        private static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            return services;
        }
    }

    public class OptionalValidationProvider : IValidationProvider
    {
        private readonly IServiceProvider _serviceProvider;

        public OptionalValidationProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IValidator<T> GetValidator<T>()
        {
            return _serviceProvider.GetService<IValidator<T>>();
        }
    }
}