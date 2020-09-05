using dotMorten.Xamarin.Forms;
using HMS.Models;
using HMS.ViewModel.Warden;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMS.View.Warden
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmHostelDetail : ContentPage
    {
        HostelDetailMasterViewModel vm;
        ObservableCollection<HostalMasterModel> ListHostel;
        public FrmHostelDetail()
        {
            InitializeComponent();
            BindingContext = vm = new HostelDetailMasterViewModel();
            //_listView.ItemsSource = vm.HostalMasterData;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            //_listView.ItemsSource = vm.HostalMasterData;
        }
        private void txtsearchbykeyword_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    ListHostel = new ObservableCollection<HostalMasterModel>();
                    if (vm.HostalMasterData != null)
                    {
                        foreach (var item in vm.HostalMasterData)
                        {
                            if (!string.IsNullOrEmpty(item.hostelName) || item.hostelName != null)
                            {
                                //VM.AreaVisible = !VM.AreaVisible;
                                if (txtsearchbykeyword.Text != string.Empty)
                                {
                                    if (item.hostelName.ToUpper().StartsWith(txtsearchbykeyword.Text.ToUpper()) || item.hostelName.ToLower().StartsWith(txtsearchbykeyword.Text.ToLower()))
                                        ListHostel.Add(item);
                                }
                            }
                        }
                        txtsearchbykeyword.ItemsSource = ListHostel;
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
                txtsearchbykeyword.Text = ((HostalMasterModel)e.SelectedItem).hostelName;
                _listView.ItemsSource = ListHostel;
                _listView.IsVisible = true;
            }
            catch (Exception ex)
            {

            }
        }
    }
}