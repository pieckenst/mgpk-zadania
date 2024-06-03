using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using TrainsMauiHybrid.Services;
using TrainsMauiHybrid.Texts;
using DialogService = Radzen.DialogService;

namespace TrainsMauiHybrid.Components.Layout
{
    public partial class MainLayoutMobile
    {
        string[] items =
        {
            "Click Me",
            "Click Me",
            "Click Me",
            "Click Me 2"
        };
        static AppTheme currentTheme = Application.Current.RequestedTheme;
        string getwiptheme = currentTheme.ToString();
        private bool _drawer;
        [Inject]
        // Inject the theme service
        private ThemeService ThemeService { get; set; }
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        private bool sidebarExpanded = true;

        void SidebarToggleClick()
        {
            sidebarExpanded = !sidebarExpanded;
        }
        void hidedrawer()
        {
            _drawer = !_drawer;
        }
        private bool _isDark { get; set; }

        private void IsDarkChanged(bool isDark)
        {
            var appTheme = ThemeService.GetAppTheme();
            // Whether the theme of the system is DARK, assigning a value for the ISDARK attribute
            _isDark = appTheme == AppTheme.Dark;
            
            Console.WriteLine(_isDark.ToString());
            
            MasaBlazor.ToggleTheme();
            
        }
        
       
        

        /// <summary>
        /// Processing system theme switch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandlerAppThemeChanged(object sender, AppThemeChangedEventArgs e)
        {
            _isDark = e.RequestedTheme == AppTheme.Dark;
            InvokeAsync(StateHasChanged);
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                // Get the system theme
                var appTheme = ThemeService.GetAppTheme();
                // Whether the theme of the system is DARK, assigning a value for the ISDARK attribute
                _isDark = appTheme == AppTheme.Dark;
                Console.WriteLine(_isDark.ToString());
                ThemeService.ThemeChanged(HandlerAppThemeChanged);
                StateHasChanged();
            }
            await base.OnAfterRenderAsync(firstRender);
        }
    }
}