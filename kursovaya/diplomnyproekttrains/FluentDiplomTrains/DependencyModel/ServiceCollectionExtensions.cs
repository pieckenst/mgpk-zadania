

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace FluentKursovayaAvtoparkA.DependencyModel;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTransientFromNamespace(
        this IServiceCollection services,
        string namespaceName,
        params Assembly[] assemblies
    )
    {
        foreach (Assembly assembly in assemblies)
        {
            IEnumerable<Type> types = assembly
                .GetTypes()
                .Where(x =>
                    x.IsClass
                    && x.Namespace!.StartsWith(namespaceName, StringComparison.InvariantCultureIgnoreCase)
                );

            foreach (Type? type in types)
            {
                if (services.All(x => x.ServiceType != type))
                {
                    _ = services.AddTransient(type);
                }
            }
        }

        return services;
    }
}
