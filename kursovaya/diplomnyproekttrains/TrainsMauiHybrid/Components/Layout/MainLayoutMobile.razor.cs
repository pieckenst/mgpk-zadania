using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using TrainsMauiHybrid.Texts;
using DialogService = Radzen.DialogService;

namespace TrainsMauiHybrid.Components.Layout
{
    public partial class MainLayoutMobile
    {
        static AppTheme currentTheme = Application.Current.RequestedTheme;
        string getwiptheme = currentTheme.ToString();
        private bool _drawer;
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
        bool _isDark;

        protected override Task OnInitializedAsync()
        {
            _isDark = MasaBlazor?.Theme?.Dark ?? false;
            return base.OnInitializedAsync();
        }

        private void IsDarkChanged(bool isDark)
        {
            
            _isDark = isDark;
            MasaBlazor.ToggleTheme();
        }
    }
}