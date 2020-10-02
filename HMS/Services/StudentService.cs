﻿using Acr.UserDialogs;
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
        Iupdatestudentpassword iupdatestudentpassword;
        StudentLeaveRequestI leaveRequestCallback;
        RegistrationI registrationCallback;
        RoomTypeI roomTypeCallback;
        ContactWardenI ContactWardenCallback;
        Iservicecategory iservicecategory;
        public StudentService(ProfileI callback)
        {
            profileCallback = callback;
        }
        public StudentService(Iupdatestudentpassword updatestudentpassword)
        {
            iupdatestudentpassword = updatestudentpassword;
        }
        public StudentService(StudentLeaveRequestI callback)
        {
            leaveRequestCallback = callback;
        }
        public StudentService(HostelAdmissionI hostel)
        {
            hostelAdmissionI = hostel;
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
                await App.Current.MainPage.DisplayAlert("HMS", ex.ToString(), "OK");
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
                await App.Current.MainPage.DisplayAlert("HMS",e.ToString(), "OK");
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
