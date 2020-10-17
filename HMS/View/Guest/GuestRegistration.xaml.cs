
using HMS.Models;
using HMS.ViewModel.Guest;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Guest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GuestRegistration : ContentPage
    {
        GuestRegistrationViewModel vm;
        public ObservableCollection<AreaModel> areaModels;
        public GuestRegistration()
        {
            InitializeComponent();
            BindingContext = vm = new GuestRegistrationViewModel();
        }

        private void txtsearchbyarea_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            
        }

        private void txtsearchbyarea_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            
        }
    }
}