using HMS.Models;
using HMS.ViewModel.Student;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Student
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentHostelAdmission : ContentPage
    {
        StudentHostelAdmissionVM vm;
        ObservableCollection<AreaModel> areaModels;
        ObservableCollection<HostelModel> hostelModels;
        ObservableCollection<RoomBedData> roomBedDatas;
        ObservableCollection<RoomTypeModel> roomTypeModels;
        public StudentHostelAdmission()
        {
            InitializeComponent();
        }

        private void txtsearchbyareaname_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == dotMorten.Xamarin.Forms.AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    areaModels = new ObservableCollection<AreaModel>();
                    if (vm.AreaLists != null)
                    {
                        foreach (var items in vm.AreaLists)
                        {
                            if (!string.IsNullOrEmpty(items.areaName))
                            {
                                if (!string.IsNullOrEmpty(txtsearchbyareaname.Text))
                                {
                                    if (items.areaName.ToUpper().StartsWith(txtsearchbyareaname.Text.ToUpper()) || items.areaName.ToLower().StartsWith(txtsearchbyareaname.Text.ToLower()))
                                        areaModels.Add(items);
                                }
                            }
                        }
                        txtsearchbyareaname.ItemsSource = areaModels;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txtsearchbyareaname_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            txtsearchbyareaname.Text = ((AreaModel)e.SelectedItem).areaName;
            var id= ((AreaModel)e.SelectedItem).id;
            vm.GethostelList(id);
        }

        private void txtsearchbyhostel_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == dotMorten.Xamarin.Forms.AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    hostelModels = new ObservableCollection<HostelModel>();
                    if (vm.HostelLists != null)
                    {
                        foreach (var items in vm.HostelLists)
                        {
                            if (!string.IsNullOrEmpty(items.hostelName))
                            {
                                if (!string.IsNullOrEmpty(txtsearchbyhostelname.Text))
                                {
                                    if (items.hostelName.ToUpper().StartsWith(txtsearchbyhostelname.Text.ToUpper()) || items.hostelName.ToLower().StartsWith(txtsearchbyhostelname.Text.ToLower()))
                                        hostelModels.Add(items);
                                }
                            }
                        }
                        txtsearchbyhostelname.ItemsSource = hostelModels;
                    }
                }
            }
            catch
            {

            }
        }

        private void txtsearchbyhostel_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            txtsearchbyhostelname.Text = ((HostelModel)e.SelectedItem).hostelName;
            var id= ((HostelModel)e.SelectedItem).id;
            vm.HostelAdmission.hostelId = id;
            vm.GetRoombedlist(id);
        }

        private void txtsearchbycourse_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {

        }

        private void txtsearchbycourse_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {

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
            vm.HostelAdmission.roomTypeId= ((RoomTypeModel)e.SelectedItem).id;
        }
        private void txtsearchbybedname_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == dotMorten.Xamarin.Forms.AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    roomBedDatas = new ObservableCollection<RoomBedData>();
                    if (vm.RoomBedDatas != null)
                    {
                        foreach (var items in vm.RoomBedDatas)
                        {
                            if (!string.IsNullOrEmpty(items.bedNo))
                            {
                                if (!string.IsNullOrEmpty(txtsearchbyroombed.Text))
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

        private void txtsearchbybedname_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            txtsearchbyroombed.Text = ((RoomBedData)e.SelectedItem).bedNo;
            vm.HostelAdmission.roomId = ((RoomBedData)e.SelectedItem).hostelRoomId;
            vm.HostelAdmission.bedId = ((RoomBedData)e.SelectedItem).bedId;
        }
    }
}