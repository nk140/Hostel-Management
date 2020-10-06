using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HMS.ViewModel.Admin
{
    public class ViewLeaveTypeVM : BaseViewModel, StudentLeaveRequestI
    {
        StudentService web;
        private ObservableCollection<LeaveTypeModel> leaveTypeModel_ = new ObservableCollection<LeaveTypeModel>();
        public ObservableCollection<LeaveTypeModel> LeaveTypeList
        {
            get { return leaveTypeModel_; }
            set { leaveTypeModel_ = value; OnPropertyChanged("LeaveTypeList"); }
        }
        public ICommand EditCommand => new Command<LeaveTypeModel>(OnEditCommand);
        public ICommand DeleteCommand => new Command<LeaveTypeModel>(OnDeleteCommand);
        public ViewLeaveTypeVM()
        {
            web = new StudentService(this);
            web.GetAllLeaveType();
        }
        public async void OnEditCommand(LeaveTypeModel obj)
        {

        }
        public async void OnDeleteCommand(LeaveTypeModel obj)
        {

        }
        public async Task GetAllLeaveType(ObservableCollection<LeaveTypeModel> leaveTypes)
        {
            LeaveTypeList = leaveTypes;
            OnPropertyChanged("LeaveTypeList");
        }

        public async Task SaveLeaveRequest(string result)
        {

        }

        public async Task ServiceFaild(string result)
        {
            LeaveTypeList.Clear();
            OnPropertyChanged("LeaveTypeList");
        }
    }
}
