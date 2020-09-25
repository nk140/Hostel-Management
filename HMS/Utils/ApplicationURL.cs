namespace HMS.Utils
{
    public class ApplicationURL
    {
        //Production
        // public static string BaseURL = "https://erp.reva.edu.in";

        // Development
        // public static string BaseURL = "http://172.16.16.5:8080";
        public static string BaseURL = "http://203.192.204.167:8081";
        // public static string BaseURL = "http://203.192.204.167:8080";

        //  public static string BaseURL = "http://203.192.204.167:8080";

        // lOCAL SERVER
        // public static string BaseURL = "http://172.16.16.148:8282";

        //  revastudentapiios war file name
        public static string LOGIN = "/hostelandmess/api/v1/auth/login";
        public static string Country = "/hostelandmess/api/v1/area/country";
        public static string State = "/hostelandmess/api/v1/area/state";
        public static string AreaAvailable = "/hostelandmess/api/v1/area/localArea";
        public static string AllArea = "/hostelandmess/api/v1/area/allArea";
        public static string AllHostel = "/hostelandmess/api/v1/hostel/allHostel";
        public static string AllBlock = "/hostelandmess/api/v1/hostel/block";
        public static string AllFloor = "/hostelandmess/api/v1/hostel/floor";
        public static string AllRoom = "/hostelandmess/api/v1/hostel/room";
        public static string AllRoomBed = "/hostelandmess/api/v1/hostel/allroombeds";
        public static string AllRoomType = "/hostelandmess/api/v1/hostel/roomtype";
        public static string GetRoomList = "/hostelandmess/api/v1/roomdetails/hostelDetils";

        #region ADMIN
        public static string AreaInsertion = "/hostelandmess/api/v1/area/localArea";
        public static string UpdateArea = "/hostelandmess/api/v1/area/areaupdate";
        public static string DeleteArea = "/hostelandmess/api/v1/area/deleteareaname";
        public static string HostelInsertion = "/hostelandmess/api/v1/hostel/hostelsetup";
        public static string UpdateHostel = "/hostelandmess/api/v1/hostel/hostelupdate";
        public static string DeleteHostel = "/hostelandmess/api/v1/hostel/deletehostel";
        public static string BlockInsertion = "/hostelandmess/api/v1/hostel/blocksetup";
        public static string UpdateBlock = "/hostelandmess/api/v1/hostel/blockupdate";
        public static string DeleteBlock = "/hostelandmess/api/v1/hostel/deleteblock";
        public static string Floornsertion = "/hostelandmess/api/v1/hostel/floorsetup ";
        public static string UpdateFloor = "/hostelandmess/api/v1/hostel/floorupdate";
        public static string DeleteFloor = "/hostelandmess/api/v1/hostel/deletefloor";
        public static string ServiceCategoryInsertion = "/hostelandmess/api/v1/hostel/roomservicecategory";
        public static string UpdateServicecategory = "/hostelandmess/api/v1/hostel/servicecategoryupdate";
        public static string DeleteServiceCategory = "/hostelandmess/api/v1/hostel/deleteservicecategory";
        public static string FasilityInsertion = "/hostelandmess/api/v1/hostel/hostelfacilitysetup";
        public static string UpdateFacility = "/hostelandmess/api/v1/hostel/facilityupdate";
        public static string DeleteFacility = "/hostelandmess/api/v1/hostel/deletehostelfacility";
        public static string RoomInsertion = "/hostelandmess/api/v1/hostel/roomsetup";
        public static string UpdateRoom = "/hostelandmess/api/v1/hostel/roomupdate";
        public static string DeleteRoom = "/hostelandmess/api/v1/hostel/deleteroom";
        public static string RoomBedInsertion = "/hostelandmess/api/v1/hostel/roombeds";
        public static string UpdateRoomBed = "/hostelandmess/api/v1/hostel/roombedupdate";
        public static string DeleteRoomBed = "/hostelandmess/api/v1/hostel/deleteroombed";
        public static string RoomTypeInsertioon = "/hostelandmess/api/v1/hostel/hostelroomtypesetup";
        public static string UpdateRoomType = "/hostelandmess/api/v1/hostel/roomtypeupdate";
        public static string DeleteRoomType = "/hostelandmess/api/v1/hostel/deleteroomtype";

        public static string GetAllRole = "/hostelandmess/api/v1/warden/roles";
        public static string SaveWarden = "/hostelandmess/api/v1/warden/addwarden";
        public static string SaveDisciplinaryType = "/hostelandmess/api/v1/hostel/disciplinarytype";
        public static string UpdateDisciplinaryType = "/hostelandmess/api/v1/hostel/disciplinarytypeupdate";
        public static string DeleteDisciplinaryType = "/hostelandmess/api/v1/hostel/deletedisciplinarytype";
        #endregion

        #region Student
        public static string GetProfiile = "/hostelandmess/api/v1/student/studentprofile";
        public static string GetLeaveTypeList = "/hostelandmess/api/v1/leave/allleavetype";
        public static string SaveLeaveRequest = "/hostelandmess/api/v1/leave/applyforleave";
        public static string StudentRegister = "/hostelandmess/api/v1/student/studentregister";
        public static string GetAllWarden = "/hostelandmess/api/v1/leave/wardeninfo";
        public static string StudentProfileUpdate = "/hostelandmess/api/v1/student/studentphoneupdate";
        #endregion

        #region Warden
        public static string GetAllServiceType = "/hostelandmess/api/v1/student/allservicetype";
        public static string WardenRegistration = "/hostelandmess/api/v1/warden/wardenregister";
        public static string GetStudentLeaveHistory = "/hostelandmess/api/v1/adminleave/adminstatus";
        public static string GetHostelDetailMaster = "/hostelandmess/api/v1/hostel/allHostel";
        public static string GetParentApprovalData = "/hostelandmess/api/v1/leave/parentleaves";
        public static string Approveleave = "/hostelandmess/api/v1/adminleave/adminapprove";
        public static string GetNewAdmittedStudentDetail = "/hostelandmess/api/v1/warden/allnewstudentlist";
        #endregion
        #region NewsFeed
        public static string GetNewsFeedData = "/hostelandmess/api/v1/notification/allNotification";
        public static string UpdateNotification = "/hostelandmess/api/v1/notification/notificationupdate";
        public static string DeleteNotification = "/hostelandmess/api/v1/notification/deletenotification";
        #endregion
        #region GUEST
        public static string GuestRegistration = "/hostelandmess/api/v1/student/guestregister";
        #endregion
        #region Parent
        public static string ParentRegistration = "/hostelandmess/api/v1/student/parentregister";
        #endregion
    }
}
