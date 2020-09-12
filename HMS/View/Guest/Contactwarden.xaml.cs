
using dotMorten.Xamarin.Forms;
using HMS.Models;
using HMS.ViewModel.Guest;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Guest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Contactwarden : ContentPage
    {
        ContactWardenVM vm;
        public ObservableCollection<WardenInfoModel> wardenInfos;
        public ObservableCollection<WardenInfoModel> infoModels;
        public Contactwarden()
        {
            InitializeComponent();
            BindingContext = vm = new ContactWardenVM();
        }

        private void txtsearchbykeyword_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    wardenInfos = new ObservableCollection<WardenInfoModel>();
                    if (vm.WardenInfoModels != null)
                    {
                        foreach (var items in vm.WardenInfoModels)
                        {
                            if (!string.IsNullOrEmpty(items.firstName))
                            {
                                if (!string.IsNullOrEmpty(txtsearchbykeyword.Text))
                                {
                                    if (items.firstName.ToUpper().StartsWith(txtsearchbykeyword.Text.ToUpper()) || items.firstName.ToLower().StartsWith(txtsearchbykeyword.Text.ToLower()))
                                        wardenInfos.Add(items);
                                }
                            }
                        }
                        txtsearchbykeyword.ItemsSource = wardenInfos;
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
                txtsearchbykeyword.Text = ((WardenInfoModel)e.SelectedItem).firstName;
                infoModels = new ObservableCollection<WardenInfoModel>();
                if (wardenInfos != null)
                {
                    foreach (var items in wardenInfos)
                    {
                        if (txtsearchbykeyword.Text == items.firstName)
                        {
                            if(!string.IsNullOrEmpty(items.contact))
                            {
                                infoModels.Add(items);
                                break;
                            } 
                        }
                    }
                }
                if(infoModels==null)
                {
                    _listView.ItemsSource = null;
                    App.Current.MainPage.DisplayAlert("HMS", "No contact no found for the entered name", "OK");
                }
                else
                _listView.ItemsSource = infoModels;
            }
            catch (Exception ex)
            {

            }
        }
    }
}