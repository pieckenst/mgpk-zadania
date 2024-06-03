namespace TrainsMauiHybrid.Services;

public class ThemeService
{
    /// <summary>
    /// Get the theme of the current system
    /// </summary>
    /// <returns></returns>
    public AppTheme GetAppTheme()
    {
        return Application.Current!.RequestedTheme;
    }

    /// <summary>
    /// System theme switch
    /// </summary>
    /// <param name="handler"></param>
    public void ThemeChanged(EventHandler<AppThemeChangedEventArgs> handler)
    {
        Application.Current!.RequestedThemeChanged += handler;
    }
}