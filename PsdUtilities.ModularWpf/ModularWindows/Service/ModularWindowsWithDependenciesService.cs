using System.Windows;

using Microsoft.Extensions.DependencyInjection;

using PsdUtilities.ModularWpf.ModularWindows.Models;

namespace PsdUtilities.ModularWpf.ModularWindows.Service;

public sealed class ModularWindowsWithDependenciesService : IModularWindowsWithDependenciesService
{
    private readonly IServiceProvider _serviceProvider;

    public ModularWindowsWithDependenciesService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Task Show<TWindow>()
        where TWindow : Window, IModularWindow, new()
    {
        var window = _serviceProvider.GetRequiredService<TWindow>();
        return window.DisplayWindow();
    }

    public Task<object> ShowWithResult<TWindow>()
        where TWindow : Window, IModularWindow, new()
    {
        var window = _serviceProvider.GetRequiredService<TWindow>();
        return window.DisplayWindow();
    }

    public Task<TResult> ShowWithResult<TWindow, TResult>()
        where TWindow : Window, IModularWindow<TResult>, new()
    {
        var window = _serviceProvider.GetRequiredService<TWindow>();
        return window.DisplayWindow<TWindow, TResult>();
    }
}