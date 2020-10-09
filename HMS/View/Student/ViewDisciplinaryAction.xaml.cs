﻿using HMS.Models;
using HMS.ViewModel.Student;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Student
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewDisciplinaryAction : ContentPage
    {
        ViewStudentDisciplinaryActionVM vm;
        public ViewDisciplinaryAction()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = vm = new ViewStudentDisciplinaryActionVM();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}