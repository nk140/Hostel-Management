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
    public partial class ViewServiceCategory : ContentPage
    {
        ServiceCategory serviceCategory;
        public ObservableCollection<WardenServiceModel> wardenServiceModels;
        public ObservableCollection<WardenServiceModel> wardenServiceModels1;
        public ViewServiceCategory()
        {
            InitializeComponent();
            BindingContext = serviceCategory = new ServiceCategory();
        }

        private void txtsearchbyservicename_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == dotMorten.Xamarin.Forms.AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    wardenServiceModels = new ObservableCollection<WardenServiceModel>();
                    if (serviceCategory.WardenServiceData!= null)
                    {
                        foreach (var items in serviceCategory.WardenServiceData)
                        {
                            if (!string.IsNullOrEmpty(items.name))
                            {
                                if (!string.IsNullOrEmpty(txtsearchbyservicename.Text))
                                {
                                    if (items.name.ToUpper().StartsWith(txtsearchbyservicename.Text.ToUpper()) || items.name.ToLower().StartsWith(txtsearchbyservicename.Text.ToLower()))
                                        wardenServiceModels.Add(items);
                                }
                            }
                        }
                        txtsearchbyservicename.ItemsSource = wardenServiceModels;
                    }
                }
            }
            catch
            {

            }
        }

        private void txtsearchbyservicename_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            txtsearchbyservicename.Text = ((WardenServiceModel)e.SelectedItem).name;
            wardenServiceModels1 = new ObservableCollection<WardenServiceModel>();
            if (wardenServiceModels != null)
            {
                foreach (var items in wardenServiceModels)
                {
                    if (txtsearchbyservicename.Text == items.name)
                        wardenServiceModels1.Add(items);
                }
                _listView.ItemsSource = wardenServiceModels1;
            }
        }
    }
}