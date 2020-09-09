using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace HMS.ViewModel.Admin
{
    public class DisciplinaryTypeVM : BaseViewModel, IDisciplinary
    {
        private string _DisciplinaryReason;
        MasterServices masterService;
        #region properties
        public string DisciplinaryReason
        {
            get
            {
                return _DisciplinaryReason;
            }
            set
            {
                _DisciplinaryReason = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Commands
        public ICommand SaveCommands => new Command(OnSaveCommands);
        #endregion
        public DisciplinaryTypeVM()
        {
            masterService = new MasterServices(this);
        }
        public async void OnSaveCommands()
        {
            if (string.IsNullOrEmpty(DisciplinaryReason))
                await App.Current.MainPage.DisplayAlert("HMS", "Enter Disciplinary Type", "OK");
            else
            {
                DisciplinaryType disciplinary = new DisciplinaryType();
                disciplinary.name = DisciplinaryReason;
                disciplinary.userId = App.userid;
                masterService.Savedisciplinary(disciplinary);
            }
        }
        public void SaveDisciplinaryType(string result)
        {
            DisciplinaryReason = string.Empty;
            App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }
    }
}
