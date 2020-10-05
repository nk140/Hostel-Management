﻿using HMS.ViewModel.Parent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Guest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetPassword : ContentPage
    {
        UpdatePasswordVM vm;
        public SetPassword()
        {
            InitializeComponent();
            BindingContext = vm = new UpdatePasswordVM();
        }
    }
}