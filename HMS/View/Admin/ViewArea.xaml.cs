using HMS.Data;
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
    public partial class ViewArea : ContentPage
    {
        ViewAreaVM vm;
        public ObservableCollection<AreaModel> areaModels;
        public ObservableCollection<AreaModel> areaModels1;
        public ViewArea()
        {
            InitializeComponent();
            BindingContext = vm = new ViewAreaVM();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = vm = new ViewAreaVM();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
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
            areaModels1 = new ObservableCollection<AreaModel>();
            if (areaModels != null)
            {
                foreach (var items in areaModels)
                {
                    if (txtsearchbyareaname.Text == items.areaName)
                        areaModels1.Add(items);
                }
                arealist.ItemsSource = areaModels1;
            }
        }
    }
}