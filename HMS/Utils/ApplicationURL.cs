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
        public static string LOGIN = "/hostelandmesstest/api/v1/auth/login";
        public static string Country = "/hostelandmesstest/api/v1/area/country";
        public static string State = "/hostelandmesstest/api/v1/area/state";
        public static string AreaAvailable = "/hostelandmesstest/api/v1/area/localArea";
        public static string AllArea = "/hostelandmesstest/api/v1/area/allArea";
        public static string AllHostel = "/hostelandmesstest/api/v1/hostel/allHostel";
        public static string AllBlock = "/hostelandmesstest/api/v1/hostel/block";
        public static string AllFloor = "/hostelandmesstest/api/v1/hostel/floor";
        public static string AllRoom = "/hostelandmesstest/api/v1/hostel/room";
        public static string AllRoomBed = "/hostelandmesstest/api/v1/hostel/allroombeds";
        public static string AllRoomType = "/hostelandmesstest/api/v1/hostel/roomtype";
        public static string GetRoomList = "/hostelandmesstest/api/v1/roomdetails/hostelDetils";

        #region ADMIN
        public static string AreaInsertion = "/hostelandmesstest/api/v1/area/localArea";
        public static string UpdateArea = "/hostelandmesstest/api/v1/area/areaupdate";
        public static string DeleteArea = "/hostelandmesstest/api/v1/area/deleteareaname";
        public static string HostelInsertion = "/hostelandmesstest/api/v1/hostel/hostelsetup";
        public static string UpdateHostel = "/hostelandmesstest/api/v1/hostel/hostelupdate";
        public static string DeleteHostel = "/hostelandmesstest/api/v1/hostel/deletehostel";
        public static string BlockInsertion = "/hostelandmesstest/api/v1/hostel/blocksetup";
        public static string UpdateBlock = "/hostelandmesstest/api/v1/hostel/blockupdate";
        public static string DeleteBlock = "/hostelandmesstest/api/v1/hostel/deleteblock";
        public static string Floornsertion = "/hostelandmesstest/api/v1/hostel/floorsetup ";
        public static string UpdateFloor = "/hostelandmesstest/api/v1/hostel/floorupdate";
        public static string DeleteFloor = "/hostelandmesstest/api/v1/hostel/deletefloor";
        public static string ServiceCategoryInsertion = "/hostelandmesstest/api/v1/hostel/roomservicecategory";
        public static string UpdateServicecategory = "/hostelandmesstest/api/v1/hostel/servicecategoryupdate";
        public static string DeleteServiceCategory = "/hostelandmesstest/api/v1/hostel/deleteservicecategory";
        public static string FasilityInsertion = "/hostelandmesstest/api/v1/hostel/hostelfacilitysetup";
        public static string FacilityList = "/hostelandmesstest/api/v1/hostel/facilitylist";
        public static string UpdateFacility = "/hostelandmesstest/api/v1/hostel/facilityupdate";
        public static string DeleteFacility = "/hostelandmesstest/api/v1/hostel/deletehostelfacility";
        public static string RoomInsertion = "/hostelandmesstest/api/v1/hostel/roomsetup";
        public static string UpdateRoom = "/hostelandmesstest/api/v1/hostel/roomupdate";
        public static string DeleteRoom = "/hostelandmesstest/api/v1/hostel/deleteroom";
        public static string RoomBedInsertion = "/hostelandmesstest/api/v1/hostel/roombeds";
        public static string UpdateRoomBed = "/hostelandmesstest/api/v1/hostel/roombedupdate";
        public static string DeleteRoomBed = "/hostelandmesstest/api/v1/hostel/deleteroombed";
        public static string RoomTypeInsertioon = "/hostelandmesstest/api/v1/hostel/hostelroomtypesetup";
        public static string UpdateRoomType = "/hostelandmesstest/api/v1/hostel/roomtypeupdate";
        public static string DeleteRoomType = "/hostelandmesstest/api/v1/hostel/deleteroomtype";
        public static string GetAllRole = "/hostelandmesstest/api/v1/warden/roles";
        public static string SaveWarden = "/hostelandmesstest/api/v1/warden/addwarden";
        public static string SaveDisciplinaryType = "/hostelandmesstest/api/v1/hostel/disciplinarytype";
        public static string DisciplinaryList = "/hostelandmesstest/api/v1/hostel/disciplinarytype";
        public static string UpdateDisciplinaryType = "/hostelandmesstest/api/v1/hostel/disciplinarytypeupdate";
        public static string DeleteDisciplinaryType = "/hostelandmesstest/api/v1/hostel/deletedisciplinarytype";
        public static string ParentStudentList = "/hostelandmesstest/api/v1/student/parentstudentlist";
        public static string Wardenassignment = "/hostelandmesstest/api/v1/hostel/wardenAssignment";
        #endregion

        #region Student
        public static string GetProfiile = "/hostelandmesstest/api/v1/student/studentprofile";
        public static string HostelAdmission = "/hostelandmesstest/api/v1/auth/admission";
        public static string GetHostelStudent = "/hostelandmesstest/api/v1/hostel/allAdmissionDetails";
        public static string GetHostelStudentbyapplicationno = "/hostelandmesstest/api/v1/hostel/AdmissionDetails";
        public static string GetLeaveTypeList = "/hostelandmesstest/api/v1/leave/allleavetype";
        public static string SaveLeaveRequest = "/hostelandmesstest/api/v1/leave/applyforleave";
        public static string StudentRegister = "/hostelandmesstest/api/v1/student/studentregister";
        public static string GetAllWarden = "/hostelandmesstest/api/v1/leave/wardeninfo";
        public static string StudentProfileUpdate = "/hostelandmesstest/api/v1/student/studentphoneupdate";
        public static string UpdateStudentPassword = "/hostelandmesstest/api/v1/student/studentpasswordupdate";
        public static string Allcourse = "/hostelandmesstest/api/v1/area/allCourse";
        public static string coursesetup = "/hostelandmesstest/api/v1/area/coursesetup";
        public static string UpdateCourse = "/hostelandmesstest/api/v1/area/courseupdate";
        public static string DeleteCourse = "/hostelandmesstest/api/v1/area/deletecourse";
        #endregion

        #region Warden
        public static string GetAllServiceType = "/hostelandmesstest/api/v1/student/allservicetype";
        public static string WardenRegistration = "/hostelandmesstest/api/v1/warden/wardenregister";
        public static string EditWarenDetail = "/hostelandmesstest/api/v1/warden/wardenupdate";
        public static string DeleteWardenDetail = "/hostelandmesstest/api/v1/warden/deletewarden";
        public static string GetStudentLeaveHistory = "/hostelandmesstest/api/v1/adminleave/adminstatus";
        public static string GetHostelDetailMaster = "/hostelandmesstest/api/v1/hostel/allHostel";
        public static string GetParentApprovalData = "/hostelandmesstest/api/v1/leave/parentleaves";
        public static string Approveleave = "/hostelandmesstest/api/v1/adminleave/adminapprove";
        public static string GetNewAdmittedStudentDetail = "/hostelandmesstest/api/v1/warden/allnewstudentlist";
        public static string Disciplinaryaction = "/hostelandmesstest/api/v1/hostel/wardendisciplanary";
        public static string ViewDisciplinaryActionByAppno = "/hostelandmesstest/api/v1/hostel/allWardenDisciplinaryDetails";
        public static string ViewDisciplinaryAction = "/hostelandmesstest/api/v1/hostel/wardenDisciplinaryDetails";
        public static string UpdateDisciplinaryAction = "/hostelandmesstest/api/v1/hostel/wardendisciplinaryupdate";
        public static string DeleteDisciplinaryAction = "/hostelandmesstest/api/v1/hostel/deletewardendisciplinary";
        #endregion
        #region NewsFeed
        public static string GetNewsFeedData = "/hostelandmesstest/api/v1/notification/allNotification";
        public static string UpdateNotification = "/hostelandmesstest/api/v1/notification/notificationupdate";
        public static string DeleteNotification = "/hostelandmesstest/api/v1/notification/deletenotification";
        #endregion
        #region GUEST
        public static string GuestRegistration = "/hostelandmesstest/api/v1/student/guestregister";
        #endregion
        #region Parent
        public static string ParentRegistration = "/hostelandmesstest/api/v1/student/parentregister";
        public static string UpdatePassword = "/hostelandmesstest/api/v1/student/passwordupdate";
        public static string GetWardeLeaveDetail = "/hostelandmesstest/api/v1/leave/parentleaves";
        public static string ActionAgainstWardLeave = "/hostelandmesstest/api/v1/leave/parrentapprove";
        #endregion
    }
}
