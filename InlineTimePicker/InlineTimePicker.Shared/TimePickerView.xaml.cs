using System;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace kahua.host.uno.control.timepicker
{
    public static class l
    {
        public static void g(string s)
        {
            System.Console.WriteLine($"#########{s}");
            System.Diagnostics.Debug.WriteLine($"#########{s}");
        }
    }
    public sealed partial class TimePickerView : UserControl
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
          "Value", typeof(DateTime?), typeof(TimePickerView), new PropertyMetadata(null, (s, e) => ((TimePickerView)s).OnValueChanged()));

        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
        "Header", typeof(string), typeof(TimePickerView), new PropertyMetadata(null));

        public static readonly DependencyProperty TimeValueProperty = DependencyProperty.Register(
            "TimeValue", typeof(TimeSpan?), typeof(TimePickerView), new PropertyMetadata(null, (s, e) => ((TimePickerView)s).OnTimeValueChanged()));

        private void OnTimeValueChanged()
        {
            if (Value != null && TimeValue == null)
            {
                Value = Value.Value.Date;
                l.g($"OnTimeValueChanged updated value={Value}");
                return;
            }
            if (Value != null && TimeValue != null)
            {
                var v = Value.Value;
                var t = TimeValue.Value;
                if (v.Hour != t.Hours || v.Minute != t.Minutes)
                {
                    Value = new DateTime(v.Year, v.Month, v.Day, t.Hours, t.Minutes, 0);
                    l.g($"OnTimeValueChanged 2 updated value={Value}");

                }
                return;
            }
            if (Value == null && TimeValue != null)
            {
                var today = DateTime.Today;
                var t = TimeValue.Value;
                Value = new DateTime(today.Year, today.Month, today.Day, t.Hours, t.Minutes, 0);
                l.g($"OnTimeValueChanged 3 updated value={Value}");

            }
        }
        private void OnValueChanged()
        {
            if (Value != null && TimeValue == null)
            {
                var v = Value.Value;
                TimeValue = TimeSpan.FromHours(v.Hour).Add(TimeSpan.FromMinutes(v.Minute));
                l.g($"OnValueChanged updated value={TimeValue}");

                return;
            }
            if (Value != null && TimeValue != null)
            {
                var v = Value.Value;
                var t = TimeValue.Value;
                if (v.Hour != t.Hours || v.Minute != t.Minutes)
                {
                    TimeValue = TimeSpan.FromHours(v.Hour).Add(TimeSpan.FromMinutes(v.Minute));
                    l.g($"OnValueChanged 2 updated value={TimeValue}");
                }
                return;
            }
            if (Value == null && TimeValue != null)
            {
                TimeValue = null;
                l.g($"OnValueChanged 3 updated value={TimeValue}");
            }
        }

        public string Header
        {
            get => (string)GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }

        public DateTime? Value
        {
            get => (DateTime?)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public TimeSpan? TimeValue
        {
            get { return (TimeSpan?)GetValue(TimeValueProperty); }
            set { SetValue(TimeValueProperty, value); }
        }

        public void ClearTimeClicked(object sender, RoutedEventArgs e)
        {
            TimeValue = null;
            Value = null;
        }

        public TimePickerView()
        {
            this.InitializeComponent();
        }
    }
}
