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
        public int approvecounter, rejectcounter;
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
        public ICommand LeaveActionOption => new Command<ParentStudentLeaveStatus>(OnLeaveActionOption);
        #endregion
        public LeaveAction()
        {
            warden = new WardenService(this);
            warden.GetParentLeaveApproval();
        }
        public async void OnApproveCommand(ParentStudentLeaveStatus obj)
        {
            if (rejectcounter == 1 || rejectcounter > 1)
                await App.Current.MainPage.DisplayAlert("HMS", "Rejected leave can't be approve", "OK");
            else if (approvecounter == 1 || approvecounter > 1)
                await App.Current.MainPage.DisplayAlert("HMS", "You Have already approve the leave.", "OK");
            else
            {
                var ans = await App.Current.MainPage.DisplayAlert("HMS", "Do you really want to approve the leave.", "OK", "Cancel");
                if (ans)
                {
                    approvecounter = approvecounter + 1;
                }
            }
        }
        public async void OnLeaveActionOption(ParentStudentLeaveStatus obj)
        {
            var result = await App.Current.MainPage.DisplayActionSheet("Choose what action you take", "Cancel", null, "Approve", "Reject");
            if (result.Equals("Approve"))
            {

            }
            else if (result.Equals("Reject"))
            {

            }
            else
            {

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
