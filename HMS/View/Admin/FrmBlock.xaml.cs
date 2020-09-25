using dotMorten.Xamarin.Forms;
using HMS.Models;
using HMS.ViewModel.Admin;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace HMS.View.Admin
{
    public partial class FrmBloack : ContentPage
    {
        public FrmBloack()
        {
            InitializeComponent();
        }


        BlockVM VM;
        ObservableCollection<AreaModel> ListArea;
        protected override void OnAppearing()
        {
            VM = new BlockVM();
            BindingContext = VM;
        }

        private void OnSelectedAreaItem(object sender, ItemTappedEventArgs e)
        {

         //   AreaModel md = (AreaModel)lv_area.SelectedItem;
         //   int cnt = VM.AreaModelList.IndexOf(md);
         //   if (cnt >= 0)
         //   {
         //       VM.AreaSelection(cnt);
         //   }

         //((ListView)sender).SelectedItem = null;
        }

        private void OnSelectedHostelItem(object sender, ItemTappedEventArgs e)
        {

            HostelModel md = (HostelModel)lv_hostel.SelectedItem;
            int cnt = VM.HostelModelList.IndexOf(md);
            if (cnt >= 0)
            {
                VM.HostelSelection(cnt);
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
                    if (VM.AreaModelList != null)
                    {
                        foreach (var items in VM.AreaModelList)
                        {
                            if (!string.IsNullOrEmpty(items.areaName) || items.areaName != null)
                            {
                                if (txtsearchbykeyword.Text != string.Empty)
                                {
                                    VM.AreaName = txtsearchbykeyword.Text;
                                    if (items.areaName.ToUpper().StartsWith(VM.AreaName.ToUpper()) || items.areaName.ToLower().StartsWith(VM.AreaName.ToLower()))
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

        private void txtsearchbykeyword_SuggestionChosen(object sender, AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            try
            {
                VM.AreaName = ((AreaModel)e.SelectedItem).areaName;
                AreaModel value = (AreaModel)e.SelectedItem;
                VM.SelectedArea(value.id);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
