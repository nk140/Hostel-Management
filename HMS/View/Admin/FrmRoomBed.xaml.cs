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
    }
}
