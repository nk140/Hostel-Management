using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HMS.Controls
{
    public class DatePickers:DatePicker
    {
        public static readonly BindableProperty EnterTextProperty = BindableProperty.Create(propertyName: "Placeholder", returnType: typeof(string), declaringType: typeof(DatePickers), defaultValue: default(string));
        public string Placeholder
        {
            get;
            set;
        }
    }
}
