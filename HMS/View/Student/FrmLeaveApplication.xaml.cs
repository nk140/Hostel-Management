using dotMorten.Xamarin.Forms;
using HMS.Models;
using HMS.ViewModel.Student;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace HMS.View.Student
{
    public partial class FrmLeaveApplication : ContentPage
    {
        public ObservableCollection<LeaveTypeModel> leaveTypes;
        string result1, result2;
        public FrmLeaveApplication()
        {
            InitializeComponent();
            dp_start_date.MinimumDate = DateTime.Now.Date;
        }

        LeaveRequestVM Vm;

        protected override void OnAppearing()
        {
            Vm = new LeaveRequestVM();
            BindingContext = Vm;
        }
        private void from_date_selected(object sender, FocusEventArgs e)
        {
            //Add Note
              result1 = string.Format("{0:yyy-MM-dd}", dp_start_date.Date);
        }
        private void to_date_selected(object sender, FocusEventArgs e)
        {
            //Add Note
           result2 = string.Format("{0:yyy-MM-dd}", dp_end_date.Date);
            Validation();
        }
        public void Validation()
        {
            DateTime startdateTime = dp_start_date.Date;
            DateTime enddate = dp_end_date.Date;
            if (startdateTime > enddate || enddate<startdateTime)
                App.Current.MainPage.DisplayAlert("HMS", "Check your start date and end date", "OK");
            else if (enddate == startdateTime)
                App.Current.MainPage.DisplayAlert("HMS", "end date can't equal to start date", "OK");
            else
            {
                Vm.StartDate = result1;
                Vm.EndDate = result2;
            }
        }
        private void txtsearchbykeyword_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            try
            {
                if (e.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    leaveTypes = new ObservableCollection<LeaveTypeModel>();
                    if (Vm.LeaveTypeList != null)
                    {
                        foreach (var items in Vm.LeaveTypeList)
                        {
                            if (!string.IsNullOrEmpty(items.name))
                            {
                                if (!string.IsNullOrEmpty(txtsearchbykeyword.Text))
                                {
                                    if (items.name.ToUpper().StartsWith(txtsearchbykeyword.Text.ToUpper()) || items.name.ToLower().StartsWith(txtsearchbykeyword.Text.ToLower()))
                                        leaveTypes.Add(items);
                                }
                            }
                        }
                        txtsearchbykeyword.ItemsSource = leaveTypes;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void txtsearchbykeyword_SuggestionChosen(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxSuggestionChosenEventArgs e)
        {
            txtsearchbykeyword.Text = ((LeaveTypeModel)e.SelectedItem).name;
            Vm.LeaveType = txtsearchbykeyword.Text;
            var id = ((LeaveTypeModel)e.SelectedItem).id;
            Vm.LeaveTypeId = id;
        }
    }
}
