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
    public partial class ViewDisciplinaryType : ContentPage
    {
        ViewDisciplinaryTypeVM vm;
        ObservableCollection<Models.ViewDisciplinaryType> viewDisciplinaryTypes;
        ObservableCollection<Models.ViewDisciplinaryType> viewDisciplinaryTypes1;
        public ViewDisciplinaryType()
        {
            InitializeComponent();
            BindingContext = vm = new ViewDisciplinaryTypeVM();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = vm = new ViewDisciplinaryTypeVM();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
        private void txtsearchbydisciplinarytype_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == dotMorten.Xamarin.Forms.AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    viewDisciplinaryTypes = new ObservableCollection<Models.ViewDisciplinaryType>();
                    if (vm.ViewDisciplinaryTypes != null)
                    {
                        foreach (var items in vm.ViewDisciplinaryTypes)
                        {
                            if (!string.IsNullOrEmpty(items.name))
                            {
                                if (!string.IsNullOrEmpty(txtsearchbydisciplinarytype.Text))
                                {
                                    if (items.name.ToUpper().StartsWith(txtsearchbydisciplinarytype.Text.ToUpper()) || items.name.ToLower().StartsWith(txtsearchbydisciplinarytype.Text.ToLower()))
                                        viewDisciplinaryTypes.Add(items);
                                }
                            }
                        }
                        txtsearchbydisciplinarytype.ItemsSource = viewDisciplinaryTypes;
                    }
                }
            }
            catch
            {

            }
        }

        private void txtsearchbydisciplinarytype_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            txtsearchbydisciplinarytype.Text = ((Models.ViewDisciplinaryType)e.SelectedItem).name;
            viewDisciplinaryTypes1 = new ObservableCollection<Models.ViewDisciplinaryType>();
            if (viewDisciplinaryTypes != null)
            {
                foreach (var items in viewDisciplinaryTypes)
                {
                    if (txtsearchbydisciplinarytype.Text == items.name)
                        viewDisciplinaryTypes1.Add(items);
                }
                blocklist.ItemsSource = viewDisciplinaryTypes1;
            }
        }
    }
}