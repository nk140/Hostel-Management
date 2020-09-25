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
    public partial class ViewRoom : ContentPage
    {
        ViewRoomVM vm;
        public ObservableCollection<RoomNameList> roomNameLists;
        public ObservableCollection<RoomNameList> roomNameLists1;
        public ViewRoom()
        {
            InitializeComponent();
        }
        public ViewRoom(string hostelid,string blockid)
        {
            InitializeComponent();
            BindingContext = vm = new ViewRoomVM(hostelid, blockid);
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
    }
}