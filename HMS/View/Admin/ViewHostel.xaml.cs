using HMS.Models;
using HMS.ViewModel.Admin;
using Rg.Plugins.Popup.Extensions;
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
    public partial class ViewHostel : ContentPage
    {
        ViewHostelVM vm;
        string areaids;
        public ObservableCollection<HostelModel> hostelModels;
        public ObservableCollection<HostelModel> hostelModels1;
        public ViewHostel(string areaid)
        {
            InitializeComponent();
            areaids = areaid;
            BindingContext = vm = new ViewHostelVM(areaid);
            //viewhostel.ItemsSource = vm.HostelDetaillists;
        }
        public ViewHostel()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if(!string.IsNullOrEmpty(App.filterno))
            {
                BindingContext = vm = new ViewHostelVM(App.filterno);
            }
            else
            BindingContext = vm = new ViewHostelVM(areaids);
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
        private void txtsearchbyhostelname_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == dotMorten.Xamarin.Forms.AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    hostelModels = new ObservableCollection<HostelModel>();
                    if (vm.HostelLists != null)
                    {
                        foreach (var items in vm.HostelLists)
                        {
                            if (!string.IsNullOrEmpty(items.hostelName))
                            {
                                if (!string.IsNullOrEmpty(txtsearchbyhostelname.Text))
                                {
                                    if (items.hostelName.ToUpper().StartsWith(txtsearchbyhostelname.Text.ToUpper()) || items.hostelName.ToLower().StartsWith(txtsearchbyhostelname.Text.ToLower()))
                                        hostelModels.Add(items);
                                }
                            }
                        }
                        txtsearchbyhostelname.ItemsSource = hostelModels;
                    }
                }
            }
            catch
            {

            }
        }

        private void txtsearchbyhostelname_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            txtsearchbyhostelname.Text = ((HostelModel)e.SelectedItem).hostelName;
            hostelModels1 = new ObservableCollection<HostelModel>();
            if (hostelModels != null)
            {
                foreach (var items in hostelModels)
                {
                    if (txtsearchbyhostelname.Text == items.hostelName)
                        hostelModels1.Add(items);
                }
                viewhostel.ItemsSource = hostelModels1;
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            
        }

        private void txtsearchbyhostelname_Unfocused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(txtsearchbyhostelname.Text))
                viewhostel.ItemsSource = vm.HostelLists;
        }
    }
}