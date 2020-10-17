using dotMorten.Xamarin.Forms;
using HMS.Models;
using HMS.ViewModel.Warden;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Warden
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmStudentParentContact : ContentPage
    {
        StudentParentInfo vm;
        public ObservableCollection<StudentParentDetail> studentParentDetails;
        public ObservableCollection<StudentParentDetail> studentParentDetails1;
        public FrmStudentParentContact()
        {
            InitializeComponent();
            BindingContext = vm = new StudentParentInfo();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = vm = new StudentParentInfo();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
        private void txtsearchbykeyword_TextChanged(object sender, AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == dotMorten.Xamarin.Forms.AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    studentParentDetails = new ObservableCollection<StudentParentDetail>();
                    if (vm.StudentParentDetails != null)
                    {
                        foreach (var items in vm.StudentParentDetails)
                        {
                            if (!string.IsNullOrEmpty(items.parentName))
                            {
                                if (!string.IsNullOrEmpty(txtsearchbykeyword.Text))
                                {
                                    if (items.parentName.ToUpper().StartsWith(txtsearchbykeyword.Text.ToUpper()) || items.parentName.ToLower().StartsWith(txtsearchbykeyword.Text.ToLower()))
                                        studentParentDetails.Add(items);
                                }
                            }
                        }
                        txtsearchbykeyword.ItemsSource = studentParentDetails;
                    }
                }
            }
            catch
            {

            }
        }

        private void txtsearchbykeyword_SuggestionChosen(object sender, AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            txtsearchbykeyword.Text = ((StudentParentDetail)e.SelectedItem).parentName;
            studentParentDetails1 = new ObservableCollection<StudentParentDetail>();
            if (studentParentDetails != null)
            {
                foreach (var items in studentParentDetails)
                {
                    if (txtsearchbykeyword.Text == items.parentName)
                        studentParentDetails1.Add(items);
                }
                lv_contact.ItemsSource = studentParentDetails1;
            }
        }

        private void txtsearchbykeyword_Unfocused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(txtsearchbykeyword.Text))
                lv_contact.ItemsSource = vm.StudentParentDetails;
        }
    }
}