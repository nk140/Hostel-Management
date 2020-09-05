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
    public partial class Frmservicecategory : ContentPage
    {
        ServiceCategory vm;
        ObservableCollection<WardenServiceModel> serviceCategories;
        ObservableCollection<WardenServiceModel> serviceCategories1;
        public Frmservicecategory()
        {
            InitializeComponent();
            BindingContext = vm = new ServiceCategory();
            //_listView.ItemsSource = vm.WardenServiceData;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            //_listView.ItemsSource = vm.WardenServiceData;
        }
        private void txtsearchbykeyword_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    serviceCategories = new ObservableCollection<WardenServiceModel>();
                    if (vm.WardenServiceData != null)
                    {
                        foreach (var items in vm.WardenServiceData)
                        {
                            if (!string.IsNullOrEmpty(items.id.ToString()))
                            {
                                if (!string.IsNullOrEmpty(txtsearchbykeyword.Text))
                                {
                                    if (items.id.ToString().StartsWith(txtsearchbykeyword.Text))
                                        serviceCategories.Add(items);
                                }
                            }
                        }
                        txtsearchbykeyword.ItemsSource = serviceCategories;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void txtsearchbykeyword_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            try
            {
                txtsearchbykeyword.Text = ((WardenServiceModel)e.SelectedItem).id.ToString();
                serviceCategories1 = new ObservableCollection<WardenServiceModel>();
                foreach (var items in serviceCategories)
                {
                    if (items.id.ToString() == txtsearchbykeyword.Text)
                        serviceCategories1.Add(items);
                }
                _listView.ItemsSource = serviceCategories1;
            }
            catch (Exception ex)
            {

            }
        }
    }
}