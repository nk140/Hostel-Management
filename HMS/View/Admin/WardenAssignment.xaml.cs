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
    public partial class WardenAssignment : ContentPage
    {
        WardenAssignmentVM vm;
        ObservableCollection<WardenInfoModel> wardenInfoModels;
        ObservableCollection<AreaModel> areaModels;
        ObservableCollection<HostelModel> hostelModels = new ObservableCollection<HostelModel>();
        List<string> hostellist = new List<string>();
        StringBuilder sb = new StringBuilder();
        StringBuilder sb2 = new StringBuilder();
        public WardenAssignment()
        {
            InitializeComponent();
            BindingContext = vm = new WardenAssignmentVM();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
        private void txtsearchbyarea_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == dotMorten.Xamarin.Forms.AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    areaModels = new ObservableCollection<AreaModel>();
                    if (vm.AreaModel != null)
                    {
                        foreach (var items in vm.AreaModel)
                        {
                            if (!string.IsNullOrEmpty(items.areaName))
                            {
                                if (!string.IsNullOrEmpty(txtsearchbyarea.Text))
                                {
                                    if (items.areaName.ToUpper().StartsWith(txtsearchbyarea.Text.ToUpper()) || items.areaName.ToLower().StartsWith(txtsearchbyarea.Text.ToLower()))
                                        areaModels.Add(items);
                                }
                                else
                                {

                                }
                            }
                        }
                        txtsearchbyarea.ItemsSource = areaModels;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void txtsearchbyarea_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            txtsearchbyarea.Text = ((AreaModel)e.SelectedItem).areaName;
            vm.WardenAssignment.areaId = ((AreaModel)e.SelectedItem).id;
            vm.GetHostelList(vm.WardenAssignment.areaId);
        }

        private void txtsearchbywarden_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    wardenInfoModels = new ObservableCollection<WardenInfoModel>();
                    if (vm.Warden != null)
                    {
                        foreach (var items in vm.Warden)
                        {
                            if (!string.IsNullOrEmpty(items.firstName))
                            {
                                if (!string.IsNullOrEmpty(txtsearchbywarden.Text))
                                {
                                    if (items.firstName.ToUpper().StartsWith(txtsearchbywarden.Text.ToUpper()) || items.firstName.ToLower().StartsWith(txtsearchbywarden.Text.ToLower()))
                                        wardenInfoModels.Add(items);
                                }
                            }
                        }
                        txtsearchbywarden.ItemsSource = wardenInfoModels;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txtsearchbywarden_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            txtsearchbywarden.Text = ((WardenInfoModel)e.SelectedItem).firstName;
            vm.WardenAssignment.employeeId = ((WardenInfoModel)e.SelectedItem).id.ToString();
        }

        private void txtsearchbyhostel_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            //try
            //{
            //    if (e.Reason == dotMorten.Xamarin.Forms.AutoSuggestionBoxTextChangeReason.UserInput)
            //    {
            //        hostelModels = new ObservableCollection<HostelModel>();
            //        if (vm.HostelModelList != null)
            //        {
            //            foreach (var items in vm.HostelModelList)
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
            //hostellist.Add(txtsearchbyhostel.Text);
            //for (int i = 0; i < hostellist.Count; i++)
            //{
            //    sb.Append(hostellist[i].ToString());
            //    sb.Append(",");
            //}
            //txtassignedhostellist.Text = sb.ToString();
        }
        private void ddhostel_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string selectedhostelname = ddhostel.Items[ddhostel.SelectedIndex];
            //sb.Append(selectedhostelname);
            //sb.Append(",");
            //txtassignedhostellist.Text = sb.ToString();
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (vm.HostelModelList.Count == 0 || vm.HostelModelList == null)
                App.Current.MainPage.DisplayAlert("HMS", "No Hostel List", "OK");
            else
            {
                lv_role.IsVisible = true;
                lv_role.IsEnabled = true;
                lv_role.HeightRequest = (40 * vm.HostelModelList.Count) + 20;
            }
        }
        private void lv_role_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            HostelModel md = (HostelModel)lv_role.SelectedItem;
            int cnt = vm.HostelModelList.IndexOf(md);
            if (cnt >= 0)
            {
                selectehostel(cnt);
            }
        }
        public void selectehostel(int index)
        {
            string hostelname = vm.HostelModelList[index].hostelName;
            string hostelid = vm.HostelModelList[index].id;
            vm.WardenAssignment.hostelId = hostelid;
            sb.Append(hostelname);
            sb2.Append(hostelid);
            //sb.Append(",");
            sb2.Append(",");
            txtassignedhostellist.Text = sb.ToString();
            vm.WardenAssignment.hostelAssigned = txtassignedhostellist.Text;
        }
    }
}