using Application.Shared;
using Application.Shared.Interfaces;

namespace Services.Api.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Registrar o repositório
            services.AddScoped<IRepository, Repository>();

            // Buscar todos os assemblies carregados
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            // Registrar os tipos de comando
            var commandTypes = assemblies.SelectMany(a => a.GetTypes())
                                         .Where(t => t.IsClass && !t.IsAbstract && IsSubclassOfGeneric(t, typeof(BaseCommand<,,>)))
                                         .ToList();

            foreach (var commandType in commandTypes)
            {
                services.AddScoped(commandType);
            }

            // Registrar os tipos de consulta (Query)
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
