﻿using HMS.Interface;
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

        }
        public async void OnRejectCommand(ParentStudentLeaveStatus obj)
        {

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