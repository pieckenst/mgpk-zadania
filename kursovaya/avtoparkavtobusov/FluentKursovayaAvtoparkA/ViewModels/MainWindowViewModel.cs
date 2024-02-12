// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using CommunityToolkit.Mvvm.ComponentModel;
using Wpf.Ui.Controls;
using FluentKursovayaAvtoparkA.Views.Pages;


namespace FluentKursovayaAvtoparkA.ViewModels.Windows;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private string _applicationTitle = "WPF UI Gallery";

    [ObservableProperty]
    private ICollection<object> _menuItems = new ObservableCollection<object>
    {
        new NavigationViewItem()
        {
            Content = "Информация о сотрудниках",
            PageTag = "dashboard",
            Icon = SymbolRegular.Person24,
            PageType = typeof(Views.Pages.DashboardPage)
        },
        new NavigationItem()
        {
            Content = "Продажа билетов",
            PageTag = "ticketsale",
            Icon = SymbolRegular.TicketDiagonal24,
            PageType = typeof(Views.Pages.TicketPage)
        },
        new NavigationItem()
        {
            Content = "Информация о маршрутах",
            PageTag = "transportroutes",
            Icon = SymbolRegular.VehicleBus24,
            PageType = typeof(Views.Pages.DataPage)
        },
        new NavigationItem()
        {
            Content = "Состояние Автобусного Парка",
            PageTag = "transportstatus",
            Icon = SymbolRegular.Wrench24,
            PageType = typeof(Views.Pages.MaintenancePage)
        }
    };

    [ObservableProperty]
    private ICollection<object> _footerMenuItems = new ObservableCollection<object>()
    {
        new NavigationViewItem("Settings", SymbolRegular.Settings24, typeof(SettingsPage))
    };

    [ObservableProperty]
    private ObservableCollection<Wpf.Ui.Controls.MenuItem> _trayMenuItems =
        new()
        {
            new Wpf.Ui.Controls.MenuItem { Header = "Home", Tag = "tray_home" },
            new Wpf.Ui.Controls.MenuItem { Header = "Close", Tag = "tray_close" }
        };
}
