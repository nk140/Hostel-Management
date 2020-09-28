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
    public partial class ViewRoomByHostel : PopupPage
    {
        ViewFilteredRoomVM vm;
        public ObservableCollection<AreaModel> areaModels;
        public ObservableCollection<FloorData> floorDatas;
        public ViewRoomByHostel()
        {
            InitializeComponent();
            BindingContext = vm = new ViewFilteredRoomVM();
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

        private void ddhostel_SelectedIndexChanged(object sender, EventArgs e)
        {
            App.hostelid = ddhostel.Items[ddhostel.SelectedIndex];
            vm.selectedblock(App.hostelid);
        }

        private void ddblock_SelectedIndexChanged(object sender, EventArgs e)
        {
            App.blockid = ddblock.Items[ddblock.SelectedIndex];
        }

        private async void btnviewroom_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new ViewRoom(App.hostelid, App.blockid),true);
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (vm.BlockModelList.Count == 0)
                App.Current.MainPage.DisplayAlert("HMS", "No Block", "OK");
            else
                ddblock.IsEnabled = true;
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            if (vm.HostelLists.Count == 0)
                App.Current.MainPage.DisplayAlert("HMS", "No hostel", "OK");
            else
                ddhostel.IsEnabled = true;
        }

        private void txtsearchbyfloorname_TextChanged(object sender, AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    floorDatas = new ObservableCollection<FloorData>();
                    if (vm.FloorModelList != null)
                    {
                        foreach (var items in vm.FloorModelList)
                        {
                            if (!string.IsNullOrEmpty(items.floorNo) || items.floorNo != null)
                            {
                                if (txtsearchbyfloorname.Text != string.Empty)
                                {

                                    if (items.floorNo.ToUpper().StartsWith(txtsearchbyfloorname.Text.ToUpper()) || items.floorNo.ToLower().StartsWith(txtsearchbyfloorname.Text.ToLower()))
                                        floorDatas.Add(items);
                                }
                            }
                        }
                        txtsearchbyfloorname.ItemsSource = floorDatas;
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

        private void txtsearchbyfloorname_SuggestionChosen(object sender, AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            txtsearchbyfloorname.Text = ((FloorData)e.SelectedItem).floorNo;
            var value = ((FloorData)e.SelectedItem).id;
            App.floorid = value.ToString();
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            if (vm.FloorModelList.Count == 0)
                App.Current.MainPage.DisplayAlert("HMS", "No Floor Found", "OK");
            else
                txtsearchbyfloorname.IsEnabled = true;
        }
    }
}