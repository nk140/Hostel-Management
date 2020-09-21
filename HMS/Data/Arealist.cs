using HMS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HMS.Data
{
    public class AreaList
    {
        public IList<AreaDetaillist> areaDetails { get; set; }
        public AreaList()
        {
            areaDetails = new List<AreaDetaillist>();
            areaDetails.Add(new AreaDetaillist()
            {
                id="1",
                areaname="ollayadu"
            });
            areaDetails.Add(new AreaDetaillist()
            {
                id = "35",
                areaname = "yehlanka"
            });
            areaDetails.Add(new AreaDetaillist()
            {
                id = "38",
                areaname = "timil"
            });
        }
    }
    public class FloorList
    {
        public IList<FloorDetaillist> floordetail { get; set; }
        public FloorList()
        {
            floordetail = new List<FloorDetaillist>();
            floordetail.Add(new FloorDetaillist()
            {
                id = "1",
                floorname = "floor1"
            });
            floordetail.Add(new FloorDetaillist()
            {
                id = "35",
                floorname = "main floor"
            });
            floordetail.Add(new FloorDetaillist()
            {
                id = "38",
                floorname = "floor 5"
            });
        }
    }
    public class BlockList
    {
        public IList<BlockDetaillist> blockDetaillists { get; set; }
        public BlockList()
        {
            blockDetaillists = new List<BlockDetaillist>();
            blockDetaillists.Add(new BlockDetaillist()
            {
                id = "1",
                blockname = "Main Block 1"
            });
            blockDetaillists.Add(new BlockDetaillist()
            {
                id = "35",
                blockname = "main block 12"
            });
            blockDetaillists.Add(new BlockDetaillist()
            {
                id = "38",
                blockname = "block 5"
            });
        }
    }
    public class HostelList
    {
        public IList<HostelDetaillist> hostelDetaillists { get; set; }
        public HostelList()
        {
            hostelDetaillists = new List<HostelDetaillist>();
            hostelDetaillists.Add(new HostelDetaillist()
            {
                id = "1",
                hostelname = "Nimesh Boys Pg"
            });
            hostelDetaillists.Add(new HostelDetaillist()
            {
                id = "35",
                hostelname = "Anshika Girls Hostel"
            });
            hostelDetaillists.Add(new HostelDetaillist()
            {
                id = "38",
                hostelname = "Surya Boys Hostel"
            });
        }
    }
    public class RoomList
    {
        public IList<RoomDetaillists> roomDetaillists { get; set; }
        public RoomList()
        {
            roomDetaillists = new List<RoomDetaillists>();
            roomDetaillists.Add(new RoomDetaillists()
            {
                id = "1",
                roomname = "Royal Enclave"
            });
            roomDetaillists.Add(new RoomDetaillists()
            {
                id = "35",
                roomname = "Dreams Villa"
            });
            roomDetaillists.Add(new RoomDetaillists()
            {
                id = "38",
                roomname = "Maharaja Enclave"
            });
        }
    }
    public class RoombedList
    {
        public IList<RoombedDetaillist> roombedDetaillists { get; set; }
        public RoombedList()
        {
            roombedDetaillists = new List<RoombedDetaillist>();
            roombedDetaillists.Add(new RoombedDetaillist()
            {
                id = "1",
                roombedname = "Royal enclave/bed1"
            });
            roombedDetaillists.Add(new RoombedDetaillist()
            {
                id = "35",
                roombedname = "Dreams Villa/bed 3"
            });
            roombedDetaillists.Add(new RoombedDetaillist()
            {
                id = "38",
                roombedname = "Maharaja Enclave/bed 2"
            });
        }
    }
}
