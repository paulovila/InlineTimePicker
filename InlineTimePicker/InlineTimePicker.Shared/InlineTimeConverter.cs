using kahua.host.uno.control.timepicker;
using System;
using System.Text.RegularExpressions;
using Windows.UI.Xaml.Data;

namespace kahua.host.uno.ui.converters
{
    public class InlineTimeConverter : IValueConverter
    {
        #region Instance Properties

        public static InlineTimeConverter Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new InlineTimeConverter();
                }
                return _instance;
            }
        }
        private static InlineTimeConverter _instance = null;

        #endregion Instance Properties

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is TimeSpan t)
            {
                l.g($"InlineTimeConverter convert {t}");
                return $"{t.Hours:D2}:{t.Minutes:D2}";
            }
            l.g($"InlineTimeConverter convert null");
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is string s)
            {
                var match = Regex.Match(s, "^(?<h>\\d{1,2})[ :](?<m>\\d{1,2})$");
                if (match.Success)
                {
                    var h = int.Parse(match.Groups["h"].Value);
                    var mString = match.Groups["m"].Value;
                    if (mString.Length == 1)
                        mString += "0";
                    var m = int.Parse(mString);
                    if (0 <= h && h < 24 && 0 <= m && m < 60)
                    {
                        l.g($"InlineTimeConverter convertback {h} {m}");
                        return new TimeSpan(h, m, 0);
                    }
                }
            }
            l.g($"InlineTimeConverter convertback null");
            return null;
        }
    }
}