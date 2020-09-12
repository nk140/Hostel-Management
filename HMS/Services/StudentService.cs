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
        StudentLeaveRequestI leaveRequestCallback;
        RegistrationI registrationCallback;
        RoomTypeI roomTypeCallback;
        ContactWardenI ContactWardenCallback;
        Iservicecategory iservicecategory;
        public StudentService(ProfileI callback)
        {
            profileCallback = callback;
        }

        public StudentService(StudentLeaveRequestI callback)
        {
            leaveRequestCallback = callback;
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
        public async void GetProfiile()
        {

            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);


                client.DefaultRequestHeaders.Add("studentId", Constants.UserId.ToString());

                HttpResponseMessage response = await client.GetAsync(ApplicationURL.GetProfiile);
                string result = await response.Content.ReadAsStringAsync();
                if ((int)response.StatusCode == 200)
                {

                    ObservableCollection<StudentProfileModel> profile = JsonConvert.DeserializeObject<ObservableCollection<StudentProfileModel>>(result);
                    if (profile.Count > 0)
                    {
                        profileCallback.LoadStudentProfile(profile[0]);
                    }
                    else
                    {
                        await profileCallback.ServiceFaild();
                    }

                }
                else
                {
                    await profileCallback.ServiceFaild();
                    await App.Current.MainPage.DisplayAlert(" ", "Data Error", "OK");

                }
            }
            catch (Exception ex)
            {
                await profileCallback.ServiceFaild();
                await App.Current.MainPage.DisplayAlert(" ", "Server Error", "OK");
            }




            //return response;

        }

        public async void GetAllLeaveType()
        {

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
                        await leaveRequestCallback.GetAllLeaveType(leaveType);
                    }
                    else
                    {
                        await leaveRequestCallback.ServiceFaild();
                    }

                }
                else
                {
                    await leaveRequestCallback.ServiceFaild();
                    await App.Current.MainPage.DisplayAlert(" ", "Data Error", "OK");

                }
            }
            catch (Exception ex)
            {
                await leaveRequestCallback.ServiceFaild();
                await App.Current.MainPage.DisplayAlert(" ", "Server Error", "OK");
            }




            //return response;

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

        public async void SaveLeaveRequest(LeaveRequestModel model)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(ApplicationURL.BaseURL);

                string jsn = JsonConvert.SerializeObject(model);

                var content = new StringContent(jsn, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(ApplicationURL.SaveLeaveRequest, content);

                if ((int)response.StatusCode == 200)
                {
                    string resultHostel = await response.Content.ReadAsStringAsync();
                    await leaveRequestCallback.SaveLeaveRequest("");
                }
                else
                {
                    await leaveRequestCallback.ServiceFaild();
                    await App.Current.MainPage.DisplayAlert(" ", "Server Error", "OK");
                }

            }
            catch (Exception e)
            {
                await leaveRequestCallback.ServiceFaild();
                await App.Current.MainPage.DisplayAlert(" ", "Server Error", "OK");
            }
        }


        public async void SaveStudentRegister(RegistrationModel model)
        {
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
                    await registrationCallback.RegistrationSuccess(resultHostel);
                }
                else
                {
                    await registrationCallback.ServiceFaild();
                    await App.Current.MainPage.DisplayAlert(" ", "Server Error", "OK");
                }

            }
            catch (Exception e)
            {
                await registrationCallback.ServiceFaild();
                await App.Current.MainPage.DisplayAlert(" ", "Server Error", "OK");
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
