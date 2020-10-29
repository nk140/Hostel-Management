
using HMS.Models;
using HMS.ViewModel.Warden;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Warden
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Frmviewservicerequest : ContentPage
    {
        viewrequestedservicebystudentVM vm;
        public ObservableCollection<ViewRequestedServiceModel> viewRequestedServiceModels;
        public ObservableCollection<ViewRequestedServiceModel> viewRequestedServiceModels1;
        public Frmviewservicerequest()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = vm = new viewrequestedservicebystudentVM();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        private void txtsearchstudentname_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == dotMorten.Xamarin.Forms.AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    viewRequestedServiceModels = new ObservableCollection<ViewRequestedServiceModel>();
                    if (vm.ViewRequestedServiceModels != null)
                    {
                        foreach (var items in vm.ViewRequestedServiceModels)
                        {
                            if (!string.IsNullOrEmpty(items.studentName))
                            {
                                if (!string.IsNullOrEmpty(txtsearchstudentname.Text))
                                {
                                    if (items.studentName.ToUpper().StartsWith(txtsearchstudentname.Text.ToUpper()) || items.studentName.ToLower().StartsWith(txtsearchstudentname.Text.ToLower()))
                                        viewRequestedServiceModels.Add(items);
                                }
                            }
                        }
                        txtsearchstudentname.ItemsSource = viewRequestedServiceModels;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txtsearchstudentname_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            txtsearchstudentname.Text = ((ViewRequestedServiceModel)e.SelectedItem).studentName;
            viewRequestedServiceModels1 = new ObservableCollection<ViewRequestedServiceModel>();
            if (viewRequestedServiceModels != null)
            {
                foreach (var items in viewRequestedServiceModels)
                {
                    if (txtsearchstudentname.Text == items.studentName)
                        viewRequestedServiceModels1.Add(items);
                }
                lstdisciplinaryaction.ItemsSource = viewRequestedServiceModels1;
            }
        }

        private void txtsearchstudentname_Unfocused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(txtsearchstudentname.Text))
                lstdisciplinaryaction.ItemsSource = vm.ViewRequestedServiceModels;
        }
    }
}