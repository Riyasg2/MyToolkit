﻿using System;

#if !WINRT
using System.Windows;
using System.Windows.Data;
#else
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml;
#endif

namespace MyToolkit.Converters
{
	public class NotConverter : IValueConverter
	{
#if !WINRT
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (targetType == typeof(Visibility))
			{
				var c = new VisibilityConverter();
				var r = c.Convert(value, targetType, parameter, culture);
				return ((Visibility)r) == Visibility.Visible
						? Visibility.Collapsed : Visibility.Visible;
			}

			if (targetType == typeof(bool))
			{
				if (value == null)
					return true;
				return !((bool) value);
			}

			return null;
		}
#else
        public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (targetType == typeof(Visibility))
			{
				var c = new VisibilityConverter();
				var r = c.Convert(value, targetType, parameter, language);
				return ((Visibility)r) == Visibility.Visible
						? Visibility.Collapsed : Visibility.Visible;
			}

			if (targetType == typeof(bool))
			{
				if (value == null)
					return true;
				return !((bool) value);
			}

			return null;
		}
#endif


#if !WINRT
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
#else
        public object ConvertBack(object value, Type typeName, object parameter, string language)
#endif
		{
			if (value is bool && targetType == typeof(bool))
				return !((bool) value);
			throw new NotImplementedException();
		}
	}
}
