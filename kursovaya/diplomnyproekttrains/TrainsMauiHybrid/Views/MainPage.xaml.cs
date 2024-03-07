using CustomShellMaui.Enum;
using Microsoft.Maui.Controls.PlatformConfiguration;
using TrainsMauiHybrid.Views.PlatformSpecific;

namespace TrainsMauiHybrid.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
// #if ANDROID
// 		VerticalLayout.Add(new TrainsMauiHybrid.Views.PlatformSpecific.MainPagePhoneView());
// #elif IOS
//         VerticalLayout.Add(new TrainsMauiHybrid.Views.PlatformSpecific.MainPagePhoneView());
// #else
//            
//             VerticalLayout.Add(new TrainsMauiHybrid.Views.PlatformSpecific.MainPageDesktopView());
// #endif
        }

        private void OnCurrentRoot(object s, EventArgs e)
        {
            Shell.Current.CustomShellMaui(new CustomShellMaui.Models.Transitions
            {
                Root = new CustomShellMaui.Models.TransitionRoot
                {
                    CurrentPage = TransitionType.FadeOut //is Above by default 
                },
                Push = new CustomShellMaui.Models.Transition
                {
                    CurrentPage = TransitionType.LeftOut,
                    NextPage = TransitionType.RightIn //is Above
                },
                Pop = new CustomShellMaui.Models.Transition
                {
                    CurrentPage = TransitionType.RightOut, //is Above
                    NextPage = TransitionType.LeftIn
                },
            });
            Shell.Current.GoToAsync(nameof(Components.Pages.BlazorWEBviewhost));
        }
        private void OnCustomRoot(object s, EventArgs e)
        {
            Shell.Current.CustomShellMaui(new CustomShellMaui.Models.Transitions
            {
                Root = new CustomShellMaui.Models.TransitionRoot
                {
                    CurrentPage = TransitionType.FadeOut //is Above by default 
                },
                Push = new CustomShellMaui.Models.Transition
                {
                    CurrentPage = TransitionType.LeftOut,
                    NextPage = TransitionType.RightIn //is Above
                },
                Pop = new   CustomShellMaui.Models.Transition
                {
                    CurrentPage = TransitionType.RightOut, //is Above
                    NextPage = TransitionType.LeftIn
                },
            });
            Shell.Current.GoToAsync(nameof(Components.Pages.NewPage1));
        }
    }
}
