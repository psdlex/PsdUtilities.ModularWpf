using System.Windows;

using PsdUtilities.ModularWpf.ModularWindows.Models;

namespace PsdUtilities.ModularWpf.ModularWindows;

internal static class Utils
{
    public static Task<object> DisplayWindow<TWindow>(this TWindow window)
        where TWindow : Window, IModularWindow
    {
        var tcs = new TaskCompletionSource<object>();

        window.Closed += (_, _) => tcs.SetResult(window.GetResult());
        window.Show();

        return tcs.Task;
    }

    public static Task<TResult> DisplayWindow<TWindow, TResult>(this TWindow window)
        where TWindow : Window, IModularWindow<TResult>
    {
        var tcs = new TaskCompletionSource<TResult>();

        window.Closed += (_, _) => tcs.SetResult(window.GetResult());
        window.Show();

        return tcs.Task;
    }
}