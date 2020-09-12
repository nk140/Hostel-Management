using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace HMS.ViewModel.Warden
{
    public class LeaveAction : BaseViewModel, Iwardenleaveaction
    {
        WardenService warden;
        private ObservableCollection<ParentStudentLeaveStatus> parentStudentLeaveStatuses = new ObservableCollection<ParentStudentLeaveStatus>();
        public int counter;
        #region lisproperties
        public ObservableCollection<ParentStudentLeaveStatus> ParentStudentLeaveData
        {
            get
            {
                return parentStudentLeaveStatuses;
            }
            set
            {
                parentStudentLeaveStatuses = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Commands
        public ICommand UpdateLeaveStatusCommand => new Command(OnUpdateLeaveStatusCommand);
        public ICommand ApproveCommand => new Command<ParentStudentLeaveStatus>(OnApproveCommand);
        public ICommand RejectCommand => new Command<ParentStudentLeaveStatus>(OnRejectCommand);
        #endregion
        public LeaveAction()
        {
            warden = new WardenService(this);
            warden.GetParentLeaveApproval();
        }
        public async void OnApproveCommand(ParentStudentLeaveStatus obj)
        {
            if(counter==1 || counter>1)
                await App.Current.MainPage.DisplayAlert("HMS", "Rejected leave can't be approve", "OK");
            else
            {
                var ans = await App.Current.MainPage.DisplayAlert("HMS", "Do you really want to approve the leave.", "OK", "Cancel");
                if (ans)
                {
                    counter = counter + 1;
                    if (counter > 1)
                        await App.Current.MainPage.DisplayAlert("HMS", "You already approve.", "OK");
                }
            }
            
        }
        public async void OnRejectCommand(ParentStudentLeaveStatus obj)
        {
            if (counter == 1 || counter > 1)
                await App.Current.MainPage.DisplayAlert("HMS", "Approved leave can't reject", "OK");
            else
            {
                var ans = await App.Current.MainPage.DisplayAlert("HMS", "Do you really want to reject the leave.", "OK", "Cancel");
                if (ans)
                {
                    counter = counter + 1;
                    if (counter > 1)
                        await App.Current.MainPage.DisplayAlert("HMS", "You Already rejected the leave", "OK");
                }
            }
           
        }
        public void OnUpdateLeaveStatusCommand()
        {

        }
        public void GetStudentLeaveDetail(ObservableCollection<ParentStudentLeaveStatus> parent)
        {
            ParentStudentLeaveData = new ObservableCollection<ParentStudentLeaveStatus>();
            ParentStudentLeaveData = parent;
            OnPropertyChanged();
        }
    }
}
