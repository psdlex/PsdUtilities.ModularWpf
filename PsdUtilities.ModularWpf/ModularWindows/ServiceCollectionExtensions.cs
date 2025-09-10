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
}