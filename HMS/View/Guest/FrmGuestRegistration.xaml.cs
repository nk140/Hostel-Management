using HMS.Models;
using HMS.ViewModel.Guest;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Guest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmGuestRegistration : ContentPage
    {
        GuestRegBeforeLoginVM vm;
        string hostelid, blockid;
        public ObservableCollection<AreaModel> areaModels;
        public ObservableCollection<HostelModel> hostelModels;
        public ObservableCollection<BlockModel> blockModels;
        public ObservableCollection<RoomNameList> roomNameLists;
        public FrmGuestRegistration()
        {
            InitializeComponent();
            BindingContext = vm = new GuestRegBeforeLoginVM();
        }

        private void login_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new FrmLogin();
        }

        private void txtsearchbyarea_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            //try
            //{
            //    if (e.Reason == dotMorten.Xamarin.Forms.AutoSuggestionBoxTextChangeReason.UserInput)
            //    {
            //        areaModels = new ObservableCollection<AreaModel>();
            //        if (vm.AreaLists != null)
            //        {
            //            foreach (var items in vm.AreaLists)
            //            {
            //                if (!string.IsNullOrEmpty(items.areaName))
            //                {
            //                    if (!string.IsNullOrEmpty(txtsearchbyarea.Text))
            //                    {
            //                        if (items.areaName.ToUpper().StartsWith(txtsearchbyarea.Text.ToUpper()) || items.areaName.ToLower().StartsWith(txtsearchbyarea.Text.ToLower()))
            //                            areaModels.Add(items);
            //                    }
            //                }
            //            }
            //            txtsearchbyarea.ItemsSource = areaModels;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{

            //}
        }

        private void txtsearchbyarea_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            //txtsearchbyarea.Text = ((AreaModel)e.SelectedItem).areaName;
            //vm.GetHostelList(((AreaModel)e.SelectedItem).id);
        }

        private void txtsearchbyhostel_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            //try
            //{
            //    if (e.Reason == dotMorten.Xamarin.Forms.AutoSuggestionBoxTextChangeReason.UserInput)
            //    {
            //        hostelModels = new ObservableCollection<HostelModel>();
            //        if (vm.HostelLists != null)
            //        {
            //            foreach (var items in vm.HostelLists)
            //            {
            //                if (!string.IsNullOrEmpty(items.hostelName))
            //                {
            //                    if (!string.IsNullOrEmpty(txtsearchbyhostel.Text))
            //                    {
            //                        if (items.hostelName.ToUpper().StartsWith(txtsearchbyhostel.Text.ToUpper()) || items.hostelName.ToLower().StartsWith(txtsearchbyhostel.Text.ToLower()))
            //                            hostelModels.Add(items);
            //                    }
            //                }
            //            }
            //            txtsearchbyhostel.ItemsSource = hostelModels;
            //        }
            //    }
            //}
            //catch
            //{

            //}
        }

        private void txtsearchbyhostel_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            //txtsearchbyhostel.Text = ((HostelModel)e.SelectedItem).hostelName;
            //hostelid= ((HostelModel)e.SelectedItem).id;
            //vm.GetAllblocklist(hostelid);
        }

        private void txtsearchbyblock_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            //try
            //{
            //    if (e.Reason == dotMorten.Xamarin.Forms.AutoSuggestionBoxTextChangeReason.UserInput)
            //    {
            //        blockModels = new ObservableCollection<BlockModel>();
            //        if (vm.BlockModelList != null)
            //        {
            //            foreach (var items in vm.BlockModelList)
            //            {
            //                if (!string.IsNullOrEmpty(items.name))
            //                {
            //                    if (!string.IsNullOrEmpty(txtsearchbyblock.Text))
            //                    {
            //                        if (items.name.ToUpper().StartsWith(txtsearchbyblock.Text.ToUpper()) || items.name.ToLower().StartsWith(txtsearchbyblock.Text.ToLower()))
            //                            blockModels.Add(items);
            //                    }
            //                }
            //            }
            //            txtsearchbyblock.ItemsSource = blockModels;
            //        }
            //    }
            //}
            //catch
            //{

            //}
        }

        private void txtsearchbyroomname_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            //try
            //{
            //    if (e.Reason == dotMorten.Xamarin.Forms.AutoSuggestionBoxTextChangeReason.UserInput)
            //    {
            //        roomNameLists = new ObservableCollection<RoomNameList>();
            //        if (vm.RoomNameLists != null)
            //        {
            //            foreach (var items in vm.RoomNameLists)
            //            {
            //                if (!string.IsNullOrEmpty(items.name))
            //                {
            //                    if (!string.IsNullOrEmpty(txtsearchbyroomname.Text))
            //                    {
            //                        if (items.name.ToUpper().StartsWith(txtsearchbyroomname.Text.ToUpper()) || items.name.ToLower().StartsWith(txtsearchbyroomname.Text.ToLower()))
            //                            roomNameLists.Add(items);
            //                    }
            //                }
            //            }
            //            txtsearchbyroomname.ItemsSource = roomNameLists;
            //        }
            //    }
            //}
            //catch
            //{

            //}
        }

        private void txtsearchbyroomname_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            //txtsearchbyroomname.Text = ((RoomNameList)e.SelectedItem).name;
        }

        private void txtsearchbyblock_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            //txtsearchbyblock.Text = ((BlockModel)e.SelectedItem).name;
            //blockid = ((BlockModel)e.SelectedItem).id;
            //vm.GetAllRoomnamelist(hostelid, blockid);
        }
    }
}