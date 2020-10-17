using HMS.Models;
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
    public partial class ViewRoomBed : ContentPage
    {
        ViewRoomBedVM vm;
        string Roomname, HostelId;
        public ObservableCollection<RoomBedData> roomBedDatas;
        public ObservableCollection<RoomBedData> roomBedDatas1;
        public ViewRoomBed()
        {
            InitializeComponent();
        }
        public ViewRoomBed(string roomname, string hostelid)
        {
            InitializeComponent();
            Roomname = roomname;
            HostelId = hostelid;
            BindingContext = vm = new ViewRoomBedVM(roomname, hostelid);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = vm = new ViewRoomBedVM(Roomname, HostelId);
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
        private void txtsearchbyroombed_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == dotMorten.Xamarin.Forms.AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    roomBedDatas = new ObservableCollection<RoomBedData>();
                    if(vm.RoomBedDatas!=null)
                    {
                        foreach(var items in vm.RoomBedDatas)
                        {
                            if(!string.IsNullOrEmpty(items.bedNo))
                            {
                                if(!string.IsNullOrEmpty(txtsearchbyroombed.Text))
                                {
                                    if (items.bedNo.ToUpper().StartsWith(txtsearchbyroombed.Text.ToUpper()) || items.bedNo.ToLower().StartsWith(txtsearchbyroombed.Text.ToLower()))
                                        roomBedDatas.Add(items);
                                }
                            }
                        }
                        txtsearchbyroombed.ItemsSource = roomBedDatas;
                    }
                }
            }
            catch
            {

            }
        }

        private void txtsearchbyroombed_Unfocused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(txtsearchbyroombed.Text))
                roombeddata.ItemsSource = vm.RoomBedDatas;
        }

        private void txtsearchbyroombed_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            txtsearchbyroombed.Text = ((RoomBedData)e.SelectedItem).bedNo;
            roomBedDatas1 = new ObservableCollection<RoomBedData>();
            if(roomBedDatas!=null)
            {
                foreach(var items in roomBedDatas)
                {
                    if (txtsearchbyroombed.Text == items.bedNo)
                        roomBedDatas1.Add(items);
                }
                roombeddata.ItemsSource = roomBedDatas1;
            }
        }
    }
}