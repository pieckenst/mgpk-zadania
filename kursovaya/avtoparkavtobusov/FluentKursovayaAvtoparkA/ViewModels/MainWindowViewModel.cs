// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Wpf.Ui.Controls;
using FluentKursovayaAvtoparkA.Views.Pages;


namespace FluentKursovayaAvtoparkA.ViewModels.Windows;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private string _applicationTitle = "Автопарк Автобусов";

    [ObservableProperty]
     private ICollection<object> _menuItems = new ObservableCollection<object>
    {
        new NavigationViewItem("Информация о сотрудниках", SymbolRegular.Person24, typeof(DashboardPage)),
        new NavigationViewItem("Продажа билетов", SymbolRegular.TicketDiagonal24, typeof(TicketPage)),
        new NavigationViewItem("Информация о маршрутах", SymbolRegular.VehicleBus24, typeof(DataPage)),
        new NavigationViewItem("Состояние Автобусного Парка", SymbolRegular.Wrench24, typeof(MaintenancePage)),

        
    };

    [ObservableProperty]
    private ICollection<object> _footerMenuItems = new ObservableCollection<object>()
    {
        new NavigationViewItem("Настройки", SymbolRegular.Settings24, typeof(SettingsPage))
    };

    [ObservableProperty]
    private ObservableCollection<Wpf.Ui.Controls.MenuItem> _trayMenuItems =
        new()
        {
            new Wpf.Ui.Controls.MenuItem { Header = "Home", Tag = "tray_home" },
            new Wpf.Ui.Controls.MenuItem { Header = "Close", Tag = "tray_close" }
        };
}
