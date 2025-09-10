using System.Windows;

using PsdUtilities.ModularWpf.ModularWindows.Models;

namespace PsdUtilities.ModularWpf.ModularWindows.Service;
public interface IModularWindowsWithDependenciesService
{
    Task Show<TWindow>() where TWindow : Window, IModularWindow;
    Task<TResult> ShowWithResult<TWindow, TResult>() where TWindow : Window, IModularWindow<TResult>;
    Task<object> ShowWithResult<TWindow>() where TWindow : Window, IModularWindow;
}