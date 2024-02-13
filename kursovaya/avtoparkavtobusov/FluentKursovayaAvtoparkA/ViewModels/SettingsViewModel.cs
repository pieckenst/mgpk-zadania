using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Windows.Input;
using System.Windows.Media;
using Wpf.Ui.Appearance;

using Wpf.Ui.Controls;

namespace FluentKursovayaAvtoparkA.ViewModels
{
    public partial class SettingsViewModel : ObservableObject, INavigationAware
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
        }
    }
}

