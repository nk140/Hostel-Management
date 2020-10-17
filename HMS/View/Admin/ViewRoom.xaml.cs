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
    public partial class ViewRoom : ContentPage
    {
        ViewRoomVM vm;
        string blockids, hostelids, floorids;
        public ObservableCollection<RoomNameList> roomNameLists;
        public ObservableCollection<RoomNameList> roomNameLists1;
        public ViewRoom()
        {
            InitializeComponent();
        }
        public ViewRoom(string hostelid,string blockid,string floorid)
        {
            InitializeComponent();
            hostelids = hostelid;
            blockids = blockid;
            floorids = floorid;
            BindingContext = vm = new ViewRoomVM(hostelid, blockid,floorid);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = vm = new ViewRoomVM(hostelids, blockids,floorids);
        }
        private void txtsearchbyroomname_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == dotMorten.Xamarin.Forms.AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    roomNameLists = new ObservableCollection<RoomNameList>();
                    if (vm.RoomNameLists != null)
                    {
                        foreach (var items in vm.RoomNameLists)
                        {
                            if (!string.IsNullOrEmpty(items.name))
                            {
                                if (!string.IsNullOrEmpty(txtsearchbyroomname.Text))
                                {
                                    if (items.name.ToUpper().StartsWith(txtsearchbyroomname.Text.ToUpper()) || items.name.ToLower().StartsWith(txtsearchbyroomname.Text.ToLower()))
                                        roomNameLists.Add(items);
                                }
                            }
                        }
                        txtsearchbyroomname.ItemsSource = roomNameLists;
                    }
                }
            }
            catch
            {

            }
        }

        private void txtsearchbyroomname_Unfocused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(txtsearchbyroomname.Text))
                FloorDetaillists1.ItemsSource = vm.RoomNameLists;
        }

        private void txtsearchbyroomname_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            txtsearchbyroomname.Text = ((RoomNameList)e.SelectedItem).name;
            roomNameLists1 = new ObservableCollection<RoomNameList>();
            if (roomNameLists != null)
            {
                foreach (var items in roomNameLists)
                {
                    if (txtsearchbyroomname.Text == items.name)
                        roomNameLists1.Add(items);
                }
                FloorDetaillists1.ItemsSource = roomNameLists1;
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PopModalAsync(true);
           // await App.Current.MainPage.Navigation.PushPopupAsync(new FilterRoomPopup(App.hostelid), true);
        }
    }
}