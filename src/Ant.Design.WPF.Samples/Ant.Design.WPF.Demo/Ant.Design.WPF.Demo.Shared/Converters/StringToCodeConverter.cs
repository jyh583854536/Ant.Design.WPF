﻿using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;

namespace AntdDemo.Converters
{
    public class StringToCodeConverter : IValueConverter
    {
        private static StringToCodeConverter instance;

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static StringToCodeConverter() { }

        private StringToCodeConverter() { }

        public static StringToCodeConverter Instance
        {
            get { return instance ?? (instance = new StringToCodeConverter()); }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var str       = value as string;
            var textBlock = new TextBlock() { TextWrapping = TextWrapping.Wrap };

            if (!string.IsNullOrEmpty(str))
            {
                string pattern = "=\".*?\"|[</>]";
                int index      = 0;

                var inlines    = textBlock.Inlines;
                str            = str.Replace(@"\n", Environment.NewLine);

                foreach (Match match in Regex.Matches(str, pattern))
                {
                    inlines.Add(str.Substring(index, match.Index - index));
                    inlines.Add(new Run(match.Value) { Foreground = Brushes.Blue });
                    index = match.Index + match.Length;
                }

                inlines.Add(str.Substring(index));
            } 

            return textBlock;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
