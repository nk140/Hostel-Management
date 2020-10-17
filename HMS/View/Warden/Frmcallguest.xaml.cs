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
    public partial class Frmcallguest : ContentPage
    {
        GuestContactList vm;
        public ObservableCollection<GuestModel> guests;
        public ObservableCollection<GuestModel> GuestModels;
        public Frmcallguest()
        {
            InitializeComponent();
            BindingContext = vm = new GuestContactList();
        }

        private void txtsearchbykeyword_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    guests = new ObservableCollection<GuestModel>();
                    if (vm.listofguests != null)
                    {
                        foreach (var items in vm.listofguests)
                        {
                            if (!string.IsNullOrEmpty(items.Name))
                            {
                                if (!string.IsNullOrEmpty(txtsearchbykeyword.Text))
                                {
                                    if (items.Name.ToUpper().StartsWith(txtsearchbykeyword.Text.Trim().ToUpper()) || items.Name.ToLower().StartsWith(txtsearchbykeyword.Text.Trim().ToLower()))
                                        guests.Add(items);
                                }
                            }
                        }
                        txtsearchbykeyword.ItemsSource = guests;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txtsearchbykeyword_SuggestionChosen(object sender, AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            try
            {
                txtsearchbykeyword.Text = ((GuestModel)e.SelectedItem).Name;
                if (guests != null)
                {
                    GuestModels = new ObservableCollection<GuestModel>();
                    foreach (var items in guests)
                    {
                        if (items.Name == txtsearchbykeyword.Text)
                            GuestModels.Add(items);
                    }
                }
                lv_contact.ItemsSource = GuestModels;
            }
            catch (Exception ex)
            {

            }
        }

        private void txtsearchbykeyword_Unfocused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(txtsearchbykeyword.Text))
                lv_contact.ItemsSource = vm.listofguests;
        }
    }
}