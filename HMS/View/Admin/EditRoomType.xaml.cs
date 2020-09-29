using dotMorten.Xamarin.Forms;
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
    public partial class EditRoomType : ContentPage
    {
        EditRoomTypeVM VM;
        ObservableCollection<AreaModel> areaModels;
        ObservableCollection<HostelModel> hostelModels;
        public EditRoomType()
        {
            InitializeComponent();
        }
        public EditRoomType(string roomids, string userids, string hostelroomtypenames, string hostelids)
        {
            InitializeComponent();
            BindingContext = VM = new EditRoomTypeVM(roomids, userids, hostelroomtypenames, hostelids);
        }

        private void txtselectbyarea_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    areaModels = new ObservableCollection<AreaModel>();
                    if (VM.AreaLists != null)
                    {
                        foreach (var items in VM.AreaLists)
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
                string value = ((AreaModel)e.SelectedItem).id;
                App.areaid = value;
                VM.GetHostelList(App.areaid);
            }
            catch (Exception ex)
            {

            }
        }

        private void txtsearchbyhostel_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    hostelModels = new ObservableCollection<HostelModel>();
                    if (VM.HostelLists != null)
                    {
                        foreach (var items in VM.HostelLists)
                        {
                            if (!string.IsNullOrEmpty(items.hostelName) || items.hostelName != null)
                            {
                                if (txtsearchbyhostel.Text != string.Empty)
                                {

                                    if (items.hostelName.ToUpper().StartsWith(txtsearchbyhostel.Text.ToUpper()) || items.hostelName.ToLower().StartsWith(txtsearchbyhostel.Text.ToLower()))
                                        hostelModels.Add(items);
                                }
                            }
                        }
                        txtsearchbyhostel.ItemsSource = hostelModels;
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

        private void txtsearchbyhostel_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            txtsearchbyhostel.Text = ((HostelModel)e.SelectedItem).hostelName;
            App.hostelid = ((HostelModel)e.SelectedItem).id;
        }
    }
}