
using dotMorten.Xamarin.Forms;
using HMS.Models;
using HMS.ViewModel.Student;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace HMS.View.Student
{
    public partial class FrmServiceRequest : ContentPage
    {
        ServiceRequestVM vm;
        public ObservableCollection<WardenServiceModel> serviceModels;
        public FrmServiceRequest()
        {
            InitializeComponent();
            BindingContext = vm = new ServiceRequestVM();
        }

        private void txtsearchbykeyword_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    serviceModels = new ObservableCollection<WardenServiceModel>();
                    if (vm.WardenServiceModels != null)
                    {
                        foreach (var items in vm.WardenServiceModels)
                        {
                            if(!string.IsNullOrEmpty(items.name))
                            {
                                if(!string.IsNullOrEmpty(txtsearchbykeyword.Text))
                                {
                                    if (items.name.ToUpper().StartsWith(txtsearchbykeyword.Text.ToUpper()) || items.name.ToLower().StartsWith(txtsearchbykeyword.Text.ToLower()))
                                        serviceModels.Add(items);
                                }
                            }
                        }
                        txtsearchbykeyword.ItemsSource = serviceModels;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void txtsearchbykeyword_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            txtsearchbykeyword.Text = ((WardenServiceModel)e.SelectedItem).name;
            vm.Servicecategoryname = txtsearchbykeyword.Text;
        }
    }
}
