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

namespace HMS.View.Warden
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditDisciplinaryAction : ContentPage
    {
        EditDisciplinaryActionVM vm;
        ObservableCollection<Models.ViewDisciplinaryType> ViewDisciplinaryTypes;
        public EditDisciplinaryAction()
        {
            InitializeComponent();
        }
        public EditDisciplinaryAction(string disciplinaryname,string discipid, string description, string hostelAdmissionId, string date, string time)
        {
            InitializeComponent();
            BindingContext = vm = new EditDisciplinaryActionVM(disciplinaryname, discipid, description, hostelAdmissionId, date, time);
        }
        private void txtsearchbydisciplinarytype_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == dotMorten.Xamarin.Forms.AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    ViewDisciplinaryTypes = new ObservableCollection<ViewDisciplinaryType>();
                    if (vm.ViewDisciplinaryTypes != null)
                    {
                        foreach (var items in vm.ViewDisciplinaryTypes)
                        {
                            if (!string.IsNullOrEmpty(items.name))
                            {
                                if (!string.IsNullOrEmpty(txtsearchbydisciplinarytype.Text))
                                {
                                    if (items.name.ToUpper().StartsWith(txtsearchbydisciplinarytype.Text.ToUpper()) || items.name.ToLower().StartsWith(txtsearchbydisciplinarytype.Text.ToLower()))
                                        ViewDisciplinaryTypes.Add(items);
                                }
                            }
                        }
                        txtsearchbydisciplinarytype.ItemsSource = ViewDisciplinaryTypes;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txtsearchbydisciplinarytype_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            txtsearchbydisciplinarytype.Text = ((ViewDisciplinaryType)e.SelectedItem).name;
            vm.UpdateDisciplinaryActionbywarden.wardenDisciplinaryId = ((ViewDisciplinaryType)e.SelectedItem).id;
        }
    }
}