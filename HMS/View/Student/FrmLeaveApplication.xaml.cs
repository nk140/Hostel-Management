using HMS.Models;
using HMS.ViewModel.Student;
using Xamarin.Forms;

namespace HMS.View.Student
{
    public partial class FrmLeaveApplication : ContentPage
    {
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

            LeaveTypeModel md = (LeaveTypeModel)lv_type_list.SelectedItem;
            int cnt = Vm.LeaveTypeList.IndexOf(md);
            if (cnt >= 0)
            {
                Vm.TypeSelection(cnt);
            }

         ((ListView)sender).SelectedItem = null;
        }


        private void from_date_selected(object sender, FocusEventArgs e)
        {
            //Add Note

            Vm.StartDate = dp_start_date.Date.ToString("yyy-mm-dd");


        }

        private void to_date_selected(object sender, FocusEventArgs e)
        {
            //Add Note
            Vm.EndDate = dp_end_date.Date.ToString("yyy-mm-dd");
        }

        private void from_t_selected(object sender, FocusEventArgs e)
        {
            //Add Note

            Vm.StartTime = tp_start_time.Time.Hours.ToString() + ":" + tp_start_time.Time.Minutes + "." + tp_start_time.Time.Seconds;

        }

        private void to_t_selected(object sender, FocusEventArgs e)
        {
            //Add Note
            Vm.EndTime = tp_end_time.Time.Hours.ToString() + ":" + tp_end_time.Time.Minutes + "." + tp_end_time.Time.Seconds;

        }
    }
}
