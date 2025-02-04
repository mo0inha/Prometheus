using Application.Shared;
using Application.Shared.Interfaces;
using FluentValidation;
using System.Reflection;

namespace Services.Api.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Application.AssemblyReference.Assembly, includeInternalTypes: true);

            services.AddSingleton<IValidationProvider>(sp => new OptionalValidationProvider(sp));


            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            var validatorTypes = assemblies.SelectMany(a => a.GetTypes())
                .Where(t => t.IsClass && !t.IsAbstract && typeof(IValidator).IsAssignableFrom(t))
                .ToList();

            foreach (var validatorType in validatorTypes)
            {
                services.AddScoped(validatorType);
            }

            services.AddScoped<IRepository, Repository>();

            var commandTypes = assemblies.SelectMany(a => a.GetTypes())
                .Where(t => t.IsClass && !t.IsAbstract && IsSubclassOfGeneric(t, typeof(BaseCommand<,,>)))
                .ToList();

            foreach (var commandType in commandTypes)
            {
                services.AddScoped(commandType);
            }

            var queryTypes = assemblies.SelectMany(a => a.GetTypes())
                .Where(t => t.IsClass && !t.IsAbstract && IsSubclassOfGeneric(t, typeof(BaseQuery<,,>)))
                .ToList();

            foreach (var queryType in queryTypes)
            {
                services.AddScoped(queryType);
            }


            return services;
        }

        private static bool IsSubclassOfGeneric(Type type, Type genericType)
        {
            while (type != null && type != typeof(object))
            {
                var currentType = type.IsGenericType ? type.GetGenericTypeDefinition() : type;

                if (currentType == genericType)
                {
                    return true;
                }

                type = type.BaseType;
            }
            return false;
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
}