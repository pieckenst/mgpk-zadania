﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

using MarkupExtension = System.Windows.Markup.MarkupExtension;

namespace KursovayaAvtoparkAvtobusov
{
    public class PixelsToGridLengthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new GridLength((double)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}