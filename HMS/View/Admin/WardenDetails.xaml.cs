using dotMorten.Xamarin.Forms;
using HMS.Models;
using HMS.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WardenDetails : ContentPage
    {
        WardenDetailVM vm;
        ObservableCollection<WardenInfoModel> Warden;
        ObservableCollection<WardenInfoModel> Warden1;
        public WardenDetails()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = vm = new WardenDetailVM();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
        private void txtsearchbywarden_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    Warden = new ObservableCollection<WardenInfoModel>();
                    if (vm.Warden != null)
                    {
                        foreach (var items in vm.Warden)
                        {
                            if (!string.IsNullOrEmpty(items.firstName))
                            {
                                if (!string.IsNullOrEmpty(txtsearchbywarden.Text))
                                {
                                    if (items.firstName.ToUpper().StartsWith(txtsearchbywarden.Text.ToUpper()) || items.firstName.ToLower().StartsWith(txtsearchbywarden.Text.ToLower()))
                                        Warden.Add(items);
                                }
                            }
                        }
                        txtsearchbywarden.ItemsSource = Warden;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txtsearchbywarden_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            txtsearchbywarden.Text = ((WardenInfoModel)e.SelectedItem).firstName;
            Warden1 = new ObservableCollection<WardenInfoModel>();
            if(Warden!=null || Warden.Count==0)
            {
                foreach(var items in Warden)
                {
                    if(txtsearchbywarden.Text==items.firstName)
                    {
                        Warden1.Add(items);
                        break;
                    }
                }
            }
            lv_contact.ItemsSource = Warden1;
        }
    }
}