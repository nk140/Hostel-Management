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
        public ObservableCollection<BlockModel> blockModels;
        public ObservableCollection<HostelModel> hostelModels;
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
                txtsearchbyhostelname.IsEnabled = true;
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            if (vm.BlockModelList.Count == 0)
                App.Current.MainPage.DisplayAlert("HMS", "No Block", "OK");
            else
                txtsearchbyblockname.IsEnabled = true;
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
            //App.hostelid = ddhostel.Items[ddhostel.SelectedIndex];
            //vm.selectedhostel(App.hostelid);
        }

        private void ddblock_SelectedIndexChanged(object sender, EventArgs e)
        {
            //App.blockid = ddblock.Items[ddblock.SelectedIndex];
            //vm.selectedhostelandblock(App.hostelid, App.blockid);
        }

        private void ddroomname_SelectedIndexChanged(object sender, EventArgs e)
        {
            roomname = ddroomname.Items[ddroomname.SelectedIndex];
        }

        private void txtsearchbyhostelname_TextChanged(object sender, AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    hostelModels = new ObservableCollection<HostelModel>();
                    if (vm.HostelLists != null)
                    {
                        foreach (var items in vm.HostelLists)
                        {
                            if (!string.IsNullOrEmpty(items.hostelName) || items.hostelName != null)
                            {
                                if (txtsearchbyhostelname.Text != string.Empty)
                                {

                                    if (items.hostelName.ToUpper().StartsWith(txtsearchbyhostelname.Text.ToUpper()) || items.hostelName.ToLower().StartsWith(txtsearchbyhostelname.Text.ToLower()))
                                        hostelModels.Add(items);
                                }
                            }
                        }
                        txtsearchbyhostelname.ItemsSource = hostelModels;
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

        private void txtsearchbyhostelname_SuggestionChosen(object sender, AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            txtsearchbyhostelname.Text = ((HostelModel)e.SelectedItem).hostelName;
            App.hostelid = ((HostelModel)e.SelectedItem).id;
            vm.selectedhostel(App.hostelid);
        }

        private void txtsearchbyblockname_TextChanged(object sender, AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    blockModels = new ObservableCollection<BlockModel>();
                    if (vm.BlockModelList != null)
                    {
                        foreach (var items in vm.BlockModelList)
                        {
                            if (!string.IsNullOrEmpty(items.name) || items.name != null)
                            {
                                if (txtsearchbyblockname.Text != string.Empty)
                                {

                                    if (items.name.ToUpper().StartsWith(txtsearchbyblockname.Text.ToUpper()) || items.name.ToLower().StartsWith(txtsearchbyblockname.Text.ToLower()))
                                        blockModels.Add(items);
                                }
                            }
                        }
                        txtsearchbyblockname.ItemsSource = blockModels;
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

        private void txtsearchbyblockname_SuggestionChosen(object sender, AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            txtsearchbyblockname.Text = ((BlockModel)e.SelectedItem).name;
            App.blockid = ((BlockModel)e.SelectedItem).id;
            vm.selectedhostelandblock(App.hostelid, App.blockid);
        }
    }
}