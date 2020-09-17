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
    public partial class FrmStudleavehistory : ContentPage
    {
        StudentLeaveHistoryVM vm;
        ObservableCollection<StudentLeaveHistory> studentLeaveHistories;
        ObservableCollection<StudentLeaveHistory> studentLeaveHistories1;
        public FrmStudleavehistory()
        {
            InitializeComponent();
            BindingContext = vm = new StudentLeaveHistoryVM();
        }

        private void txtsearchbykeyword_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    studentLeaveHistories = new ObservableCollection<StudentLeaveHistory>();
                    if (vm.Studentleavedata != null)
                    {
                        foreach (var items in vm.Studentleavedata)
                        {
                            if (!string.IsNullOrEmpty(items.leaveTypeName))
                            {
                                if (!string.IsNullOrEmpty(txtsearchbykeyword.Text))
                                {
                                    if (items.leaveTypeName.ToUpper().StartsWith(txtsearchbykeyword.Text.ToUpper()) || items.leaveTypeName.ToLower().StartsWith(txtsearchbykeyword.Text.ToLower()))
                                        studentLeaveHistories.Add(items);
                                }
                            }
                        }
                        txtsearchbykeyword.ItemsSource = studentLeaveHistories;
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
                txtsearchbykeyword.Text = ((StudentLeaveHistory)e.SelectedItem).leaveTypeName.ToString();
                studentLeaveHistories1 = new ObservableCollection<StudentLeaveHistory>();
                if (studentLeaveHistories != null)
                {
                    foreach (var items in studentLeaveHistories)
                    {
                        if (items.leaveTypeName == txtsearchbykeyword.Text)
                            studentLeaveHistories1.Add(items);
                    }
                }
                _listView.ItemsSource = studentLeaveHistories1;
            }
            catch (Exception ex)
            {

            }
        }
    }
}