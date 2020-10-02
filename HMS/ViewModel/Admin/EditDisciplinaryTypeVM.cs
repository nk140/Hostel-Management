using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HMS.ViewModel.Admin
{
    public class EditDisciplinaryTypeVM : BaseViewModel,IEditDisciplinary
    {
        MasterServices web;
        private UpdateDisciplinaryType updateDisciplinaryType = new UpdateDisciplinaryType();
        public UpdateDisciplinaryType UpdateDisciplinaryTypes
        {
            get
            {
                return updateDisciplinaryType;
            }
            set
            {
                updateDisciplinaryType = value;
                OnPropertyChanged("UpdateDisciplinaryTypes");
            }
        }
        public ICommand UpdateDisciplinaryTypeCommand => new Command(OnUpdateDisciplinaryTypeCommand);
        public async void OnUpdateDisciplinaryTypeCommand()
        {
            if(validate())
            {
                web.UpdateDisciplinaryType(UpdateDisciplinaryTypes);
            }
        }
        bool validate()
        {
            if(UpdateDisciplinaryTypes.name.Length==0 || string.IsNullOrEmpty(UpdateDisciplinaryTypes.name))
            {
                App.Current.MainPage.DisplayAlert("HMS", "Disciplinary Name Required", "OK");
                return false;
            }
            return true;
        }
        public void UpdateDisciplinaryType(string result)
        {
            App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }

        public  void Failer(string result)
        {
            App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }

        public EditDisciplinaryTypeVM(string id, string disciplinaryname, string userid)
        {
            UpdateDisciplinaryTypes.id = id;
            UpdateDisciplinaryTypes.name = disciplinaryname;
            UpdateDisciplinaryTypes.userId = userid;
            web = new MasterServices((IEditDisciplinary)this);
        }
    }
}
