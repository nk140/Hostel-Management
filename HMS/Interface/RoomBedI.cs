using HMS.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace HMS.Interface
{
    public interface RoomBedI
    {
        Task LoadAreaList(ObservableCollection<AreaModel> AreaList);
        Task LoadHostelList(ObservableCollection<HostelModel> HostelList);
        Task LoadRoomTypeList(ObservableCollection<RoomTypeModel> roomTypeModels);
        Task SaveRoomBedSuccess(string result);
        Task Failer(int index);

    }
    public interface RoomBedI1
    {
        void LoadRoomBedList(ObservableCollection<RoomBedData> roomBedDatas);
        void Failer(string result);
        void NoListFound(string result);

    }
    public interface EditRoomBedI
    {
       // Task LoadAreaList(ObservableCollection<AreaModel> AreaList);
       // Task LoadHostelList(ObservableCollection<HostelModel> HostelList);
      //  Task LoadRoomTypeList(ObservableCollection<RoomTypeModel> roomTypeModels);
        void EditRoomBedSucess(string result);
        void Failer(string result);

    }
    public interface DeleteRoomBedI
    {
        // Task LoadAreaList(ObservableCollection<AreaModel> AreaList);
        // Task LoadHostelList(ObservableCollection<HostelModel> HostelList);
        //  Task LoadRoomTypeList(ObservableCollection<RoomTypeModel> roomTypeModels);
        void DeleteRoomBedSucess(string result);
        void Failer(string result);

    }
}
