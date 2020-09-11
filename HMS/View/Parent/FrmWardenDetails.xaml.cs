
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
        public ObservableCollection<WardenInfoModel> wardenInfoModels;
        public ObservableCollection<WardenInfoModel> selectedtextdata;
        public FrmWardenDetails()
        {
            InitializeComponent();
            BindingContext = vm = new WardenDetailsVM();
        }

        private void txtsearchbykeyword_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    wardenInfoModels = new ObservableCollection<WardenInfoModel>();
                    if (vm.WardenInfoModels != null)
                    {
                        foreach (var items in vm.WardenInfoModels)
                        {
                            if (!string.IsNullOrEmpty(items.firstName))
                            {
                                if (!string.IsNullOrEmpty(txtsearchbykeyword.Text))
                                {
                                    if (items.firstName.ToUpper().StartsWith(txtsearchbykeyword.Text.ToUpper()) || items.firstName.ToLower().StartsWith(txtsearchbykeyword.Text.ToLower()))
                                        wardenInfoModels.Add(items);
                                }
                            }
                        }
                        txtsearchbykeyword.ItemsSource = wardenInfoModels;
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
                txtsearchbykeyword.Text = ((WardenInfoModel)e.SelectedItem).firstName;
                selectedtextdata = new ObservableCollection<WardenInfoModel>();
                if (wardenInfoModels != null)
                {
                    foreach (var items in wardenInfoModels)
                    {
                        if (txtsearchbykeyword.Text == items.firstName)
                            selectedtextdata.Add(items);
                    }
                }
                _listView.ItemsSource = selectedtextdata;
            }
            catch (Exception ex)
            {

            }
        }
    }
}