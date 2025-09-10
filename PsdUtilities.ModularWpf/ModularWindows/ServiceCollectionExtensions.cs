using System.Reflection;

using Microsoft.Extensions.DependencyInjection;

using PsdUtilities.ModularWpf.ModularWindows.Models;
using PsdUtilities.ModularWpf.ModularWindows.Service;

namespace PsdUtilities.ModularWpf.ModularWindows;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddModularWindowsService(this IServiceCollection services)
    {
        services.AddSingleton<IModularWindowsService, ModularWindowsService>();
        services.AddSingleton<IModularWindowsWithDependenciesService, ModularWindowsWithDependenciesService>();

        return services;
    }

    public static IServiceCollection AddModularWindow<TWindow>(this IServiceCollection services)
        where TWindow : class, IModularWindow
    {
        services.AddTransient<TWindow>();
        return services;
    }

    public static IServiceCollection AddModularWindow<TWindow, TResult>(this IServiceCollection services)
        where TWindow : class, IModularWindow<TResult>
    {
        services.AddTransient<TWindow>();
        return services;
    }

    public static IServiceCollection AddModularWindows(this IServiceCollection services) => AddModularWindows(services, _ => true);
    public static IServiceCollection AddModularWindows(this IServiceCollection services, Func<Assembly, bool> assemblyFilter)
    {
        AddModularWindowsService(services);

        var windows = AppDomain
            .CurrentDomain
            .GetAssemblies()
            .Where(assemblyFilter)
            .SelectMany(a => a.GetTypes())
            .Where(t =>
                (
                    t.IsAssignableTo(typeof(IModularWindow)) ||
                    (
                        t.GetInterfaces().Any(i => 
                            i.IsGenericType &&
                            i.GetGenericTypeDefinition() == typeof(IModularWindow<>)
                        )
                    )
                ) &&
                t.IsClass &&
                t.IsAbstract == false
            )
            .ToArray();

        foreach (var window in windows)
            services.AddTransient(window);

        return services;
    }
}