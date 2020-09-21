using HMS.Data;
using HMS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HMS.ViewModel.Admin
{
    public class ViewAreaVM : BaseViewModel
    {
        AreaList list = new AreaList();
        HostelList hostelList = new HostelList();
        RoomDetailList roomDetail = new RoomDetailList();
        RoombedList roombedList = new RoombedList();
        private ObservableCollection<AreaDetaillist> areaLists = new ObservableCollection<AreaDetaillist>();
        public ObservableCollection<AreaDetaillist> AreaLists
        {
            get
            {
                return areaLists;
            }
            set
            {
                areaLists = value;
                OnPropertyChanged();
            }
        }
        public ViewAreaVM()
        {
            AreaLists = new ObservableCollection<AreaDetaillist>(list.areaDetails);
        }
    }
    public class ViewBlockVM : BaseViewModel
    {
        BlockList blockList = new BlockList();
        private ObservableCollection<BlockDetaillist> blockDetaillists = new ObservableCollection<BlockDetaillist>();
        AreaList list = new AreaList();
        public ObservableCollection<BlockDetaillist> BlockDetaillists
        {
            get
            {
                return blockDetaillists;
            }
            set
            {
                blockDetaillists = value;
                OnPropertyChanged();
            }
        }
        public ViewBlockVM()
        {
            BlockDetaillists = new ObservableCollection<BlockDetaillist>(blockList.blockDetaillists);
        }
    }
    public class ViewFloorVM : BaseViewModel
    {
        FloorList floorList = new FloorList();
        private ObservableCollection<FloorDetaillist> floorDetaillists = new ObservableCollection<FloorDetaillist>();
        AreaList list = new AreaList();
        public ObservableCollection<FloorDetaillist> FloorDetaillists
        {
            get
            {
                return floorDetaillists;
            }
            set
            {
                floorDetaillists = value;
                OnPropertyChanged();
            }
        }
        public ViewFloorVM()
        {
            FloorDetaillists = new ObservableCollection<FloorDetaillist>(floorList.floordetail);
        }
    }
    public class ViewHostelVM : BaseViewModel
    {
        HostelList hostelList = new HostelList();
        private ObservableCollection<HostelDetaillist> hostelDetaillists = new ObservableCollection<HostelDetaillist>();
        AreaList list = new AreaList();
        public ObservableCollection<HostelDetaillist> HostelDetaillists
        {
            get
            {
                return hostelDetaillists;
            }
            set
            {
                hostelDetaillists = value;
                OnPropertyChanged();
            }
        }
        public ViewHostelVM()
        {
            HostelDetaillists = new ObservableCollection<HostelDetaillist>(hostelList.hostelDetaillists);
        }
    }
}
