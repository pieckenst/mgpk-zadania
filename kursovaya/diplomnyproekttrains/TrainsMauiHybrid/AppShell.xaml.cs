using CustomShellMaui.Enum;
using TrainsMauiHybrid.Views;
using TrainsMauiHybrid.Views.PlatformSpecific;

namespace TrainsMauiHybrid;

public partial class AppShell : Shell
{
    public bool isVisible_Android { get; set; }

    public bool isVisible_iOS { get; set; }
    public bool isVisible_Desktop { get; set; }
	public AppShell()
	{
		InitializeComponent();

        Shell.Current.DisableSwipeBackiOS(true);

        Routing.RegisterRoute(nameof(EditBioPage), typeof(EditBioPage));
        Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
        Routing.RegisterRoute(nameof(MainPagePhoneView), typeof(MainPagePhoneView));
        Routing.RegisterRoute(nameof(EmployeesPhoneView), typeof(EmployeesPhoneView));
        Routing.RegisterRoute(nameof(MainPageDesktopView), typeof(MainPageDesktopView));

        Routing.RegisterRoute("SettingsPage/EditBioPage", typeof(EditBioPage));
        if (Microsoft.Maui.Devices.DeviceInfo.Platform == DevicePlatform.iOS )
        {
            isVisible_iOS = true;
        }
        else if (DeviceInfo.Platform == DevicePlatform.Android)
        {
            isVisible_Android = true;
        }
        else
        {
            isVisible_Desktop = true;
        }
        BindingContext = this;

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
}
