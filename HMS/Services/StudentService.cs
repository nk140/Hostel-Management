using Acr.UserDialogs;
using HMS.Interface;
using HMS.Models;
using HMS.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;

namespace HMS.Services
{
    public class StudentService
    {

        ProfileI profileCallback;
        HostelAdmissionI hostelAdmissionI;
        ViewHostelAdmittedStudent iviewhosteladmittedstudent;
        Iupdatestudentpassword iupdatestudentpassword;
        StudentLeaveRequestI leaveRequestCallback;
        icreateleavetype icreateleavetype;
        EditleaveType editleaveType;
        DeleteLeavetype deleteLeavetype;
        RegistrationI registrationCallback;
        RoomTypeI roomTypeCallback;
        ContactWardenI ContactWardenCallback;
        IEditWardenDetail editWardenDetail;
        IDeleteWardenDetail deleteWardenDetail;
        Iservicecategory iservicecategory;
        Icoursedetail icoursedetail;
        IEditCourse ieditcourse;
        IDeleteCourse deleteCourse;
        ISaveCourse saveCourse;
        ViewDisciplinaryActionTaken disciplinaryActionTaken;
        ViewLeaveStatus viewLeaveStatus;
        Iviewservicestatus iviewservicestatus;
        public StudentService(ProfileI callback)
        {
            profileCallback = callback;
        }
        public StudentService(ViewLeaveStatus iviewleavestatus)
        {
            viewLeaveStatus = iviewleavestatus;
        }
        public StudentService(ViewDisciplinaryActionTaken callback)
        {
            disciplinaryActionTaken = callback;
        }
        public StudentService(Iviewservicestatus callback)
        {
            iviewservicestatus = callback;
        }
        public StudentService(Iservicecategory servicecategorydata, ProfileI callback)
        {
            iservicecategory = servicecategorydata;
            profileCallback = callback;
        }
        public StudentService(IEditWardenDetail callback)
        {
            editWardenDetail = callback;
        }
        public StudentService(icreateleavetype createleavetype)
        {
            icreateleavetype = createleavetype;
        }
        public StudentService(EditleaveType ieditleavetype)
        {
            editleaveType = ieditleavetype;
        }
        public StudentService(Icoursedetail coursedetail)
        {
            icoursedetail = coursedetail;
        }
        public StudentService(Icoursedetail coursedetail, IDeleteCourse ideletecourse)
        {
            icoursedetail = coursedetail;
            deleteCourse = ideletecourse;
        }
        public StudentService(IEditCourse editCourse)
        {
            ieditcourse = editCourse;
        }
        public StudentService(ISaveCourse isavecourse)
        {
            saveCourse = isavecourse;
        }
        public StudentService(Iupdatestudentpassword updatestudentpassword)
        {
            iupdatestudentpassword = updatestudentpassword;
        }
        public StudentService(ProfileI viewHostelAdmittedStudent, StudentLeaveRequestI callback)
        {
            profileCallback = viewHostelAdmittedStudent;
            leaveRequestCallback = callback;
        }
        public StudentService(StudentLeaveRequestI callback)
        {
            leaveRequestCallback = callback;
        }
        public StudentService(StudentLeaveRequestI callback, DeleteLeavetype ideleteleavetype)
        {
            leaveRequestCallback = callback;
            deleteLeavetype = ideleteleavetype;
        }
        public StudentService(ContactWardenI callback, IDeleteWardenDetail ideleteWardenDetail)
        {
            ContactWardenCallback = callback;
            deleteWardenDetail = ideleteWardenDetail;
        }
        public StudentService(HostelAdmissionI hostel, Icoursedetail coursedetail, ProfileI calls)
        {
            hostelAdmissionI = hostel;
            icoursedetail = coursedetail;
            profileCallback = calls;
        }
        public StudentService(ViewHostelAdmittedStudent viewHostelAdmittedStudent)
        {
            iviewhosteladmittedstudent = viewHostelAdmittedStudent;
        }
        public StudentService(RegistrationI callback)
        {
            registrationCallback = callback;
        }

        public StudentService(RoomTypeI callback)
        {
            roomTypeCallback = callback;
        }

        public StudentService(ContactWardenI callback)
        {
            ContactWardenCallback = callback;
        }
        public StudentService(Iservicecategory servicecategorydata)
        {
            iservicecategory = servicecategorydata;
        }
        public async void GetProfiile(string studentId)
        {

            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);


                client.DefaultRequestHeaders.Add("studentId", studentId);

                HttpResponseMessage response = await client.GetAsync(ApplicationURL.GetProfiile);
                string result = await response.Content.ReadAsStringAsync();
                if ((int)response.StatusCode == 200)
                {
                    ObservableCollection<StudentProfileModel> profile = JsonConvert.DeserializeObject<ObservableCollection<StudentProfileModel>>(result);
                    if (profile.Count != 0)
                    {
                        UserDialogs.Instance.HideLoading();
                        profileCallback.LoadStudentProfile(profile);
                    }
                    else
                    {
                        UserDialogs.Instance.HideLoading();
                        await profileCallback.ServiceFaild();
                    }

                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    await profileCallback.ServiceFaild();
                    await App.Current.MainPage.DisplayAlert(" ", "Data Error", "OK");

                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await profileCallback.ServiceFaild();
            }

            //return response;
        }
        public async void GetRequestedServiceStatus(string studentId)
        {

            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                client.DefaultRequestHeaders.Add("studentId", studentId);
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.GetRequestedservicestatus);
                string result = await response.Content.ReadAsStringAsync();
                if ((int)response.StatusCode == 200)
                {
                    ObservableCollection<ViewRequestedServiceStatusModel> profile = JsonConvert.DeserializeObject<ObservableCollection<ViewRequestedServiceStatusModel>>(result);
                    foreach (var items in profile)
                    {
                        if (items.workStatus == true)
                        {
                            items.WorkStatus = "Completed";
                        }
                        else
                        {
                            items.WorkStatus = "Pending";
                        }
                        UserDialogs.Instance.HideLoading();
                        iviewservicestatus.LoadServicestatus(profile);
                    }
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    iviewservicestatus.failer("Data Not Found.");
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                iviewservicestatus.failer("Something went wrong.");
            }

            //return response;
        }
        public async void GetDisciplinaryDetails(string studentId)
        {
            try
            {
                UserDialogs.Instance.ShowLoading();
                ObservableCollection<StudentDisciplinaryDetails> profile = new ObservableCollection<StudentDisciplinaryDetails>();
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                client.DefaultRequestHeaders.Add("studentId", studentId);

                HttpResponseMessage response = await client.GetAsync(ApplicationURL.StudentDisciplinaryList);
                string result = await response.Content.ReadAsStringAsync();
                if ((int)response.StatusCode == 200)
                {
                    profile = JsonConvert.DeserializeObject<ObservableCollection<StudentDisciplinaryDetails>>(result);
                    if (profile.Count != 0)
                    {
                        UserDialogs.Instance.HideLoading();
                        disciplinaryActionTaken.LoadStudentdisciplinarylist(profile);
                    }
                    else
                    {
                        UserDialogs.Instance.HideLoading();
                        disciplinaryActionTaken.servicefailed("No Disciplinary record");
                    }

                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    disciplinaryActionTaken.servicefailed("Data Error");
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                disciplinaryActionTaken.servicefailed("Seems that you didn't done anything wrong in the hostel");
            }

            //return response;
        }
        public async void GetCourseList()
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.Allcourse);
                string result = await response.Content.ReadAsStringAsync();
                if ((int)response.StatusCode == 200)
                {

                    ObservableCollection<CourseDetailModel> profile = JsonConvert.DeserializeObject<ObservableCollection<CourseDetailModel>>(result);
                    if (profile.Count > 0)
                    {
                        icoursedetail.GetCourseList(profile);
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("HMS", "No Course Found", "OK");
                    }
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert(" ", "Data Error", "OK");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert(" ", "Server Error", "OK");
            }
        }
        public async void CreateCourse(CourseModel courseModel)
        {
            CourseResponse courseResponse;
            CourseErrorResponse courseErrorResponse;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);

                string jsn = JsonConvert.SerializeObject(courseModel);

                var content = new StringContent(jsn, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(ApplicationURL.coursesetup, content);

                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    courseResponse = JsonConvert.DeserializeObject<CourseResponse>(resultHostel);
                    saveCourse.Sucess(courseResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    courseErrorResponse = JsonConvert.DeserializeObject<CourseErrorResponse>(resultHostel);
                    saveCourse.servicefailed(courseErrorResponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void RequestServiceByStudent(RequestServiceModel requestServiceModel)
        {
            CourseResponse courseResponse;
            CourseErrorResponse courseErrorResponse;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                client.DefaultRequestHeaders.Add("studentId", App.userid);
                string jsn = JsonConvert.SerializeObject(requestServiceModel);

                var content = new StringContent(jsn, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(ApplicationURL.ServiceRequestByStudent, content);

                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    courseResponse = JsonConvert.DeserializeObject<CourseResponse>(resultHostel);
                    iservicecategory.requestedsucess(courseResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    courseErrorResponse = JsonConvert.DeserializeObject<CourseErrorResponse>(resultHostel);
                    iservicecategory.failer(courseErrorResponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void UpdateCourse(UpdateCourseModel updateCourseModel)
        {
            ProfileUpdateResponse profileUpdateResponse;
            ProfileUpdateErrorresponse profileUpdateErrorresponse;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);

                string jsn = JsonConvert.SerializeObject(updateCourseModel);

                var content = new StringContent(jsn, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(ApplicationURL.UpdateCourse, content);

                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    profileUpdateResponse = JsonConvert.DeserializeObject<ProfileUpdateResponse>(resultHostel);
                    ieditcourse.UpdateSucess(profileUpdateResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    profileUpdateErrorresponse = JsonConvert.DeserializeObject<ProfileUpdateErrorresponse>(resultHostel);
                    ieditcourse.servicefailed(profileUpdateErrorresponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void DeleteCourse(string courseId)
        {
            UpdateRoomTypeResponse updateNewsFeedResponse;
            UpdateRoomErrorTypeResponse updateNewsFeederrorresponse;
            HttpResponseMessage response;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                UserDialogs.Instance.ShowLoading();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                string json = @"[{""courseId"" : """ + courseId + @"""}]";
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync(ApplicationURL.DeleteCourse, content);
                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateNewsFeedResponse = JsonConvert.DeserializeObject<UpdateRoomTypeResponse>(result);
                    deleteCourse.DeleteSucess(updateNewsFeedResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateNewsFeederrorresponse = JsonConvert.DeserializeObject<UpdateRoomErrorTypeResponse>(result);
                    deleteCourse.servicefailed(updateNewsFeederrorresponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void CreateLeaveType(CreateLeaveTypeModel createLeaveTypeModel)
        {
            CourseResponse courseResponse;
            CourseErrorResponse courseErrorResponse;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);

                string jsn = JsonConvert.SerializeObject(createLeaveTypeModel);

                var content = new StringContent(jsn, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(ApplicationURL.CreateLeaveType, content);

                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    courseResponse = JsonConvert.DeserializeObject<CourseResponse>(resultHostel);
                    icreateleavetype.sucess(courseResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    courseErrorResponse = JsonConvert.DeserializeObject<CourseErrorResponse>(resultHostel);
                    icreateleavetype.failer(courseErrorResponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void UpdateLeavetype(UpdateLeavetype updateLeavetype)
        {
            CourseResponse courseResponse;
            CourseErrorResponse courseErrorResponse;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);

                string jsn = JsonConvert.SerializeObject(updateLeavetype);

                var content = new StringContent(jsn, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(ApplicationURL.EditLeavetype, content);

                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    courseResponse = JsonConvert.DeserializeObject<CourseResponse>(resultHostel);
                    editleaveType.sucess(courseResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    courseErrorResponse = JsonConvert.DeserializeObject<CourseErrorResponse>(resultHostel);
                    editleaveType.failer(courseErrorResponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void DeleteLeavetype(string leaveTypeId)
        {
            UpdateRoomTypeResponse updateNewsFeedResponse;
            UpdateRoomErrorTypeResponse updateNewsFeederrorresponse;
            HttpResponseMessage response;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                UserDialogs.Instance.ShowLoading();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                string json = @"[{""leaveTypeId"" : """ + leaveTypeId + @"""}]";
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync(ApplicationURL.DeleteLeavetype, content);
                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateNewsFeedResponse = JsonConvert.DeserializeObject<UpdateRoomTypeResponse>(result);
                    deleteLeavetype.deletesucess(updateNewsFeedResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateNewsFeederrorresponse = JsonConvert.DeserializeObject<UpdateRoomErrorTypeResponse>(result);
                    deleteLeavetype.failer(updateNewsFeederrorresponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void UpdateProfile(ProfileUpdate profileUpdate)
        {
            ProfileUpdateResponse profileUpdateResponse;
            ProfileUpdateErrorresponse profileUpdateErrorresponse;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);

                string jsn = JsonConvert.SerializeObject(profileUpdate);

                var content = new StringContent(jsn, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(ApplicationURL.StudentProfileUpdate, content);

                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    profileUpdateResponse = JsonConvert.DeserializeObject<ProfileUpdateResponse>(resultHostel);
                    profileCallback.UpdatedSucessfully(profileUpdateResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    profileUpdateErrorresponse = JsonConvert.DeserializeObject<ProfileUpdateErrorresponse>(resultHostel);
                    profileCallback.UpdatedSucessfully(profileUpdateErrorresponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void UpdateStudentPassword(UpdateStudPassword updateStudPassword)
        {
            UpdateStudPasswordResponse updateStudPasswordResponse;
            UpdateStudErrorResponse updateStudErrorResponse;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);

                string jsn = JsonConvert.SerializeObject(updateStudPassword);

                var content = new StringContent(jsn, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(ApplicationURL.UpdateStudentPassword, content);

                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    updateStudPasswordResponse = JsonConvert.DeserializeObject<UpdateStudPasswordResponse>(resultHostel);
                    iupdatestudentpassword.UpdatedSucessfully(updateStudPasswordResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    updateStudErrorResponse = JsonConvert.DeserializeObject<UpdateStudErrorResponse>(resultHostel);
                    iupdatestudentpassword.ServiceFaild(updateStudErrorResponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void SaveHostelAdmission(HostelAdmission hostelAdmission)
        {
            HostelAdmissionResponse hostelAdmissionResponse;
            HostelAdmissionErrorResponse hostelAdmissionErrorResponse;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);

                string jsn = JsonConvert.SerializeObject(hostelAdmission);

                var content = new StringContent(jsn, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(ApplicationURL.HostelAdmission, content);

                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    hostelAdmissionResponse = JsonConvert.DeserializeObject<HostelAdmissionResponse>(resultHostel);
                    hostelAdmissionI.Sucess(hostelAdmissionResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    hostelAdmissionErrorResponse = JsonConvert.DeserializeObject<HostelAdmissionErrorResponse>(resultHostel);
                    hostelAdmissionI.failed(hostelAdmissionErrorResponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void GetAllLeaveType()
        {
            LeaveTypeerrorresponse leaveTypeerrorresponse;
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);


                HttpResponseMessage response = await client.GetAsync(ApplicationURL.GetLeaveTypeList);
                string result = await response.Content.ReadAsStringAsync();
                if ((int)response.StatusCode == 200)
                {

                    ObservableCollection<LeaveTypeModel> leaveType = JsonConvert.DeserializeObject<ObservableCollection<LeaveTypeModel>>(result);
                    if (leaveType.Count > 0)
                    {
                        for (int i = 0; i < leaveType.Count; i++)
                        {
                            leaveType[i].listcount = (i + 1).ToString();
                        }
                        await leaveRequestCallback.GetAllLeaveType(leaveType);
                    }
                    else
                    {
                        result = await response.Content.ReadAsStringAsync();
                        leaveTypeerrorresponse = JsonConvert.DeserializeObject<LeaveTypeerrorresponse>(result);
                        await leaveRequestCallback.ServiceFaild(leaveTypeerrorresponse.errors[0].message);
                    }

                }
                else
                {
                    result = await response.Content.ReadAsStringAsync();
                    leaveTypeerrorresponse = JsonConvert.DeserializeObject<LeaveTypeerrorresponse>(result);
                    await leaveRequestCallback.ServiceFaild(leaveTypeerrorresponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("HMS", "No Leave Type List Found.", "OK");
            }

            //return response;
        }
        public async void GetLeaveStatus(string studentId)
        {
            try
            {
                var client = new HttpClient();
                UserDialogs.Instance.ShowLoading();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                client.DefaultRequestHeaders.Add("studentId", studentId);
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.GetLeaveStatus);
                string result = await response.Content.ReadAsStringAsync();
                if ((int)response.StatusCode == 200)
                {

                    ObservableCollection<ViewLeaveStatusModel> profile = JsonConvert.DeserializeObject<ObservableCollection<ViewLeaveStatusModel>>(result);
                    if (profile.Count > 0)
                    {
                        foreach (var items in profile)
                        {
                            if (items.wardenApproved.Equals("true"))
                            {
                                items.leavestatus = "Leave Approved";
                                items.isrejectreasonavaialble = false;
                            }
                            else
                            {
                                items.leavestatus = "Leave Rejected";
                                items.isrejectreasonavaialble = true;
                            }
                        }
                        UserDialogs.Instance.HideLoading();
                        viewLeaveStatus.GetLeavestatus(profile);
                    }
                    else
                    {
                        UserDialogs.Instance.HideLoading();
                        viewLeaveStatus.failer("No Leave Status Found");
                    }
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    viewLeaveStatus.failer("Server Issue");
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                viewLeaveStatus.failer("Seems that you haven't applied for any leave.");
            }
        }
        public async void GetHostelStudent()
        {
            LeaveTypeerrorresponse leaveTypeerrorresponse;
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);


                HttpResponseMessage response = await client.GetAsync(ApplicationURL.GetHostelStudent);
                string result = await response.Content.ReadAsStringAsync();
                if ((int)response.StatusCode == 200)
                {

                    ObservableCollection<HostelAdmittedStudentDetails> leaveType = JsonConvert.DeserializeObject<ObservableCollection<HostelAdmittedStudentDetails>>(result);
                    if (leaveType.Count > 0)
                    {
                        iviewhosteladmittedstudent.LoadHostelStudent(leaveType);
                    }
                    else
                    {
                        result = await response.Content.ReadAsStringAsync();
                        leaveTypeerrorresponse = JsonConvert.DeserializeObject<LeaveTypeerrorresponse>(result);
                        iviewhosteladmittedstudent.servicefailed(leaveTypeerrorresponse.errors[0].message);
                    }

                }
                else
                {
                    result = await response.Content.ReadAsStringAsync();
                    leaveTypeerrorresponse = JsonConvert.DeserializeObject<LeaveTypeerrorresponse>(result);
                    iviewhosteladmittedstudent.servicefailed(leaveTypeerrorresponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("HMS", "No Leave Type List Found.", "OK");
            }
        }
        public async void GetHostelAdmittedStudentbyappno(string applicationNo)
        {
            LeaveTypeerrorresponse leaveTypeerrorresponse;
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                client.DefaultRequestHeaders.Add("applicationNo", applicationNo);

                HttpResponseMessage response = await client.GetAsync(ApplicationURL.GetHostelStudentbyapplicationno);
                string result = await response.Content.ReadAsStringAsync();
                if ((int)response.StatusCode == 200)
                {

                    ObservableCollection<HostelAdmittedStudentDetails> leaveType = JsonConvert.DeserializeObject<ObservableCollection<HostelAdmittedStudentDetails>>(result);
                    if (leaveType.Count > 0)
                    {
                        iviewhosteladmittedstudent.LoadHostelStudent(leaveType);
                    }
                    else
                    {
                        result = await response.Content.ReadAsStringAsync();
                        leaveTypeerrorresponse = JsonConvert.DeserializeObject<LeaveTypeerrorresponse>(result);
                        iviewhosteladmittedstudent.servicefailed(leaveTypeerrorresponse.errors[0].message);
                    }

                }
                else
                {
                    result = await response.Content.ReadAsStringAsync();
                    leaveTypeerrorresponse = JsonConvert.DeserializeObject<LeaveTypeerrorresponse>(result);
                    iviewhosteladmittedstudent.servicefailed(leaveTypeerrorresponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("HMS", "No Hostel Student  List Found.", "OK");
            }
        }
        public async void GetServiceType()
        {
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.GetAllServiceType);
                string result = await response.Content.ReadAsStringAsync();
                if ((int)response.StatusCode == 200)
                {

                    ObservableCollection<WardenServiceModel> leaveType = JsonConvert.DeserializeObject<ObservableCollection<WardenServiceModel>>(result);
                    if (leaveType.Count > 0)
                    {
                        UserDialogs.Instance.HideLoading();
                        iservicecategory.getallservicecategory(leaveType);
                    }
                    else
                    {
                        UserDialogs.Instance.HideLoading();
                        await App.Current.MainPage.DisplayAlert(" ", "Data Not found", "OK");
                    }

                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    await App.Current.MainPage.DisplayAlert(" ", "Data Error", "OK");
                }
            }
            catch
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert(" ", "Server Error", "OK");
            }
        }
        public async void GetAllWarden()
        {

            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);


                HttpResponseMessage response = await client.GetAsync(ApplicationURL.GetAllWarden);
                string result = await response.Content.ReadAsStringAsync();

                if ((int)response.StatusCode == 200)
                {

                    ObservableCollection<WardenInfoModel> data_ = JsonConvert.DeserializeObject<ObservableCollection<WardenInfoModel>>(result);
                    if (data_.Count > 0)
                    {
                        await ContactWardenCallback.GetAllWarden(data_);
                    }
                    else
                    {
                        await ContactWardenCallback.ServiceFaild();
                    }

                }
                else
                {
                    await ContactWardenCallback.ServiceFaild();
                    await App.Current.MainPage.DisplayAlert(" ", "Data Error", "OK");

                }
            }
            catch (Exception ex)
            {
                await ContactWardenCallback.ServiceFaild();
                await App.Current.MainPage.DisplayAlert(" ", "Server Error", "OK");
            }

        }
        public async void UpdateWardenDetail(UpdateWarden updateWarden)
        {
            UpdateWardenResponse updateWardenResponse;
            UpdateWardenErrorResponse updateWardenErrorResponse;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);

                string jsn = JsonConvert.SerializeObject(updateWarden);

                var content = new StringContent(jsn, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(ApplicationURL.EditWarenDetail, content);

                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    updateWardenResponse = JsonConvert.DeserializeObject<UpdateWardenResponse>(resultHostel);
                    editWardenDetail.updatesucessfully(updateWardenResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    updateWardenErrorResponse = JsonConvert.DeserializeObject<UpdateWardenErrorResponse>(resultHostel);
                    editWardenDetail.servicefailed(updateWardenErrorResponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void DeleteWardenDetail(string userId)
        {
            DeleteAreaResppnse deleteAreaResppnse;
            DeleteAreaErrorResponse deleteAreaErrorResponse;
            HttpResponseMessage response;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                UserDialogs.Instance.ShowLoading();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                string json = @"[{""userId"" : """ + userId + @"""}]";
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync(ApplicationURL.DeleteWardenDetail, content);
                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    deleteAreaResppnse = JsonConvert.DeserializeObject<DeleteAreaResppnse>(result);
                    deleteWardenDetail.Deletesucessfully(deleteAreaResppnse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    deleteAreaErrorResponse = JsonConvert.DeserializeObject<DeleteAreaErrorResponse>(result);
                    deleteWardenDetail.servicefailed(deleteAreaErrorResponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void SaveLeaveRequest(LeaveRequestModel model)
        {
            LeaveErrorResponse leaveErrorResponse;
            LeaveResponse leaveResponse;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);

                string jsn = JsonConvert.SerializeObject(model);

                var content = new StringContent(jsn, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(ApplicationURL.SaveLeaveRequest, content);

                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    leaveResponse = JsonConvert.DeserializeObject<LeaveResponse>(resultHostel);
                    await leaveRequestCallback.SaveLeaveRequest(leaveResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    leaveErrorResponse = JsonConvert.DeserializeObject<LeaveErrorResponse>(resultHostel);
                    await leaveRequestCallback.ServiceFaild(leaveErrorResponse.errors[0].message);
                }
            }
            catch (Exception e)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", e.ToString(), "OK");
            }
        }
        public async void SaveStudentRegister(RegistrationModel model)
        {
            RegistrationResponse registrationResponse;
            RegistrationErrorResponse registrationErrorResponse;
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);

                string jsn = JsonConvert.SerializeObject(model);

                var content = new StringContent(jsn, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(ApplicationURL.StudentRegister, content);

                if ((int)response.StatusCode == 200)
                {
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    registrationResponse = JsonConvert.DeserializeObject<RegistrationResponse>(resultHostel);
                    registrationCallback.RegistrationSuccess(registrationResponse.message);
                }
                else
                {
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    registrationErrorResponse = JsonConvert.DeserializeObject<RegistrationErrorResponse>(resultHostel);
                    registrationCallback.ServiceFaild(registrationErrorResponse.errors[0].message);
                }

            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("HMS", e.ToString(), "OK");
            }
        }

        public async void SaveRoomType(SaveRoomType model)
        {
            try
            {
                var client = new HttpClient();
                RoomTypeResponse roomTypeResponse;
                RoomErrorTypeResponse roomErrorTypeResponse;
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                string jsn = JsonConvert.SerializeObject(model);
                //string jsn = @"{""userId"" : """ + Constants.UserId + @""",""hostelRoomTypeName"" : """ + model.hostelRoomTypeName + @""",""noOfOccupants"" : """ + model.noOfOccupants + @"""}";

                var content = new StringContent(jsn, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(ApplicationURL.RoomTypeInsertioon, content);

                if ((int)response.StatusCode == 200)
                {
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    roomTypeResponse = JsonConvert.DeserializeObject<RoomTypeResponse>(resultHostel);
                    await roomTypeCallback.PostRoomTypeSuccess(roomTypeResponse.message);
                }
                else
                {
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    roomErrorTypeResponse = JsonConvert.DeserializeObject<RoomErrorTypeResponse>(resultHostel);
                    await roomTypeCallback.ServiceFaild(roomErrorTypeResponse.errors[0].message);
                }

            }
            catch (Exception e)
            {
                await roomTypeCallback.ServiceFaild(e.ToString());
            }
        }

    }
}
