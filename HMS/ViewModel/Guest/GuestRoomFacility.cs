using HMS.Data;
using HMS.Models;
using System.Collections.ObjectModel;

namespace HMS.ViewModel.Guest
{
    public class GuestRoomFacility : BaseViewModel
    {
        private ObservableCollection<Room> roomdetails = new ObservableCollection<Room>();
        public RoomDetailList roomDetail = new RoomDetailList();
        #region Listproperties
        public ObservableCollection<Room> RoomDetails
        {
            get
            {
                return roomdetails;
            }
            set
            {
                roomdetails = value;
                OnPropertyChanged();
            }
        }
        #endregion
        public GuestRoomFacility()
        {
            RoomDetails = new ObservableCollection<Room>(roomDetail.Rooms);
        }
    }
}
