using HMS.Data;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace HMS.ViewModel.Warden
{
    public class NotificationVM : BaseViewModel
    {
        private ObservableCollection<Studentlevanotificationmodel> studentlevanotificationmodels = new ObservableCollection<Studentlevanotificationmodel>();
        private bool _IsReadAll;
        private bool _IsReadChecked;
        public Studentleavenotification studentleavenotification;
        #region list
        public ObservableCollection<Studentlevanotificationmodel> Studentlevanotificationmodels
        {
            get
            {
                return studentlevanotificationmodels;
            }
            set
            {
                studentlevanotificationmodels = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region CheckedProperties
        public bool IsReadAll
        {
            get
            {
                return _IsReadAll;
            }
            set
            {
                _IsReadAll = value;
                OnPropertyChanged();
            }
        }
        public bool IsReadChecked
        {
            get
            {
                return _IsReadChecked;
            }
            set
            {
                _IsReadChecked = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region commands
        public ICommand ReadAllCommand => new Command(OnReadAllCommand);
        #endregion
        public NotificationVM()
        {
            studentleavenotification = new Studentleavenotification();
            Studentlevanotificationmodels = new ObservableCollection<Studentlevanotificationmodel>(studentleavenotification.studentlevanotifications);
        }
        public async void OnReadAllCommand()
        {
            //if (IsReadAll == true)
            //    foreach (var items in Studentlevanotificationmodels)
            //    {
            //        items.IsReadChecked = true;
            //    }
        }
    }
}
