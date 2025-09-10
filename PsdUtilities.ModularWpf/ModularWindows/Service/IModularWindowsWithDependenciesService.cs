using System.Windows;

using PsdUtilities.ModularWpf.ModularWindows.Models;

namespace PsdUtilities.ModularWpf.ModularWindows.Service;
public interface IModularWindowsWithDependenciesService
{
    Task Show<TWindow>() where TWindow : Window, IModularWindow, new();
    Task<TResult> ShowWithResult<TWindow, TResult>() where TWindow : Window, IModularWindow<TResult>, new();
    Task<object> ShowWithResult<TWindow>() where TWindow : Window, IModularWindow, new();
}