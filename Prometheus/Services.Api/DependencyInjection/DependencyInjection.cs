using Application.Shared;
using Application.Shared.Interfaces;

namespace Services.Api.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            var commandTypes = assemblies.SelectMany(a => a.GetTypes()).Where(t => t.IsClass && !t.IsAbstract && IsSubclassOfGeneric(t, typeof(BaseCommand<,,>))).ToList();

            foreach (var commandType in commandTypes)
            {
                services.AddScoped(commandType);
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
