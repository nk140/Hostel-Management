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
    public class WardenDetailVM : BaseViewModel, ContactWardenI, IDeleteWardenDetail
    {
        StudentService web;

        private ObservableCollection<WardenInfoModel> warden_ = new ObservableCollection<WardenInfoModel>();


        public ObservableCollection<WardenInfoModel> Warden
        {
            get { return warden_; }
            set { warden_ = value; OnPropertyChanged("Warden"); }
        }
        public ICommand EditCommand => new Command<WardenInfoModel>(OnEditCommand);
        public ICommand DeleteCommand => new Command<WardenInfoModel>(OnDeleteCommand);
        public WardenDetailVM()
        {
            web = new StudentService((ContactWardenI)this, (IDeleteWardenDetail)this);
            web.GetAllWarden();
        }
        public async void OnEditCommand(WardenInfoModel obj)
        {
            //App.areaid = obj.id;
            await App.Current.MainPage.Navigation.PushModalAsync(new EditWarden(obj.id.ToString(), obj.firstName, obj.contact));
        }
        public async void OnDeleteCommand(WardenInfoModel obj)
        {
            web.DeleteWardenDetail(obj.userId);
        }
        public async void Deletesucessfully(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            web.GetAllWarden();
        }

        public async Task GetAllWarden(ObservableCollection<WardenInfoModel> warden_)
        {
            Warden = warden_;
            OnPropertyChanged("Warden");
        }

        public async Task ServiceFaild()
        {
            Warden.Clear();
            OnPropertyChanged("Warden");
        }

        public async void servicefailed(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }
    }
    public class EditWardenVM : BaseViewModel, IEditWardenDetail
    {
        StudentService studentService;
        private UpdateWarden updateWarden = new UpdateWarden();
        public UpdateWarden UpdateWarden
        {
            get
            {
                return updateWarden;
            }
            set
            {
                updateWarden = value;
                OnPropertyChanged("UpdateWarden");
            }
        }
        public ICommand UpdateWardenCommand => new Command(OnUpdateWardenCommand);
        public EditWardenVM(string id, string name, string contactno)
        {
            studentService = new StudentService((IEditWardenDetail)this);
            UpdateWarden.name = name;
            UpdateWarden.contactNo = contactno;
            UpdateWarden.wardenId = id;
        }
        public async void OnUpdateWardenCommand()
        {
            if (string.IsNullOrEmpty(UpdateWarden.name) || UpdateWarden.name.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Enter Name", "OK");
            else if(UpdateWarden.contactNo.Length != 10)
                await App.Current.MainPage.DisplayAlert("HMS", "Enter 10 digit contact no", "OK");
            else if (string.IsNullOrEmpty(UpdateWarden.contactNo) || UpdateWarden.contactNo.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Enter contact no", "OK");
            else
            {
                UpdateWarden.userId = App.userid;
                studentService.UpdateWardenDetail(UpdateWarden);
            }
        }
        public async void servicefailed(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }

        public async void updatesucessfully(string result)
        {
            UpdateWarden = new UpdateWarden();
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
            OnPropertyChanged("UpdateWarden");
        }
    }
}
