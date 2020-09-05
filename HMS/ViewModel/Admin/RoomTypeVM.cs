using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HMS.ViewModel.Admin
{
    public class RoomTypeVM : BaseViewModel, RoomTypeI
    {
        public RoomTypeVM()
        {
            web = new StudentService(this);
        }

        StudentService web;

        RoomTypeModel roomType_ = new RoomTypeModel();

        public RoomTypeModel RoomType
        {
            get { return roomType_; }
            set { roomType_ = value; OnPropertyChanged("RoomType"); }
        }
        public Command SaveCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (RoomType.hostelRoomTypeName == null || RoomType.hostelRoomTypeName.Length == 0)
                    {
                        App.Current.MainPage.DisplayAlert("", "Enter Room Type Name", "OK");
                    }
                    else if (RoomType.noOfOccupants == null || RoomType.hostelRoomTypeName.Length == 0)
                    {
                        App.Current.MainPage.DisplayAlert("", "Enter Number of occupants.", "OK");
                    }
                    else
                    {
                        SaveRoomType saveRoomType = new SaveRoomType();
                        saveRoomType.userId = App.userid;
                        saveRoomType.hostelRoomTypeName = RoomType.hostelRoomTypeName;
                        saveRoomType.noOfOccupants = RoomType.noOfOccupants;
                        web.SaveRoomType(saveRoomType);
                    }
                });
            }
        }
        public async Task ServiceFaild(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }

        public async Task PostRoomTypeSuccess(string result)
        {
            await App.Current.MainPage.DisplayAlert("", result, "OK");
            RoomType.hostelRoomTypeName = "";
            RoomType.noOfOccupants = "";
            OnPropertyChanged("RoomType");
        }
    }
}
