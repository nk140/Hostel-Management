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
    public partial class Frmstudentleaveaction : ContentPage
    {
        LeaveAction vm;
        ObservableCollection<ParentStudentLeaveStatus> parentStudentLeaveStatuses;
        ObservableCollection<ParentStudentLeaveStatus> parentStudentLeaveStatuses1;
        public Frmstudentleaveaction()
        {
            InitializeComponent();
            BindingContext = vm = new LeaveAction();
        }

        private void txtsearchbykeyword_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    parentStudentLeaveStatuses = new ObservableCollection<ParentStudentLeaveStatus>();
                    if (vm.ParentStudentLeaveData != null)
                    {
                        foreach (var items in vm.ParentStudentLeaveData)
                        {
                            if (!string.IsNullOrEmpty(items.leaveType.ToString()))
                            {
                                if (!string.IsNullOrEmpty(txtsearchbykeyword.Text))
                                {
                                    if (items.leaveType.ToUpper().StartsWith(txtsearchbykeyword.Text.ToUpper()) || items.leaveType.ToLower().StartsWith(txtsearchbykeyword.Text.ToLower()))
                                        parentStudentLeaveStatuses.Add(items);
                                }
                            }
                        }
                        txtsearchbykeyword.ItemsSource = parentStudentLeaveStatuses;
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
                txtsearchbykeyword.Text = ((ParentStudentLeaveStatus)e.SelectedItem).leaveType.ToString();
                parentStudentLeaveStatuses1 = new ObservableCollection<ParentStudentLeaveStatus>();
                if (parentStudentLeaveStatuses != null)
                {
                    foreach (var items in parentStudentLeaveStatuses)
                    {
                        if (items.leaveType == txtsearchbykeyword.Text)
                            parentStudentLeaveStatuses1.Add(items);
                    }
                    collectionView.ItemsSource = parentStudentLeaveStatuses1;
                }
                else
                    App.Current.MainPage.DisplayAlert("HMS", "No Matching data.", "OK");
            }
            catch (Exception ex)
            {

            }
        }
    }
}