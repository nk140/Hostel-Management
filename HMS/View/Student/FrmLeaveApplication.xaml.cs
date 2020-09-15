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
        public FrmLeaveApplication()
        {
            InitializeComponent();
        }

        LeaveRequestVM Vm;

        protected override void OnAppearing()
        {
            Vm = new LeaveRequestVM();
            BindingContext = Vm;
        }

        private void OnSelectedLeaveTypeItem(object sender, ItemTappedEventArgs e)
        {

            //   LeaveTypeModel md = (LeaveTypeModel)lv_type_list.SelectedItem;
            //   int cnt = Vm.LeaveTypeList.IndexOf(md);
            //   if (cnt >= 0)
            //   {
            //       Vm.TypeSelection(cnt);
            //   }

            //((ListView)sender).SelectedItem = null;
        }


        private void from_date_selected(object sender, FocusEventArgs e)
        {
            //Add Note
            // Vm.StartDate = dp_start_date.Date.ToString("yyy-MMM-dd");
            var result = string.Format("{0:yyy-MM-dd}", dp_start_date.Date);
            Vm.StartDate = result;
        }

        private void to_date_selected(object sender, FocusEventArgs e)
        {
            //Add Note
            var result = string.Format("{0:yyy-MM-dd}", dp_end_date.Date);
            Vm.EndDate = result;
        }

        private void from_t_selected(object sender, FocusEventArgs e)
        {
            //Add Note
            Vm.StartTime = tp_start_time.Time.Hours.ToString() + ":" + tp_start_time.Time.Minutes.ToString() + ":" + tp_start_time.Time.Seconds.ToString();
        }

        private void to_t_selected(object sender, FocusEventArgs e)
        {
            //Add Note
            Vm.EndTime = tp_end_time.Time.Hours.ToString() + ":" + tp_end_time.Time.Minutes.ToString() + "." + tp_end_time.Time.Seconds.ToString();
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
            Vm.LeaveRequest.hostelLeaveTypeId = id;
        }
    }
}
