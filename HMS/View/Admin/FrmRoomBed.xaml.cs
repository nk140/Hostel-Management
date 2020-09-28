using dotMorten.Xamarin.Forms;
using HMS.Models;
using HMS.Services;
using HMS.ViewModel.Admin;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace HMS.View.Admin
{
    public partial class FrmRoomBed : ContentPage
    {
        public FrmRoomBed()
        {
            InitializeComponent();
        }

        RoomBedVM Vm;
        MasterServices web;
        ObservableCollection<AreaModel> ListArea;
        ObservableCollection<RoomNameList> roomListModels;
        ObservableCollection<BlockModel> blockModels;
        protected override void OnAppearing()
        {
            Vm = new RoomBedVM();
            BindingContext = Vm;
        }

        private void OnSelectedAreaItem(object sender, ItemTappedEventArgs e)
        {

            //  AreaModel md = (AreaModel)lv_area.SelectedItem;
            //  int cnt = Vm.AreaModelList.IndexOf(md);
            //  if (cnt >= 0)
            //  {
            //      Vm.AreaSelection(cnt);
            //  }

            //((ListView)sender).SelectedItem = null;
        }

        private void OnSelectedHostelItem(object sender, ItemTappedEventArgs e)
        {

            HostelModel md = (HostelModel)lv_hostel.SelectedItem;
            int cnt = Vm.HostelModelList.IndexOf(md);
            if (cnt >= 0)
            {
                Vm.HostelSelection(cnt);
            }

         ((ListView)sender).SelectedItem = null;
        }

        private async void txtsearchbykeyword_TextChanged(object sender, AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    ListArea = new ObservableCollection<AreaModel>();
                    if (Vm.AreaModelList != null)
                    {
                        foreach (var items in Vm.AreaModelList)
                        {
                            if (!string.IsNullOrEmpty(items.areaName) || items.areaName != null)
                            {
                                //VM.AreaVisible = !VM.AreaVisible;
                                if (txtsearchbykeyword.Text != string.Empty)
                                {
                                    Vm.AreaName = txtsearchbykeyword.Text;
                                    if (items.areaName.ToUpper().StartsWith(Vm.AreaName.ToUpper()) || items.areaName.ToLower().StartsWith(Vm.AreaName.ToLower()))
                                        ListArea.Add(items);
                                }
                            }
                        }
                        txtsearchbykeyword.ItemsSource = ListArea;
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
            try
            {
                Vm.AreaName = ((AreaModel)e.SelectedItem).areaName;
                Vm.AreaName = txtsearchbykeyword.DisplayMemberPath;
                AreaModel value = (AreaModel)e.SelectedItem;
                Vm.selectedarea(value.id);
            }
            catch (Exception ex)
            {

            }
        }
        private void txtsearchbyroomname_TextChanged(object sender, AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    roomListModels = new ObservableCollection<RoomNameList>();
                    if (Vm.RoomNameList != null)
                    {
                        foreach (var items in Vm.RoomNameList)
                        {
                            if(!string.IsNullOrEmpty(items.name))
                            {
                                if (txtsearchbyroomname.Text != string.Empty)
                                {
                                    if (items.name.ToUpper().StartsWith(txtsearchbyroomname.Text.ToUpper()) || items.name.ToLower().StartsWith(txtsearchbyroomname.Text.ToLower()))
                                        roomListModels.Add(items);
                                }
                              
                            }
                        }
                        txtsearchbyroomname.ItemsSource = roomListModels;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txtsearchbyroomname_SuggestionChosen(object sender, AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            try
            {
                txtsearchbyroomname.Text = ((RoomNameList)e.SelectedItem).name;
                EntryName.Text = ((RoomNameList)e.SelectedItem).name + "/";
                App.roomid = ((RoomNameList)e.SelectedItem).id;
            }
            catch (Exception ex)
            {

            }
        }

        private void txtsearchbyblock_TextChanged(object sender, AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    blockModels = new ObservableCollection<BlockModel>();
                    if (Vm.BlockModelList != null)
                    {
                        foreach (var items in Vm.BlockModelList)
                        {
                            if (!string.IsNullOrEmpty(items.name))
                            {
                                if (txtsearchbyblock.Text != string.Empty)
                                {
                                    if (items.name.ToUpper().StartsWith(txtsearchbyblock.Text.ToUpper()) || items.name.ToLower().StartsWith(txtsearchbyblock.Text.ToLower()))
                                        blockModels.Add(items);
                                }

                            }
                        }
                        txtsearchbyblock.ItemsSource = blockModels;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txtsearchbyblock_SuggestionChosen(object sender, AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            txtsearchbyblock.Text = ((BlockModel)e.SelectedItem).name;
            App.blockid = ((BlockModel)e.SelectedItem).id;
            Vm.Selectedblock(App.blockid);
        }
    }
}
