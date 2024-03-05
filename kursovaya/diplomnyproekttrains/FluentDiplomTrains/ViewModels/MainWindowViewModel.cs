

using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Wpf.Ui.Controls;
using FluentKursovayaAvtoparkA.Views.Pages;
using System;
using Wpf.Ui.Appearance;
using Wpf.Ui;


namespace FluentKursovayaAvtoparkA.ViewModels.Windows;

public partial class MainWindowViewModel : ObservableObject
{
    
    private readonly IServiceProvider _serviceProvider;
    public IContentDialogService _dialogService;
    public MainWindowViewModel( IContentDialogService dialogService, IServiceProvider serviceProvider)
    {
        

        _dialogService = dialogService;
        //_snackbarService = snackbarService;
        _serviceProvider = serviceProvider;
    }
    [ObservableProperty]
    private string _applicationTitle = "Автопарк Автобусов";

    [ObservableProperty]
     private ICollection<object> _menuItems = new ObservableCollection<object>
    {
        new NavigationViewItem("Информация о маршрутах", SymbolRegular.VehicleBus24, typeof(DataPage)),
        new NavigationViewItem("Информация о сотрудниках", SymbolRegular.Person24, typeof(DashboardPage)),
        new NavigationViewItem("Продажа билетов", SymbolRegular.TicketDiagonal24, typeof(TicketPage)),
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
