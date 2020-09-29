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
    public partial class ViewRoomType : ContentPage
    {
        ViewRoomTypeVM vm;
        public ObservableCollection<RoomTypeModel> roomTypeModels;
        public ObservableCollection<RoomTypeModel> roomTypeModels1;
        public ViewRoomType()
        {
            InitializeComponent();
            BindingContext = vm = new ViewRoomTypeVM();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = vm = new ViewRoomTypeVM();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
        private void txtsearchbyroomtypename_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == dotMorten.Xamarin.Forms.AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    roomTypeModels = new ObservableCollection<RoomTypeModel>();
                    if (vm.RoomTypeModels != null)
                    {
                        foreach (var items in vm.RoomTypeModels)
                        {
                            if (!string.IsNullOrEmpty(items.name))
                            {
                                if (!string.IsNullOrEmpty(txtsearchbyroomtypename.Text))
                                {
                                    if (items.name.ToUpper().StartsWith(txtsearchbyroomtypename.Text.ToUpper()) || items.name.ToLower().StartsWith(txtsearchbyroomtypename.Text.ToLower()))
                                        roomTypeModels.Add(items);
                                }
                            }
                        }
                        txtsearchbyroomtypename.ItemsSource = roomTypeModels;
                    }
                }
            }
            catch
            {

            }
        }

        private void txtsearchbyroomtypename_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            txtsearchbyroomtypename.Text = ((RoomTypeModel)e.SelectedItem).name;
            roomTypeModels1 = new ObservableCollection<RoomTypeModel>();
            if(roomTypeModels!=null)
            {
                foreach(var items in roomTypeModels)
                {
                    if(txtsearchbyroomtypename.Text==items.name)
                    {
                        roomTypeModels1.Add(items);
                        break;
                    }
                }
                roombeddata.ItemsSource = roomTypeModels1;
            }
        }
    }
}