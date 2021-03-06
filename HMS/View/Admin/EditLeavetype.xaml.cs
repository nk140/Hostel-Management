﻿using HMS.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditLeavetype : ContentPage
    {
        EditLeavetypeVM vm;
        public EditLeavetype()
        {
            InitializeComponent();
        }
        public EditLeavetype(string leaveid,string leavename,string userid)
        {
            InitializeComponent();
            BindingContext = vm = new EditLeavetypeVM(leaveid, leavename, userid);
        }
    }
}