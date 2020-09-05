using dotMorten.Xamarin.Forms;
using HMS.Models;
using HMS.Services;
using HMS.ViewModel.Admin;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace HMS.View.Admin
{
    public partial class FrmHostel : ContentPage
    {
        public FrmHostel()
        {
            InitializeComponent();
        }
        HostelVM Vm;
        ObservableCollection<AreaModel> ListArea;
        MasterServices webs;
        bool AreaVisibility = false;

        protected override void OnAppearing()
        {
            Vm = new HostelVM();
            BindingContext = Vm;
        }
        private void OnSelectedAreaItem(object sender, ItemTappedEventArgs e)
        {

            AreaModel md = (AreaModel)lv_area.SelectedItem;
            int cnt = Vm.AreaList.IndexOf(md);
            if (cnt >= 0)
            {
                Vm.AreaSelection(cnt);
            }

          ((ListView)sender).SelectedItem = null;
        }

        private async void txtsearchbykeyword_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    ListArea = new ObservableCollection<AreaModel>();
                    if (Vm.AreaList != null)
                    {
                        foreach (var items in Vm.AreaList)
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
                //Vm.AreaName = txtsearchbykeyword.DisplayMemberPath;
                //Vm.AreaName = txtsearchbykeyword.TextMemberPath;
                Vm.AreaId = ((AreaModel)e.SelectedItem).id;
            }
            catch (Exception ex)
            {

            }
        }

        //private void male_CheckedChanged(object sender, CheckedChangedEventArgs e)
        //{
        //    if (Vm.IsCheck1 == true)
        //    {

        //        Vm.IsCheck2 = false;

        //    }
        //    else
        //    {
        //        Vm.IsCheck2 = true;
        //    }
        //}

        //private void female_CheckedChanged(object sender, CheckedChangedEventArgs e)
        //{
        //    if (Vm.IsCheck2 == false)
        //    {

        //        Vm.IsCheck1 = false;
        //        Vm.IsCheck2 = true;
        //    }
        //    else
        //    {
        //        Vm.IsCheck1 = true;
        //    }
        //}
    }
}
