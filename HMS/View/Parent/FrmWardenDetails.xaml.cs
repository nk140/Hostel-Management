
using dotMorten.Xamarin.Forms;
using HMS.Models;
using HMS.ViewModel.Parent;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Parrent
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmWardenDetails : ContentPage
    {
        WardenDetailsVM vm;
        public ObservableCollection<StudentProfileModel> wardenInfoModels;
        public ObservableCollection<StudentProfileModel> selectedtextdata;
        public FrmWardenDetails()
        {
            InitializeComponent();
            BindingContext = vm = new WardenDetailsVM();
        }

        private void txtsearchbykeyword_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            //try
            //{
            //    if (e.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            //    {
            //        wardenInfoModels = new ObservableCollection<StudentProfileModel>();
            //        if (vm.WardenInfoModels != null)
            //        {
            //            foreach (var items in vm.WardenInfoModels)
            //            {
            //                if (!string.IsNullOrEmpty(items.wardenName))
            //                {
            //                    if (!string.IsNullOrEmpty(txtsearchbykeyword.Text))
            //                    {
            //                        if (items.wardenName.ToUpper().StartsWith(txtsearchbykeyword.Text.ToUpper()) || items.wardenName.ToLower().StartsWith(txtsearchbykeyword.Text.ToLower()))
            //                            wardenInfoModels.Add(items);
            //                    }
            //                }
            //            }
            //            txtsearchbykeyword.ItemsSource = wardenInfoModels;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{

            //}
        }
        private void txtsearchbykeyword_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            //try
            //{
            //    txtsearchbykeyword.Text = ((StudentProfileModel)e.SelectedItem).wardenName;
            //    selectedtextdata = new ObservableCollection<StudentProfileModel>();
            //    if (wardenInfoModels != null)
            //    {
            //        foreach (var items in wardenInfoModels)
            //        {
            //            if (txtsearchbykeyword.Text == items.wardenName)
            //            {
            //                if (!string.IsNullOrEmpty(items.wardenPhoneNo))
            //                    selectedtextdata.Add(items);
            //            }
            //        }
            //    }
            //    if (selectedtextdata == null || selectedtextdata.Count == 0)
            //    {
            //        _listView.ItemsSource = null;
            //        App.Current.MainPage.DisplayAlert("HMS", "No contact no found for the entered name", "OK");
            //    }
            //    else
            //        _listView.ItemsSource = selectedtextdata;
            //}
            //catch (Exception ex)
            //{

            //}
        }

        private void txtsearchbykeyword_Unfocused(object sender, FocusEventArgs e)
        {
            //if (string.IsNullOrEmpty(txtsearchbykeyword.Text))
            //{
            //    _listView.ItemsSource = vm.WardenInfoModels;
            //}
        }
    }
}