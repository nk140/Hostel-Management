using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HMS.ViewModel.Warden
{
    public class DisciplinaryActionVM : BaseViewModel,IDisciplinaryAction
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
        public ICommand TakeDisciplinaryActionCommand => new Command(OnTakeDisciplinaryActionCommand);
        public async void OnTakeDisciplinaryActionCommand()
        {
            if (string.IsNullOrEmpty(DisciplinaryActionbywarden.StudRegno) || DisciplinaryActionbywarden.StudRegno.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Enter Student registration no", "OK");
            else if (string.IsNullOrEmpty(DisciplinaryActionbywarden.Studentname) || DisciplinaryActionbywarden.Studentname.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Enter Student name", "OK");
            else if (string.IsNullOrEmpty(DisciplinaryActionbywarden.Date) || DisciplinaryActionbywarden.Date.Length == 0)
                await App.Current.MainPage.DisplayAlert("HMS", "Enter Date", "OK");
            else if(string.IsNullOrEmpty(DisciplinaryActionbywarden.Time) || DisciplinaryActionbywarden.Time.Length==0)
                await App.Current.MainPage.DisplayAlert("HMS", "Enter Time", "OK");
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

        public DisciplinaryActionVM()
        {
            warden = new WardenService((IDisciplinaryAction)this);
        }
    }
}
