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
    public partial class FrmDiscpoption : ContentPage
    {
        DisciplinaryActionVM vm;
        int count;
        ObservableCollection<ViewDisciplinaryType> viewDisciplinaryTypes;
        ObservableCollection<HostelAdmittedStudentDetails> hostelAdmittedStudentDetails1;
        public FrmDiscpoption()
        {
            InitializeComponent();
            BindingContext = vm = new DisciplinaryActionVM();
        }

        private void txtdisciplinarytype_TextChanged(object sender, AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == dotMorten.Xamarin.Forms.AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    viewDisciplinaryTypes = new ObservableCollection<ViewDisciplinaryType>();
                    if (vm.ViewDisciplinaryTypes != null)
                    {
                        foreach (var items in vm.ViewDisciplinaryTypes)
                        {
                            if (!string.IsNullOrEmpty(items.name))
                            {
                                if (!string.IsNullOrEmpty(txtdisciplinarytype.Text))
                                {
                                    if (items.name.ToUpper().StartsWith(txtdisciplinarytype.Text.ToUpper()) || items.name.ToLower().StartsWith(txtdisciplinarytype.Text.ToLower()))
                                        viewDisciplinaryTypes.Add(items);
                                }
                            }
                        }
                        txtdisciplinarytype.ItemsSource = viewDisciplinaryTypes;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txtdisciplinarytype_SuggestionChosen(object sender, AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            txtdisciplinarytype.Text = ((ViewDisciplinaryType)e.SelectedItem).name;
            vm.DisciplinaryActionbywarden.disciplinaryTypeId = ((ViewDisciplinaryType)e.SelectedItem).id;
        }

        private void txtstudentregistrationno_TextChanged(object sender, AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == dotMorten.Xamarin.Forms.AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    hostelAdmittedStudentDetails1 = new ObservableCollection<HostelAdmittedStudentDetails>();
                    if (vm.HostelAdmittedStudentDetails != null)
                    {
                        foreach (var items in vm.HostelAdmittedStudentDetails)
                        {
                            if (!string.IsNullOrEmpty(items.applicationNo))
                            {
                                if (!string.IsNullOrEmpty(txtstudentregistrationno.Text))
                                {
                                    if (items.applicationNo.ToUpper().StartsWith(txtstudentregistrationno.Text.ToUpper()) || items.applicationNo.ToLower().StartsWith(txtstudentregistrationno.Text.ToLower()))
                                        hostelAdmittedStudentDetails1.Add(items);
                                }
                            }
                        }
                        txtstudentregistrationno.ItemsSource = hostelAdmittedStudentDetails1;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private async void txtstudentregistrationno_SuggestionChosen(object sender, AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            if (count == 1)
            {
                txtstudentregistrationno.Text = ((HostelAdmittedStudentDetails)e.SelectedItem).applicationNo;
                vm.GetStudentDetailbyapplicationno(txtstudentregistrationno.Text);
                txtstudentname.Text = vm.HostelAdmittedStudentDetails[0].studentName;
                //vm.DisciplinaryActionbywarden.Studentname = txtstudentname.Text;
                vm.DisciplinaryActionbywarden.hostelAdmissionId = ((HostelAdmittedStudentDetails)e.SelectedItem).hostelAdmissionId;
            }
            else
            {
                var result = await App.Current.MainPage.DisplayAlert("HMS", "Do you really want to choose this no", "OK", "Cancel");
                if (result)
                {
                    count = count + 1;
                    txtstudentregistrationno.Text = ((HostelAdmittedStudentDetails)e.SelectedItem).applicationNo;
                    vm.GetStudentDetailbyapplicationno(txtstudentregistrationno.Text);
                    foreach(var items in vm.HostelAdmittedStudentDetails)
                    {
                        if(txtstudentregistrationno.Text==items.applicationNo)
                        {
                            txtstudentname.Text = items.studentName;
                            break;
                        }
                    }
                    //vm.DisciplinaryActionbywarden.Studentname = txtstudentname.Text;
                    vm.DisciplinaryActionbywarden.hostelAdmissionId = ((HostelAdmittedStudentDetails)e.SelectedItem).hostelAdmissionId;
                }
                else
                {

                }
            }
        }
        //private void dtofaction_DateSelected(object sender, DateChangedEventArgs e)
        //{
        //    vm.DisciplinaryActionbywarden.date= string.Format("{0:yyy-MM-dd}", dtofaction.Date);
        //}

        //private void timeofaction_Unfocused(object sender, FocusEventArgs e)
        //{
        //    string hours = ((timeofaction.Time.Hours + 11) % 12 + 1).ToString();
        //    vm.DisciplinaryActionbywarden.time = hours +":"+timeofaction.Time.Minutes+":"+timeofaction.Time.Seconds+"0";
        //}

        //private void dtofaction_Unfocused(object sender, FocusEventArgs e)
        //{
        //    vm.DisciplinaryActionbywarden.date = string.Format("{0:yyy-MM-dd}", dtofaction.Date);
        //}
    }
}