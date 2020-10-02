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
    public partial class ViewFacility : ContentPage
    {
        ViewFacilityVM vm;
        ObservableCollection<Models.ViewFacility> viewFacilities;
        ObservableCollection<Models.ViewFacility> viewFacilities1;
        public ViewFacility()
        {
            InitializeComponent();
            BindingContext = vm = new ViewFacilityVM();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = vm = new ViewFacilityVM();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
        private void txtsearchbyfloor_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == dotMorten.Xamarin.Forms.AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    viewFacilities = new ObservableCollection<Models.ViewFacility>();
                    if (vm.ViewFacilities != null)
                    {
                        foreach (var items in vm.ViewFacilities)
                        {
                            if (!string.IsNullOrEmpty(items.name))
                            {
                                if (!string.IsNullOrEmpty(txtsearchbyfloor.Text))
                                {
                                    if (items.name.ToUpper().StartsWith(txtsearchbyfloor.Text.ToUpper()) || items.name.ToLower().StartsWith(txtsearchbyfloor.Text.ToLower()))
                                        viewFacilities.Add(items);
                                }
                            }
                        }
                        txtsearchbyfloor.ItemsSource = viewFacilities;
                    }
                }
            }
            catch
            {

            }
        }

        private void txtsearchbyfloor_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            txtsearchbyfloor.Text = ((Models.ViewFacility)e.SelectedItem).name;
            viewFacilities1 = new ObservableCollection<Models.ViewFacility>();
            if (viewFacilities != null)
            {
                foreach (var items in viewFacilities)
                {
                    if (txtsearchbyfloor.Text == items.name)
                        viewFacilities1.Add(items);
                }
                blocklist.ItemsSource = viewFacilities1;
            }
        }
    }
}