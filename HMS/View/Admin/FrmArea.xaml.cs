using dotMorten.Xamarin.Forms;
using HMS.Models;
using HMS.ViewModel.Admin;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace HMS.View.Admin
{
    public partial class FrmArea : ContentPage
    {
        public FrmArea()
        {
            InitializeComponent();
        }

        AreaVM Vm;
        ObservableCollection<CountryModel> ListCountry;
        protected override void OnAppearing()
        {
            Vm = new AreaVM();
            BindingContext = Vm;
        }

        private void OnSelectedCountryItem(object sender, ItemTappedEventArgs e)
        {

            //  CountryModel md = (CountryModel)lv_country.SelectedItem;
            //  int cnt = Vm.CountryModel.IndexOf(md);
            //  if (cnt >= 0)
            //  {
            //      Vm.CountrySelection(cnt);
            //  }

            //((ListView)sender).SelectedItem = null;
        }


        private void OnSelectedStateItem(object sender, ItemTappedEventArgs e)
        {

            StateModel md = (StateModel)lv_state.SelectedItem;
            int cnt = Vm.StateModel.IndexOf(md);
            if (cnt >= 0)
            {
                Vm.StateSelection(cnt);
            }

          ((ListView)sender).SelectedItem = null;
        }

        private void OnSelectedAreaItem(object sender, ItemTappedEventArgs e)
        {

            //  AreaModel md = (AreaModel)lv_area.SelectedItem;
            //  int cnt = Vm.AreaModel.IndexOf(md);
            //  if (cnt >= 0)
            //  {
            //      Vm.AreaSelection(cnt);
            //  }

            //((ListView)sender).SelectedItem = null;
        }

        private async void txtsearchbykeyword_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    ListCountry = new ObservableCollection<CountryModel>();
                    if (Vm.CountryModel != null)
                    {
                        foreach (var items in Vm.CountryModel)
                        {
                            if (!string.IsNullOrEmpty(items.country) || items.country != null)
                            {
                                //VM.AreaVisible = !VM.AreaVisible;
                                if (txtsearchbykeyword.Text != string.Empty)
                                {
                                    Vm.CountryName = txtsearchbykeyword.Text;
                                    if (items.country.ToUpper().StartsWith(Vm.CountryName.ToUpper()) || items.country.ToLower().StartsWith(Vm.CountryName.ToLower()))
                                        ListCountry.Add(items);
                                }
                            }
                        }
                        txtsearchbykeyword.ItemsSource = ListCountry;
                    }
                    else
                    {
                        await DisplayAlert("HMS", "No Matching Area Name", "OK");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txtsearchbykeyword_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            Vm.CountryName = ((CountryModel)e.SelectedItem).country;
            CountryModel md = (CountryModel)e.SelectedItem;
            int cnt = Vm.CountryModel.IndexOf(md);
            Vm.CountrySelection(cnt);
        }
    }
}
