

using System;
using System.Globalization;
using System.Windows.Data;
using Wpf.Ui.Appearance;

namespace FluentKursovayaAvtoparkA.Helpers;

internal sealed class ThemeToIndexConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is ApplicationTheme.Light)
        {
            return 0;
        }

        if (value is ApplicationTheme.HighContrast)
        {
            return 2;
        }

        return 1;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is 0)
        {
            return ApplicationTheme.Light;
        }

        if (value is 2)
        {
            return ApplicationTheme.HighContrast;
        }

        return ApplicationTheme.Dark;
    }
}
