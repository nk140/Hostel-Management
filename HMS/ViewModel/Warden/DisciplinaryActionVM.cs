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

namespace HMS.ViewModel.Warden
{
    public class DisciplinaryActionVM : BaseViewModel, IDisciplinaryAction, ViewIDisciplinary, ViewHostelAdmittedStudent
    {
        WardenService warden;
        private DisciplinaryActionbywarden disciplinaryActionbywarden = new DisciplinaryActionbywarden();
        public DisciplinaryActionbywarden DisciplinaryActionbywarden
        {
            get
            {
                return disciplinaryActionbywarden;
            }
            set
            {
                disciplinaryActionbywarden = value;
                OnPropertyChanged("DisciplinaryActionbywarden");
            }
        }
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
        StudentService student;
        private ObservableCollection<HostelAdmittedStudentDetails> hostelAdmittedStudentDetails = new ObservableCollection<HostelAdmittedStudentDetails>();
        public ObservableCollection<HostelAdmittedStudentDetails> HostelAdmittedStudentDetails
        {
            get
            {
                return hostelAdmittedStudentDetails;
            }
            set
            {
                hostelAdmittedStudentDetails = value;
                OnPropertyChanged("HostelAdmittedStudentDetails");
            }
        }
        public ICommand TakeDisciplinaryActionCommand => new Command(OnTakeDisciplinaryActionCommand);
        public async void OnTakeDisciplinaryActionCommand()
        {
            //if (string.IsNullOrEmpty(DisciplinaryActionbywarden.Studentname) || DisciplinaryActionbywarden.Studentname.Length == 0)
            //    await App.Current.MainPage.DisplayAlert("HMS", "Enter Student name", "OK");
            //if (string.IsNullOrEmpty(DisciplinaryActionbywarden.date) || DisciplinaryActionbywarden.date.Length == 0)
            //    await App.Current.MainPage.DisplayAlert("HMS", "Enter Date", "OK");
            //else if (string.IsNullOrEmpty(DisciplinaryActionbywarden.time) || DisciplinaryActionbywarden.time.Length == 0)
            //    await App.Current.MainPage.DisplayAlert("HMS", "Enter Time", "OK");
             if (string.IsNullOrEmpty(DisciplinaryActionbywarden.disciplinaryTypeId) || DisciplinaryActionbywarden.disciplinaryTypeId.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Enter Disciplinary type", "OK");
            else if (string.IsNullOrEmpty(DisciplinaryActionbywarden.description) || DisciplinaryActionbywarden.description.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Enter Description", "OK");
            else
            {
                DisciplinaryActionbywarden.userId = App.userid;
                string result= DateTime.Now.ToShortDateString();
               var results= String.Format("{0:yyyy-MM-dd}",DateTime.Now.Date);
                DisciplinaryActionbywarden.date = results;
                DisciplinaryActionbywarden.time = DateTime.Now.TimeOfDay.ToString();
                warden.SaveDisciplinaryActionTaken(DisciplinaryActionbywarden);
            }
        }

        public async void Disciplinaryactiontaken(string result)
        {
            DisciplinaryActionbywarden = new DisciplinaryActionbywarden();
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            OnPropertyChanged("DisciplinaryActionbywarden");
        }

        public async void servicefailed(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }

        public Task ServiceFaild(string result)
        {
            throw new NotImplementedException();
        }
        public async Task SaveLeaveRequest(string result)
        {

        }

        public async void LoadDisciplinaryList(ObservableCollection<ViewDisciplinaryType> viewDisciplinaryTypes)
        {
            ViewDisciplinaryTypes = viewDisciplinaryTypes;
            OnPropertyChanged("ViewDisciplinaryTypes");
        }

        public async void ServiceFailed(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }

        public async void LoadHostelStudent(ObservableCollection<HostelAdmittedStudentDetails> hostelAdmittedStudentDetails)
        {
            HostelAdmittedStudentDetails = hostelAdmittedStudentDetails;
            OnPropertyChanged("HostelAdmittedStudentDetails");
        }

        public DisciplinaryActionVM()
        {
            warden = new WardenService((IDisciplinaryAction)this);
            web = new MasterServices((ViewIDisciplinary)this);
            student = new StudentService((ViewHostelAdmittedStudent)this);
            web.ViewDisciplinaryType();
            student.GetHostelStudent();
        }
        public void GetStudentDetailbyapplicationno(string applicationNo)
        {
            student.GetHostelAdmittedStudentbyappno(applicationNo);
        }
    }
}
