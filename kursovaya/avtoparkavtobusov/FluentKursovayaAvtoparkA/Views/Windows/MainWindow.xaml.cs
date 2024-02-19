

using System;
using System.Windows;
using System.Windows.Controls;
using Wpf.Ui.Controls;
using FluentKursovayaAvtoparkA.Services.Contracts;
using FluentKursovayaAvtoparkA.ViewModels.Windows;
using FluentKursovayaAvtoparkA.Views.Pages;
using Wpf.Ui;
using Wpf.Ui.Appearance;
using FluentKursovayaAvtoparkA.Controls;

namespace FluentKursovayaAvtoparkA.Views.Windows;

public partial class MainWindow : INavigationWindow
{
    public FluentKursovayaAvtoparkA.ViewModels.Windows.MainWindowViewModel ViewModel { get; }
    private bool _isUserClosedPane;

    private bool _isPaneOpenedOrClosedFromCode;
    public static FluentKursovayaAvtoparkA.ViewModels.Windows.MainWindowViewModel ViewModelexport { get; set; }
    //public static ContentPresenter ContentPresenterexport { get; set; }


    public MainWindow(
        FluentKursovayaAvtoparkA.ViewModels.Windows.MainWindowViewModel viewModel,
        IPageService pageService,
        INavigationService navigationService,
        IServiceProvider serviceProvider, 
       //ISnackbarService snackbarService,
        IContentDialogService contentDialogService
    )
    {
        ViewModel = viewModel;
        ViewModelexport = viewModel;
        DataContext = this;
        



        SystemThemeWatcher.Watch(this);

        InitializeComponent();
        //navigationService.SetNavigationControl(NavigationView);
        ViewModel._dialogService.SetContentPresenter(RootContentDialog);

        SetPageService(pageService);
        //NavigationView.SetServiceProvider(serviceProvider);

        
        //_snackbarService = snackbarService;
       // _serviceProvider = serviceProvider;
    }
    
 
    #region INavigationWindow methods

    public INavigationView GetNavigation() => NavigationView;

    public bool Navigate(Type pageType) => NavigationView.Navigate(pageType);
    public void SetServiceProvider(IServiceProvider serviceProvider)
    {
        throw new NotImplementedException();
    }

    public void SetPageService(IPageService pageService) => NavigationView.SetPageService(pageService);

    public void ShowWindow() => Show();

    public void CloseWindow() => Close();

    #endregion INavigationWindow methods

    /// <summary>
    /// Raises the closed event.
    /// </summary>

    private void OnNavigationSelectionChanged(object sender, RoutedEventArgs e)
    {
        if (sender is not Wpf.Ui.Controls.NavigationView navigationView)
        {
            return;
        }

        NavigationView.HeaderVisibility =
            navigationView.SelectedItem?.TargetPageType != typeof(DashboardPage)
                ? Visibility.Visible
                : Visibility.Collapsed;
    }

    private void MainWindow_OnSizeChanged(object sender, SizeChangedEventArgs e)
    {
        if (_isUserClosedPane)
        {
            return;
        }

        _isPaneOpenedOrClosedFromCode = true;
        NavigationView.IsPaneOpen = !(e.NewSize.Width <= 1200);
        _isPaneOpenedOrClosedFromCode = false;
    }

    private void NavigationView_OnPaneOpened(NavigationView sender, RoutedEventArgs args)
    {
        if (_isPaneOpenedOrClosedFromCode)
        {
            return;
        }

        _isUserClosedPane = false;
    }

    private void NavigationView_OnPaneClosed(NavigationView sender, RoutedEventArgs args)
    {
        if (_isPaneOpenedOrClosedFromCode)
        {
            return;
        }

        _isUserClosedPane = true;
    }

    public async void FluentWindow_Loaded(object sender, RoutedEventArgs e)
    {
        var termsOfUseContentDialog = new CallSQLConnectionSettingsContentDialog(ViewModel._dialogService.GetContentPresenter(), ViewModel);

        _ = await termsOfUseContentDialog.ShowAsync();
    }
}
