using HMS.Interface;
using HMS.Models;
using HMS.Services;
using HMS.View.Admin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HMS.ViewModel.Admin
{
    public class EditBlockVM : BaseViewModel, MasterI,EditBlockI
    {
        MasterServices web;
        UpdateBlock updateBlock = new UpdateBlock();
        private BlockModel blockModel = new BlockModel();
        private string blockId, hostelid,areaId;
        private string blockname;
        public string BlockId
        {
            get
            {
                return blockId;
            }
            set
            {
                blockId = value;
                OnPropertyChanged("BlockId");
            }
        }
        public string BlockName
        {
            get
            {
                return blockname;
            }
            set
            {
                blockname = value;
                OnPropertyChanged("BlockName");
            }
        }
        public BlockModel BlockModel
        {
            get
            {
                return blockModel;
            }
            set
            {
                blockModel = value;
                OnPropertyChanged("BlockModel");
            }
        }
        public ICommand UpdateBlockCommand => new Command(OnUpdateBlockCommand);
        public async void OnUpdateBlockCommand()
        {
            try
            {
                if(validate())
                {
                    updateBlock.userId=App.userid;
                    updateBlock.blockId = BlockModel.id;
                    updateBlock.blockName = BlockName;
                    updateBlock.hostelId = hostelid;
                    updateBlock.areaId = areaId;
                    web.UpdateBlock(updateBlock);
                }
            }
            catch(Exception ex)
            {

            }
        }
        bool validate()
        {
            if(string.IsNullOrEmpty(BlockModel.id)|| BlockModel.id.Length==0)
            {
                App.Current.MainPage.DisplayAlert("HMS", "Block id required", "OK");
                return false;
            }
            else if(string.IsNullOrEmpty(BlockModel.name)|| BlockModel.name.Length==0)
            {
                App.Current.MainPage.DisplayAlert("HMS", "Block name required", "OK");
                return false;
            }
            return true;
        }
        public EditBlockVM(string id,string name,string hostelid,string areaid)
        {
            BlockModel.id = id;
            BlockModel.name = name;
            BlockName = name;
            this.hostelid = hostelid;
            areaId = areaid;
            web = new MasterServices((MasterI)this,(EditBlockI)this);
        }
        public Task LoadAreaList(ObservableCollection<AreaModel> AreaList)
        {
            throw new NotImplementedException();
        }

        public Task LoadBlockList(ObservableCollection<BlockModel> BlockList)
        {
            throw new NotImplementedException();
        }

        public Task LoadFloorList(ObservableCollection<FloorData> FloorList)
        {
            throw new NotImplementedException();
        }

        public Task LoadHostelList(ObservableCollection<HostelModel> HostelList)
        {
            throw new NotImplementedException();
        }

        public Task LoadRoomList(ObservableCollection<RoomModel> RoomList)
        {
            throw new NotImplementedException();
        }

        public async void PostBlockNameSuccess(string resultBlock)
        {
            BlockModel = new BlockModel();
            updateBlock = new UpdateBlock();
            BlockName = string.Empty;
            await App.Current.MainPage.DisplayAlert("HMS", resultBlock, "OK");
            OnPropertyChanged("BlockName");
            OnPropertyChanged("BlockModel");
            //await App.Current.MainPage.Navigation.PopModalAsync(true);
            //MessagingCenter.Send<EditBlock>((EditBlock)this, "click_profile_tab");
        }

        public async void ServiceFaild(string result)
        {
            await App.Current.MainPage.DisplayAlert("HMS", result, "OK");
        }

        public Task ServiceFailed(int index)
        {
            throw new NotImplementedException();
        }
    }
}
