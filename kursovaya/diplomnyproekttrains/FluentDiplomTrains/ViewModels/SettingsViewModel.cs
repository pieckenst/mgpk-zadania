using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Reflection;
using System.Windows.Input;
using System.Windows.Media;
using Wpf.Ui;
using Wpf.Ui.Appearance;

using Wpf.Ui.Controls;
using Wpf.Ui.Extensions;

namespace FluentKursovayaAvtoparkA.ViewModels
{
    public sealed partial class SettingsViewModel : ObservableObject, INavigationAware
    {
        private readonly INavigationService _navigationService;

        private bool _isInitialized = false;

        [ObservableProperty]
        private string _appVersion = String.Empty;

        [ObservableProperty]
        private ApplicationTheme _currentApplicationTheme = ApplicationTheme.Unknown;

        [ObservableProperty]
        private NavigationViewPaneDisplayMode _currentApplicationNavigationStyle =
            NavigationViewPaneDisplayMode.Left;

        public SettingsViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        

        public void OnNavigatedTo()
        {
            if (!_isInitialized)
            {
                InitializeViewModel();
            }
        }

        public void OnNavigatedFrom() { }

        void OnCurrentApplicationThemeChanged(ApplicationTheme oldValue, ApplicationTheme newValue)
        {
            ApplicationThemeManager.Apply(newValue);
        }

        void OnCurrentApplicationNavigationStyleChanged(
            NavigationViewPaneDisplayMode oldValue,
            NavigationViewPaneDisplayMode newValue
        )
        {
            _ = _navigationService.SetPaneDisplayMode(newValue);
        }

        private void InitializeViewModel()
        {
            CurrentApplicationTheme = Wpf.Ui.Appearance.ApplicationThemeManager.GetAppTheme();
            AppVersion = $"Информационная Система Автопарк Автобусов  - Версия: {GetAssemblyVersion()}";

            ApplicationThemeManager.Changed += OnThemeChanged;

            _isInitialized = true;
        }

        private void OnThemeChanged(ApplicationTheme currentApplicationTheme, Color systemAccent)
        {
            // Update the theme if it has been changed elsewhere than in the settings.
            if (CurrentApplicationTheme != currentApplicationTheme)
            {
                CurrentApplicationTheme = currentApplicationTheme;
            }
        }

        private string GetAssemblyVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? String.Empty;
        }
        
        [RelayCommand]
        private void OnChangeTheme(string parameter)
        {
            switch (parameter)
            {
                case "theme_light":
                    if (CurrentApplicationTheme != Wpf.Ui.Appearance.ApplicationTheme.Light)
                    {
                        Wpf.Ui.Appearance.ApplicationThemeManager.Apply(Wpf.Ui.Appearance.ApplicationTheme.Light);
                        CurrentApplicationTheme = Wpf.Ui.Appearance.ApplicationTheme.Light;
                    }
                    else
                        break;


                    break;
                
                case "theme_highcontrast":
                    if (CurrentApplicationTheme != Wpf.Ui.Appearance.ApplicationTheme.HighContrast)
                    {
                        Wpf.Ui.Appearance.ApplicationThemeManager.Apply(Wpf.Ui.Appearance.ApplicationTheme
                            .HighContrast);
                        CurrentApplicationTheme = Wpf.Ui.Appearance.ApplicationTheme.HighContrast;
                    }
                    else
                        break;


                    break;

                default: 
                    Wpf.Ui.Appearance.ApplicationThemeManager.Apply(Wpf.Ui.Appearance.ApplicationTheme.Dark);
                    CurrentApplicationTheme = Wpf.Ui.Appearance.ApplicationTheme.Dark;
                    


                    break;
            }
        }
    }

}

/*public partial class SettingsViewModel : ObservableObject, INavigationAware
{

    private bool _isInitialized = false;

    [ObservableProperty]
    private string _appVersion = String.Empty;

    [ObservableProperty]
    private Wpf.Ui.Appearance.ApplicationTheme _currentApplicationTheme = Wpf.Ui
        .Appearance
        .ApplicationTheme
        .Unknown;

    public void OnNavigatedTo()
    {
        if (!_isInitialized)
            InitializeViewModel();
    }

    public void OnNavigatedFrom() { }

    private void InitializeViewModel()
    {
        CurrentApplicationTheme = Wpf.Ui.Appearance.ApplicationThemeManager.GetAppTheme();
        AppVersion = $"Автопарк Автобус - {GetAssemblyVersion()}";

        _isInitialized = true;
    }

    private string GetAssemblyVersion()
    {
        return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version?.ToString()
               ?? String.Empty;
    }

    [RelayCommand]
    private void OnChangeTheme(string parameter)
    {
        switch (parameter)
        {
            case "theme_light":
                if (CurrentApplicationTheme == Wpf.Ui.Appearance.ApplicationTheme.Light)
                    break;

                Wpf.Ui.Appearance.ApplicationThemeManager.Apply(Wpf.Ui.Appearance.ApplicationTheme.Light);
                CurrentApplicationTheme = Wpf.Ui.Appearance.ApplicationTheme.Light;

                break;

            default:
                if (CurrentApplicationTheme == Wpf.Ui.Appearance.ApplicationTheme.Dark)
                    break;

                Wpf.Ui.Appearance.ApplicationThemeManager.Apply(Wpf.Ui.Appearance.ApplicationTheme.Dark);
                CurrentApplicationTheme = Wpf.Ui.Appearance.ApplicationTheme.Dark;

                break;
        }
    } */
    


