using dotMorten.Xamarin.Forms;
using HMS.Models;
using HMS.ViewModel.Admin;
using Rg.Plugins.Popup.Pages;
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
    public partial class ViewBlockByHostel : PopupPage
    {
        ViewFilteredBlockVM vm;
        public ObservableCollection<AreaModel> areaModels;
        public ViewBlockByHostel()
        {
            InitializeComponent();
            BindingContext = vm = new ViewFilteredBlockVM();
        }
        private void ddhostel_SelectedIndexChanged(object sender, EventArgs e)
        {
            App.hostelid = ddhostel.Items[ddhostel.SelectedIndex];
        }

        private async void btnviewblock_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new ViewBlock(App.hostelid));
        }

        private async void txtselectbyarea_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    areaModels = new ObservableCollection<AreaModel>();
                    if (vm.AreaLists != null)
                    {
                        foreach (var items in vm.AreaLists)
                        {
                            if (!string.IsNullOrEmpty(items.areaName) || items.areaName != null)
                            {
                                if (txtselectbyarea.Text != string.Empty)
                                {
                                    
                                    if (items.areaName.ToUpper().StartsWith(txtselectbyarea.Text.ToUpper()) || items.areaName.ToLower().StartsWith(txtselectbyarea.Text.ToLower()))
                                        areaModels.Add(items);
                                }
                            }
                        }
                        txtselectbyarea.ItemsSource = areaModels;
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
        private void txtselectbyarea_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            try
            {
                txtselectbyarea.Text = ((AreaModel)e.SelectedItem).areaName;
                string value = ((AreaModel)e.SelectedItem).id;
                App.areaid = value;
                vm.selectedarea(App.areaid);
            }
            catch (Exception ex)
            {

            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if(vm.HostelLists==null || vm.HostelLists.Count==0)
            {
                await App.Current.MainPage.DisplayAlert("HMS", "There Is No Hostel in selected area", "OK");
            }
            else
            {
                ddhostel.IsEnabled = true;
            }
        }
    }
}