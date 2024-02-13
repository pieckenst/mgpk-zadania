// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System;
using System.Windows;
using Wpf.Ui.Controls;
using FluentKursovayaAvtoparkA.Services.Contracts;
using FluentKursovayaAvtoparkA.ViewModels.Windows;
using FluentKursovayaAvtoparkA.Views.Pages;
using Wpf.Ui;
using Wpf.Ui.Appearance;

namespace FluentKursovayaAvtoparkA.Views.Windows;

public partial class MainWindow : INavigationWindow
{
    public FluentKursovayaAvtoparkA.ViewModels.Windows.MainWindowViewModel ViewModel { get; }
    private bool _isUserClosedPane;

    private bool _isPaneOpenedOrClosedFromCode;


    public MainWindow(
        FluentKursovayaAvtoparkA.ViewModels.Windows.MainWindowViewModel viewModel,
        IPageService pageService,
        INavigationService navigationService
    )
    {
        ViewModel = viewModel;
        DataContext = this;

        SystemThemeWatcher.Watch(this);

        InitializeComponent();
        SetPageService(pageService);

        navigationService.SetNavigationControl(NavigationView);
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
}
