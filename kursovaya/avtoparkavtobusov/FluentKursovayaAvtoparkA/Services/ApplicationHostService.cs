

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using FluentKursovayaAvtoparkA.Services.Contracts;
using FluentKursovayaAvtoparkA.Views.Pages;
using FluentKursovayaAvtoparkA.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Wpf.Ui;

namespace FluentKursovayaAvtoparkA.Services;

/// <summary>
/// Managed host of the application.
/// </summary>
public class ApplicationHostService : IHostedService
{
    private readonly IServiceProvider _serviceProvider;
    private INavigationWindow _navigationWindow;

    public ApplicationHostService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Triggered when the application host is ready to start the service.
    /// </summary>
    /// <param name="cancellationToken">Indicates that the start process has been aborted.</param>
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await HandleActivationAsync();
    }

    /// <summary>
    /// Triggered when the application host is performing a graceful shutdown.
    /// </summary>
    /// <param name="cancellationToken">Indicates that the shutdown process should no longer be graceful.</param>
    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    /// <summary>
    /// Creates main window during activation.
    /// </summary>
    private Task HandleActivationAsync()
    {
        if (Application.Current.Windows.OfType<MainWindow>().Any())
        {
            return Task.CompletedTask;
        }

        INavigationWindow mainWindow = _serviceProvider.GetRequiredService<INavigationWindow>();
        
        mainWindow?.ShowWindow();

        return Task.CompletedTask;
    }

    private void OnMainWindowLoaded(object sender, RoutedEventArgs e)
    {
        if (sender is not MainWindow mainWindow)
        {
            return;
        }

        _ = mainWindow.NavigationView.Navigate(typeof(DashboardPage));
    }
}
