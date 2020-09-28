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
    public partial class ViewRoomBedOption : PopupPage
    {
        ViewFilteredRoombedVM vm;
        string roomname;
        public ObservableCollection<AreaModel> areaModels;
        public ViewRoomBedOption()
        {
            InitializeComponent();
            BindingContext = vm = new ViewFilteredRoombedVM();
        }

        private async void btnviewroombed_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new ViewRoomBed(roomname, App.hostelid));
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
            if (vm.HostelLists.Count == 0)
                App.Current.MainPage.DisplayAlert("HMS", "No Hostel", "OK");
            else
                ddhostel.IsEnabled = true;
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            if (vm.BlockModelList.Count == 0)
                App.Current.MainPage.DisplayAlert("HMS", "No Block", "OK");
            else
                ddblock.IsEnabled = true;
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            if (vm.RoomNameLists.Count == 0)
                App.Current.MainPage.DisplayAlert("HMS", "No Room List", "OK");
            else
                ddroomname.IsEnabled = true;
        }

        private void ddhostel_SelectedIndexChanged(object sender, EventArgs e)
        {
            App.hostelid = ddhostel.Items[ddhostel.SelectedIndex];
            vm.selectedhostel(App.hostelid);
        }

        private void ddblock_SelectedIndexChanged(object sender, EventArgs e)
        {
            App.blockid = ddblock.Items[ddblock.SelectedIndex];
            vm.selectedhostelandblock(App.hostelid, App.blockid);
        }

        private void ddroomname_SelectedIndexChanged(object sender, EventArgs e)
        {
            roomname = ddroomname.Items[ddroomname.SelectedIndex];
        }
    }
}