using System;
using Windows.UI.Xaml.Data;

namespace kahua.host.uno.ui.converters
{
    public class NullToBoolConverter : IValueConverter
    {
        #region Instance Properties

        public static NullToBoolConverter TrueWhenNullInstance
        {
            get
            {
                if (_trueWhenNullInstance == null)
                {
                    _trueWhenNullInstance = new NullToBoolConverter { TrueWhenNull = true };
                }
                return _trueWhenNullInstance;
            }
        }
        private static NullToBoolConverter _trueWhenNullInstance = null;

        public static NullToBoolConverter FalseWhenNullInstance
        {
            get
            {
                if (_falseWhenNullInstance == null)
                {
                    _falseWhenNullInstance = new NullToBoolConverter { TrueWhenNull = false };
                }
                return _falseWhenNullInstance;
            }
        }
        private static NullToBoolConverter _falseWhenNullInstance = null;

        #endregion Instance Properties

        public bool TrueWhenNull { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                return TrueWhenNull ? true : false;
            }
            else
            {
                return TrueWhenNull ? false : true;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}