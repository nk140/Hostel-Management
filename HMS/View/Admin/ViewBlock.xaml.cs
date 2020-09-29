using HMS.Models;
using HMS.ViewModel.Admin;
using Rg.Plugins.Popup.Extensions;
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
    public partial class ViewBlock : ContentPage
    {
        ViewBlockVM vm;
        public ObservableCollection<BlockModel> blockModels;
        public ObservableCollection<BlockModel> blockModels1;
        string hostelids1,areaids;
        public ViewBlock()
        {
            InitializeComponent();
        }
        public ViewBlock(string hostelids,string areaid)
        {
            InitializeComponent();
            hostelids1 = hostelids;
            areaids = areaid;
            BindingContext = vm = new ViewBlockVM(hostelids,areaid);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = vm = new ViewBlockVM(hostelids1,areaids);
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
        private void txtsearchbyblockname_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == dotMorten.Xamarin.Forms.AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    blockModels = new ObservableCollection<BlockModel>();
                    if (vm.BlockModelList != null)
                    {
                        foreach (var items in vm.BlockModelList)
                        {
                            if (!string.IsNullOrEmpty(items.name))
                            {
                                if (!string.IsNullOrEmpty(txtsearchbyblockname.Text))
                                {
                                    if (items.name.ToUpper().StartsWith(txtsearchbyblockname.Text.ToUpper()) || items.name.ToLower().StartsWith(txtsearchbyblockname.Text.ToLower()))
                                        blockModels.Add(items);
                                }
                            }
                        }
                        txtsearchbyblockname.ItemsSource = blockModels;
                    }
                }
            }
            catch
            {

            }
        }
        private void txtsearchbyblockname_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            txtsearchbyblockname.Text = ((BlockModel)e.SelectedItem).name;
            blockModels1 = new ObservableCollection<BlockModel>();
            if (blockModels != null)
            {
                foreach (var items in blockModels)
                {
                    if (txtsearchbyblockname.Text == items.name)
                        blockModels1.Add(items);
                }
                blocklist.ItemsSource = blockModels1;
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushPopupAsync(new PopupBlock(App.areaid));
        }
    }
}