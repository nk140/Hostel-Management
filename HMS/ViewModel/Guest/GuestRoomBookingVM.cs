using HMS.Data;
using HMS.Models;
using System.Collections.ObjectModel;

namespace HMS.ViewModel.Guest
{
    public class GuestRoomBookingVM : BaseViewModel
    {
        private ObservableCollection<GuestRoombooking> guestRoombookings = new ObservableCollection<GuestRoombooking>();
        RequestedGuestRoom requestedGuest = new RequestedGuestRoom();
        #region list
        public ObservableCollection<GuestRoombooking> GuestRoombookings
        {
            get
            {
                return guestRoombookings;
            }
            set
            {
                guestRoombookings = value;
                OnPropertyChanged();
            }
        }
        #endregion
        public GuestRoomBookingVM()
        {
            GuestRoombookings = new ObservableCollection<GuestRoombooking>(requestedGuest.guestbooking);
        }
    }
}
