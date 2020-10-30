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
using System.Threading.Tasks;
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
        private bool isbuttonvisible;
        private ViewDisciplinaryActionbywarden _OldDisciplinaryData;

        public bool Isbuttonvisible
        {
            get
            {
                return isbuttonvisible;
            }
            set
            {
                isbuttonvisible = value;
                OnPropertyChanged("Isbuttonvisible");
            }
        }
        public ViewDisciplinaryActionVM()
        {
            wardenService = new WardenService((ViewDisciplinaryActionTaken)this, (IDeleteDisciplinary)this);
            wardenService.GetAllDisciplinaryAction();
        }
        public void GetAllDiscpAction()
        {
            wardenService.GetAllDisciplinaryAction();
        }
        public ICommand EditCommand => new Command<ViewDisciplinaryActionbywarden>(OnEditCommand);
        public ICommand ViewCommand => new Command<ViewDisciplinaryActionbywarden>(OnViewCommand);
        public ICommand DeleteCommand => new Command<ViewDisciplinaryActionbywarden>(OnDeleteCommand);
        public ICommand TapCommand => new Command<ViewDisciplinaryActionbywarden>(OnTapCommand);
        public async void OnEditCommand(ViewDisciplinaryActionbywarden obj)
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new EditDisciplinaryAction(obj.disciplinaryTypeName,obj.disciplinaryTypeId, obj.wardenDisciplinaryId, obj.discription, obj.hostelAdmissionId, obj.date, obj.time));
            Hideorshowbutton(obj);
        }
        public async void OnViewCommand(ViewDisciplinaryActionbywarden obj)
        {
            await App.Current.MainPage.Navigation.PushPopupAsync(new ViewDisciplinaryActionPopup(obj.date, obj.time, obj.studentName, obj.appicationNo, obj.disciplinaryTypeName, obj.discription));
            Hideorshowbutton(obj);
        }
        public async void OnDeleteCommand(ViewDisciplinaryActionbywarden obj)
        {
            wardenService.DeleteDisciplinaryActionTaken(obj.wardenDisciplinaryId);
        }
        public async void OnTapCommand(ViewDisciplinaryActionbywarden obj)
        {
            Hideorshowbutton(obj);
        }
        public void Hideorshowbutton(ViewDisciplinaryActionbywarden obj)
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
                    foreach (var items in DisciplinaryActionbywardens)
                    {
                        if (_OldDisciplinaryData.studentName == items.studentName)
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
        public void UpdateProduct(ViewDisciplinaryActionbywarden obj)
        {
            var index = DisciplinaryActionbywardens.IndexOf(obj);
            DisciplinaryActionbywardens.Remove(obj);
            DisciplinaryActionbywardens.Insert(index, obj);
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
            OnPropertyChanged("DisciplinaryActionbywardens");
        }

        public async void Failer(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }

        public void LoadStudentdisciplinarylist(ObservableCollection<StudentDisciplinaryDetails> studentDisciplinaryDetails)
        {
            throw new NotImplementedException();
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
        public EditDisciplinaryActionVM(string disciplinaryname, string discpid,string wardendiscipid, string description, string hostelAdmissionId, string date, string time)
        {
            DisciplinaryName = disciplinaryname;
            UpdateDisciplinaryActionbywarden.disciplinaryTypeId = discpid;
            UpdateDisciplinaryActionbywarden.wardenDisciplinaryId = wardendiscipid;
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
    public class ViewStudentDisciplinaryActionVM : BaseViewModel, ViewDisciplinaryActionTaken
    {
        public StudentService studentService;
        private ObservableCollection<StudentModel> studentModels = new ObservableCollection<StudentModel>();
        private StudentDisciplinaryDetails _OldDisciplinaryData;

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
        private ObservableCollection<StudentDisciplinaryDetails> studentProfile = new ObservableCollection<StudentDisciplinaryDetails>();
        public ObservableCollection<StudentDisciplinaryDetails> StudentProfileModel
        {
            get
            {
                return studentProfile;
            }
            set
            {
                studentProfile = value;
                OnPropertyChanged("StudentProfileModel");
            }
        }
        private bool isdataavailable;
        public bool Isdataavailable
        {
            get
            {
                return isdataavailable;
            }
            set
            {
                isdataavailable = value;
                OnPropertyChanged("Isdataavailable");
            }
        }
        public ViewStudentDisciplinaryActionVM()
        {
            studentService = new StudentService(this);
            studentService.GetDisciplinaryDetails(App.userid);
            //StudentModels.Add(new StudentModel
            //{
            //    wardenDisciplinaryId = SecureStorage.GetAsync("wardenDisciplinaryId").GetAwaiter().GetResult(),
            //    studentName = SecureStorage.GetAsync("studentName").GetAwaiter().GetResult(),
            //    disciplinaryName = SecureStorage.GetAsync("disciplinaryName").GetAwaiter().GetResult(),
            //    applicationNo = SecureStorage.GetAsync("applicationNo").GetAwaiter().GetResult(),
            //    date = SecureStorage.GetAsync("date").GetAwaiter().GetResult(),
            //    time = SecureStorage.GetAsync("time").GetAwaiter().GetResult()
            //});
            //if (string.IsNullOrEmpty(StudentModels[0].applicationNo) || StudentModels[0].applicationNo.Length == 0)
            //    App.Current.MainPage.DisplayAlert("HMS", "Seems you haven't done hostel admission", "OK");
        }
        public ICommand ViewCommand => new Command<StudentDisciplinaryDetails>(OnViewCommand);
        public ICommand TapCommand => new Command<StudentDisciplinaryDetails>(OnTapCommand);
        public async void OnViewCommand(StudentDisciplinaryDetails obj)
        {
            await App.Current.MainPage.Navigation.PushPopupAsync(new ViewDisciplinaryActionPopup(obj.date, obj.time, obj.studentName, obj.applicationNo, obj.disciplinaryName, obj.disciplinaryName));
        }
        public async void OnTapCommand(StudentDisciplinaryDetails obj)
        {
            Hideorshowbutton(obj);
        }
        public void Hideorshowbutton(StudentDisciplinaryDetails obj)
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
                    foreach (var items in StudentModels)
                    {
                        if (_OldDisciplinaryData.studentName == items.studentName)
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
        public void UpdateProduct(StudentDisciplinaryDetails obj)
        {
            var index = StudentProfileModel.IndexOf(obj);
            StudentProfileModel.Remove(obj);
            StudentProfileModel.Insert(index, obj);
        }
        public void LoadTakenDisciplinaryAction(ObservableCollection<ViewDisciplinaryActionbywarden> disciplinaryActionbywardens)
        {
            throw new NotImplementedException();
        }

        public void LoadStudentdisciplinarylist(ObservableCollection<StudentDisciplinaryDetails> studentDisciplinaryDetails)
        {
            Isdataavailable = true;
            StudentProfileModel = studentDisciplinaryDetails;
            OnPropertyChanged("StudentProfileModel");
        }

        public void servicefailed(string result)
        {
            App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }
    }
    public class ViewWardDisciplinaryActionVM : BaseViewModel, Iviewchildhosteldetail
    {
        ParentService parent;
        private ObservableCollection<ChildHostelDetailModel> wardmodels = new ObservableCollection<ChildHostelDetailModel>();
        private ChildHostelDetailModel _OldDisciplinaryData;

        public ObservableCollection<ChildHostelDetailModel> WardModels
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
            parent = new ParentService(this);
            string studentid = SecureStorage.GetAsync("studentId").GetAwaiter().GetResult();
            parent.GetChildHostelData(studentid);
        }
        public ICommand ViewCommand => new Command<ChildHostelDetailModel>(OnViewCommand);
        public ICommand TapCommand => new Command<ChildHostelDetailModel>(OnTapCommand);
        public async void OnViewCommand(ChildHostelDetailModel obj)
        {
            await App.Current.MainPage.Navigation.PushPopupAsync(new ViewDisciplinaryActionPopup(obj.date, obj.time, obj.studentName, obj.applicationNo, obj.disciplinaryName, obj.disciplinaryName));
        }
        public async void OnTapCommand(ChildHostelDetailModel obj)
        {
            Hideorshowbutton(obj);
        }
        public void Hideorshowbutton(ChildHostelDetailModel obj)
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
                    foreach (var items in WardModels)
                    {
                        if (_OldDisciplinaryData.studentName == items.studentName)
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
        public void UpdateProduct(ChildHostelDetailModel obj)
        {
            var index = WardModels.IndexOf(obj);
            WardModels.Remove(obj);
            WardModels.Insert(index, obj);
        }

        public void LoadChildHostelDetails(ObservableCollection<ChildHostelDetailModel> childHostelDetailModels)
        {
            WardModels = childHostelDetailModels;
            OnPropertyChanged("WardModels");
        }

        public void servicefailed(string result)
        {
            App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }
    }
}
