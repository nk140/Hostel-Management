using HMS.Interface;
using HMS.Models;
using HMS.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace HMS.ViewModel.Student
{
    public class RoomListVM : BaseViewModel, RoomListI1
    {
        public RoomListVM()
        {
            web = new MasterServices(this);
            web.RoomList();
        }


        private ObservableCollection<RoomListModel> RoomList_ = new ObservableCollection<RoomListModel>();
        MasterServices web;

        public ObservableCollection<RoomListModel> RoomList
        {
            get { return RoomList_; }
            set { RoomList_ = value; OnPropertyChanged("RoomList"); }
        }

        public async Task LoadRoomList(ObservableCollection<RoomListModel> list_)
        {
            RoomList = new ObservableCollection<RoomListModel>();
            RoomList = list_;
            OnPropertyChanged("RoomList");
        }

        public Task Failer()
        {
            throw new NotImplementedException();
        }
    }
}
