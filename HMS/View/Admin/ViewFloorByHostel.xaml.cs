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
    public partial class ViewFloorByHostel : PopupPage
    {
        ViewFilteredFloorVM vm;
        public ObservableCollection<AreaModel> areaModels;
        public ViewFloorByHostel()
        {
            InitializeComponent();
            BindingContext = vm = new ViewFilteredFloorVM();
        }

        private void txtselectbyarea_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
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
                        DisplayAlert("HMS", "No Matching Area Name", "OK");
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
                AreaModel value = (AreaModel)e.SelectedItem;
                vm.selectedarea(value.id);
            }
            catch (Exception ex)
            {

            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if(vm.HostelLists.Count==0)
            {
                App.Current.MainPage.DisplayAlert("HMS", "No Hostel", "OK");
            }
            else
            {
                ddhostel.IsEnabled = true;
            }
        }

        private void btnviewblock_Clicked(object sender, EventArgs e)
        {
            if(vm.HostelLists!=null || vm.HostelLists.Count==0)
            {
                App.Current.MainPage.DisplayAlert("HMS", "No Hostel Found", "OK");
            }
            else
            {
                ddhostel.IsEnabled = true;
            }
        }

        private void ddhostel_SelectedIndexChanged(object sender, EventArgs e)
        {
            App.hostelid = ddhostel.Items[ddhostel.SelectedIndex];
            vm.selectedhostel(App.hostelid);
        }

        private async void btnviewblock_Clicked_1(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new ViewFloor(App.hostelid));
        }

        private void ddblock_SelectedIndexChanged(object sender, EventArgs e)
        {
            App.blockid = ddblock.Items[ddblock.SelectedIndex];
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            if(vm.BlockModelList.Count==0)
            {
                App.Current.MainPage.DisplayAlert("HMS", "No Block List", "OK");
            }
            else
            {
                ddblock.IsEnabled = true;
            }
        }
    }
}