using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HMS.ViewModel.Student
{
    public class ViewRequestedServiceStatusVM : BaseViewModel, Iviewservicestatus
    {
        StudentService studentService;
        private ObservableCollection<ViewRequestedServiceStatusModel> viewRequestedServiceStatusModels = new ObservableCollection<ViewRequestedServiceStatusModel>();
        public ObservableCollection<ViewRequestedServiceStatusModel> ViewRequestedServiceStatusModels
        {
            get
            {
                return viewRequestedServiceStatusModels;
            }
            set
            {
                viewRequestedServiceStatusModels = value;
                OnPropertyChanged("ViewRequestedServiceStatusModels");
            }
        }
        private bool isdataavailable;
        private ViewRequestedServiceStatusModel _OldDisciplinaryData;

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
        public ICommand CallCommand => new Command<ViewRequestedServiceStatusModel>(OnCallCommand);
        public ICommand WhatsappCommand => new Command<ViewRequestedServiceStatusModel>(Onwhatsappcommand);
        public ICommand TapCommand => new Command<ViewRequestedServiceStatusModel>(OnTapCommand);
        public ViewRequestedServiceStatusVM()
        {
            studentService = new StudentService((Iviewservicestatus)this);
            studentService.GetRequestedServiceStatus(App.userid);
        }

        public void LoadServicestatus(ObservableCollection<ViewRequestedServiceStatusModel> viewRequestedServiceStatusModels)
        {
            foreach (var items in viewRequestedServiceStatusModels)
            {
                if (items.personName != null || items.personJob != null || items.personMobileNo!=null)
                {
                    Isdataavailable = true;
                    ViewRequestedServiceStatusModels = viewRequestedServiceStatusModels;
                    OnPropertyChanged("ViewRequestedServiceStatusModels");
                }
            }
        }
        public async void OnTapCommand(ViewRequestedServiceStatusModel obj)
        {
            Hideorshowbutton(obj);
        }
        public async void OnCallCommand(ViewRequestedServiceStatusModel obj)
        {
            try
            {
                PhoneDialer.Open(obj.personMobileNo);
            }
            catch (ArgumentNullException anEx)
            {
                // Number was null or white space
            }
            catch (FeatureNotSupportedException ex)
            {
                // Phone Dialer is not supported on this device.
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }

        [Obsolete]
        public async void Onwhatsappcommand(ViewRequestedServiceStatusModel obj)
        {
            try
            {
                Device.OpenUri(new Uri("whatsapp://send?phone=+91" + obj.personMobileNo));
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Not Installed", "Whatsapp Not Installed", "ok");
            }
        }
        public void Hideorshowbutton(ViewRequestedServiceStatusModel obj)
        {
            if (_OldDisciplinaryData == obj)
            {
                obj.isbuttonvisible = !obj.isbuttonvisible;
                UpdateProduct(obj);
            }
            else
            {
                if (_OldDisciplinaryData != null)
                {
                    foreach (var items in ViewRequestedServiceStatusModels)
                    {
                        if (_OldDisciplinaryData.personName == items.personName)
                        {
                            _OldDisciplinaryData.isbuttonvisible = false;
                            UpdateProduct(_OldDisciplinaryData);
                            break;
                        }
                    }
                }
                obj.isbuttonvisible = true;
                UpdateProduct(obj);
            }
            _OldDisciplinaryData = obj;
        }
        public void UpdateProduct(ViewRequestedServiceStatusModel obj)
        {
            var index = ViewRequestedServiceStatusModels.IndexOf(obj);
            ViewRequestedServiceStatusModels.Remove(obj);
            ViewRequestedServiceStatusModels.Insert(index, obj);
        }
        public void failer(string result)
        {

        }
    }
}
