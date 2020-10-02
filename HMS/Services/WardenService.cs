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
        IHostelMaster hostalmaster;
        Istudentleave studentleavemaster;
        Iwardenregistrtion wardenregistration;
        Iwardenleaveaction leaveaction;
        Inewsfeeddata inewsfeeddata;
        Inewstudentdata inewstudentdata;
        iViewParent iViewParent;
        public WardenService(Iservicewarden callbackservice)
        {
            service = callbackservice;
        }
        public WardenService(Iwardenregistrtion callbackresponse)
        {
            wardenregistration = callbackresponse;
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
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
            }
        }
        public async void  GetParentDetails()
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
            catch
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert(" ", "Server Error", "OK");
            }
        }
    }
}
