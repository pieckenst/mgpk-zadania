using CustomShellMaui.Enum;

namespace TrainsMauiHybrid.Views.PlatformSpecific
{
    public partial class MainPagePhoneView : ContentPage
    {
        public MainPagePhoneView()
        {
            InitializeComponent();
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
            Shell.Current.GoToAsync(nameof(SettingsPage));
        }
    }
}
