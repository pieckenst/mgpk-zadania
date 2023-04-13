using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;
using Wpf.Ui.Common;
using Wpf.Ui.Controls;
using Wpf.Ui.Controls.Interfaces;
using Wpf.Ui.Mvvm.Contracts;

namespace FluentKursovayaAvtoparkA.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        private bool _isInitialized = false;

        [ObservableProperty]
        private string _applicationTitle = String.Empty;

        [ObservableProperty]
        private ObservableCollection<INavigationControl> _navigationItems = new();

        [ObservableProperty]
        private ObservableCollection<INavigationControl> _navigationFooter = new();

        [ObservableProperty]
        private ObservableCollection<MenuItem> _trayMenuItems = new();

        public MainWindowViewModel(INavigationService navigationService)
        {
            if (!_isInitialized)
                InitializeViewModel();
        }

        private void InitializeViewModel()
        {
            ApplicationTitle = "Автопарк Автобусов";

            NavigationItems = new ObservableCollection<INavigationControl>
            {
                new NavigationItem()
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

            NavigationFooter = new ObservableCollection<INavigationControl>
            {
                new NavigationItem()
                {
                    Content = "Настройки",
                    PageTag = "settings",
                    Icon = SymbolRegular.Settings24,
                    PageType = typeof(Views.Pages.SettingsPage)
                }
            };

            TrayMenuItems = new ObservableCollection<MenuItem>
            {
                new MenuItem
                {
                    Header = "Home",
                    Tag = "tray_home"
                }
            };

            _isInitialized = true;
        }
    }
}
