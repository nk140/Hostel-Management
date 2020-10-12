using HMS.Models;
using HMS.ViewModel.Student;
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
    public partial class ViewDisciplinaryAction : ContentPage
    {
        ViewDisciplinaryActionVM vm;
        int counter;
        ObservableCollection<ViewDisciplinaryActionbywarden> viewDisciplinaryActionbywardens;
        ObservableCollection<ViewDisciplinaryActionbywarden> viewDisciplinaryActionbywardens1;
        public ViewDisciplinaryAction()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = vm = new ViewDisciplinaryActionVM();
        }

        private void txtsearchbystudentname_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == dotMorten.Xamarin.Forms.AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    viewDisciplinaryActionbywardens = new ObservableCollection<ViewDisciplinaryActionbywarden>();
                    if (vm.DisciplinaryActionbywardens != null)
                    {
                        foreach (var items in vm.DisciplinaryActionbywardens)
                        {
                            if (!string.IsNullOrEmpty(items.studentName))
                            {
                                if (!string.IsNullOrEmpty(txtsearchbystudentname.Text))
                                {
                                    if (items.studentName.ToUpper().StartsWith(txtsearchbystudentname.Text.ToUpper()) || items.studentName.ToLower().StartsWith(txtsearchbystudentname.Text.ToLower()))
                                        viewDisciplinaryActionbywardens.Add(items);
                                }
                            }
                        }
                        txtsearchbystudentname.ItemsSource = viewDisciplinaryActionbywardens;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txtsearchbystudentname_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            txtsearchbystudentname.Text = ((ViewDisciplinaryActionbywarden)e.SelectedItem).studentName;
            if (viewDisciplinaryActionbywardens != null)
            {
                viewDisciplinaryActionbywardens1 = new ObservableCollection<ViewDisciplinaryActionbywarden>();
                foreach (var items in viewDisciplinaryActionbywardens)
                {
                    if (txtsearchbystudentname.Text == items.studentName)
                        viewDisciplinaryActionbywardens1.Add(items);
                }
                arealist.ItemsSource = viewDisciplinaryActionbywardens1;
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
          
        }
    }
}