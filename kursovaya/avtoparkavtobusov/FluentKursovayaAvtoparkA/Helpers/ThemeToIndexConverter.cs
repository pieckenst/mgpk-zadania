// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

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
