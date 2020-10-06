using HMS.Interface;
using HMS.Models;
using HMS.Services;
using HMS.View.Student;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HMS.ViewModel.Student
{
    public class ViewDisciplinaryActionVM : BaseViewModel, ViewDisciplinaryActionTaken
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
            wardenService = new WardenService((ViewDisciplinaryActionTaken)this);
            wardenService.GetAllDisciplinaryAction();
        }
        public ICommand EditCommand => new Command<ViewDisciplinaryActionbywarden>(OnEditCommand);
        public ICommand ViewCommand => new Command<ViewDisciplinaryActionbywarden>(OnViewCommand);
        public ICommand DeleteCommand => new Command<ViewDisciplinaryActionbywarden>(OnDeleteCommand);
        public async void OnEditCommand(ViewDisciplinaryActionbywarden obj)
        {

        }
        public async void OnViewCommand(ViewDisciplinaryActionbywarden obj)
        {
            await App.Current.MainPage.Navigation.PushPopupAsync(new ViewDisciplinaryActionPopup(obj.date, obj.time, obj.studentName, obj.appicationNo, obj.disciplinaryTypeName, obj.discription));
        }
        public async void OnDeleteCommand(ViewDisciplinaryActionbywarden obj)
        {

        }
        public async void servicefailed(string result)
        {

        }

        public async void LoadTakenDisciplinaryAction(ObservableCollection<ViewDisciplinaryActionbywarden> disciplinaryActionbywardens)
        {
            DisciplinaryActionbywardens = disciplinaryActionbywardens;
            OnPropertyChanged("DisciplinaryActionbywardens");
        }
    }
}
