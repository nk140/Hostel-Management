using dotMorten.Xamarin.Forms;
using HMS.Models;
using HMS.ViewModel.Admin;
using Rg.Plugins.Popup.Extensions;
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
        string hostelids, blockids;
        public ObservableCollection<AreaModel> areaModels;
        public ObservableCollection<BlockModel> blockModels;
        public ObservableCollection<HostelModel> hostelModels;
        public ViewFloorByHostel()
        {
            InitializeComponent();
            BindingContext = vm = new ViewFilteredFloorVM();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = vm = new ViewFilteredFloorVM();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            App.hostelid = string.Empty;
            App.blockid = string.Empty;
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
                txtsearchbyhostelname.IsEnabled = true;
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
                txtsearchbyhostelname.IsEnabled = true;
            }
        }

        private void ddhostel_SelectedIndexChanged(object sender, EventArgs e)
        {
            //App.hostelid = ddhostel.Items[ddhostel.SelectedIndex];
            //vm.selectedhostel(App.hostelid);
        }

        private async void btnviewblock_Clicked_1(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(App.hostelid))
            {
                await App.Current.MainPage.DisplayAlert("HMS", "Please Enter Hostel Name", "OK");
            }
            else if(string.IsNullOrEmpty(App.blockid))
            {
                await App.Current.MainPage.DisplayAlert("HMS", "Please Enter Block Name", "OK");
            }
            else if (string.IsNullOrEmpty(hostelids))
            {
                await App.Current.MainPage.DisplayAlert("HMS", "Please Enter Hostel Name", "OK");
            }
            else if (string.IsNullOrEmpty(blockids))
            {
                await App.Current.MainPage.DisplayAlert("HMS", "Please Enter Block Name", "OK");
            }
            else
            {
                await App.Current.MainPage.Navigation.PushModalAsync(new ViewFloor(hostelids,blockids));
                await App.Current.MainPage.Navigation.PopPopupAsync(true);
            }
        }

        private void ddblock_SelectedIndexChanged(object sender, EventArgs e)
        {
            //App.blockid = ddblock.Items[ddblock.SelectedIndex];
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            if(vm.BlockModelList.Count==0)
            {
                App.Current.MainPage.DisplayAlert("HMS", "No Block List", "OK");
            }
            else
            {
                txtsearchbyblockname.IsEnabled = true;
            }
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
            hostelids = App.hostelid;
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
            blockids = App.blockid;
        }
    }
}