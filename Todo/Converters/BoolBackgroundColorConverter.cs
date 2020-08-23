using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Todo.Converters
{
    public class BoolBackgroundColorConverter : BindableObject, IValueConverter
    {
        public string TrueValue { get; set; }
        public string FalseValue { get; set; }
        public static readonly BindableProperty DueDateProperty = BindableProperty.Create(nameof(DueDate), typeof(DateTime), typeof(BoolBackgroundColorConverter));
        public DateTime DueDate
        {
            get => (DateTime)GetValue(DueDateProperty);
            set => SetValue(DueDateProperty, value);
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return FalseValue;
            var arg = System.Convert.ToBoolean(value);
            return arg && DueDate < DateTime.Now ? TrueValue : FalseValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
