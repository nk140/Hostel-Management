using Acr.UserDialogs;
using HMS.Interface;
using HMS.Models;
using HMS.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using Xamarin.Essentials;

namespace HMS.Services
{
    public class WardenService
    {
        Iservicewarden service;
        Isubmitfeedback submissionfeedback;
        IHostelMaster hostalmaster;
        Istudentleave studentleavemaster;
        Iwardenregistrtion wardenregistration;
        Iwardenleaveaction leaveaction;
        IApproveLeave iapproveleave;
        IRejectLeave irejectleave;
        Inewsfeeddata inewsfeeddata;
        Inewstudentdata inewstudentdata;
        iViewParent iViewParent;
        IDisciplinaryAction disciplinaryAction;
        ViewDisciplinaryActionTaken iviewDisciplinaryActionTaken;
        IEditDisciplinary editDisciplinary;
        IDeleteDisciplinary deleteDisciplinary;
        IViewDirectorDetail iviewdirector;
        ProfileI profileI;
        Iviewrequestedservice iviewrequestedservice;
        Iviewservicestatusbyperson iviewservicestatusbyperson;
        Iassignserviceperson iassignserviceperson;
        public WardenService(Iservicewarden callbackservice)
        {
            service = callbackservice;
        }
        public WardenService(Iviewrequestedservice callbackservice, ProfileI profile)
        {
            iviewrequestedservice = callbackservice;
            profileI = profile;
        }
        public WardenService(Iassignserviceperson callbackservice)
        {
            iassignserviceperson = callbackservice;
        }
        public WardenService(Iviewservicestatusbyperson callback)
        {
            iviewservicestatusbyperson = callback;
        }
        public WardenService(Iviewservicestatusbyperson callback, ProfileI profile)
        {
            iviewservicestatusbyperson = callback;
            profileI = profile;
        }
        public WardenService(ProfileI profile)
        {
            profileI = profile;
        }
        public WardenService(Isubmitfeedback isubmitfeedback)
        {
            submissionfeedback = isubmitfeedback;
        }
        public WardenService(IViewDirectorDetail viewDirectorDetail)
        {
            iviewdirector = viewDirectorDetail;
        }
        public WardenService(ViewDisciplinaryActionTaken viewDisciplinaryActionTaken, IDeleteDisciplinary ideletedisciplinary)
        {
            iviewDisciplinaryActionTaken = viewDisciplinaryActionTaken;
            deleteDisciplinary = ideletedisciplinary;
        }
        public WardenService(IEditDisciplinary ieditdisciplinary)
        {
            editDisciplinary = ieditdisciplinary;
        }
        public WardenService(Iwardenregistrtion callbackresponse)
        {
            wardenregistration = callbackresponse;
        }
        public WardenService(IDisciplinaryAction idisciplinaryaction)
        {
            disciplinaryAction = idisciplinaryaction;
        }
        public WardenService(Inewsfeeddata getnewsfeedlist)
        {
            inewsfeeddata = getnewsfeedlist;
        }
        public WardenService(Inewstudentdata callbacknewstudentdata)
        {
            inewstudentdata = callbacknewstudentdata;
        }
        public WardenService(Iwardenleaveaction callbackleave)
        {
            leaveaction = callbackleave;
        }
        public WardenService(Iwardenleaveaction callbackleave, IApproveLeave approveLeave, IRejectLeave rejectLeave)
        {
            leaveaction = callbackleave;
            iapproveleave = approveLeave;
            irejectleave = rejectLeave;
        }
        public WardenService(IHostelMaster callbackmaster)
        {
            hostalmaster = callbackmaster;
        }
        public WardenService(Istudentleave callbackmaster)
        {
            studentleavemaster = callbackmaster;
        }
        public WardenService(iViewParent viewParent)
        {
            iViewParent = viewParent;
        }
        public async void GetParentLeaveApproval()
        {
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                client.DefaultRequestHeaders.Add("studentId", "MQ");
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.GetParentApprovalData);
                string result = await response.Content.ReadAsStringAsync();
                if ((int)response.StatusCode == 200)
                {
                    ObservableCollection<ParentStudentLeaveStatus> parentleave = JsonConvert.DeserializeObject<ObservableCollection<ParentStudentLeaveStatus>>(result);
                    UserDialogs.Instance.HideLoading();
                    leaveaction.GetStudentLeaveDetail(parentleave);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    await App.Current.MainPage.DisplayAlert("", "Data Not Found.", "OK");
                }
            }
            catch
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("", "Server Error.", "OK");
            }
        }
        public async void GetWardLeave(string studentId)
        {
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                byte[] byt = System.Text.Encoding.UTF8.GetBytes(studentId);

                // convert the byte array to a Base64 string

                string idValue = Convert.ToBase64String(byt);
                client.DefaultRequestHeaders.Add("studentId", idValue);
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.GetWardeLeaveDetail);
                string result = await response.Content.ReadAsStringAsync();
                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    ObservableCollection<ParentStudentLeaveStatus> parentleave = JsonConvert.DeserializeObject<ObservableCollection<ParentStudentLeaveStatus>>(result);
                    foreach (var items in parentleave)
                    {
                        if(string.IsNullOrEmpty(items.isParentApproved))
                        {
                           
                        }
                        else if (items.isParentApproved.Equals("true"))
                        {
                            items.ParentStatus = "Leave Approved";
                        }
                        else
                        {
                            items.ParentStatus = "Leave Rejected";
                        }
                    }
                    leaveaction.GetStudentLeaveDetail(parentleave);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    await App.Current.MainPage.DisplayAlert("", "Data Not Found.", "OK");
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("", "Ward Leave Data Not Found.", "OK");
            }
        }
        public async void GetWardenprofile(string userId)
        {
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                client.DefaultRequestHeaders.Add("userId", userId);
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.WardenProfile);
                string result = await response.Content.ReadAsStringAsync();
                if ((int)response.StatusCode == 200)
                {
                    ObservableCollection<WardenProfileModel> parentleave = JsonConvert.DeserializeObject<ObservableCollection<WardenProfileModel>>(result);
                    if (parentleave.Count != 0)
                    {
                        for (int i = 0; i < parentleave.Count; i++)
                        {
                            parentleave[i].serialno = (i + 1).ToString();
                        }
                        UserDialogs.Instance.HideLoading();
                        profileI.Loadwardenprofile(parentleave);
                    }
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    await profileI.ServiceFaild();
                }
            }
            catch
            {
                UserDialogs.Instance.HideLoading();
                await profileI.ServiceFaild();
            }
        }
        public async void GetDisciplinaryAction(string applicationNo)
        {
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                client.DefaultRequestHeaders.Add("applicationNo", applicationNo);
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.ViewDisciplinaryActionByAppno);
                string result = await response.Content.ReadAsStringAsync();
                if ((int)response.StatusCode == 200)
                {
                    ObservableCollection<ViewDisciplinaryActionbywarden> parentleave = JsonConvert.DeserializeObject<ObservableCollection<ViewDisciplinaryActionbywarden>>(result);
                    UserDialogs.Instance.HideLoading();
                    iviewDisciplinaryActionTaken.LoadTakenDisciplinaryAction(parentleave);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    iviewDisciplinaryActionTaken.servicefailed("Data Not Found.");
                }
            }
            catch
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("", "Server Error.", "OK");
            }
        }
        public async void GetAllDisciplinaryAction()
        {
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.ViewDisciplinaryAction);
                string result = await response.Content.ReadAsStringAsync();
                if ((int)response.StatusCode == 200)
                {
                    ObservableCollection<ViewDisciplinaryActionbywarden> parentleave = JsonConvert.DeserializeObject<ObservableCollection<ViewDisciplinaryActionbywarden>>(result);
                    for (int i = 0; i < parentleave.Count; i++)
                    {
                        parentleave[i].Isbuttonvisible = false;
                    }
                    UserDialogs.Instance.HideLoading();
                    iviewDisciplinaryActionTaken.LoadTakenDisciplinaryAction(parentleave);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    iviewDisciplinaryActionTaken.servicefailed("Data Not Found.");
                }
            }
            catch
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("", "Server Error.", "OK");
            }
        }
        public async void GetAllrequestservicebystudent(string hostelId)
        {
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                client.DefaultRequestHeaders.Add("hostelId", hostelId);
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.viewrequestedservice);
                string result = await response.Content.ReadAsStringAsync();
                if ((int)response.StatusCode == 200)
                {
                    ObservableCollection<ViewRequestedServiceModel> parentleave = JsonConvert.DeserializeObject<ObservableCollection<ViewRequestedServiceModel>>(result);
                    for (int i = 0; i < parentleave.Count; i++)
                    {
                        parentleave[i].Isbuttonvisible = false;
                    }
                    UserDialogs.Instance.HideLoading();
                    iviewrequestedservice.LoadAllrequestedservicelist(parentleave);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    iviewrequestedservice.failer("Data Not Found.");
                }
            }
            catch
            {
                UserDialogs.Instance.HideLoading();
                iviewrequestedservice.failer("Data is not available.");
            }
        }
        public async void GetServiceStatusbyperson(string hostelId)
        {
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                client.DefaultRequestHeaders.Add("hostelId", hostelId);
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.Servicestatusbyperson);
                string result = await response.Content.ReadAsStringAsync();
                if ((int)response.StatusCode == 200)
                {
                    ObservableCollection<ServiceStatusModel> parentleave = JsonConvert.DeserializeObject<ObservableCollection<ServiceStatusModel>>(result);
                    //for (int i = 0; i < parentleave.Count; i++)
                    //{
                    //    parentleave[i].Isbuttonvisible = false;
                    //}
                    UserDialogs.Instance.HideLoading();
                    iviewservicestatusbyperson.LoadAllservicestatus(parentleave);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    iviewservicestatusbyperson.servicefailed("Data Not Found.");
                }
            }
            catch
            {
                UserDialogs.Instance.HideLoading();
                iviewservicestatusbyperson.servicefailed("Something went wrong.");
            }
        }
        public async void Getnewstudentdata()
        {
            Studenterrorresponse studenterrorresponse;
            string result;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.GetNewAdmittedStudentDetail);
                result = await response.Content.ReadAsStringAsync();
                if ((int)response.StatusCode == 200)
                {

                    ObservableCollection<Students> students = JsonConvert.DeserializeObject<ObservableCollection<Students>>(result);
                    if (students.Count > 0)
                    {
                        UserDialogs.Instance.HideLoading();
                        inewstudentdata.GetNewStudentData(students);
                    }
                    else
                    {
                        UserDialogs.Instance.HideLoading();
                        result = await response.Content.ReadAsStringAsync();
                        studenterrorresponse = JsonConvert.DeserializeObject<Studenterrorresponse>(result);
                        await App.Current.MainPage.DisplayAlert("HMS", studenterrorresponse.errors[0].message, "OK");
                    }

                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    result = await response.Content.ReadAsStringAsync();
                    studenterrorresponse = JsonConvert.DeserializeObject<Studenterrorresponse>(result);
                    await App.Current.MainPage.DisplayAlert("HMS", studenterrorresponse.errors[0].message, "OK");
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", "No New Student list Found", "OK");
            }
        }
        public async void ViewDirectorDetails()
        {
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.DirectorDetails);
                string result = await response.Content.ReadAsStringAsync();
                if ((int)response.StatusCode == 200)
                {
                    ObservableCollection<ViewDirectorDetails> directorlists = JsonConvert.DeserializeObject<ObservableCollection<ViewDirectorDetails>>(result);
                    if (directorlists.Count > 0)
                    {
                        UserDialogs.Instance.HideLoading();
                        iviewdirector.GetDirectorDetails(directorlists);
                    }
                    else
                    {
                        UserDialogs.Instance.HideLoading();
                        iviewdirector.failer("No Director record");
                    }

                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    iviewdirector.failer("No Director record");
                }
            }
            catch
            {
                UserDialogs.Instance.HideLoading();
                iviewdirector.failer("Something went wrong please contact to administrator");
            }
        }
        public async void GetParentDetails()
        {
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.ParentStudentList);
                string result = await response.Content.ReadAsStringAsync();
                if ((int)response.StatusCode == 200)
                {
                    ObservableCollection<StudentParentDetail> leaveType = JsonConvert.DeserializeObject<ObservableCollection<StudentParentDetail>>(result);
                    if (leaveType.Count > 0)
                    {
                        UserDialogs.Instance.HideLoading();
                        iViewParent.LoadParentData(leaveType);
                    }
                    else
                    {
                        UserDialogs.Instance.HideLoading();
                        iViewParent.Servicefailed("No Parent record");
                    }

                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    iViewParent.Servicefailed("No Data record");
                }
            }
            catch
            {
                UserDialogs.Instance.HideLoading();
                iViewParent.Servicefailed("Something Went wrong");
            }
        }
        public async void UpdateDisciplinaryActionTaken(UpdateDisciplinaryActionbywarden updateDisciplinaryActionbywarden)
        {
            UpdateAreaResponse updateAreaResponse;
            UpdateAreaErrorResponse updateAreaErrorResponse;
            HttpResponseMessage response;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                UserDialogs.Instance.ShowLoading();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                string json = JsonConvert.SerializeObject(updateDisciplinaryActionbywarden);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync(ApplicationURL.UpdateDisciplinaryAction, content);
                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateAreaResponse = JsonConvert.DeserializeObject<UpdateAreaResponse>(result);
                    editDisciplinary.UpdateDisciplinaryType(updateAreaResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateAreaErrorResponse = JsonConvert.DeserializeObject<UpdateAreaErrorResponse>(result);
                    editDisciplinary.Failer(updateAreaErrorResponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void AssignServiceToPerson(AssignServiceModel assignServiceModel, string requestTypeId, string userId)
        {
            UpdateAreaResponse updateAreaResponse;
            UpdateAreaErrorResponse updateAreaErrorResponse;
            HttpResponseMessage response;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                UserDialogs.Instance.ShowLoading();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                client.DefaultRequestHeaders.Add("requestTypeId", requestTypeId);
                client.DefaultRequestHeaders.Add("userId", userId);
                string json = JsonConvert.SerializeObject(assignServiceModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync(ApplicationURL.Assignserviceperson, content);
                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateAreaResponse = JsonConvert.DeserializeObject<UpdateAreaResponse>(result);
                    iassignserviceperson.sucess(updateAreaResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateAreaErrorResponse = JsonConvert.DeserializeObject<UpdateAreaErrorResponse>(result);
                    iassignserviceperson.failer(updateAreaErrorResponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", "Something went wrong.", "OK");
            }
        }
        public async void FeedBackOnServiceByStudent(FeedbackDetailsByStudent feedbackDetailsByStudent)
        {
            UpdateAreaResponse updateAreaResponse;
            UpdateAreaErrorResponse updateAreaErrorResponse;
            HttpResponseMessage response;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                UserDialogs.Instance.ShowLoading();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                string json = JsonConvert.SerializeObject(feedbackDetailsByStudent);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync(ApplicationURL.FeedBackOnServicebystudent, content);
                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateAreaResponse = JsonConvert.DeserializeObject<UpdateAreaResponse>(result);
                    submissionfeedback.sucess(updateAreaResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateAreaErrorResponse = JsonConvert.DeserializeObject<UpdateAreaErrorResponse>(result);
                    submissionfeedback.failer(updateAreaErrorResponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void ApproveWardLeave(LeaveStatusModel leaveStatusModel)
        {
            UpdateAreaResponse updateAreaResponse;
            UpdateAreaErrorResponse updateAreaErrorResponse;
            HttpResponseMessage response;
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                string jsn = JsonConvert.SerializeObject(leaveStatusModel);
                var content = new StringContent(jsn, Encoding.UTF8, "application/json");
                response = await client.PostAsync(ApplicationURL.ActionAgainstWardLeave, content);
                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateAreaResponse = JsonConvert.DeserializeObject<UpdateAreaResponse>(result);
                    iapproveleave.approved(updateAreaResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateAreaErrorResponse = JsonConvert.DeserializeObject<UpdateAreaErrorResponse>(result);
                    iapproveleave.failer(updateAreaErrorResponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", "Something went wrong", "OK");
            }
        }
        public async void ApproveStudentLeave(wardenstatusonleavemodel wardenstatusonleavemodel)
        {
            UpdateAreaResponse updateAreaResponse;
            UpdateAreaErrorResponse updateAreaErrorResponse;
            HttpResponseMessage response;
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                string jsn = JsonConvert.SerializeObject(wardenstatusonleavemodel);
                var content = new StringContent(jsn, Encoding.UTF8, "application/json");
                response = await client.PostAsync(ApplicationURL.WardenLeaveAction, content);
                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateAreaResponse = JsonConvert.DeserializeObject<UpdateAreaResponse>(result);
                    studentleavemaster.wardenaction(updateAreaResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateAreaErrorResponse = JsonConvert.DeserializeObject<UpdateAreaErrorResponse>(result);
                    studentleavemaster.failer(updateAreaErrorResponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", "Something went wrong", "OK");
            }
        }
        public async void DeleteDisciplinaryActionTaken(string wardenDisciplinaryId)
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
                string json = @"[{""wardenDisciplinaryId"" : """ + wardenDisciplinaryId + @"""}]";
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync(ApplicationURL.DeleteDisciplinaryAction, content);
                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateNewsFeedResponse = JsonConvert.DeserializeObject<UpdateRoomTypeResponse>(result);
                    deleteDisciplinary.DeleteDisciplinaryType(updateNewsFeedResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    string result = await response.Content.ReadAsStringAsync();
                    updateNewsFeederrorresponse = JsonConvert.DeserializeObject<UpdateRoomErrorTypeResponse>(result);
                    deleteDisciplinary.Failer(updateNewsFeederrorresponse.errors[0].message);
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void GetNewsFeedDatalist()
        {
            string result;
            NewsFeederrorresponse newsFeederrorresponse;
            var profiles = Connectivity.ConnectionProfiles;
            if (profiles.Contains(ConnectionProfile.WiFi) || profiles.Contains(ConnectionProfile.Cellular))
            {
                try
                {
                    UserDialogs.Instance.ShowLoading();
                    var client = new HttpClient();
                    client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                    HttpResponseMessage response = await client.GetAsync(ApplicationURL.GetNewsFeedData);
                    result = await response.Content.ReadAsStringAsync();
                    if ((int)response.StatusCode == 200)
                    {

                        ObservableCollection<NewsFeed> leaveType = JsonConvert.DeserializeObject<ObservableCollection<NewsFeed>>(result);
                        if (leaveType.Count > 0)
                        {
                            UserDialogs.Instance.HideLoading();
                            inewsfeeddata.Getnewsfeedlist(leaveType);
                        }
                        else
                        {
                            UserDialogs.Instance.HideLoading();
                            result = await response.Content.ReadAsStringAsync();
                            newsFeederrorresponse = JsonConvert.DeserializeObject<NewsFeederrorresponse>(result);
                            await App.Current.MainPage.DisplayAlert(" ", newsFeederrorresponse.errors[0].message, "OK");
                        }

                    }
                    else
                    {
                        UserDialogs.Instance.HideLoading();
                        result = await response.Content.ReadAsStringAsync();
                        newsFeederrorresponse = JsonConvert.DeserializeObject<NewsFeederrorresponse>(result);
                        await App.Current.MainPage.DisplayAlert(" ", newsFeederrorresponse.errors[0].message, "OK");
                    }
                }
                catch (Exception ex)
                {
                    UserDialogs.Instance.HideLoading();
                    inewsfeeddata.Servicefailed();
                }
            }
            else
            {
                inewsfeeddata.Servicefailed();
            }
        }
        public async void SavewardenData(WardenRegistration wardenRegistration)
        {
            string resultHostel;
            WardenResponse wardenResponse;
            Wardenerrorresponse wardenerrorresponse;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                string json = JsonConvert.SerializeObject(wardenRegistration);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(ApplicationURL.WardenRegistration, content);
                resultHostel = await response.Content.ReadAsStringAsync();
                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    resultHostel = await response.Content.ReadAsStringAsync();
                    wardenResponse = JsonConvert.DeserializeObject<WardenResponse>(resultHostel);
                    wardenregistration.wardenregistrationresponse(wardenResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    resultHostel = await response.Content.ReadAsStringAsync();
                    wardenerrorresponse = JsonConvert.DeserializeObject<Wardenerrorresponse>(resultHostel);
                    wardenregistration.wardenregistrationresponse(wardenerrorresponse.errors[0].message);
                }

            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("", ex.ToString(), "OK");
            }
        }
        public async void SaveDisciplinaryActionTaken(DisciplinaryActionbywarden disciplinaryActionbywarden)
        {
            string resultHostel;
            WardenResponse wardenResponse;
            Wardenerrorresponse wardenerrorresponse;
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                string json = JsonConvert.SerializeObject(disciplinaryActionbywarden);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(ApplicationURL.Disciplinaryaction, content);
                resultHostel = await response.Content.ReadAsStringAsync();
                if ((int)response.StatusCode == 200)
                {
                    UserDialogs.Instance.HideLoading();
                    resultHostel = await response.Content.ReadAsStringAsync();
                    wardenResponse = JsonConvert.DeserializeObject<WardenResponse>(resultHostel);
                    disciplinaryAction.Disciplinaryactiontaken(wardenResponse.message);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    resultHostel = await response.Content.ReadAsStringAsync();
                    wardenerrorresponse = JsonConvert.DeserializeObject<Wardenerrorresponse>(resultHostel);
                    disciplinaryAction.servicefailed(wardenerrorresponse.errors[0].message);
                }

            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("", ex.ToString(), "OK");
            }
        }
        public async void GetServicelist()
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
                        for (int i = 0; i < leaveType.Count; i++)
                        {
                            leaveType[i].listcount = (i + 1).ToString();
                        }
                        service.GetServicelist(leaveType);
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
                service.Servicefailed("No Service List Found");
            }
        }
        public async void GetHostelDetailList()
        {
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                client.DefaultRequestHeaders.Add("areaId", "1");
                HttpResponseMessage response = await client.GetAsync(ApplicationURL.GetHostelDetailMaster);
                string result = await response.Content.ReadAsStringAsync();
                if ((int)response.StatusCode == 200)
                {

                    ObservableCollection<HostalMasterModel> leaveType = JsonConvert.DeserializeObject<ObservableCollection<HostalMasterModel>>(result);
                    if (leaveType.Count > 0)
                    {
                        UserDialogs.Instance.HideLoading();
                        hostalmaster.GetHostelDetailList(leaveType);
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
        public async void GetStudentLeaveHistory()
        {
            try
            {
                UserDialogs.Instance.ShowLoading();
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);
                string json = "{}";
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(ApplicationURL.GetStudentLeaveHistory, content);
                string result = await response.Content.ReadAsStringAsync();
                if ((int)response.StatusCode == 200)
                {
                    ObservableCollection<StudentLeaveHistory> leaveType = JsonConvert.DeserializeObject<ObservableCollection<StudentLeaveHistory>>(result);
                    if (leaveType.Count > 0)
                    {
                        for (int i = 0; i < leaveType.Count; i++)
                        {
                            if (string.IsNullOrEmpty(leaveType[i].isParentApprove) || string.IsNullOrEmpty(leaveType[i].isParenetReject))
                            {
                                leaveType[i].Parentleavestatus = "Leave Pending";
                            }
                            else if(leaveType[i].isParentApprove.Equals("true"))
                            {
                                leaveType[i].Parentleavestatus = "Leave Approved";
                            }
                            else
                            {
                                leaveType[i].Parentleavestatus = "Leave Rejected";
                            }
                        }
                        UserDialogs.Instance.HideLoading();
                        studentleavemaster.GetStudentLeaveHistory(leaveType);
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
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert(" ", "Server Error", "OK");
            }
        }
    }
}
