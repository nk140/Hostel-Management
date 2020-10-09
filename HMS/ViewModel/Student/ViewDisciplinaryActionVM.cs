using HMS.Interface;
using HMS.Models;
using HMS.Services;
using HMS.View.Student;
using HMS.View.Warden;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HMS.ViewModel.Student
{
    public class ViewDisciplinaryActionVM : BaseViewModel, ViewDisciplinaryActionTaken, IDeleteDisciplinary
    {
        WardenService wardenService;
        private ObservableCollection<ViewDisciplinaryActionbywarden> disciplinaryActionbywardens = new ObservableCollection<ViewDisciplinaryActionbywarden>();
        public ObservableCollection<ViewDisciplinaryActionbywarden> DisciplinaryActionbywardens
        {
            get
            {
                return disciplinaryActionbywardens;
            }
            set
            {
                disciplinaryActionbywardens = value;
                OnPropertyChanged("DisciplinaryActionbywardens");
            }
        }
        public ViewDisciplinaryActionVM()
        {
            wardenService = new WardenService((ViewDisciplinaryActionTaken)this, (IDeleteDisciplinary)this);
            wardenService.GetAllDisciplinaryAction();
        }
        public ICommand EditCommand => new Command<ViewDisciplinaryActionbywarden>(OnEditCommand);
        public ICommand ViewCommand => new Command<ViewDisciplinaryActionbywarden>(OnViewCommand);
        public ICommand DeleteCommand => new Command<ViewDisciplinaryActionbywarden>(OnDeleteCommand);
        public async void OnEditCommand(ViewDisciplinaryActionbywarden obj)
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new EditDisciplinaryAction(obj.disciplinaryTypeName,obj.disciplinaryTypeId,obj.discription,obj.hostelAdmissionId,obj.date,obj.time));
        }
        public async void OnViewCommand(ViewDisciplinaryActionbywarden obj)
        {
            await App.Current.MainPage.Navigation.PushPopupAsync(new ViewDisciplinaryActionPopup(obj.date, obj.time, obj.studentName, obj.appicationNo, obj.disciplinaryTypeName, obj.discription));
        }
        public async void OnDeleteCommand(ViewDisciplinaryActionbywarden obj)
        {
            wardenService.DeleteDisciplinaryActionTaken(obj.disciplinaryTypeId);
        }
        public async void servicefailed(string result)
        {
            DisciplinaryActionbywardens.Clear();
            OnPropertyChanged("DisciplinaryActionbywardens");
        }

        public async void LoadTakenDisciplinaryAction(ObservableCollection<ViewDisciplinaryActionbywarden> disciplinaryActionbywardens)
        {
            DisciplinaryActionbywardens = disciplinaryActionbywardens;
            OnPropertyChanged("DisciplinaryActionbywardens");
        }

        public async void DeleteDisciplinaryType(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            wardenService.GetAllDisciplinaryAction();
        }

        public async void Failer(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }
    }
    public class EditDisciplinaryActionVM : BaseViewModel, IEditDisciplinary, ViewIDisciplinary
    {
        WardenService WardenService;
        MasterServices web;
        private ObservableCollection<Models.ViewDisciplinaryType> viewDisciplinaryTypes = new ObservableCollection<Models.ViewDisciplinaryType>();
        public ObservableCollection<Models.ViewDisciplinaryType> ViewDisciplinaryTypes
        {
            get
            {
                return viewDisciplinaryTypes;
            }
            set
            {
                viewDisciplinaryTypes = value;
                OnPropertyChanged("ViewDisciplinaryTypes");
            }
        }
        private UpdateDisciplinaryActionbywarden updateDisciplinary = new UpdateDisciplinaryActionbywarden();
        public UpdateDisciplinaryActionbywarden UpdateDisciplinaryActionbywarden
        {
            get
            {
                return updateDisciplinary;
            }
            set
            {
                updateDisciplinary = value;
                OnPropertyChanged("UpdateDisciplinaryActionbywarden");
            }
        }
        private string disciplinaryname;
        public string DisciplinaryName
        {
            get
            {
                return disciplinaryname;
            }
            set
            {
                disciplinaryname = value;
                OnPropertyChanged("DisciplinaryName");
            }
        }
        public ICommand UpdateDisciplinaryAction => new Command(OnUpdateDisciplinaryAction);
        public EditDisciplinaryActionVM(string disciplinaryname, string discipid,string description,string hostelAdmissionId,string date,string time)
        {
            DisciplinaryName = disciplinaryname;
            UpdateDisciplinaryActionbywarden.disciplinaryTypeId = discipid;
            UpdateDisciplinaryActionbywarden.description = description;
            UpdateDisciplinaryActionbywarden.hostelAdmissionId = hostelAdmissionId;
            UpdateDisciplinaryActionbywarden.date = date;
            UpdateDisciplinaryActionbywarden.time = time;
            WardenService = new WardenService((IEditDisciplinary)this);
            web = new MasterServices((ViewIDisciplinary)this);
            web.ViewDisciplinaryType();
        }
        public async void OnUpdateDisciplinaryAction()
        {
            if (string.IsNullOrEmpty(UpdateDisciplinaryActionbywarden.disciplinaryTypeId) || UpdateDisciplinaryActionbywarden.disciplinaryTypeId.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Disciplinary type require", "OK");
            else if (string.IsNullOrEmpty(UpdateDisciplinaryActionbywarden.description) || UpdateDisciplinaryActionbywarden.description.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Disciplinary description require", "OK");
            else
            {
                UpdateDisciplinaryActionbywarden.userId = App.userid;
                string result = DateTime.Now.ToShortDateString();
                var results = String.Format("{0:yyyy-MM-dd}", DateTime.Now.Date);
                UpdateDisciplinaryActionbywarden.date = results;
                UpdateDisciplinaryActionbywarden.time = DateTime.Now.TimeOfDay.ToString();
                WardenService.UpdateDisciplinaryActionTaken(UpdateDisciplinaryActionbywarden);
            }
        }
        public void Failer(string result)
        {
            App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }

        public void LoadDisciplinaryList(ObservableCollection<ViewDisciplinaryType> viewDisciplinaryTypes)
        {
            ViewDisciplinaryTypes = viewDisciplinaryTypes;
            OnPropertyChanged("ViewDisciplinaryTypes");
        }

        public void ServiceFailed(string result)
        {
           
        }

        public async void UpdateDisciplinaryType(string result)
        {
            UpdateDisciplinaryActionbywarden = new UpdateDisciplinaryActionbywarden();
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            OnPropertyChanged("UpdateDisciplinaryActionbywarden");
        }
    }
    public class ViewStudentDisciplinaryActionVM : BaseViewModel
    {
        private ObservableCollection<StudentModel> studentModels = new ObservableCollection<StudentModel>();
        public ObservableCollection<StudentModel> StudentModels
        {
            get
            {
                return studentModels;
            }
            set
            {
                studentModels = value;
                OnPropertyChanged("StudentModels");
            }
        }
        public ViewStudentDisciplinaryActionVM()
        {
            StudentModels.Add(new StudentModel
            {
                wardenDisciplinaryId = SecureStorage.GetAsync("wardenDisciplinaryId").GetAwaiter().GetResult(),
                studentName = SecureStorage.GetAsync("studentName").GetAwaiter().GetResult(),
                disciplinaryName = SecureStorage.GetAsync("disciplinaryName").GetAwaiter().GetResult(),
                applicationNo = SecureStorage.GetAsync("applicationNo").GetAwaiter().GetResult(),
                date = SecureStorage.GetAsync("date").GetAwaiter().GetResult(),
                time = SecureStorage.GetAsync("time").GetAwaiter().GetResult()
            });
        }
        public ICommand ViewCommand => new Command<StudentModel>(OnViewCommand);
        public async void OnViewCommand(StudentModel obj)
        {
            await App.Current.MainPage.Navigation.PushPopupAsync(new ViewDisciplinaryActionPopup(obj.date, obj.time, obj.studentName, obj.applicationNo, obj.disciplinaryName, obj.disciplinaryName));
        }
    }
    public class ViewWardDisciplinaryActionVM : BaseViewModel
    {
        private ObservableCollection<UserModel> wardmodels = new ObservableCollection<UserModel>();
        public ObservableCollection<UserModel> WardModels
        {
            get
            {
                return wardmodels;
            }
            set
            {
                wardmodels = value;
                OnPropertyChanged("WardModels");
            }
        }
        public ViewWardDisciplinaryActionVM()
        {
            WardModels.Add(new UserModel
            {
                wardenDisciplinaryId = SecureStorage.GetAsync("wardenDisciplinaryId").GetAwaiter().GetResult(),
                studentName = SecureStorage.GetAsync("studentName").GetAwaiter().GetResult(),
                disciplinaryName = SecureStorage.GetAsync("disciplinaryName").GetAwaiter().GetResult(),
                applicationNo = SecureStorage.GetAsync("applicationNo").GetAwaiter().GetResult(),
                studentId= SecureStorage.GetAsync("studentId").GetAwaiter().GetResult(),
                date = SecureStorage.GetAsync("date").GetAwaiter().GetResult(),
                time = SecureStorage.GetAsync("time").GetAwaiter().GetResult()
            });
        }
        public ICommand ViewCommand => new Command<UserModel>(OnViewCommand);
        public async void OnViewCommand(UserModel obj)
        {
            await App.Current.MainPage.Navigation.PushPopupAsync(new ViewDisciplinaryActionPopup(obj.date, obj.time, obj.studentName, obj.applicationNo, obj.disciplinaryName, obj.disciplinaryName));
        }
    }
}
