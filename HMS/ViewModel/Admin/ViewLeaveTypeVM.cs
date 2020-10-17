using HMS.Interface;
using HMS.Models;
using HMS.Services;
using HMS.View.Admin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HMS.ViewModel.Admin
{
    public class ViewLeaveTypeVM : BaseViewModel, StudentLeaveRequestI, DeleteLeavetype
    {
        StudentService web;
        private ObservableCollection<LeaveTypeModel> leaveTypeModel_ = new ObservableCollection<LeaveTypeModel>();
        private LeaveTypeModel _OldDisciplinaryData;

        public ObservableCollection<LeaveTypeModel> LeaveTypeList
        {
            get { return leaveTypeModel_; }
            set { leaveTypeModel_ = value; OnPropertyChanged("LeaveTypeList"); }
        }
        public ICommand EditCommand => new Command<LeaveTypeModel>(OnEditCommand);
        public ICommand DeleteCommand => new Command<LeaveTypeModel>(OnDeleteCommand);
        public ICommand TapCommand => new Command<LeaveTypeModel>(OnTapCommand);
        public ViewLeaveTypeVM()
        {
            web = new StudentService((StudentLeaveRequestI)this, (DeleteLeavetype)this);
            web.GetAllLeaveType();
        }
        public async void OnEditCommand(LeaveTypeModel obj)
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new EditLeavetype(obj.leaveTypeId, obj.name, App.userid));
            Hideorshowbutton(obj);
        }
        public async void OnDeleteCommand(LeaveTypeModel obj)
        {
            web.DeleteLeavetype(obj.leaveTypeId);
            Hideorshowbutton(obj);
        }
        public async void OnTapCommand(LeaveTypeModel obj)
        {
            Hideorshowbutton(obj);
        }
        public void Hideorshowbutton(LeaveTypeModel obj)
        {
            if (_OldDisciplinaryData == obj)
            {
                obj.Isbuttonvisible = !obj.Isbuttonvisible;
                UpdateProduct(obj);
            }
            else
            {
                if (_OldDisciplinaryData != null)
                {
                    foreach (var items in LeaveTypeList)
                    {
                        if (_OldDisciplinaryData.name == items.name)
                        {
                            _OldDisciplinaryData.Isbuttonvisible = false;
                            UpdateProduct(_OldDisciplinaryData);
                            break;
                        }
                    }
                }
                obj.Isbuttonvisible = true;
                UpdateProduct(obj);
            }
            _OldDisciplinaryData = obj;
        }
        public void UpdateProduct(LeaveTypeModel obj)
        {
            var index = LeaveTypeList.IndexOf(obj);
            LeaveTypeList.Remove(obj);
            LeaveTypeList.Insert(index, obj);
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

        public async void deletesucess(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            web.GetAllLeaveType();
            OnPropertyChanged("LeaveTypeList");
        }

        public async void failer(string result)
        {
            LeaveTypeList.Clear();
            OnPropertyChanged("LeaveTypeList");
        }
    }
    public class CreateLeaveTypeVM : BaseViewModel, icreateleavetype
    {
        StudentService studentService;
        private CreateLeaveTypeModel createLeaveTypeModel = new CreateLeaveTypeModel();
        public CreateLeaveTypeModel CreateLeaveTypeModel
        {
            get
            {
                return createLeaveTypeModel;
            }
            set
            {
                createLeaveTypeModel = value;
                OnPropertyChanged("CreateLeaveTypeModel");
            }
        }
        public ICommand CreateLeaveTypeCommand => new Command(OnCreateLeaveTypeCommand);
        public CreateLeaveTypeVM()
        {
            CreateLeaveTypeModel.userId = App.userid;
            studentService = new StudentService((icreateleavetype)this);
        }
        public async void OnCreateLeaveTypeCommand()
        {
            if (string.IsNullOrEmpty(CreateLeaveTypeModel.name) || CreateLeaveTypeModel.name.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Leave type name required", "OK");
            else
                studentService.CreateLeaveType(CreateLeaveTypeModel);
        }
        public async void failer(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS",result, "OK");
        }

        public async void sucess(string result)
        {
            CreateLeaveTypeModel = new CreateLeaveTypeModel();
            await App.Current.MainPage.DisplayAlert("HMS",result, "OK");
            OnPropertyChanged("CreateLeaveTypeModel");
        }
    }

    public class EditLeavetypeVM : BaseViewModel, EditleaveType
    {
        StudentService studentService;
        private UpdateLeavetype updateLeavetype = new UpdateLeavetype();
        public UpdateLeavetype UpdateLeavetype
        {
            get
            {
                return updateLeavetype;
            }
            set
            {
                updateLeavetype = value;
                OnPropertyChanged("UpdateLeavetype");
            }
        }
        public ICommand UpdateLeavetypeCommand => new Command(OnUpdateLeavetypeCommand);
        public EditLeavetypeVM(string leaveid, string leavetypename, string userid)
        {
            UpdateLeavetype.leaveTypeId = leaveid;
            UpdateLeavetype.name = leavetypename;
            UpdateLeavetype.userId = userid;
            studentService = new StudentService((EditleaveType)this);
            OnPropertyChanged("UpdateLeavetype");
        }
        public async void OnUpdateLeavetypeCommand()
        {
            if (string.IsNullOrEmpty(UpdateLeavetype.name) || UpdateLeavetype.name.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Leave type name required", "OK");
            else
            {
                studentService.UpdateLeavetype(UpdateLeavetype);
            }
        }
        public async void sucess(string result)
        {
            UpdateLeavetype = new UpdateLeavetype();
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            OnPropertyChanged("UpdateLeavetype");
        }
        public async void failer(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }
    }
}
