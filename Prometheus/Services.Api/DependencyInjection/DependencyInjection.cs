using Application.Shared;
using Application.Shared.Interfaces;
using Application.Validator;
using FluentValidation;

namespace Services.Api.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Registra o FluentValidation automaticamente para as classes de Request
            services.AddValidatorsFromAssemblyContaining<CreateTenantValidator>();

            // Registra todos os validadores automaticamente
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var validatorTypes = assemblies.SelectMany(a => a.GetTypes())
                .Where(t => t.IsClass && !t.IsAbstract && typeof(IValidator).IsAssignableFrom(t))
                .ToList();

            foreach (var validatorType in validatorTypes)
            {
                services.AddScoped(validatorType);
            }

            // Adiciona o repositório e comandos/consultas
            services.AddScoped<IRepository, Repository>();

            // Registra todos os comandos automaticamente
            var commandTypes = assemblies.SelectMany(a => a.GetTypes())
                .Where(t => t.IsClass && !t.IsAbstract && IsSubclassOfGeneric(t, typeof(BaseCommand<,,>)))
                .ToList();

            foreach (var commandType in commandTypes)
            {
                services.AddScoped(commandType);
            }

            // Registra todas as consultas automaticamente
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
    }
}
