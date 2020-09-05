﻿using Xamarin.Forms;

namespace HMS.Controls
{
    public class BetterEntry : Entry
    {
        public static readonly BindableProperty PlaceholderFontFamilyProperty
            = BindableProperty.Create(nameof(PlaceholderFontFamily),
                                      typeof(string),
                                      typeof(BetterEntry),
                                      default(string));

        public string PlaceholderFontFamily
        {
            get { return (string)GetValue(PlaceholderFontFamilyProperty); }
            set { SetValue(PlaceholderFontFamilyProperty, value); }
        }
    }
}
